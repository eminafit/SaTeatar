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


namespace SaTeatar.WinUI.Pozorista
{
    public partial class frmPozoristeDetalji : Form
    {
        APIService _pozoristaService = new APIService("pozorista");
        APIService _zoneService = new APIService("zone");

        public frmPozoristeDetalji()
        {
            InitializeComponent();
        }

        rPozoristaInsert upit = new rPozoristaInsert();
        mPozorista result = new mPozorista();

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result==DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                upit.Logo = file;

                txtSlikaInput.Text = filename;
                Image slika = Image.FromFile(filename);
                pbSlika.Image = slika;

            }

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            upit.Naziv = txtNaziv.Text;
            upit.Adresa = txtAdresa.Text;

            result = await _pozoristaService.Insert<mPozorista>(upit);
            MessageBox.Show("Pozoriste uspjesno dodato!");
            //if (result.PozoristeId != 0)
            //{
            //    btnDodajZone_Click(null, null);
            //}

        }

        private void btnDodajZone_Click(object sender, EventArgs e)
        {
            if (result.PozoristeId==0)
            {
                MessageBox.Show("Pozoriste se treba najprije dodati! Kliknuti na dugme 'Sacuvaj'");

               // btnSacuvaj_Click(null, null);
            }
            else
            {
                frmZonaDetalji frm = new frmZonaDetalji(result.PozoristeId, result.Naziv);
                //frm.MdiParent = this;
               // frm.Parent = this;
                frm.Show();
            }
        }

        private void frmPozoristeDetalji_Load(object sender, EventArgs e)
        {

        }

        private async void txtPrikaziZone_Click(object sender, EventArgs e)
        {
            if (result.PozoristeId != 0)
            {
                rZoneSearch zahtjev = new rZoneSearch() { PozoristeId = result.PozoristeId };
                var zone = await _zoneService.Get<List<mZone>>(zahtjev);
                lbZone.DisplayMember = "NazivSjedista";
                lbZone.DataSource = zone;
            }
            else
            {
                MessageBox.Show("Zone nisu dodate!");
            }
        }
    }
}
