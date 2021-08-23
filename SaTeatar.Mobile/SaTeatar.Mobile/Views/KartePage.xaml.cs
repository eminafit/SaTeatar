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
             Navigation.PopToRootAsync();

        }

        protected override  void OnAppearing()
        {
            model.Init();
            base.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}