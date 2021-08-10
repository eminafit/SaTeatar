using SaTeatar.Mobile.ViewModels;
using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaTeatar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IzvodjenjaDetaljiPage : ContentPage
    {
        private IzvodjenjeDetaljiViewModel model = null;
        private mIzvodjenja _izvodjenje = null;
        public IzvodjenjaDetaljiPage(mIzvodjenja izvodjenje)
        {
            InitializeComponent();
            BindingContext = model = new IzvodjenjeDetaljiViewModel()
            {
                Izvodjenje = izvodjenje
            };
            _izvodjenje = izvodjenje;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NarudzbaPage());
        }

        //private void Picker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //}

        //private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var novimodel = new IzvodjenjeDetaljiViewModel()
        //    {
        //        Izvodjenje = new mIzvodjenja()
        //        {
        //            IzvodjenjeId = _izvodjenje.IzvodjenjeId,
        //            PozoristeId = _izvodjenje.PozoristeId,
        //            PredstavaId = _izvodjenje.PredstavaId,
        //            PozoristeNaziv = _izvodjenje.PozoristeNaziv,
        //            PredstavaNaziv = _izvodjenje.PredstavaNaziv
        //        },
        //        IzvodjenjeZone = new mIzvodjenjaZone()

        //    };
        //    await novimodel.Init();

        //    novimodel.PromjenaZone();

        //}
    }
}