using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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

        public ObservableCollection<mPoslaneObavijesti> PoslaneObavijestiList { get; set; } = new ObservableCollection<mPoslaneObavijesti>();
        public async Task Init()
        {
            var searchKupac = new rKupciSearch() { KorisnickoIme = APIService.Username };
            var kupci = await _kupciService.Get<List<mKupci>>(searchKupac);
            _idKupca = kupci[0].KupacId;

            var searchPoslaneObavijesti = new rPoslaneObavijestiSearch() { KupacId = _idKupca };
            List<mPoslaneObavijesti> poslaneObavijesti = await _poslaneObavijestiService.Get<List<mPoslaneObavijesti>>(searchPoslaneObavijesti);

            foreach (var poslanaObavijest in poslaneObavijesti)
            {
                if (DateTime.Compare(DateTime.Now,poslanaObavijest.DatumVazenja)<=0 && !poslanaObavijest.Procitano)
                {
                    await Application.Current.MainPage.DisplayAlert("Obavijest", poslanaObavijest.Poruka, "OK");
                    
                }
            }
        }
    }
}
