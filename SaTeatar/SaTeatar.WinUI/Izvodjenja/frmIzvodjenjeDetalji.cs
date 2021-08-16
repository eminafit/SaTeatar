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
        APIService _zoneService = new APIService("zone");
        APIService _izvodjenjaZoneService = new APIService("izvodjenjaZone");
        APIService _karteService = new APIService("karte");

        private int? _id = null;
        private bool update = false;
        
        public frmIzvodjenjeDetalji(int? izvodjenjeId=null)
        {
            InitializeComponent();
            _id = izvodjenjeId;
            AutoValidate = AutoValidate.Disable;
        }

        rIzvodjenjaInsert inrequest = new rIzvodjenjaInsert();
        rIzvodjenjaUpdate uprequest = new rIzvodjenjaUpdate();
        mIzvodjenja _izvodjenje = new mIzvodjenja();
        List<rIzvodjenjaZoneInsert> izvodjenjaZoneInsert = new List<rIzvodjenjaZoneInsert>();
        List<rIzvodjenjaZoneUpdate> izvodjenjaZoneUpdate = new List<rIzvodjenjaZoneUpdate>();
        private bool promjenaPozorista = false;
        private int _postojecePozoristeId = 0;

        private async void frmIzvodjenjeDetalji_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
            await LoadPredstave();

            txtKorisnik.Enabled = false;
            dtpDatumVrijeme.Format = DateTimePickerFormat.Time;

            if (_id.HasValue)
            {
                update = true;

                _izvodjenje = await _izvodjenjaService.GetById<mIzvodjenja>(_id);

                mKorisnici user = await _korisniciService.GetById<mKorisnici>(_izvodjenje.KorisnikId);
                
                txtKorisnik.Text = user.KorisnickoIme;
                txtNapomena.Text = _izvodjenje.Napomena;
                cmbPredstave.SelectedValue = _izvodjenje.PredstavaId;
                cmbPozoriste.SelectedValue = _izvodjenje.PozoristeId;
                _postojecePozoristeId = _izvodjenje.PozoristeId;
                _postojecePozoristeId = _izvodjenje.PozoristeId;
                dtpDatumVrijeme.Value = _izvodjenje.DatumVrijeme;

                //zone
                var searchiz = new rIzvodjenjaZoneSearch() { IzvodjenjeId = _izvodjenje.IzvodjenjeId };
                List<mIzvodjenjaZone> izs = await _izvodjenjaZoneService.Get<List<mIzvodjenjaZone>>(searchiz);

                PrikaziZone(izs);
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
                            if (_postojecePozoristeId!=idpredstave)
                            {
                                promjenaPozorista = true;
                            }
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
                    PosaljiObavijest(true);
                }
                else
                {
                    inrequest.KorisnikId = APIService.TrenutniKorisnik.KorisnikId;
                    inrequest.DatumVrijeme = dtpDatumVrijeme.Value;
                    inrequest.Napomena = txtNapomena.Text;

                    _izvodjenje = await _izvodjenjaService.Insert<mIzvodjenja>(inrequest);
                    MessageBox.Show("Izvodjenje uspjesno dodato!");
                    PosaljiObavijest();
                }

                //dodavanje cijene za zone

                //vidi ima li zapisa sa ovo izvodjenje
                var searchiz = new rIzvodjenjaZoneSearch() { IzvodjenjeId = _izvodjenje.IzvodjenjeId  };
                List<mIzvodjenjaZone> izs = await _izvodjenjaZoneService.Get<List<mIzvodjenjaZone>>(searchiz);

                //ako nema nikako
                if (izs.Count == 0)
                {
                    //dodaj nove
                    DodajZone();
                }

                //ako ima i ako se pozoriste promijenilo
                if (izs.Count > 0 && promjenaPozorista)
                {
                    //obrisi stare zapise (odnose se na zone drugog pozorista)
                    foreach (var item in izs) 
                    {
                        await _izvodjenjaZoneService.Delete<mIzvodjenjaZone>(item.IzvodjenjeZonaId);
                    }
                    //dodaj nove
                    DodajZone();
                }

                //ako ima i ako se pozoriste nije promijenilo
                if (izs.Count > 0 && !promjenaPozorista)
                {
                    //prikazi postojece/uradi update
                    PrikaziZone(izs);
                }


            }        
        }

        private async void DodajZone()
        {
            //var search = new rZoneSearch() { PozoristeId = int.Parse(cmbPozoriste.SelectedValue.ToString()) };
            var search = new rZoneSearch() { PozoristeId = _izvodjenje.PozoristeId };
            var zone = await _zoneService.Get<List<mZone>>(search);
            izvodjenjaZoneInsert.Clear();
            foreach (var item in zone)
            {
                izvodjenjaZoneInsert.Add(new rIzvodjenjaZoneInsert()
                {
                    IzvodjenjeId = _izvodjenje.IzvodjenjeId,
                    ZonaId = item.ZonaId,
                    ZonaNaziv = item.Naziv,
                    Cijena = 0,
                    Popust = 0,
                });
            }

            dgvZone.DataSource = null;
            dgvZone.AutoGenerateColumns = false;
            dgvZone.DataSource = izvodjenjaZoneInsert;
            dgvZone.Columns["ZonaNaziv"].ReadOnly = true;
        }

        private void PrikaziZone(List<mIzvodjenjaZone> izs)
        {
            izvodjenjaZoneUpdate.Clear();
            foreach (var item in izs)
            {
                izvodjenjaZoneUpdate.Add(new rIzvodjenjaZoneUpdate()
                {
                    IzvodjenjeZonaId = item.IzvodjenjeZonaId,
                    IzvodjenjeId = item.IzvodjenjeId,
                    Cijena = item.Cijena,
                    ZonaId = item.ZonaId,
                    ZonaNaziv = item.ZonaNaziv,
                    Popust = item.Popust,

                });
            }
            update = true;
            dgvZone.DataSource = null;
            dgvZone.AutoGenerateColumns = false;
            dgvZone.DataSource = izvodjenjaZoneUpdate;
            dgvZone.Columns["ZonaNaziv"].ReadOnly = true;
        }

        private async void PosaljiObavijest(bool update = false)
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
            List<mPostavkeObavijesti> po = await _postavkeObavijestiService.Get<List<mPostavkeObavijesti>>(search);
            var kupci_po = po.Select(x => x.KupacId).Distinct();

            //salji obavijest jedino ako vec nisu gledali predstavu
            //karte -> placena true + izvodjenja -> predstava
            var srcKarte = new rKartaSearch() { PredstavaId=predstava.PredstavaId, Placeno=true };
            var karte = await _karteService.Get<List<mKarta>>(srcKarte);
            var kupci_karte = karte.Select(x => x.KupacId).Distinct();

            var kupcifinalids = kupci_po.Except(kupci_karte); 

            var poruka = "Postovani,\nObavjestavamo Vas ";

            if (update)
            {
                poruka += "da je doslo je do izmjene i ";
            }

            poruka += $" da se predstava \"{predstava.Naziv}\" izvodi " +
                $"{_izvodjenje.DatumVrijeme.Date.ToShortDateString()} " +
                $"u { _izvodjenje.DatumVrijeme.ToShortTimeString()}h " +
                $"u pozoristu \"{pozoriste.Naziv}\".";


            foreach (var kupac in kupcifinalids)
            {
                var request = new rPoslaneObavijestiInsert()
                {
                    KupacId = kupac,
                    DatumVazenja = _izvodjenje.DatumVrijeme,
                    VrijemeSlanja = DateTime.Now,
                    PrestavaId = _izvodjenje.PredstavaId,
                    Procitano = false,
                    Poruka = poruka
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


        private async void btnSacuvajCijeneZona_Click(object sender, EventArgs e)
        {
            if (_izvodjenje.IzvodjenjeId == 0)
            {
                MessageBox.Show("Greska! Morate prvo dodati izvodjenje!. Kliknite na dugme 'Sacuvaj'.", "OK");
            }
            else
            {


                bool greska = false;
                for (int rows = 0; rows < dgvZone.Rows.Count; rows++)
                {
                    if (decimal.Parse(dgvZone.Rows[rows].Cells["Cijena"].Value.ToString()) == 0)
                    {
                        MessageBox.Show($"Greska! {dgvZone.Rows[rows].Cells["ZonaNaziv"].Value} ima cijenu 0!", "OK");
                        greska = true;
                    }
                }

                if (!greska)
                {
                    if (update && !promjenaPozorista)
                    {
                        for (int rows = 0; rows < dgvZone.Rows.Count; rows++)
                        {
                            izvodjenjaZoneUpdate[rows].Cijena = decimal.Parse(dgvZone.Rows[rows].Cells["Cijena"].Value.ToString());
                        }
                        foreach (var item in izvodjenjaZoneUpdate)
                        {
                            await _izvodjenjaZoneService.Update<mIzvodjenjaZone>(item.IzvodjenjeZonaId, item);
                        }
                        MessageBox.Show("Uspjesno izmijenjene cijene karta!", "OK!");
                        this.Close();
                    }
                    else
                    {
                        for (int rows = 0; rows < dgvZone.Rows.Count; rows++)
                        {
                            izvodjenjaZoneInsert[rows].Cijena = decimal.Parse(dgvZone.Rows[rows].Cells["Cijena"].Value.ToString());
                        }

                        foreach (var item in izvodjenjaZoneInsert)
                        {
                            await _izvodjenjaZoneService.Insert<mIzvodjenjaZone>(item);
                        }
                        MessageBox.Show("Uspjesno dodane cijene karta!", "OK!");
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Unesite ispravne vrijednosti cijena!", "OK!");
                }
            }
        }

        private void dgvZone_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception !=null )
            {
                MessageBox.Show("Unesite ispravan format cijene!", "OK");
            }
        }
    }
}
