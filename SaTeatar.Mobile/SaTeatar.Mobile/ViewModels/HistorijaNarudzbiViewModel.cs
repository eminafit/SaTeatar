using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SaTeatar.Mobile.ViewModels
{
    public class HistorijaNarudzbiViewModel : BaseViewModel
    {
        private readonly APIService _karteService = new APIService("karte");
        private readonly APIService _kupciService = new APIService("kupci");

        public ObservableCollection<mKarta> ListaKarata { get; set; } = new ObservableCollection<mKarta>();

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
            }
        }
    }
}
