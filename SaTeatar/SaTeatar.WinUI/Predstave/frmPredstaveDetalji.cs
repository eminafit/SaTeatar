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

        public frmPredstaveDetalji()
        {
            InitializeComponent();
        }


        rPredstavaInsert request = new rPredstavaInsert(); //zbog slike


        private async void frmPredstaveDetalji_Load(object sender, EventArgs e)
        {
            await LoadTipoviPredstava();
        }

        private async Task LoadTipoviPredstava()
        {
            var result = await _tipPredstavaService.Get<List<mTipoviPredstava>>(null);
            result.Insert(0, new mTipoviPredstava());
            cmbTipPredstave.DisplayMember = "Naziv";
            cmbTipPredstave.ValueMember = "TipPredstaveId";
            cmbTipPredstave.DataSource = result;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            
            var idObj = cmbTipPredstave.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int tipid))
            {
                request.TipPredstaveId = tipid;
            }
            request.Naziv = txtNaziv.Text;
            request.Opis = txtOpis.Text;
            request.Status = chbStatus.Checked;

            await _predstaveService.Insert<mPredstave>(request);

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
