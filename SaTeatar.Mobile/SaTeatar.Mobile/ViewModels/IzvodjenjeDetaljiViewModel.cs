using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class IzvodjenjeDetaljiViewModel : BaseViewModel
    {
        private readonly APIService _zoneService = new APIService("zone");
        private readonly APIService _izvodjenjaZoneService = new APIService("izvodjenjaZone");
        private readonly APIService _ocjeneService = new APIService("ocjene");
        private readonly APIService _karteService = new APIService("karte");

        private readonly APIService _tipovipredstavaService = new APIService("tipoviPredstava");
        private readonly APIService _predstaveDjelatniciService = new APIService("PredstaveDjelatnici");
        private readonly APIService _vrstedjelatnikaService = new APIService("vrsteDjelatnika");
        private readonly APIService _predstaveService = new APIService("predstava");

        public IzvodjenjeDetaljiViewModel()
        {
            PovecajKolicinuCommand = new Command(() => Povecaj());
            SmanjiKolicinuCommand = new Command(() => Smanji());
            NaruciCommand = new Command(() => Naruci());
            InitCommand = new Command(async() => await Init());
        }
        public mIzvodjenja Izvodjenje { get; set; }
        public mIzvodjenjaZone IzvodjenjeZone { get; set; }
        public mZone Zone { get; set; }

        public class PredstavaDetalji
        {
            public int PredstavaId { get; set; }
            public string Naziv { get; set; }
            public int TipId { get; set; }
            public string Tip { get; set; }
            public string Opis { get; set; }
            public byte[] Slika { get; set; }
            public string GlumciStr { get; set; }
            public string Rezija { get; set; }

        }

        PredstavaDetalji _predstavaDetalji = null;
        public PredstavaDetalji PreDetalji
        {
            get { return _predstavaDetalji; }
            set { SetProperty(ref _predstavaDetalji, value); NotifyPropertyChanged(); }
        }

        public ObservableCollection<mZone> ZoneList { get; set; } = new ObservableCollection<mZone>();

        public event PropertyChangedEventHandler PropertyChangedEH;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChangedEH != null)
            {
                PropertyChangedEH(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        mZone _selectedZona = null;
        public mZone SelectedZona
        {
            get { return _selectedZona; }
            set
            {
                SetProperty(ref _selectedZona, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        string _kljuc;

        int _brojSlobodnihSjedistaUZoni = 0;
        public int BrSlobodnihSjedistaUZoni
        {
            get { return _brojSlobodnihSjedistaUZoni; }
            set { SetProperty(ref _brojSlobodnihSjedistaUZoni, value); NotifyPropertyChanged(); }
        }


        int _brojSjedistaUZoni = 0;
        public int BrSjedistaUZoni
        {
            get { return _brojSjedistaUZoni; }
            set { SetProperty(ref _brojSjedistaUZoni, value); NotifyPropertyChanged(); }
        }

        int _kolicina = 0;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); NotifyPropertyChanged(); }
        }

        decimal _cijena = 0;
        public decimal Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); NotifyPropertyChanged(); }
        }

        decimal _popust = 0;
        public decimal Popust
        {
            get { return _popust; }
            set { SetProperty(ref _popust, value); NotifyPropertyChanged(); }
        }

        decimal _ukupnaCijena = 0;
        public decimal UkupnaCijena
        {
            get { return _ukupnaCijena; }
            set { SetProperty(ref _ukupnaCijena, value); NotifyPropertyChanged(); }
        }

        double _ocjena = 0;
        public double ProsjecnaOcjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); NotifyPropertyChanged(); }
        }

        string _ocjenaStr = string.Empty;
        public string OcjenaStr
        {
            get { return _ocjenaStr; }
            set { SetProperty(ref _ocjenaStr, value); NotifyPropertyChanged(); }
        }

        string _datumStr = string.Empty;
        public string DatumStr
        {
            get { return _datumStr; }
            set { SetProperty(ref _datumStr, value); NotifyPropertyChanged(); }
        }

        bool _ukbool = false;
        public bool UKbool
        {
            get { return _ukbool; }
            set { SetProperty(ref _ukbool, value); NotifyPropertyChanged(); }
        }

        public ICommand PovecajKolicinuCommand { get; set; }
        public ICommand SmanjiKolicinuCommand { get; set; }
        
        public ICommand NaruciCommand { get; set; }
        public ICommand InitCommand { get; set; }


        private void Povecaj()
        {
            if (BrSlobodnihSjedistaUZoni > 0)
            {
                Kolicina += 1;
                UkupnaCijena = Cijena * Kolicina;
                BrSlobodnihSjedistaUZoni -= 1;

            }
            if (UkupnaCijena != 0)
                UKbool = true;
            else
                UKbool = false;
        }

        private void Smanji()
        {
            if (Kolicina > 0)
            {
                Kolicina -= 1;
                UkupnaCijena = Cijena * Kolicina;
                BrSlobodnihSjedistaUZoni += 1;
            }
            else
            {
                Kolicina = 0;
                UkupnaCijena = 0;
            }
            if (UkupnaCijena != 0)
                UKbool = true;
            else
                UKbool = false;
        }

        private async void Naruci()
        {
            if (UkupnaCijena==0)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Unesite ispravnu kolicnu", "Pokusajte opet");
                return;
            }

            if (CartService.Cart.ContainsKey(_kljuc))
            {
                CartService.Cart.Remove(_kljuc);
            }
            CartService.Cart.Add(_kljuc, this);

        }

        public async Task Init()
        {
            //ocjene predstave
            var searchOcjene = new rOcjeneSearch { PredstavaId = Izvodjenje.PredstavaId };
            var ocjene = await _ocjeneService.Get<List<mOcjene>>(searchOcjene);
            ProsjecnaOcjena = ocjene.Select(x => x.Ocjena).Average();
            ProsjecnaOcjena = Math.Round(ProsjecnaOcjena, 2, MidpointRounding.AwayFromZero);
            OcjenaStr = string.Empty;
            for (int i = 0; i < (int)ProsjecnaOcjena; i++)
            {
                OcjenaStr += "o";
            }
            var ost = ProsjecnaOcjena - (int)ProsjecnaOcjena;
            if (ost>=0.5)
                OcjenaStr += "c";

            //formatdatum
            DatumStr = Izvodjenje.DatumVrijeme.ToString("dd.MM.yyyy.");
            DatumStr += " u ";
            DatumStr += Izvodjenje.DatumVrijeme.ToString("HH:mm") + "h";

            //detalji
            var predstavadetalji = await _predstaveService.GetById<mPredstave>(Izvodjenje.PredstavaId);
            var tip = await _tipovipredstavaService.GetById<mTipoviPredstava>(predstavadetalji.TipPredstaveId);

            var searchg = new rPredstaveDjelatnicSearch() { PredstavaId = predstavadetalji.PredstavaId };
            var listaglumaca = await _predstaveDjelatniciService.Get<List<mPredstaveDjelatnici>>(searchg);
            string lgstr = "";
            string rezija = "";
            foreach (var g in listaglumaca)
            {
                if (g.Djelatnik.VrstaDjelatnikaId == 2)
                {
                    lgstr += $"{g.DjelatnikIme} {g.DjelatnikPrezime}\n";
                }
                else
                {
                    rezija = $"{g.DjelatnikIme} {g.DjelatnikPrezime}";
                }
            }

            var pd = new PredstavaDetalji()
            {
                PredstavaId = predstavadetalji.PredstavaId,
                Naziv = predstavadetalji.Naziv,
                GlumciStr = lgstr,
                Rezija = rezija,
                TipId = predstavadetalji.TipPredstaveId,
                Tip = tip.Naziv.ToUpper(),
                Slika = predstavadetalji.Slika,
                Opis=predstavadetalji.Opis,
            };

            PreDetalji = pd;

            if (ZoneList.Count == 0)
            {
                var search = new rZoneSearch() { PozoristeId = Izvodjenje.PozoristeId };
                var zlist = await _zoneService.Get<IEnumerable<mZone>>(search);

                foreach (var z in zlist)
                {
                    ZoneList.Add(z);
                }
            }

            if (SelectedZona != null)
            {
                var search = new rIzvodjenjaZoneSearch();
                search.ZonaId = SelectedZona.ZonaId;
                search.IzvodjenjeId = Izvodjenje.IzvodjenjeId;


                var ilist = await _izvodjenjaZoneService.Get<List<mIzvodjenjaZone>>(search); //dobicu samo 1 obj

                IzvodjenjeZone = new mIzvodjenjaZone()
                {
                    IzvodjenjeZonaId = ilist[0].IzvodjenjeZonaId,
                    ZonaId = ilist[0].ZonaId,
                    Cijena = ilist[0].Cijena,
                    IzvodjenjeId = ilist[0].IzvodjenjeId,
                    ZonaNaziv=ilist[0].ZonaNaziv
                };

                _kljuc = $"{Izvodjenje.IzvodjenjeId}_{IzvodjenjeZone.ZonaId}";

                bool imavec = false;
                foreach (var item in CartService.Cart.Values)
                {
                    if(item._kljuc==_kljuc)
                    //if (item.Izvodjenje.IzvodjenjeId==Izvodjenje.IzvodjenjeId && item.IzvodjenjeZone.ZonaId==SelectedZona.ZonaId)
                    {
                        imavec = true;
                        Kolicina = item.Kolicina;
                        UkupnaCijena = item.UkupnaCijena;
                        if (UkupnaCijena!=0)
                        {
                            UKbool = true;
                        }

                    }

                }

                if (!imavec)
                {
                                                          
                        Kolicina = 0;
                        UkupnaCijena = 0;
                    
                }


                ///

                var zona = await _zoneService.GetById<mZone>(IzvodjenjeZone.ZonaId);
                var searchiz = new rKartaSearch() { IzvodjenjeZonaId = IzvodjenjeZone.IzvodjenjeZonaId, Placeno=true };
                var karte = await _karteService.Get<List<mKarta>>(searchiz);
                int brojac = 0;
                var datumVazenjaRezervacije = Izvodjenje.DatumVrijeme.AddDays(-7);
                foreach (var k in karte)
                {
                    if (k.Placeno)
                    {
                        brojac++;
                    }
                }

                var searchizf = new rKartaSearch() { IzvodjenjeZonaId = IzvodjenjeZone.IzvodjenjeZonaId, Placeno = false };
                var kartef = await _karteService.Get<List<mKarta>>(searchizf);
                foreach (var k in kartef)
                {
                    if (!k.Placeno && DateTime.Compare(DateTime.Now, datumVazenjaRezervacije) <= 0)
                    {
                        brojac++;
                    }
                }
                BrSjedistaUZoni = zona.UkupanBrojSjedista;
                BrSlobodnihSjedistaUZoni = zona.UkupanBrojSjedista - brojac - Kolicina;
                Cijena = IzvodjenjeZone.Cijena;

          
            }
        }

    }
}
