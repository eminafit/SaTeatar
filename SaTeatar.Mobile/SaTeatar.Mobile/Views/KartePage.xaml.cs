using SaTeatar.Mobile.ViewModels;
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

        //protected override async void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //}

        //protected override async bool OnBackButtonPressed()
        //{
        //     await Navigation.PopToRootAsync();
        //    return true;
        //    //return base.OnBackButtonPressed();
        //}
    }
}