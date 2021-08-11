using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class OcjeneViewModel : BaseViewModel
    {
        private readonly APIService _predstaveService = new APIService("predstava");
        private readonly APIService _ocjeneService = new APIService("ocjene");
        private readonly APIService _kupciService = new APIService("kupci");
        private readonly APIService _karteService = new APIService("karte");
        static int _idKupca { get; set; } = 0;
        public OcjeneViewModel()
        {
            OcijeniCommand = new Command(async () => await Ocijeni());
            InitCommand = new Command(async () => await Init());
        }

        //kupac treba izabrati predstavu koju je gledao (kupio kartu)
        //imati mogucnost da je ocijeni
        //imati mogucnost da izmijeni postojecu ocjenu

        //ocjene inace treba dodati u pregled predstava.. za sad imam izvodjenja i preporucene predstave..

        public ObservableCollection<mPredstave> pregledanePredstaveList { get; set; } = new ObservableCollection<mPredstave>();

        int _ocjena = 0;
        public int Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }

        string _opisOcjene = string.Empty;
        public string OpisOcjene
        {
            get { return _opisOcjene; }
            set { SetProperty(ref _opisOcjene, value); }
        }

        mPredstave _selectedPredstava = null;
        public mPredstave SelectedPredstava
        {
            get { return _selectedPredstava; }
            set { 
                SetProperty(ref _selectedPredstava, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand OcijeniCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private async Task Ocijeni()
        {
            var ocjena = new rOcjeneInsert();
            if (SelectedPredstava!=null && Ocjena!=0) 
            {
                ocjena.KupacId = _idKupca;
                ocjena.PredstavaId = SelectedPredstava.PredstavaId;
                ocjena.Ocjena = Ocjena;
                ocjena.Opis = OpisOcjene;
                ocjena.Datum = DateTime.Now;
            }

            await _ocjeneService.Insert<mOcjene>(ocjena);

            ////////////// nisi zavrsila, treba editovati ako vec ima ocjenu
        }

        public async Task Init()
        {

            //kupac
            if (_idKupca==0)
            {
                var search = new rKupciSearch() { KorisnickoIme = APIService.Username };
                var kupci = await _kupciService.Get<List<mKupci>>(search);
                _idKupca = kupci[0].KupacId;
            }

            if (pregledanePredstaveList.Count == 0)
            {
                // karte -> izvodjenje -> predstava (vise, jer moze kupiti vise karti)
                var searchKarte = new rKartaSearch() { KupacId = _idKupca };
                List<mKarta> karte = await _karteService.Get<List<mKarta>>(searchKarte); //dobijem i predstaveid
                var pregledanePredstaveIds = karte.Select(x => x.PredstavaId).Distinct();

                var predstave = await _predstaveService.Get<List<mPredstave>>(null);

                foreach (var item in predstave)
                {
                    if (pregledanePredstaveIds.Contains(item.PredstavaId))
                    {
                        pregledanePredstaveList.Add(item);
                    }
                }
            }

            if (SelectedPredstava!=null)
            {
                var search = new rOcjeneSearch() { PredstavaId = SelectedPredstava.PredstavaId, KupacId=_idKupca };
                var ocjene = await _ocjeneService.Get<List<mOcjene>>(search);
                if (ocjene.Count>0)
                {
                    Ocjena = ocjene[0].Ocjena;
                    OpisOcjene = ocjene[0].Opis;
                }
                else
                {
                    Ocjena = 0;
                    OpisOcjene = string.Empty;
                }

            }   
            //var k = pregledanePredstaveList.Count;

            //var search = new rPredstavaSearch() { }
        }

    }
}
