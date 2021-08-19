using SaTeatar.Mobile.Helpers;
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
    public partial class EditProfilaPage : ContentPage
    {
        public KupciViewModel model = null;
        public EditProfilaPage()
        {
            InitializeComponent();
            BindingContext = model = new KupciViewModel();
            var kupac = PrijavljeniKupac.Kupac;

            FirstName.Text = kupac.Ime;
            LastName.Text = kupac.Prezime;
            Username.Text = kupac.KorisnickoIme;
            Email.Text = kupac.Email;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstName.Text) ||
                string.IsNullOrWhiteSpace(LastName.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Username.Text) ||
                string.IsNullOrWhiteSpace(Password.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Sva polja su obavezna", "Pokusajte opet");
                return;
            }
            else
            {
                await model.UpdateProfila();
                Password.Text = string.Empty;
            }

        }
    }

}