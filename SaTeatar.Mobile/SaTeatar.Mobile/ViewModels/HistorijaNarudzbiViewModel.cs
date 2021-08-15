using QRCoder;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class HistorijaNarudzbiViewModel : BaseViewModel
    {
        private readonly APIService _karteService = new APIService("karte");
        private readonly APIService _kupciService = new APIService("kupci");

        public ObservableCollection<mKarta> ListaKarata { get; set; } = new ObservableCollection<mKarta>();

        public class KarteVMQCode
        {
            public string Sifra { get; set; }

          //  public bool Placeno { get; set; }
            public string PredstavaNaziv { get; set; }
            public string PozoristeNaziv { get; set; }
            public string ZonaNaziv { get; set; }
            public decimal Cijena { get; set; }
            public ImageSource QrCodeImage { get; set; }
        }

        public ObservableCollection<KarteVMQCode> KarteVMQCodeLista { get; set; } = new ObservableCollection<KarteVMQCode>();


        //ImageSource _qrCodeImage;
        //public ImageSource QrCodeImage
        //{
        //    get => _qrCodeImage;
        //    set => SetProperty(ref _qrCodeImage, value);
        //}
        //public ObservableCollection<QRKod> QRCodeLista { get; set; } = new ObservableCollection<QRKod>();

        public async void Init()
        {
            var searchkupac = new rKupciSearch() { KorisnickoIme = APIService.Username };
            List<mKupci> kupci = await _kupciService.Get<List<mKupci>>(searchkupac);
            var kupacId = kupci[0].KupacId;

            var searchkarte = new rKartaSearch() { KupacId = kupacId };
            var karte = await _karteService.Get<List<mKarta>>(searchkarte);


            foreach (var item in karte)
            {
                 ListaKarata.Add(item);
                // QRCodeLista.Add(new QRKod() { QrCodeImage = Convert(item.Sifra) });
               
                KarteVMQCodeLista.Add(new KarteVMQCode()
                {
                    Sifra = item.Sifra,
                    Cijena=item.Cijena,
                    PozoristeNaziv=item.PozoristeNaziv,
                    PredstavaNaziv=item.PredstavaNaziv,
                    ZonaNaziv=item.ZonaNaziv,
                    QrCodeImage= ImageSource.FromStream(() => new MemoryStream(item.Qrcode))
                });

            }

            //var karte = await _karteService.Get<List<mKarta>>(null);

            //foreach (var item in karte)
            //{
            //    item.Qrcode = popuni(item.Sifra);
            //    await _karteService.Update<mKarta>(item.KartaId, item);
            //}

        }


        //byte[] popuni (string InputText)
        //{
        //    if (string.IsNullOrEmpty(InputText))
        //        InputText = "";

        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.M);
        //    PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
        //    //byte[] qrCodeBytes = qRCode.GetGraphic(20);
        //    return qRCode.GetGraphic(20);
        //    //QrCodeImage = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        //    //return ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));

        //}


        ImageSource Convert(string InputText)
        {
            if (string.IsNullOrEmpty(InputText))
                InputText = "";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, QRCodeGenerator.ECCLevel.M);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            //QrCodeImage = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            return ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));

        }
    }
}
