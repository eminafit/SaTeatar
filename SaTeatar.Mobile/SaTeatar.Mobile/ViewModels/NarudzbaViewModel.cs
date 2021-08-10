using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    class NarudzbaViewModel : BaseViewModel
    {
        public ObservableCollection<IzvodjenjeDetaljiViewModel> NarudzbaList { get; set; } = new ObservableCollection<IzvodjenjeDetaljiViewModel>();

        public NarudzbaViewModel()
        {
            //PromijenjenaKolicnaCommand = new Command(() => PromijenjenaKolicina());
            RezervisiCommand = new Command(async () => await Rezervisi());
        }

        decimal _ukupniIznos = 0;
        public decimal UkupniIznos
        {
            get { return _ukupniIznos; }
            set { SetProperty(ref _ukupniIznos, value); }
        }

        public void Init()
        {
            NarudzbaList.Clear();

            foreach (var cartValue in CartService.Cart.Values)
            {
                NarudzbaList.Add(cartValue);
                UkupniIznos += cartValue.UkupnaCijena;
            }
        }

        public ICommand PromijenjenaKolicnaCommand { get; set; }
        public ICommand RezervisiCommand { get; set; }

        public void PromijenjenaKolicina()
        {
            UkupniIznos = 0;
            foreach (var cartValue in CartService.Cart.Values)
            {
                UkupniIznos += cartValue.UkupnaCijena;
            }
        }

        async Task Rezervisi()
        {
            //dodaj karte
        }


    }
}
