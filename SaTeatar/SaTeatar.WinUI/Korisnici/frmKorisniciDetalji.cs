using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaTeatar.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _korisniciService = new APIService("korisnici");
        private int? _id = null;
        public frmKorisniciDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
            AutoValidate = AutoValidate.Disable;
        }

        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var korisnik = await _korisniciService.GetById<mKorisnici>(_id);

                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_id.HasValue)
                {
                    var request = new rKorisniciUpdate()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Email = txtEmail.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Lozinka = txtLozinka.Text,
                        LozinkaPotvrda = txtPotvrdaLozinke.Text
                    };
                    await _korisniciService.Update<mKorisnici>(_id, request);
                }
                else
                {
                    var request = new rKorisniciInsert()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Email = txtEmail.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Lozinka = txtLozinka.Text,
                        LozinkaPotvrda = txtPotvrdaLozinke.Text
                    };

                    await _korisniciService.Insert<mKorisnici>(request);

                }
                MessageBox.Show("Operacija uspjesna!");
            }

        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtIme.Text.Length < 3)
                {
                    errorProvider.SetError(txtIme, Properties.Resources.Validation_MinLength);
                    e.Cancel = true;
                }
            else
            {
                errorProvider.SetError(txtIme, null);
            }

        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtPrezime.Text.Length < 3)
                {
                    errorProvider.SetError(txtPrezime, Properties.Resources.Validation_MinLength);
                    e.Cancel = true;

                }
                else
                {
                    errorProvider.SetError(txtPrezime, null);

                }
            
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    errorProvider.SetError(txtEmail, "Pogresan email format!");
                }
                else
                {
                    errorProvider.SetError(txtEmail, null);

                }
            
        }

        private async void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider.SetError(txtKorisnickoIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtKorisnickoIme.Text.Length < 3)
                {
                    errorProvider.SetError(txtKorisnickoIme, Properties.Resources.Validation_MinLength);
                }
                else
                {
                    rKorisniciSearch search = new rKorisniciSearch() { KorisnickoIme = txtKorisnickoIme.Text };
                    List<mKorisnici> korisnici = await _korisniciService.Get<List<mKorisnici>>(search);
                    if (korisnici.Count > 0)
                    {
                        errorProvider.SetError(txtKorisnickoIme, "Korisnicko ime vec postoji!");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.SetError(txtKorisnickoIme, null);
                    }
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
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(txtLozinka.Text))
                {
                    errorProvider.SetError(txtLozinka, "Lozinka treba sadrzavati bar jedno malo slovo!");
                    e.Cancel = true;
                }
                else if (!hasUpperChar.IsMatch(txtLozinka.Text))
                {
                    errorProvider.SetError(txtLozinka, "Lozinka treba sadrzavati bar jedno veliko slovo!");
                    e.Cancel = true;
                }
                else if (txtLozinka.Text.Length<8)
                {
                    errorProvider.SetError(txtLozinka, "Lozinka treba sadrzavati bar 8 karaktera!");
                    e.Cancel = true;

                }
                else if (!hasNumber.IsMatch(txtLozinka.Text))
                {
                    errorProvider.SetError(txtLozinka, "Lozinka treba sadrzavati bar jedan broj!");
                    e.Cancel = true;
                   
                }

                else if (!hasSymbols.IsMatch(txtLozinka.Text))
                {
                    errorProvider.SetError(txtLozinka, "Lozinka treba sadrzavati bar jedan simbol ili specijalni karakter!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtLozinka, null);
                }
            }
        }

        private void txtPotvrdaLozinke_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPotvrdaLozinke.Text))
            {
                errorProvider.SetError(txtPotvrdaLozinke, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (txtPotvrdaLozinke.Text != txtLozinka.Text)
                {
                    errorProvider.SetError(txtPotvrdaLozinke, "Lozinke se ne podudaraju!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPotvrdaLozinke, null);
                }
            }
        }

        private bool ValidateData(object data)
        {
            ValidationContext context = new ValidationContext(data, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(data, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);

                return false;
            }
            else
            {
                MessageBox.Show("Success!!!");
                return true;
            }
        }
    }
}
