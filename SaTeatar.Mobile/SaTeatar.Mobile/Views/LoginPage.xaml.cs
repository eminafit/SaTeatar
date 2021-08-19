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
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel model = null;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = model = new LoginViewModel();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KorisnickoIme.Text) || string.IsNullOrWhiteSpace(Lozinka.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Sva polja su obavezna", "Pokusajte opet");
                return;
            }
            else
            {
                await model.Prijava();
            }
        }


    }

    
}