using SaTeatar.Mobile.Helpers;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SaTeatar.Mobile.ViewModels
{
    public class HistorijaNarudzbiViewModel : BaseViewModel
    {
        private readonly APIService _narudzbaService = new APIService("narudzba");

        public HistorijaNarudzbiViewModel()
        {

        }

        public class XNaruzba
        {
            public int NarudzbaId { get; set; }
            public int KupacId { get; set; }
            public string BrojNarudzbe { get; set; }
            public DateTime Datum { get; set; }
            public string DatumStr { get; set; }
            public decimal Iznos { get; set; }
            public string PaymentId { get; set; }
            public string PlacenoText { get; set; } = "IZVRSITE PLACANJE";
            public bool PlacenoTF { get; set; } = true;

        }

        public ObservableCollection<XNaruzba> ListaNarudzbi { get; set; } = new ObservableCollection<XNaruzba>();

        string _placeno = string.Empty;
        public string Placeno
        {
            get { return _placeno; }
            set { SetProperty(ref _placeno, value); }
        }

        int _broj = 0;
        public int brojNarudzbi
        {
            get { return _broj; }
            set { SetProperty(ref _broj, value); }
        }

        int _brojne = 0;
        public int brojNeplacenih
        {
            get { return _brojne; }
            set { SetProperty(ref _brojne, value); }
        }

        int _brojpl = 0;
        public int brojPlacenih
        {
            get { return _brojpl; }
            set { SetProperty(ref _brojpl, value); }
        }

        public async void Init()
        {
            var kupac = PrijavljeniKupac.Kupac;
            var search = new rNarudzbaSearch() { KupacId = kupac.KupacId };

            var lnar = await _narudzbaService.Get<List<mNarudzba>>(search);
            lnar.Sort(( y,x) => x.Datum.CompareTo(y.Datum));

            ListaNarudzbi.Clear();
            brojNarudzbi = 0;
            brojNeplacenih = 0;
            brojPlacenih = 0;

            if (lnar.Count>0)
            {
                foreach (var item in lnar)
                {
                    ListaNarudzbi.Add(new XNaruzba()
                    {
                        NarudzbaId = item.NarudzbaId,
                        KupacId = item.KupacId,
                        BrojNarudzbe = item.BrNarudzbe.ToString(),
                        Datum = item.Datum,
                        DatumStr = item.Datum.ToString("dd.MM.yyyy.") + " u " + item.Datum.ToString("HH:mm")+"h",
                        Iznos=item.Iznos,
                        PaymentId=item.PaymentId,
                    });

                }

                foreach (var item in ListaNarudzbi)
                {
                    if (!string.IsNullOrWhiteSpace(item.PaymentId))
                    {
                        item.PlacenoTF = false;
                        item.PlacenoText = "PLACENO";
                        brojPlacenih++;
                    }
                }
            }



            brojNarudzbi = ListaNarudzbi.Count;
            brojNeplacenih = brojNarudzbi - brojPlacenih;
        }

    }
}
