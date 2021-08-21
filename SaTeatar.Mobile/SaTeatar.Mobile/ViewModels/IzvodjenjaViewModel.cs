using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class IzvodjenjaViewModel : BaseViewModel
    {
        private readonly APIService _izvodjenjaService = new APIService("izvodjenja");
        private readonly APIService _tipoviPredstavaService = new APIService("tipoviPredstava");
        private readonly APIService _predstavaService = new APIService("Predstava");
        
        public IzvodjenjaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<mIzvodjenja> IzvodjenjaList { get; set; } = new ObservableCollection<mIzvodjenja>();
        public ObservableCollection<mTipoviPredstava> TipoviPredstavaList { get; set; } = new ObservableCollection<mTipoviPredstava>();
        public ObservableCollection<mPredstave> PredstavaList { get; set; } = new ObservableCollection<mPredstave>();

        //tip predstave
        mTipoviPredstava _selectedTipProizvoda =null ;
        public mTipoviPredstava SelectedTipProizvoda
        {
            get { return _selectedTipProizvoda; }
            set 
            { 
                SetProperty(ref _selectedTipProizvoda, value);
                if (value!=null)
                {
                    SelectedDan = DateTime.MinValue;
                    SelectedPredstava = null;
                    InitCommand.Execute(null);
                }
            }
        }

        //predstave
        mPredstave _selectedPredstava = null;
        public mPredstave SelectedPredstava
        {
            get { return _selectedPredstava; }
            set
            {
                SetProperty(ref _selectedPredstava, value);
                if (value != null)
                {
                    SelectedDan = DateTime.MinValue;
                    SelectedTipProizvoda = null;
                    InitCommand.Execute(null);
                }
            }
        }

        //po danu
        DateTime _dan = DateTime.MinValue;
        public DateTime SelectedDan
        {
            get { return _dan; }
            set
            {
                SetProperty(ref _dan, value);
                if (value != DateTime.MinValue)
                {
                    SelectedTipProizvoda = null;
                    SelectedPredstava = null;
                    InitCommand.Execute(null);
                }
            }
        }

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

        public async Task PPPretraga()
        {
            if (SelectedPredstava != null)
            {
                IzvodjenjaList.Clear();
                var search = new rIzvodjenjaSearch();
                search.PredstavaId = SelectedPredstava.PredstavaId;
                search.DatumVrijeme = DateTime.Now;

                await Pretrazi(search);

            }
        }

        public async Task Init()
        {
            IsBusy = false;

            if (TipoviPredstavaList.Count==0)
            {
                var tplist = await _tipoviPredstavaService.Get<IEnumerable<mTipoviPredstava>>(null);

                foreach (var tp in tplist)
                {
                    TipoviPredstavaList.Add(tp);
                }
            }

            if (PredstavaList.Count == 0)
            {
                var tplist = await _predstavaService.Get<List<mPredstave>>(null);

                foreach (var tp in tplist)
                {
                    PredstavaList.Add(tp);
                }
            }


            if (SelectedTipProizvoda != null)
            {

                IzvodjenjaList.Clear();
                var search = new rIzvodjenjaSearch();
                search.TipPredstaveId = SelectedTipProizvoda.TipPredstaveId;
                search.DatumVrijeme = DateTime.Now;

                await Pretrazi(search);
            }

            if (SelectedPredstava != null)
            {
                IzvodjenjaList.Clear();
                var search = new rIzvodjenjaSearch();
                search.PredstavaId = SelectedPredstava.PredstavaId;
                search.DatumVrijeme = DateTime.Now;

                await Pretrazi(search);
            }

            if (SelectedDan.CompareTo(DateTime.MinValue)>0)
            {
                IzvodjenjaList.Clear();
                var search = new rIzvodjenjaSearch();
                search.NaDatum = SelectedDan;

                await Pretrazi(search);
            }
        }
    }
}
