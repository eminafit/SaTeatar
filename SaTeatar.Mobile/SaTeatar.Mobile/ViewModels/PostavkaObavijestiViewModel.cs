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
        
        public PostavkaObavijestiViewModel()
        {
            PostaviObavijestiCommand = new Command(() => PostaviObavijesti());
          //  InitCommand = new Command(async() => await Init());
        }
        public ObservableCollection<mTipoviPredstava> ListaTipovaPredstava { get; set; } = new ObservableCollection<mTipoviPredstava>();

        public ICommand PostaviObavijestiCommand { get; set; }
        public ICommand InitCommand { get; set; }

       // public ICommand PostaviObvCommand { get; set; }

        string _uvodniText = string.Empty;
        public string UvodniText
        {
            get { return _uvodniText; }
            set { SetProperty(ref _uvodniText, value); }
        }

        private async void PostaviObavijesti()
        {
            var search = new rKupciSearch() { KorisnickoIme = APIService.Username };
            var kupci = await _kupciService.Get<List<mKupci>>(search);
            var idKupca = kupci[0].KupacId;

            //obrisi stare
            var searchPO = new rPostavkaObavijestiSearch() { KupacId = idKupca };
            List<mPostavkeObavijesti> postavkeObavijesti = await _PostavkeObavijestiService.Get<List<mPostavkeObavijesti>>(searchPO);
            if (postavkeObavijesti.Count>0)
            {
                foreach (var item in postavkeObavijesti)
                {
                    await _PostavkeObavijestiService.Delete<mPostavkeObavijesti>(item.PostavkaObavijestiId);
                }
            }

            foreach (var item in ListaTipovaPredstava)
            {
                if (item.Checkirano)
                {
                    var po = new rPostavkaObavijestiUpsert()
                    {
                        KupacId = idKupca,
                        TipPredstaveId = item.TipPredstaveId,
                    };
                    await _PostavkeObavijestiService.Insert<mPostavkeObavijesti>(po);
                }
            }
        }

        public async Task Init()
        {
            var search = new rKupciSearch() { KorisnickoIme = APIService.Username };
            var kupci = await _kupciService.Get<List<mKupci>>(search);
            var idKupca = kupci[0].KupacId;

            var searchPO = new rPostavkaObavijestiSearch() { KupacId = idKupca };
            List<mPostavkeObavijesti> postavkeObavijesti = await _PostavkeObavijestiService.Get<List<mPostavkeObavijesti>>(searchPO);
            if (postavkeObavijesti.Count > 0)
            {             
                UvodniText = "Odabrali ste da birate obavijesti za tipove predstava: \n";

                foreach (var item in postavkeObavijesti)
                {                    
                    UvodniText += " - " + item.TipPredstaveNaziv + " \n";
                }
                UvodniText += "\nAko zelite izmijeniti postavke obavijesti za odredjene tipove predstava kliknite na dugme 'Postavka obavijesti'.\n\n\n";
            }
            else
            {
                UvodniText = "Niste postavili obavijesti. \n\n Ako zelite primati obavijesti za odredjene tipove predstava kliknite na dugme 'Postavka obavijesti'.\n\n\n";
            }

            var tipoviPredstava = await _tipoviPredstavaService.Get<List<mTipoviPredstava>>(null);

            foreach (var item in tipoviPredstava)
            {
                ListaTipovaPredstava.Add(item);
            }
        }

    }
}
