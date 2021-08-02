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
        APIService _korisniciService = new APIService("korisnici");
        private int? _id = null;
        
        public frmIzvodjenjeDetalji(int? izvodjenjeId=null)
        {
            InitializeComponent();
            _id = izvodjenjeId;
            AutoValidate = AutoValidate.Disable;

        }

        rIzvodjenjaInsert inrequest = new rIzvodjenjaInsert();
        rIzvodjenjaUpdate uprequest = new rIzvodjenjaUpdate();
        mIzvodjenja izvodjenje = new mIzvodjenja();


        private async void frmIzvodjenjeDetalji_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
            await LoadPredstave();

            txtKorisnik.Enabled = false;
            dtpDatumVrijeme.Format = DateTimePickerFormat.Time;
           // dtpDatumVrijeme.ShowUpDown = true;

            if (_id.HasValue)
            {
                
                izvodjenje = await _izvodjenjaService.GetById<mIzvodjenja>(_id);

                mKorisnici user = await _korisniciService.GetById<mKorisnici>(izvodjenje.KorisnikId);
                
                txtKorisnik.Text = user.KorisnickoIme;
                txtNapomena.Text = izvodjenje.Napomena;
                cmbPredstave.SelectedValue = izvodjenje.PredstavaId;
                cmbPozoriste.SelectedValue = izvodjenje.PozoristeId;
                dtpDatumVrijeme.Value = izvodjenje.DatumVrijeme;
            }
            else
            {
                txtKorisnik.Text = APIService.TrenutniKorisnik.KorisnickoIme;

            }
        }

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
            if (this.ValidateChildren())
            {
                var idobj = cmbPredstave.SelectedValue;
                if (int.TryParse(idobj.ToString(), out int idpredstave))
                {
                    if (idpredstave != 0)
                    {
                        if (_id.HasValue)
                        {
                            uprequest.PredstavaId = idpredstave;
                        }
                        else
                        {
                            inrequest.PredstavaId = idpredstave;
                        }
                    }
                }

                var idPoz = cmbPozoriste.SelectedValue;
                if (int.TryParse(idPoz.ToString(), out int idpozorista))
                {
                    if (idpozorista != 0)
                    {
                        if (_id.HasValue)
                        {
                            uprequest.PozoristeId = idpozorista;
                        }
                        else
                        {
                            inrequest.PozoristeId = idpozorista;
                        }
                    }
                }

                if (_id.HasValue)
                {
                    uprequest.Napomena = txtNapomena.Text;
                    // uprequest.KorisnikId= 
                    uprequest.KorisnikId = izvodjenje.KorisnikId; ////////sredi
                    uprequest.DatumVrijeme = dtpDatumVrijeme.Value;

                    await _izvodjenjaService.Update<mIzvodjenja>(_id, uprequest);
                    MessageBox.Show("Izvodjenje uspjesno izmijenjeno!");
                    this.Close();
                }
                else
                {
                    inrequest.KorisnikId = APIService.TrenutniKorisnik.KorisnikId;
                    //int.Parse(txtKorisnik.Text);  ///////sredi
                    inrequest.DatumVrijeme = dtpDatumVrijeme.Value;
                    inrequest.Napomena = txtNapomena.Text;

                    await _izvodjenjaService.Insert<mIzvodjenja>(inrequest);
                    MessageBox.Show("Izvodjenje uspjesno dodato!");
                    this.Close();
                }
            }        
        }

        private void cmbPredstave_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(cmbPredstave.SelectedValue.ToString())==0)
            {
                errorProvider.SetError(cmbPredstave, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbPredstave, null);
            }
        }

        private void cmbPozoriste_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(cmbPozoriste.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(cmbPozoriste, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbPozoriste, null);
            }
        }

        private void dtpDatumVrijeme_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDatumVrijeme.Value.Date<DateTime.Today)
            {
                errorProvider.SetError(dtpDatumVrijeme, "Pogresan datum!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpDatumVrijeme, null);
            }
        }

        //private void cmbPredstave_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var idobj = cmbPredstave.SelectedValue;
        //    if (int.TryParse(idobj.ToString(),out int idpredstave))
        //    {
        //        if (idpredstave!=0)
        //        {
        //            if (_id.HasValue)
        //            {
        //                uprequest.PredstavaId = idpredstave;
        //            }
        //            else
        //            {
        //                inrequest.PredstavaId = idpredstave;
        //            }
        //        }
        //    }
        //}

        //private void cmbPozoriste_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var idobj = cmbPozoriste.SelectedValue;
        //    if (int.TryParse(idobj.ToString(), out int idpozorista))
        //    {
        //        if (idpozorista != 0)
        //        {
        //            if (_id.HasValue)
        //            {
        //                uprequest.PozoristeId = idpozorista;
        //            }
        //            else
        //            {
        //                inrequest.PozoristeId = idpozorista;
        //            }
        //        }
        //    }
        //}
    }
}
