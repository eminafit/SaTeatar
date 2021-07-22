using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaTeatar.Model.Requests;
using System.IO;

namespace SaTeatar.WinUI.Djelatnici
{
    public partial class frmDjelatniciDetalji : Form
    {
        private APIService _vrsteDjelatnika = new APIService("vrstedjelatnika");
        private APIService _djelatnici = new APIService("djelatnici");
        public frmDjelatniciDetalji()
        {
            InitializeComponent();
        }

        private async void frmDjelatniciDetalji_Load(object sender, EventArgs e)
        {
            await LoadVrstaDjelatnika();
        }

        private rDjelatniciInsert request = new rDjelatniciInsert();

        private async Task LoadVrstaDjelatnika()
        {
            var result = await _vrsteDjelatnika.Get<List<mVrsteDjelatnika>>(null);
            result.Insert(0, new mVrsteDjelatnika());
            cmbVrsteDjelatnika.DisplayMember = "Naziv";
            cmbVrsteDjelatnika.ValueMember = "VrstaDjelatnikaId";
            cmbVrsteDjelatnika.DataSource = result;
        }

        private async void txtSacuvaj_Click(object sender, EventArgs e)
        {
            request.Ime = txtIme.Text;
            request.Prezime = txtPrezime.Text;
            request.Biografija = txtBiografija.Text;
            request.Status = chStatus.Checked;
            request.Slika = null;

            await _djelatnici.Insert<mDjelatnici>(request);

            MessageBox.Show("Uspjesno dodan djelatnik!");
            this.Close();
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result==DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                request.Slika = file;
                txtSlikaInput.Text = filename;

                Image slika = Image.FromFile(filename);
                pbSlika.Image = slika;
            }
        }

        private void cmbVrsteDjelatnika_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idvdobj = cmbVrsteDjelatnika.SelectedValue;
            if (int.TryParse(idvdobj.ToString(),out int idvd))
            {
                if (idvd!=0)
                {
                    request.VrstaDjelatnikaId = idvd;
                }
            }
        }
    }
}
