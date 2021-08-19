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
    class PreporucenePredstaveViewModel : BaseViewModel
    {
        private readonly APIService _kupciService = new APIService("kupci");
        private readonly APIService _predstaveService = new APIService("predstava");

        public PreporucenePredstaveViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<mPredstave> PreporucenePredstave { get; set; } = new ObservableCollection<mPredstave>();

        public ICommand InitCommand { get; set; }


        bool _nemaPredstava = false;
        public bool NemaPredstava
        {
            get { return _nemaPredstava; }
            set { SetProperty(ref _nemaPredstava, value); }
        }

        string _poruka = string.Empty;
        public string Poruka
        {
            get { return _poruka; }
            set { SetProperty(ref _poruka, value); }
        }

        public async Task Init()
        {
            NemaPredstava = true;
            var search = new rKupciSearch() { KorisnickoIme = APIService.Username };
            var kupci = await _kupciService.Get<List<mKupci>>(search);
            var idkupca = kupci[0].KupacId;

            List<mPredstave> predstave = await _predstaveService.Recommend<List<mPredstave>>(idkupca);

            if (predstave.Count>0)
            {
                NemaPredstava = false;
                foreach (var item in predstave)
                {
                    PreporucenePredstave.Add(item);
                }
            }
            else
            {
                Poruka = "Niste ocijenili dovoljno predstava da bi vam mogli dati preporuke koje predstave da pogledate.";
            }



        }

    }
}
