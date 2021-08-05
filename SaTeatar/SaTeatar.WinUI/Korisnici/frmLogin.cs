using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaTeatar.WinUI.Korisnici
{
    public partial class frmLogin : Form
    {
        private readonly APIService _api = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                APIService.Username = txtKorisnickoIme.Text;
                APIService.Password = txtLozinka.Text;

                try
                {
                    btnPrijava.Enabled = false;

                    var result = await _api.Get<List<mKorisnici>>(null);
                    frmIndex frm = new frmIndex(); 
                    var search = new rKorisniciSearch() { KorisnickoIme = APIService.Username };
                    List<mKorisnici> lista = await _api.Get<List<mKorisnici>>(search);
                    APIService.TrenutniKorisnik = lista[0];
                    //  Hide();
                    txtLozinka.Clear();
                    this.Visible = false;
                    frm.Show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Pogresno korisnicko ime ili lozinka!");
                    txtLozinka.Clear();
                    txtKorisnickoIme.Clear();
                    btnPrijava.Enabled = true;
                }
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider.SetError(txtKorisnickoIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider.SetError(txtLozinka, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLozinka, null);
            }
        }
    }
}
