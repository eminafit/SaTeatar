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
    public class KorpaViewModel : BaseViewModel
    {
        private readonly APIService _karteService = new APIService("karte");
        private readonly APIService _kupciService = new APIService("kupci");
        private readonly APIService _narudzbaService = new APIService("narudzba");
        private readonly APIService _narudzbaStavkeService = new APIService("narudzbaStavke");
        private readonly int _idKupca = PrijavljeniKupac.Kupac.KupacId;


        public KorpaViewModel()
        {
            RezervisiCommand = new Command(async () => await Rezervisi());
            IsprazniKorpuCommand = new Command(() =>
            {
                KorpaList.Clear();
                CartService.Cart.Clear();
                IsBusy = false;
                PraznaKorpa = true;
            });
        }
        public ObservableCollection<IzvodjenjeDetaljiViewModel> KorpaList { get; set; } = new ObservableCollection<IzvodjenjeDetaljiViewModel>();
       
        public mNarudzba Narudzba = new mNarudzba();
        public List<mNarudzbaStavke> NarudzbaStavkeList = new List<mNarudzbaStavke>();
        public List<mKarta> KarteList = new List<mKarta>();

        decimal _ukupniIznos = 0;
        public decimal UkupniIznos
        {
            get { return _ukupniIznos; }
            set { SetProperty(ref _ukupniIznos, value); }
        }
        public ICommand PromijenjenaKolicnaCommand { get; set; }
        public ICommand RezervisiCommand { get; set; }

        public ICommand IsprazniKorpuCommand { get; set; }

        bool _praznaKorpa = false;
        public bool PraznaKorpa
        {
            get { return _praznaKorpa; }
            set { SetProperty(ref _praznaKorpa, value); }
        }

        public void Init()
        {
            KorpaList.Clear();
            if (CartService.Cart.Count>0)
            {
                IsBusy = true;
                PraznaKorpa = false;
                foreach (var cartValue in CartService.Cart.Values)
                {
                    KorpaList.Add(cartValue);
                    UkupniIznos += cartValue.UkupnaCijena;
                }

            }
            else
            {
                IsBusy = false;
                PraznaKorpa = true;
            }
        }

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

        public async Task Rezervisi()
        {
            if (CartService.Cart.Count > 0)
            {

                var narudzbaInsert = new rNarudzbaInsert()
                {
                    BrNarudzbe = Guid.NewGuid(),
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
                            BrKarte =Guid.NewGuid()
                        };
                        karta.Qrcode = GenerisiQrCode(karta.BrKarte.ToString());
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
