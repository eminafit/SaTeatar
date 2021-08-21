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
    public partial class IzvodjenjaPreporucenoPage : ContentPage
    {
        private IzvodjenjaPreporucenoViewModel model = null;

        private mPredstave _predstava = null;

        public IzvodjenjaPreporucenoPage(mPredstave predstava)
        {
            InitializeComponent();
            _predstava = predstava;
            if (_predstava != null)
            {
                BindingContext = model = new IzvodjenjaPreporucenoViewModel()
                {
                    SelectedPredstava = predstava
                };
            }
            else
            {
                BindingContext = model = new IzvodjenjaPreporucenoViewModel();
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as mIzvodjenja;
            await Navigation.PushAsync(new IzvodjenjaDetaljiPage(item));
        }
    }
}