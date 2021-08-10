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
    public class IzvodjenjaViewModel : BaseViewModel
    {
        private readonly APIService _izvodjenjaService = new APIService("izvodjenja");
        private readonly APIService _tipoviPredstavaService = new APIService("tipoviPredstava");
        public IzvodjenjaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<mIzvodjenja> IzvodjenjaList { get; set; } = new ObservableCollection<mIzvodjenja>();
        public ObservableCollection<mTipoviPredstava> TipoviPredstavaList { get; set; } = new ObservableCollection<mTipoviPredstava>();

        mTipoviPredstava _selectedTipProizvoda =null ;
        public mTipoviPredstava SelectedTipProizvoda
        {
            get { return _selectedTipProizvoda; }
            set 
            { 
                SetProperty(ref _selectedTipProizvoda, value);
                if (value!=null)
                {
                  InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (TipoviPredstavaList.Count==0)
            {
                var tplist = await _tipoviPredstavaService.Get<IEnumerable<mTipoviPredstava>>(null);

                foreach (var tp in tplist)
                {
                    TipoviPredstavaList.Add(tp);
                }
            }

            if (SelectedTipProizvoda!=null)
            {
                var search = new rIzvodjenjaSearch();
                search.TipPredstaveId = SelectedTipProizvoda.TipPredstaveId;
                search.naziviZaXamarin = true;
               // search.NaDan = default(DateTime);// new DateTime();
                // var search = new rIzvodjenjaSearch() { naziviZaXamarin = true, NaDan = new DateTime(2021,6,6) };
                var ilist = await _izvodjenjaService.Get<IEnumerable<mIzvodjenja>>(search);

                IzvodjenjaList.Clear(); //pozivace se vise puta?
                foreach (var i in ilist)
                {
                    IzvodjenjaList.Add(i);
                }
            }


        }
    }
}
