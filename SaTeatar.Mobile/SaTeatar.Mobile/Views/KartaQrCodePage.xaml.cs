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
    public partial class KartaQrCodePage : ContentPage
    {
        public KartaQrCodeViewModel model = null;
        public KartaQrCodePage(mKarta karta)
        {
            InitializeComponent();
            BindingContext = model = new KartaQrCodeViewModel()
            {
                Karta = karta
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}