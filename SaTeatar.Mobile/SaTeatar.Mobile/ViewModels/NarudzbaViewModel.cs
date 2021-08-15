using QRCoder;
using SaTeatar.Mobile.Helpers;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class NarudzbaViewModel : BaseViewModel
    {
        private readonly APIService _karteService = new APIService("karte");
        private readonly APIService _kupciService = new APIService("kupci");
        private readonly APIService _narudzbaService = new APIService("narudzba");
        private readonly APIService _narudzbaStavkeService = new APIService("narudzbaStavke");
        private readonly int _idKupca = PrijavljeniKupac.Kupac.KupacId;

        public ObservableCollection<IzvodjenjeDetaljiViewModel> NarudzbaList { get; set; } = new ObservableCollection<IzvodjenjeDetaljiViewModel>();

        public NarudzbaViewModel()
        {
            //PromijenjenaKolicnaCommand = new Command(() => PromijenjenaKolicina());
            RezervisiCommand = new Command(async () => await Rezervisi());
         //   PlatiCommand = new Command(async () => await Rezervisi()) ;
            
        }
        public mNarudzba Narudzba = new mNarudzba();
        public List<mNarudzbaStavke> NarudzbaStavkeList = new List<mNarudzbaStavke>();
        public List<mKarta> KarteList = new List<mKarta>();

        decimal _ukupniIznos = 0;
        public decimal UkupniIznos
        {
            get { return _ukupniIznos; }
            set { SetProperty(ref _ukupniIznos, value); }
        }

        public void Init()
        {
            NarudzbaList.Clear();

            foreach (var cartValue in CartService.Cart.Values)
            {
                NarudzbaList.Add(cartValue);
                UkupniIznos += cartValue.UkupnaCijena;
            }
        }

        public ICommand PromijenjenaKolicnaCommand { get; set; }
        public ICommand RezervisiCommand { get; set; }
        //public ICommand PlatiCommand { get; set; }

        public void PromijenjenaKolicina()
        {
            UkupniIznos = 0;
            foreach (var cartValue in CartService.Cart.Values)
            {
                UkupniIznos += cartValue.UkupnaCijena;
            }
        }
        byte[] GenerisiQrCode(string InputText)
        {
            if (string.IsNullOrEmpty(InputText))
                InputText = "";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.M);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            return qRCode.GetGraphic(20);
        }

        async Task Rezervisi()
        {
            if (CartService.Cart.Count > 0)
            {

                //dodaj karte
                //var searchId = new rKupciSearch { KorisnickoIme = APIService.Username };
                //var kupac = PrijavljeniKupac.Kupac;
                //var kupci = await _kupciService.Get<List<mKupci>>(searchId);
                //var idKupca = kupci[0].KupacId;

                var narudzbaInsert = new rNarudzbaInsert()
                {
                    BrojNarudzbe = "Narudzba_000",
                    KupacId = _idKupca,
                    Datum = DateTime.Now,
                    Iznos = UkupniIznos,
                    PaymentId = string.Empty
                };

                var narudzba = await _narudzbaService.Insert<mNarudzba>(narudzbaInsert);

                Narudzba = narudzba;

                foreach (var cartValue in CartService.Cart.Values)
                {
                    for (int i = 0; i < cartValue.Kolicina; i++)
                    {
                        var karta = new rKartaInsert()
                        {
                            KupacId = _idKupca,
                            IzvodjenjeId = cartValue.Izvodjenje.IzvodjenjeId,
                            IzvodjenjeZonaId = cartValue.IzvodjenjeZone.IzvodjenjeZonaId,
                            Placeno = false,
                            Sifra = "xyc"
                        };
                        karta.Qrcode = GenerisiQrCode(karta.Sifra);
                        var mkarta = await _karteService.Insert<mKarta>(karta);
                        KarteList.Add(mkarta);

                        var ns = new rNarudzbaStavkeInsert()
                        {
                            KartaId = mkarta.KartaId,                            
                            NarudzbaId = narudzba.NarudzbaId
                        };

                        var mns = await _narudzbaStavkeService.Insert<mNarudzbaStavke>(ns);
                        NarudzbaStavkeList.Add(mns);
                    }
                }

                CartService.Cart.Clear();
            }
        }


    }
}
