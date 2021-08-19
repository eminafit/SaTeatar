using SaTeatar.Mobile.ViewModels;
using SaTeatar.Model.Requests;
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
    public partial class RegistracijaPage : ContentPage
    {
        private KupciViewModel model = null;
        public RegistracijaPage()
        {
            InitializeComponent();
            BindingContext = model = new KupciViewModel()
            {
                KupacInsert = new rKupciInsert()
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstName.Text) ||
                string.IsNullOrWhiteSpace(LastName.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Username.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) ||
                string.IsNullOrWhiteSpace(PasswordConfirm.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Sva polja su obavezna", "Pokusajte opet");
                return;
            }
            else if (Password.Text!=PasswordConfirm.Text)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Lozinke se ne podudaraju", "Pokusajte opet");
                return;
            }
            else
            {
                await model.Registracija();
                Password.Text = string.Empty;
                PasswordConfirm.Text = string.Empty;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, true); //get your navbar back
            NavigationPage.SetHasBackButton(this, true); //get your back button bac
        }
    }
}