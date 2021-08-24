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
            await Navigation.PopToRootAsync();
            await model.Init();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NarudzbaPage());

        }

    }
}