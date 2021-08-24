using SaTeatar.Mobile.ViewModels;
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

    class IzvodjenjaPreporucenoViewModel : BaseViewModel
    {
        private readonly APIService _predstavaService = new APIService("Predstava");
        private readonly APIService _izvodjenjaService = new APIService("izvodjenja");

        public IzvodjenjaPreporucenoViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }

        //public ObservableCollection<mPredstave> PredstavaList { get; set; } = new ObservableCollection<mPredstave>();
        public ObservableCollection<mIzvodjenja> IzvodjenjaList { get; set; } = new ObservableCollection<mIzvodjenja>();
        public mPredstave SelectedPredstava { get; set; }


        ////predstave
        //mPredstave _selectedPredstava = null;
        //public mPredstave SelectedPredstava
        //{
        //    get { return _selectedPredstava; }
        //    set
        //    {
        //        SetProperty(ref _selectedPredstava, value);
        //        if (value != null)
        //        {
        //            InitCommand.Execute(null);
        //        }
        //    }
        //}

        public ICommand InitCommand { get; set; }

        private async Task Pretrazi(rIzvodjenjaSearch search)
        {
            List<mIzvodjenja> ilist = await _izvodjenjaService.Get<List<mIzvodjenja>>(search);
            ilist.Sort((x, y) => x.DatumVrijeme.CompareTo(y.DatumVrijeme));
            if (ilist.Count == 0)
            {
                IsBusy = true;
            }

            IzvodjenjaList.Clear(); //pozivace se vise puta?
            foreach (var i in ilist)
            {
                i.Datum = i.DatumVrijeme.ToString("dd.MM.yyyy.");
                i.Vrijeme = i.DatumVrijeme.ToString("HH:mm") + "h";
                IzvodjenjaList.Add(i);
            }
        }

        public async Task Init()
        {
            IsBusy = false;

            //if (PredstavaList.Count == 0)
            //{
            //    var tplist = await _predstavaService.Get<List<mPredstave>>(null);

            //    foreach (var tp in tplist)
            //    {
            //        PredstavaList.Add(tp);
            //    }
            //}

            if (SelectedPredstava != null)
            {
                IzvodjenjaList.Clear();
                var search = new rIzvodjenjaSearch();
                search.PredstavaId = SelectedPredstava.PredstavaId;
                search.DatumVrijeme = DateTime.Now;

                await Pretrazi(search);

            }
        }
    }
}
