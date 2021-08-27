using QRCoder;
using SaTeatar.Mobile.Helpers;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class KarteViewModel : BaseViewModel
    {
        private readonly APIService _karteService = new APIService("karte");
        private int kupacId = 0;
        private List<mKarta> ListmKarti = new List<mKarta>();

        public KarteViewModel()
        {
            SortIzvodjenjaCommand = new Command(() => SortIzvodjenje());
            SortKupovinaCommand = new Command(() => SortKupovina());
        }
        public ObservableCollection<mKarta> ListaKarata { get; set; } = new ObservableCollection<mKarta>();

        public int _broj = 0;
        public int Broj
        {
            get { return _broj; }
            set { SetProperty(ref _broj, value); }
        }

        bool _izvodjenjeTF = true;
        public bool IzvodjenjeTF
        {
            get { return _izvodjenjeTF; }
            set { SetProperty(ref _izvodjenjeTF, value); }
        }

        public ICommand SortKupovinaCommand { get; set; }
        public ICommand SortIzvodjenjaCommand { get; set; }

        public async void SortKupovina()
        {
            IsBusy = false;
            IzvodjenjeTF = true;
            await InitKarte();
            ListmKarti.Sort((y, x) => x.KartaId.CompareTo(y.KartaId));

            ListaKarata.Clear();

            foreach (var item in ListmKarti)
            {
                ListaKarata.Add(item);
            }

        }

        public async void SortIzvodjenje()
        {
            IsBusy = true;
            IzvodjenjeTF = false;
            await InitKarte();

            ListmKarti.Sort((x, y) => x.DatumIzvodjenja.CompareTo(y.DatumIzvodjenja));

            ListaKarata.Clear();

            foreach (var item in ListmKarti)
            {
                ListaKarata.Add(item);
            }
        }

        public async Task InitKarte()
        {

            kupacId = PrijavljeniKupac.Kupac.KupacId;

            var searchkarte = new rKartaSearch() { KupacId = kupacId, Placeno = true };
            ListmKarti = await _karteService.Get<List<mKarta>>(searchkarte);
        }

        public async void Init()
        {

            await InitKarte();

            SortKupovina();
            
            ListaKarata.Clear();

            foreach (var item in ListmKarti)
            {
                ListaKarata.Add(item);
            }
            
            Broj = ListaKarata.Count;
        }

    }
}
