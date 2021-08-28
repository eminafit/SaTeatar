using SaTeatar.Mobile.Helpers;
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
        int _idKupca = 0;
        static int _idOcjene { get; set; } = 0;
        bool _ocjenjeno = false;

        public OcjeneViewModel()
        {
            OcijeniCommand = new Command(async () => await Ocijeni());
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<mPredstave> predstaveList { get; set; } = new ObservableCollection<mPredstave>();
        public ObservableCollection<mOcjene> OcjeneList { get; set; } = new ObservableCollection<mOcjene>();

        public mPredstave Predstava { get; set; }

        public mOcjene Ocjena { get; set; }

        int _ocjena = 0;
        public int OcjenaBr
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

        string _predstavaNaziv = string.Empty;
        public string PredstavaNaziv
        {
            get { return _predstavaNaziv; }
            set { SetProperty(ref _predstavaNaziv, value); }
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
            if (OcjenaBr < 1 || OcjenaBr > 5)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Ocjena moze biti samo u rasponu od 1 do 5", "Pokusajte opet");
                return;
            }

            if (SelectedPredstava != null && Ocjena == null)
            {
                var ocjenaInsert = new rOcjeneInsert();

                ocjenaInsert.Ocjena = OcjenaBr;
                ocjenaInsert.KupacId = _idKupca;
                ocjenaInsert.Datum = DateTime.Now;
                if (OpisOcjene != null)
                    ocjenaInsert.Opis = OpisOcjene;
                else
                    ocjenaInsert.Opis = string.Empty;
                ocjenaInsert.PredstavaId = SelectedPredstava.PredstavaId;


                await _ocjeneService.Insert<mOcjene>(ocjenaInsert);
                await App.Current.MainPage.Navigation.PopAsync();

                return;
            }

            if (Ocjena.OcjenaId==0)
            {
                var ocjenaInsert = new rOcjeneInsert();

                ocjenaInsert.Ocjena = OcjenaBr;
                ocjenaInsert.KupacId = _idKupca;
                ocjenaInsert.Datum = DateTime.Now;
                if (OpisOcjene!=null)
                    ocjenaInsert.Opis = OpisOcjene;
                else
                    ocjenaInsert.Opis = string.Empty;
                ocjenaInsert.PredstavaId = Ocjena.PredstavaId;
                

                await _ocjeneService.Insert<mOcjene>(ocjenaInsert);
                await App.Current.MainPage.Navigation.PopAsync();

                return;
            }
            else
            {
                var ocjenaUpdate = new rOcjeneUpdate();

                ocjenaUpdate.KupacId = Ocjena.KupacId;
                ocjenaUpdate.Datum = DateTime.Now;
                ocjenaUpdate.Ocjena = OcjenaBr;
                ocjenaUpdate.OcjenaId = Ocjena.OcjenaId;
                if (OpisOcjene != null)
                    ocjenaUpdate.Opis = OpisOcjene;
                else
                    ocjenaUpdate.Opis = string.Empty; 
                ocjenaUpdate.PredstavaId = Ocjena.PredstavaId;
                
                await _ocjeneService.Update<mOcjene>(Ocjena.OcjenaId, ocjenaUpdate);
                await App.Current.MainPage.Navigation.PopAsync();

                return;
            }


            //if (!_ocjenjeno)
            //{
            //    var ocjena = new rOcjeneInsert();
            //    if (SelectedPredstava != null && Ocjena != 0)
            //    {
            //        ocjena.KupacId = _idKupca;
            //        ocjena.PredstavaId = SelectedPredstava.PredstavaId;
            //        ocjena.Ocjena = Ocjena;
            //        ocjena.Opis = OpisOcjene;
            //        ocjena.Datum = DateTime.Now;
            //    }

            //    await _ocjeneService.Insert<mOcjene>(ocjena);
            //}
            //else
            //{
            //    var ocjena = new rOcjeneUpdate();


            //    await _ocjeneService.Update<mOcjene>(_idOcjene, ocjena);
            //}
        }

        public async Task Init()
        {
            _idKupca = PrijavljeniKupac.Kupac.KupacId;
            OcjeneList.Clear();
            var searchOcjene = new rOcjeneSearch { KupacId = _idKupca };
            var sveocjene = await _ocjeneService.Get<List<mOcjene>>(searchOcjene);
            sveocjene.Sort((y, x) => x.Ocjena.CompareTo(y.Ocjena));
            foreach (var item in sveocjene)
            {
                OcjeneList.Add(item);

                if (Ocjena != null)
                {
                    if (item.PredstavaId == Ocjena.PredstavaId)
                    {
                        Ocjena = item;
                    }
                }
            }

            if (Ocjena!=null)
            {
                if (Ocjena.OcjenaId!=0 || Ocjena.PredstavaId!=0)
                {
                    OcjenaBr = Ocjena.Ocjena;
                    PredstavaNaziv = Ocjena.PredstavaNaziv;
                    OpisOcjene = Ocjena.Opis;
                }

            }

            if (predstaveList.Count == 0)
            {
                //neocjenjene
                // karte -> izvodjenje -> predstava (vise, jer moze kupiti vise karti)
                var search = new rOcjeneSearch() { KupacId = _idKupca };
                var ocjenep = await _ocjeneService.Get<List<mOcjene>>(search);
                var ocjenjenePredstaveIds = ocjenep.Select(x => x.PredstavaId);

                //var searchKarte = new rKartaSearch() { KupacId = _idKupca, Placeno = true };
                //List<mKarta> karte = await _karteService.Get<List<mKarta>>(searchKarte); //dobijem i predstaveid
                //var pregledanePredstaveIds = karte.Select(x => x.PredstavaId).Distinct();

                var predstave = await _predstaveService.Get<List<mPredstave>>(null);

                foreach (var item in predstave)
                {
                    if (!ocjenjenePredstaveIds.Contains(item.PredstavaId))
                    {
                        predstaveList.Add(item);
                    }
                }
            }

            //if (SelectedPredstava != null)
            //{
            //    var search = new rOcjeneSearch() { PredstavaId = SelectedPredstava.PredstavaId, KupacId = _idKupca };
            //    var ocjene = await _ocjeneService.Get<List<mOcjene>>(search);
            //    if (ocjene.Count > 0)
            //    {
            //        Ocjena = ocjene[0].Ocjena;
            //        _ocjenjeno = true;
            //        _idOcjene = ocjene[0].OcjenaId;
            //        OpisOcjene = ocjene[0].Opis;
            //    }
            //    else
            //    {
            //        Ocjena = 0;
            //        OpisOcjene = string.Empty;
            //        _ocjenjeno = false;
            //        _idOcjene = 0;
            //    }
            //}
        }
    }
}
