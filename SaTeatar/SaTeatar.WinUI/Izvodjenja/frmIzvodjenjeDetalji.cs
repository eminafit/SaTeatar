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
        APIService _poslaneObavijestiService = new APIService("poslaneObavijesti");
        APIService _postavkeObavijestiService = new APIService("postavkeObavijesti");
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
        mIzvodjenja _izvodjenje = new mIzvodjenja();


        private async void frmIzvodjenjeDetalji_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
            await LoadPredstave();

            txtKorisnik.Enabled = false;
            dtpDatumVrijeme.Format = DateTimePickerFormat.Time;

            if (_id.HasValue)
            {
                
                _izvodjenje = await _izvodjenjaService.GetById<mIzvodjenja>(_id);

                mKorisnici user = await _korisniciService.GetById<mKorisnici>(_izvodjenje.KorisnikId);
                
                txtKorisnik.Text = user.KorisnickoIme;
                txtNapomena.Text = _izvodjenje.Napomena;
                cmbPredstave.SelectedValue = _izvodjenje.PredstavaId;
                cmbPozoriste.SelectedValue = _izvodjenje.PozoristeId;
                dtpDatumVrijeme.Value = _izvodjenje.DatumVrijeme;
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
                    uprequest.KorisnikId = _izvodjenje.KorisnikId; 
                    uprequest.DatumVrijeme = dtpDatumVrijeme.Value;

                    _izvodjenje = await _izvodjenjaService.Update<mIzvodjenja>(_id, uprequest);
                    MessageBox.Show("Izvodjenje uspjesno izmijenjeno!");
                }
                else
                {
                    inrequest.KorisnikId = APIService.TrenutniKorisnik.KorisnikId;
                    inrequest.DatumVrijeme = dtpDatumVrijeme.Value;
                    inrequest.Napomena = txtNapomena.Text;

                    _izvodjenje = await _izvodjenjaService.Insert<mIzvodjenja>(inrequest);
                    MessageBox.Show("Izvodjenje uspjesno dodato!");
                }

                PosaljiObavijest();
                this.Close();
            }        
        }

        private async void PosaljiObavijest()
        {

            //kad se napravi/izmijeni izvodjenje, poslati obavijest
            //provjeriti koji je tip predstave u izvodjenju
            //pogledati u postavke obavijesti koji kupci zele primati obavijesti za taj tip predstave
            //staviti datum vazenja do dana izvodjenja predstave
            //polje procitano oznaciti sa false
            //poslati obavijest

            mPredstave predstava = await _predstaveService.GetById<mPredstave>(_izvodjenje.PredstavaId);
            mPozorista pozoriste = await _pozoristaService.GetById<mPozorista>(_izvodjenje.PozoristeId);
            var search = new rPostavkaObavijestiSearch() { TipPredstaveId = predstava.TipPredstaveId };
            List<mPostavkeObavijesti> kupci = await _postavkeObavijestiService.Get<List<mPostavkeObavijesti>>(search);

            foreach (var kupac in kupci)
            {
                var request = new rPoslaneObavijestiInsert()
                {
                    KupacId = kupac.KupacId,
                    DatumVazenja = _izvodjenje.DatumVrijeme,
                    VrijemeSlanja = DateTime.Now,
                    PrestavaId = _izvodjenje.PredstavaId,
                    Procitano = false,
                    Poruka = $"Dana {_izvodjenje.DatumVrijeme.Date.ToShortDateString()} u { _izvodjenje.DatumVrijeme.ToShortTimeString()} se izvodi predstava \"{predstava.Naziv}\" u pozoristu \"{pozoriste.Naziv}\"."
                };
                await _poslaneObavijestiService.Insert<mPoslaneObavijesti>(request);
            }


            //sa korisnicke strane
            //kod logina kupca provjeriti da li ima obavijesti koje vaze do tog dana i koje su neprocitane
            //ako ima onda ga obavijesti o tome
            //kad otvori obavijest, oznaciti je kao procitanu
        }

        private void cmbPredstave_Validating(object sender, CancelEventArgs e)
        {
            if (cmbPredstave.SelectedValue == null || int.Parse(cmbPredstave.SelectedValue.ToString())==0 )
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
            if (cmbPozoriste.SelectedValue == null || int.Parse(cmbPredstave.SelectedValue.ToString()) == 0)
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

    }
}
