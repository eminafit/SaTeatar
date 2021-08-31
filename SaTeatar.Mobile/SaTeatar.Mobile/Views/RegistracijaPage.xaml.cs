using SaTeatar.Mobile.ViewModels;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaTeatar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistracijaPage : ContentPage
    {
        private KupciViewModel model = null;
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

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
                string.IsNullOrWhiteSpace(PasswordConfirmation.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Sva polja su obavezna", "Pokusajte opet");
                return;
            }
            else if (Password.Text!= PasswordConfirmation.Text)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Lozinke se ne podudaraju", "Pokusajte opet");
                return;
            }
            else
            {
                await model.Registracija();
                Password.Text = string.Empty;
                PasswordConfirmation.Text = string.Empty;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ErrorLabel_FirstName.IsVisible = false;
            ErrorLabel_LastName.IsVisible = false;
            ErrorLabel_Username.IsVisible = false;
            ErrorLabel_Email.IsVisible = false;
            ErrorLabel_Password.IsVisible = false;
            ErrorLabel_PasswordConfirmation.IsVisible = false;

            NavigationPage.SetHasNavigationBar(this, true); //get your navbar back
            NavigationPage.SetHasBackButton(this, true); //get your back button bac
        }

        private void firstname_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                ErrorLabel_FirstName.IsVisible = true;
                ErrorLabel_FirstName.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_FirstName.IsVisible = false;
            }
        }

        private void firstname_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                ErrorLabel_FirstName.IsVisible = true;
                ErrorLabel_FirstName.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_FirstName.IsVisible = false;

            }
        }
        private void lastname_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LastName.Text))
            {
                ErrorLabel_LastName.IsVisible = true;
                ErrorLabel_LastName.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_LastName.IsVisible = false;
            }
        }
        private void lastname_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LastName.Text))
            {
                ErrorLabel_LastName.IsVisible = true;
                ErrorLabel_LastName.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_LastName.IsVisible = false;
            }
        }

        private void email_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;
            }
            if (Email.Text != null)
            {
                bool isValid = Regex.IsMatch(Email.Text, emailPattern);
                if (!isValid)
                {
                    ErrorLabel_Email.IsVisible = true;
                    ErrorLabel_Email.Text = "Unesite ispravan email!";
                }
                else
                {
                    ErrorLabel_Email.IsVisible = false;
                }
            }
        }
        private void email_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;
            }
            if (Email.Text != null)
            {
                bool isValid = Regex.IsMatch(Email.Text, emailPattern);
                if (!isValid)
                {
                    ErrorLabel_Email.IsVisible = true;
                    ErrorLabel_Email.Text = "Unesite ispravan email!";
                }
                else
                {
                    ErrorLabel_Email.IsVisible = false;
                }
            }
        }

        private void username_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text))
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Obavezno polje!";
            }
            else if (Username.Text.Count() < 3)
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Korisnicko ime treba sadrzavati bar 3 karaktera!";
            }
            else
            {
                ErrorLabel_Username.IsVisible = false;
            }
        }
        private void username_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text))
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Obavezno polje!";
            }
            else if (Username.Text.Count() < 3)
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Korisnicko ime treba sadrzavati bar 3 karaktera!";
            }
            else
            {
                ErrorLabel_Username.IsVisible = false;
            }
        }

        private void password_changed(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (string.IsNullOrEmpty(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Obavezno polje!";
            }
            else if (!hasNumber.IsMatch(Password.Text) || !hasUpperChar.IsMatch(Password.Text) || !hasMinimum8Chars.IsMatch(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Lozinka treba sadrzavati broj, veliko slovo, malo slovo i imati bar 8 karaktera!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }
        }
        private void password_unfocused(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrEmpty(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Obavezno polje!";
            }
            else if (!hasNumber.IsMatch(Password.Text) || !hasUpperChar.IsMatch(Password.Text) || !hasMinimum8Chars.IsMatch(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Lozinka treba sadrzavati broj, veliko slovo, malo slovo i imati bar 8 karaktera!";
            }
            else
            {
                ErrorLabel_Password.IsVisible = false;
            }
        }
        private void passwordconfirmation_unfocused(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrEmpty(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Obavezno polje!";
            }
            else if (!hasNumber.IsMatch(PasswordConfirmation.Text) || !hasUpperChar.IsMatch(PasswordConfirmation.Text) || !hasMinimum8Chars.IsMatch(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Lozinka treba sadrzavati broj, veliko slovo, malo slovo i imati bar 8 karaktera!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }

        }
        private void passwordconfirmation_changed(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (string.IsNullOrEmpty(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Obavezno polje!";
            }
            else if (!hasNumber.IsMatch(PasswordConfirmation.Text) || !hasUpperChar.IsMatch(PasswordConfirmation.Text) || !hasMinimum8Chars.IsMatch(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Lozinka treba sadrzavati broj, veliko slovo, malo slovo i imati bar 8 karaktera!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }
        }
    }
}