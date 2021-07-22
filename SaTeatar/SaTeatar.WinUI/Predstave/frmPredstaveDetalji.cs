using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;

namespace SaTeatar.WinUI.Predstave
{
    public partial class frmPredstaveDetalji : Form
    {
        private readonly APIService _predstaveService = new APIService("Predstava");
        private readonly APIService _tipPredstavaService = new APIService("TipoviPredstava");
        private readonly APIService _djelatnici = new APIService("Djelatnici");
        private readonly APIService _predstaveDjelatnici = new APIService("PredstaveDjelatnici");
        private int? _id = null;

        public frmPredstaveDetalji(int? predstavaId=null)
        {
            InitializeComponent();
            _id = predstavaId;
        }

        rPredstavaInsert request = new rPredstavaInsert(); //zbog slike
        mPredstave predstava = null;
        List<int> ListaVecDodatihGlumacIDeva = new List<int>();
        List<mPredstaveDjelatnici> predstavaDjelatnici = new List<mPredstaveDjelatnici>();


        private async void frmPredstaveDetalji_Load(object sender, EventArgs e)
        {
            await LoadTipoviPredstava();
            await LoadReziseri();

            if (_id.HasValue)
            {
                predstava = await _predstaveService.GetById<mPredstave>(_id);

                txtNaziv.Text = predstava.Naziv;
                txtOpis.Text = predstava.Opis;
                cmbTipPredstave.SelectedValue = predstava.TipPredstaveId;
                chbStatus.Checked = predstava.Status;

                predstavaDjelatnici = await _predstaveDjelatnici.Get<List<mPredstaveDjelatnici>>(new rPredstaveDjelatnicSearch() { PredstavaId = (int)_id });  

                for (int i = 0; i < predstavaDjelatnici.Count; i++)
                {
                    if (predstavaDjelatnici[i].Djelatnik.VrstaDjelatnikaId==1)
                    {
                        cmbRezija.SelectedValue = predstavaDjelatnici[i].DjelatnikId;
                    }

                    if (predstavaDjelatnici[i].Djelatnik.VrstaDjelatnikaId==2)
                    {
                        ListaVecDodatihGlumacIDeva.Add(predstavaDjelatnici[i].DjelatnikId);
                    }
                }
                // pbSlika.Visible = false;
                if (predstava.Slika?.Length>0)
                {
                    using (MemoryStream ms = new MemoryStream(predstava.Slika))
                    {
                        pbSlika.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbSlika.Visible = false;
                }

            }

            await LoadGlumci();
        }

        private async Task LoadTipoviPredstava()
        {
            var result = await _tipPredstavaService.Get<List<mTipoviPredstava>>(null);
            result.Insert(0, new mTipoviPredstava());
            cmbTipPredstave.DisplayMember = "Naziv";
            cmbTipPredstave.ValueMember = "TipPredstaveId";
            cmbTipPredstave.DataSource = result;
        }

        private async Task LoadGlumci()
        {
            var result = await _djelatnici.Get<List<mDjelatnici>>(new rDjelatniciSearch { VrstaDjelatnikaId = 2 });
            lbGlumci.DisplayMember = "ImePrezime";
            lbGlumci.ValueMember = "DjelatnikId";
            lbGlumci.DataSource = result;         
            lbGlumci.SetSelected(0, false);

            if (_id.HasValue)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < ListaVecDodatihGlumacIDeva.Count; j++)
                    {
                        if (result[i].DjelatnikId == ListaVecDodatihGlumacIDeva[j])
                        {
                            lbGlumci.SetSelected(i, true);
                        }
                    }
                }
            }

        }

        private async Task LoadReziseri()
        {
            var result = await _djelatnici.Get<List<mDjelatnici>>(new rDjelatniciSearch() { VrstaDjelatnikaId = 1 });
            result.Insert(0, new mDjelatnici());
            cmbRezija.DisplayMember = "ImePrezime";
            cmbRezija.ValueMember = "DjelatnikId";
            cmbRezija.DataSource = result;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            
            var idTPObj = cmbTipPredstave.SelectedValue;

            if (int.TryParse(idTPObj.ToString(), out int tipid))
            {
                request.TipPredstaveId = tipid;
            }

            request.Naziv = txtNaziv.Text;
            request.Opis = txtOpis.Text;
            request.Status = chbStatus.Checked;
            request.Slika = null;

            var listGlumciIdCB = lbGlumci.SelectedItems.Cast<mDjelatnici>().Select(x => x.DjelatnikId).ToList();

            if (!_id.HasValue)
            {
                var insertPredstave = await _predstaveService.Insert<mPredstave>(request);

                for (int i = 0; i < listGlumciIdCB.Count; i++)
                {
                    var pd = new rPredstaveDjelatniciUpsert()
                    {
                        DjelatnikId = listGlumciIdCB[i],
                        PredstavaId = insertPredstave.PredstavaId
                    };
                    await _predstaveDjelatnici.Insert<mPredstaveDjelatnici>(pd);
                }

                var idRObj = cmbRezija.SelectedValue;

                if (int.TryParse(idRObj.ToString(), out int rid))
                {
                    if (rid != 0)
                    {
                        var pd = new rPredstaveDjelatniciUpsert()
                        {
                            DjelatnikId = rid,
                            PredstavaId = insertPredstave.PredstavaId
                        };
                        await _predstaveDjelatnici.Insert<mPredstaveDjelatnici>(pd);
                    }
                }

                MessageBox.Show("Uspjesno dodana predstava!");
                this.Close();
            }
            else
            {
                predstavaDjelatnici = await _predstaveDjelatnici.Get<List<mPredstaveDjelatnici>>(new rPredstaveDjelatnicSearch() { PredstavaId = (int)_id });

                for (int i = 0; i < predstavaDjelatnici.Count; i++)
                {
                     await _predstaveDjelatnici.Delete<mPredstaveDjelatnici>(predstavaDjelatnici[i].PredstavaDjelatnikId);
                }

                for (int i = 0; i < listGlumciIdCB.Count; i++)
                {
                    var pd = new rPredstaveDjelatniciUpsert()
                    {
                        DjelatnikId = listGlumciIdCB[i],
                        PredstavaId = (int)_id
                    };
                    await _predstaveDjelatnici.Insert<mPredstaveDjelatnici>(pd);
                }

                var idRObj = cmbRezija.SelectedValue;

                if (int.TryParse(idRObj.ToString(), out int rid))
                {
                    if (rid != 0)
                    {
                        var pd = new rPredstaveDjelatniciUpsert()
                        {
                            DjelatnikId = rid,
                            PredstavaId = (int)_id
                        };
                        await _predstaveDjelatnici.Insert<mPredstaveDjelatnici>(pd);
                    }
                }

                rPredstavaUpdate purequest = new rPredstavaUpdate();

                purequest.Naziv = txtNaziv.Text;
                purequest.Opis = txtOpis.Text;
                purequest.Status = chbStatus.Checked;
                var idTPObjpu = cmbTipPredstave.SelectedValue;

                if (int.TryParse(idTPObjpu.ToString(), out int tipidpu))
                {
                    purequest.TipPredstaveId = tipidpu;
                }
                
                purequest.Slika = predstava.Slika;

                var updatePredstave = await _predstaveService.Update<mPredstave>(_id, purequest);

                MessageBox.Show("Uspjesno izmijenjena predstava!");
                this.Close();
            }

        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            
            if (result==DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                pbSlika.Image = image;
            }
        }

    }
}
