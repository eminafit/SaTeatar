using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;

namespace SaTeatar.WinUI.Izvodjenja
{
    public partial class frmIzvodjenjeDetalji : Form
    {
        APIService _izvodjenjaService = new APIService("izvodjenja");
        APIService _predstaveService = new APIService("predstava");
        APIService _pozoristaService = new APIService("pozorista");
        
        public frmIzvodjenjeDetalji()
        {
            InitializeComponent();
        }

        private async void frmIzvodjenjeDetalji_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
            await LoadPredstave();
        }

        rIzvodjenjaInsert zahtjev = new rIzvodjenjaInsert();


        private async Task LoadPredstave()
        {
            var upit = await _predstaveService.Get<List<mPredstave>>(null);
            upit.Insert(0, new mPredstave());
            cmbPredstave.DisplayMember = "Naziv";
            cmbPredstave.ValueMember = "PredstavaId";
            cmbPredstave.DataSource = upit;
        }

        private async Task LoadPozorista()
        {
            var upit = await _pozoristaService.Get<List<mPozorista>>(null);
            upit.Insert(0, new mPozorista());
            cmbPozoriste.DisplayMember = "Naziv";
            cmbPozoriste.ValueMember = "PozoristeId";
            cmbPozoriste.DataSource = upit;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {

            zahtjev.KorisnikId = int.Parse(txtKorisnik.Text);  ///////sredi
            zahtjev.DatumVrijeme = dtpDatumVrijeme.Value;
            zahtjev.Napomena = txtNapomena.Text;

            await _izvodjenjaService.Insert<mIzvodjenja>(zahtjev);
            MessageBox.Show("Izvodjenje uspjesno dodato!");
            this.Close();
        }

        private void cmbPredstave_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idobj = cmbPredstave.SelectedValue;
            if (int.TryParse(idobj.ToString(),out int idpredstave))
            {
                if (idpredstave!=0)
                {
                    zahtjev.PredstavaId = idpredstave;
                }
            }
        }

        private void cmbPozoriste_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idobj = cmbPozoriste.SelectedValue;
            if (int.TryParse(idobj.ToString(), out int idpozorista))
            {
                if (idpozorista != 0)
                {
                    zahtjev.PozoristeId = idpozorista;
                }
            }
        }
    }
}
