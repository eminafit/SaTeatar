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
    //kupac treba
    //imati mogucnost da ocijeni samo onu predstavu koju je gledao (kupio kartu)
    //imati mogucnost da izmijeni postojecu ocjenu
    public class OcjeneViewModel : BaseViewModel
    {
        private readonly APIService _predstaveService = new APIService("predstava");
        private readonly APIService _ocjeneService = new APIService("ocjene");
        private readonly APIService _kupciService = new APIService("kupci");
        private readonly APIService _karteService = new APIService("karte");
        static int _idKupca { get; set; } = 0;
        static int _idOcjene { get; set; } = 0;
        bool _ocjenjeno = false;

        public OcjeneViewModel()
        {
            OcijeniCommand = new Command(async () => await Ocijeni());
            InitCommand = new Command(async () => await Init());
        }

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
            if (Ocjena < 1 || Ocjena > 5)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Ocjena moze biti samo u rasponu od 1 do 5", "Pokusajte opet");
                return;
            }

            if (!_ocjenjeno)
            {
                var ocjena = new rOcjeneInsert();
                if (SelectedPredstava != null && Ocjena != 0)
                {
                    ocjena.KupacId = _idKupca;
                    ocjena.PredstavaId = SelectedPredstava.PredstavaId;
                    ocjena.Ocjena = Ocjena;
                    ocjena.Opis = OpisOcjene;
                    ocjena.Datum = DateTime.Now;
                }

                await _ocjeneService.Insert<mOcjene>(ocjena);
            }
            else
            {
                var ocjena = new rOcjeneUpdate();
                if (SelectedPredstava != null && Ocjena != 0)
                {
                    ocjena.OcjenaId = _idOcjene;
                    ocjena.KupacId = _idKupca;
                    ocjena.PredstavaId = SelectedPredstava.PredstavaId;
                    ocjena.Ocjena = Ocjena;
                    ocjena.Opis = OpisOcjene;
                    ocjena.Datum = DateTime.Now;
                }

                await _ocjeneService.Update<mOcjene>(_idOcjene, ocjena);
            }
        }

        public async Task Init()
        {
            //kupac.. nesretno rjesenje..
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
                    _ocjenjeno = true;
                    _idOcjene = ocjene[0].OcjenaId;
                    OpisOcjene = ocjene[0].Opis;
                }
                else
                {
                    Ocjena = 0;
                    OpisOcjene = string.Empty;
                    _ocjenjeno = false;
                    _idOcjene = 0;
                }
            }   
        }
    }
}
