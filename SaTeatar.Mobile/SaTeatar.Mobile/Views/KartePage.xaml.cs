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
    public partial class KartePage : ContentPage
    {
        private KarteViewModel model = null;

        public KartePage()
        {
            InitializeComponent();
            BindingContext = model = new KarteViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var karta = e.SelectedItem as mKarta;
            await Navigation.PushAsync(new KartaQrCodePage(karta));
        }
    }
}