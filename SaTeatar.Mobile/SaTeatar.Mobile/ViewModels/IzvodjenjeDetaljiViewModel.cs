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
    public class IzvodjenjeDetaljiViewModel : BaseViewModel
    {
        private readonly APIService _zoneService = new APIService("zone");
        private readonly APIService _izvodjenjaZoneService = new APIService("izvodjenjaZone");

        public IzvodjenjeDetaljiViewModel()
        {
            PovecajKolicinuCommand = new Command(() => { Kolicina += 1; UkupnaCijena = Cijena * Kolicina; });
            SmanjiKolicinuCommand = new Command(() =>
            {
                if (Kolicina>0)
                {
                    Kolicina -= 1;
                    UkupnaCijena = Cijena * Kolicina;
                }
                else
                {
                    Kolicina = 0;
                    UkupnaCijena = 0;
                }
            });
            NaruciCommand = new Command(() => Naruci());
            InitCommand = new Command(async() => await Init());
        }
        public mIzvodjenja Izvodjenje { get; set; }
        public mIzvodjenjaZone IzvodjenjeZone { get; set; }
        public mZone Zone { get; set; }

        int _kolicina = 0;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }

        decimal _cijena = 0;
        public decimal Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }

        decimal _popust = 0;
        public decimal Popust
        {
            get { return _popust; }
            set { SetProperty(ref _popust, value); }
        }

        decimal _ukupnaCijena = 0;
        public decimal UkupnaCijena
        {
            get { return _ukupnaCijena; }
            set { SetProperty(ref _ukupnaCijena, value); }
        }

        public ObservableCollection<mZone> ZoneList { get; set; } = new ObservableCollection<mZone>();
        public ObservableCollection<mIzvodjenjaZone> IzvodjenjaZoneList { get; set; } = new ObservableCollection<mIzvodjenjaZone>();

        mZone _selectedZona = null;
        public mZone SelectedZona
        {
            get { return _selectedZona; }
            set
            {
                SetProperty(ref _selectedZona, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand PovecajKolicinuCommand { get; set; }
        public ICommand SmanjiKolicinuCommand { get; set; }
        
        public ICommand NaruciCommand { get; set; }
        public ICommand InitCommand { get; set; }

        private void Naruci()
        {
            if (CartService.Cart.ContainsKey(Izvodjenje.IzvodjenjeId))
            {
                CartService.Cart.Remove(Izvodjenje.IzvodjenjeId);
            }

            CartService.Cart.Add(Izvodjenje.IzvodjenjeId, this);            
        }

        public async Task Init()
        {
            if (ZoneList.Count == 0)
            {
                var search = new rZoneSearch() { PozoristeId = Izvodjenje.PozoristeId };
                var zlist = await _zoneService.Get<IEnumerable<mZone>>(search);

                foreach (var z in zlist)
                {
                    ZoneList.Add(z);
                }
            }

            if (SelectedZona != null)
            {
                var search = new rIzvodjenjaZoneSearch();
                search.ZonaId = SelectedZona.ZonaId;
                search.IzvodjenjeId = Izvodjenje.IzvodjenjeId;

                var ilist = await _izvodjenjaZoneService.Get<IEnumerable<mIzvodjenjaZone>>(search);

                IzvodjenjaZoneList.Clear(); //pozivace se vise puta?
                Cijena = 0;
                Popust = 0;
                foreach (var i in ilist)
                {
                    IzvodjenjaZoneList.Add(i);
                }
                if (IzvodjenjaZoneList[0].Popust!=null)
                {
                    Popust = (decimal)IzvodjenjaZoneList[0].Popust;
                    Cijena = IzvodjenjaZoneList[0].Cijena * Popust/100; ////sredi popust
                }
                else
                {
                    Cijena = IzvodjenjaZoneList[0].Cijena;
                }

            }
        }

    }
}
