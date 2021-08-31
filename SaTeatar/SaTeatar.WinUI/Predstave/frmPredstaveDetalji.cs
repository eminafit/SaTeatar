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
            AutoValidate = AutoValidate.Disable;

        }

        rPredstavaInsert inrequest = new rPredstavaInsert(); 
        rPredstavaUpdate uprequest = new rPredstavaUpdate();
        mPredstave predstava = null;
        List<int> ListaVecDodatihGlumacIDeva = new List<int>();
        List<mPredstaveDjelatnici> predstavaDjelatnici = new List<mPredstaveDjelatnici>();
        private bool dodanaSlika = false;

        private async void frmPredstaveDetalji_Load(object sender, EventArgs e)
        {
            await LoadTipoviPredstava();
            await LoadReziseri();

            chbStatus.Checked = true;


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
                    if (predstavaDjelatnici[i].Djelatnik.VrstaDjelatnikaId==1 || predstavaDjelatnici[i].Djelatnik.VrstaDjelatnikaId == 3)
                    {
                        cmbRezija.SelectedValue = predstavaDjelatnici[i].DjelatnikId;
                    }

                    if (predstavaDjelatnici[i].Djelatnik.VrstaDjelatnikaId==2)
                    {
                        ListaVecDodatihGlumacIDeva.Add(predstavaDjelatnici[i].DjelatnikId);
                    }
                }

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
            var result2 = await _djelatnici.Get<List<mDjelatnici>>(new rDjelatniciSearch() { VrstaDjelatnikaId = 3 });
            result.AddRange(result2);
            result.Insert(0, new mDjelatnici());
            cmbRezija.DisplayMember = "ImePrezime";
            cmbRezija.ValueMember = "DjelatnikId";
            cmbRezija.DataSource = result;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                var listGlumciIdCB = lbGlumci.SelectedItems.Cast<mDjelatnici>().Select(x => x.DjelatnikId).ToList();

                if (!_id.HasValue)
                {
                    var idTPObj = cmbTipPredstave.SelectedValue;

                    if (int.TryParse(idTPObj.ToString(), out int tipid))
                    {
                        inrequest.TipPredstaveId = tipid;
                    }

                    inrequest.Naziv = txtNaziv.Text;
                    inrequest.Opis = txtOpis.Text;
                    inrequest.Status = chbStatus.Checked;
                    if (!dodanaSlika)
                    {
                        inrequest.Slika = null;
                    }

                    var insertPredstave = await _predstaveService.Insert<mPredstave>(inrequest);

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


                    uprequest.Naziv = txtNaziv.Text;
                    uprequest.Opis = txtOpis.Text;
                    uprequest.Status = chbStatus.Checked;
                    var idTPObjpu = cmbTipPredstave.SelectedValue;

                    if (int.TryParse(idTPObjpu.ToString(), out int tipidpu))
                    {
                        uprequest.TipPredstaveId = tipidpu;
                    }

                    if (!dodanaSlika)
                    {
                        uprequest.Slika = predstava.Slika;

                    }

                    var updatePredstave = await _predstaveService.Update<mPredstave>(_id, uprequest);

                    MessageBox.Show("Uspjesno izmijenjena predstava!");
                    this.Close();
                }

            }

        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            
            if (result==DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                if (_id.HasValue)
                {
                    uprequest.Slika = file;
                    dodanaSlika = true;
                }
                else
                {
                    inrequest.Slika = file;
                    dodanaSlika = true;
                }
                txtSlikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                pbSlika.Image = image;
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (txtNaziv.Text.Length < 3)
                {
                    errorProvider.SetError(txtNaziv, Properties.Resources.Validation_MinLength);
                    e.Cancel = true;
                } 
                else
                errorProvider.SetError(txtNaziv, null);
            }
        }

        private void cmbTipPredstave_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipPredstave.SelectedValue==null || int.Parse(cmbTipPredstave.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(cmbTipPredstave, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbTipPredstave, null);
            }
        }

        private void cmbRezija_Validating(object sender, CancelEventArgs e)
        {
            if (cmbRezija.SelectedValue==null || int.Parse(cmbRezija.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(cmbRezija, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbRezija, null);
            }
        }

        private void lbGlumci_Validating(object sender, CancelEventArgs e)
        {
            if (lbGlumci.SelectedItems.Count==0)
            {
                errorProvider.SetError(lbGlumci, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(lbGlumci, null);
            }
        }
    }
}
