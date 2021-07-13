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

        public frmPredstaveDetalji()
        {
            InitializeComponent();
        }

        rPredstavaInsert request = new rPredstavaInsert(); //zbog slike

        private async void frmPredstaveDetalji_Load(object sender, EventArgs e)
        {
            await LoadTipoviPredstava();
            await LoadGlumci();
            await LoadReziseri();
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
            result.Insert(0, new mDjelatnici());
            lbGlumci.DataSource = result;
        }

        private async Task LoadReziseri()
        {
            var result = await _djelatnici.Get<List<mDjelatnici>>(new rDjelatniciSearch() { VrstaDjelatnikaId = 1 });
            result.Insert(0, new mDjelatnici());
            cmbRezija.DisplayMember = "ImePrezime";
            cmbRezija.ValueMember = "VrstaDjelatnikaId";
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

            var selectedValues = lbGlumci.SelectedItems.Cast<mDjelatnici>().Select(x => x.DjelatnikId).ToList();

            var res = await _predstaveService.Insert<mPredstave>(request);

            for (int i = 0; i < selectedValues.Count; i++)
            {
                if (selectedValues[i] == 0)
                {
                    selectedValues.RemoveAt(i);
                }
                else
                {
                    var pd = new rPredstaveDjelatniciUpsert()
                    {
                        DjelatnikId = selectedValues[i],
                        PredstavaId = res.PredstavaId
                    };
                    await _predstaveDjelatnici.Insert<mPredstaveDjelatnici>(pd);
                }
            }

            var idRObj = cmbRezija.SelectedValue;

            if (int.TryParse(idTPObj.ToString(), out int rid))
            {
                if (rid!=0)
                {
                    var pd = new rPredstaveDjelatniciUpsert()
                    {
                        DjelatnikId = rid,
                        PredstavaId = res.PredstavaId
                    };
                    await _predstaveDjelatnici.Insert<mPredstaveDjelatnici>(pd);
                }
            }

            MessageBox.Show("Uspjesno dodana predstava!");
            this.Close();
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
