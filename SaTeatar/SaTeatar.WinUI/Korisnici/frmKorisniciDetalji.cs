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
        private readonly APIService _ulogeService = new APIService("uloge");
        private readonly APIService _korisniciUlogeService = new APIService("korisniciuloge");
        private int? _id = null;
        List<mUloge> sveuloge =  new List<mUloge>();


        public frmKorisniciDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
            AutoValidate = AutoValidate.Disable;
        }

        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            var sveulogem = await _ulogeService.Get<List<mUloge>>(null);
            //YourList.GroupBy(i => i.Id).Select(i => i.FirstOrDefault()).ToList();
            IEnumerable<mUloge> sve = sveulogem.GroupBy(i => i.UlogaId).Select(i => i.FirstOrDefault()).ToList();
            sveuloge = sve.ToList();
            lbUloge.DisplayMember = "Naziv";
            lbUloge.ValueMember = "UlogaId";
            lbUloge.DataSource = sveuloge;
            lbUloge.SetSelected(0, false);

            if (_id.HasValue)
            {
                var korisnik = await _korisniciService.GetById<mKorisnici>(_id);
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                chbStatus.Checked = korisnik.Status;
                var search = new rUlogeSearch() { KorisnikId = (int)_id };
                var korisnikUloge = await _ulogeService.Get<List<mUloge>>(search);

                for (int i = 0; i < korisnikUloge.Count; i++)
                {
                    for (int j = 0; j < sveuloge.Count; j++)
                    {
                        if (korisnikUloge[i].UlogaId==sveuloge[j].UlogaId)
                        {
                            lbUloge.SetSelected(j, true);
                        }
                    }
                }
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
                        LozinkaPotvrda = txtPotvrdaLozinke.Text,
                        Status = chbStatus.Checked
                    };

                    await _korisniciService.Update<mKorisnici>(_id, request);


                    //brisanje postojecih uloga ukoliko je trenutni korisnik admin
                    var search = new rKorisniciUlogeSearch() { KorisnikId = (int)_id };
                        List<mKorisniciUloge> ulogekorisnika = await _korisniciUlogeService.Get<List<mKorisniciUloge>>(search);
                        foreach (var uk in ulogekorisnika)
                        {
                            await _korisniciUlogeService.Delete<mKorisniciUloge>(uk.KorisnikUlogaId);
                        }

                        //dodaj nove
                        foreach (mUloge uloga in lbUloge.SelectedItems)
                        {
                            await _korisniciUlogeService.Insert<mKorisniciUloge>(new mKorisniciUloge() { UlogaId = uloga.UlogaId, KorisnikId = (int)_id, DatumIzmjene = DateTime.Now });
                        }
                    

                    MessageBox.Show("Uspjesno izmijenjen korisnik!");
                    this.Close();

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
                        LozinkaPotvrda = txtPotvrdaLozinke.Text,
                        Status = chbStatus.Checked
                    };

                    var korisnik = await _korisniciService.Insert<mKorisnici>(request);


                    foreach (mUloge uloga in lbUloge.SelectedItems)
                        {
                            await _korisniciUlogeService.Insert<mKorisniciUloge>(new mKorisniciUloge() { UlogaId = uloga.UlogaId, KorisnikId = korisnik.KorisnikId, DatumIzmjene = DateTime.Now });
                        }
                    

                    MessageBox.Show("Uspjesno dodan korisnik!");
                    this.Close();
                }
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
                e.Cancel = true;
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
                if (!_id.HasValue)
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
                if (!_id.HasValue)
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
                    else if (txtLozinka.Text.Length < 8)
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

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private bool ValidateData(object data)
        //{
        //    ValidationContext context = new ValidationContext(data, null, null);
        //    IList<ValidationResult> errors = new List<ValidationResult>();

        //    if (!Validator.TryValidateObject(data, context, errors, true))
        //    {
        //        foreach (ValidationResult result in errors)
        //            MessageBox.Show(result.ErrorMessage);

        //        return false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Success!!!");
        //        return true;
        //    }
        //}
    }
}
