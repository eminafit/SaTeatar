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
    class PostavkaObavijestiViewModel : BaseViewModel
    {
        private readonly APIService _tipoviPredstavaService = new APIService("tipoviPredstava");
        private readonly APIService _PostavkeObavijestiService = new APIService("PostavkeObavijesti");
        private readonly APIService _kupciService = new APIService("kupci");
        private static int _idKupca=0;
        
        public PostavkaObavijestiViewModel()
        {
            PostaviObavijestiCommand = new Command(() => PostaviObavijesti());
            UkloniSveObavijestiCommand = new Command(async() => await UkloniSveObavijesti());
        }
        public ObservableCollection<mTipoviPredstava> ListaTipovaPredstava { get; set; } = new ObservableCollection<mTipoviPredstava>();

        public ICommand PostaviObavijestiCommand { get; set; }
        public ICommand InitCommand { get; set; }

        public ICommand UkloniSveObavijestiCommand { get; set; }

        string _uvodniText = string.Empty;
        public string UvodniText
        {
            get { return _uvodniText; }
            set { SetProperty(ref _uvodniText, value); }
        }

        private async void PostaviObavijesti()
        {

            //obrisi stare
            await UkloniSveObavijesti();

            foreach (var item in ListaTipovaPredstava)
            {
                if (item.Checkirano)
                {
                    var po = new rPostavkaObavijestiUpsert()
                    {
                        KupacId = _idKupca,
                        TipPredstaveId = item.TipPredstaveId,
                    };
                    await _PostavkeObavijestiService.Insert<mPostavkeObavijesti>(po);
                }
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task UkloniSveObavijesti()
        {
            var searchPO = new rPostavkaObavijestiSearch() { KupacId = _idKupca };
            List<mPostavkeObavijesti> postavkeObavijesti = await _PostavkeObavijestiService.Get<List<mPostavkeObavijesti>>(searchPO);
            if (postavkeObavijesti.Count > 0)
            {
                foreach (var item in postavkeObavijesti)
                {
                    await _PostavkeObavijestiService.Delete<mPostavkeObavijesti>(item.PostavkaObavijestiId);
                }
            }
        }

        public async Task Init()
        {
            IsBusy = false;
            var search = new rKupciSearch() { KorisnickoIme = APIService.Username };
            var kupci = await _kupciService.Get<List<mKupci>>(search);
            var idKupca = kupci[0].KupacId;
            _idKupca = idKupca;

            var searchPO = new rPostavkaObavijestiSearch() { KupacId = idKupca };
            List<mPostavkeObavijesti> postavkeObavijesti = await _PostavkeObavijestiService.Get<List<mPostavkeObavijesti>>(searchPO);
            if (postavkeObavijesti.Count > 0)
            {             
                UvodniText = "ODABRALI STE DA PRIMATE OBAVIJESTI ZA TIPOVE PREDSTAVA \n\n";

                foreach (var item in postavkeObavijesti)
                {                    
                    UvodniText += " - " + item.TipPredstaveNaziv.ToUpper() + " \n";
                }
                IsBusy = true;
            }
            else
            {
                UvodniText = "Niste postavili obavijesti\n\n".ToUpper();
                IsBusy = false;
            }

            var tipoviPredstava = await _tipoviPredstavaService.Get<List<mTipoviPredstava>>(null);

            ListaTipovaPredstava.Clear();
            foreach (var item in tipoviPredstava)
            {
                item.Naziv=item.Naziv.ToUpper();
                ListaTipovaPredstava.Add(item);
            }
        }

    }
}
