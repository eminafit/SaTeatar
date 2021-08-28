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
    //sa korisnicke strane
    //kod logina kupca provjeriti da li ima obavijesti koje vaze do tog dana i koje su neprocitane
    //ako ima onda ga obavijesti o tome
    //kad otvori obavijest, oznaciti je kao procitanu

    class ObavijestiViewModel : BaseViewModel
    {
        private readonly APIService _poslaneObavijestiService = new APIService("poslaneObavijesti");
        private readonly APIService _kupciService = new APIService("kupci");
        private static int _idKupca = 0;

        public ObavijestiViewModel()
        {
            OznaciKaoProcitanoCommand = new Command( () =>  OznaciKaoProcitano());
        }

        public ObservableCollection<mPoslaneObavijesti> NoveObavijestiList { get; set; } = new ObservableCollection<mPoslaneObavijesti>();
        public ObservableCollection<mPoslaneObavijesti> StareObavijestiList { get; set; } = new ObservableCollection<mPoslaneObavijesti>();

        public ICommand OznaciKaoProcitanoCommand { get; set; }

        bool _vidljivo = false;
        public bool Vidljivo
        {
            get { return _vidljivo; }
            set { SetProperty(ref _vidljivo, value); }
        }

        private async void OznaciKaoProcitano()
        {
            foreach (var item in NoveObavijestiList)
            {
                item.Procitano = true;
                await _poslaneObavijestiService.Update<mPoslaneObavijesti>(item.PoslanaObavijestId, item);
            }
            await PopuniListe();
        }

        private async Task PopuniListe()
        {
            NoveObavijestiList.Clear();
            StareObavijestiList.Clear();

            _idKupca = PrijavljeniKupac.Kupac.KupacId;

            var searchPoslaneObavijesti = new rPoslaneObavijestiSearch() { KupacId = _idKupca };
            List<mPoslaneObavijesti> poslaneObavijesti = await _poslaneObavijestiService.Get<List<mPoslaneObavijesti>>(searchPoslaneObavijesti);

            int brojac = 0;

            foreach (var poslanaObavijest in poslaneObavijesti)
            {
                if (DateTime.Compare(DateTime.Now, poslanaObavijest.DatumVazenja) <= 0 && !poslanaObavijest.Procitano)
                {
                    NoveObavijestiList.Add(poslanaObavijest);
                    brojac++;
                }
                else
                {
                    StareObavijestiList.Add(poslanaObavijest);
                }
            }

            if (brojac > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Obavijest", $"Imate nove obavijesti! ({brojac})", "OK");
                Vidljivo = true;
            }
            else
                Vidljivo = false;
        }
        public async Task Init()
        {
            await PopuniListe();
        }
    }
}
