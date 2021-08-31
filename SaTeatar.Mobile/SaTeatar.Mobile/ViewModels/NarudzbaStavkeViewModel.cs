using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static SaTeatar.Mobile.ViewModels.HistorijaNarudzbiViewModel;

namespace SaTeatar.Mobile.ViewModels
{
    public class NarudzbaStavkeViewModel : BaseViewModel
    {

        private readonly APIService _narudzbaStavkeService = new APIService("narudzbaStavke");
        private readonly APIService _karteService = new APIService("karte");

        public NarudzbaStavkeViewModel()
        {
        }
        public ObservableCollection<mKarta> KarteList { get; set; } = new ObservableCollection<mKarta>();

        public XNaruzba Narudzba { get; set; }

        public int _broj = 0;
        public int Broj
        {
            get { return _broj; }
            set { SetProperty(ref _broj, value); }
        }

        public ICommand InitCommand { get; set; }

        public async void Init()
        {
            var search = new rNarudzbaStavkeSearch() { NarudzbaId = Narudzba.NarudzbaId };
            var nslist = await _narudzbaStavkeService.Get<List<mNarudzbaStavke>>(search);

            foreach (var item in nslist)
            {
                var karta = await _karteService.GetById<mKarta>(item.KartaId);
                KarteList.Add(karta);                   
            }

            
            Broj = KarteList.Count;
        }

    }
}
