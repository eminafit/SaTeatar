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
    public partial class PlacanjePage : ContentPage
    {
        private PlacanjeViewModel model = null;
        private INavigation navigation;
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        // MUser _user;
        //public PaymentPage(MCourse course, MUser user)
        //{
        //    InitializeComponent();
        //    _user = user;
        //    SignedInUser.User = user;
        //    var nav = new NavigationPage(new CoursesPage(_user));
        //    navigation = nav.Navigation;
        //    BindingContext = model = new PaymentVM(navigation)
        //    {
        //        Course = course
        //    };
        //}
        private mNarudzba _narudzba = null;
        public PlacanjePage(mNarudzba narudzba)
        {
            InitializeComponent();

            BindingContext = model = new PlacanjeViewModel()
            {
                Narudzba = narudzba
            };
            _narudzba = narudzba;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ErrorLabel_CardNumber.IsVisible = false;
            ErrorLabel_Cvv.IsVisible = false;
            ErrorLabel_Month.IsVisible = false;
            ErrorLabel_Year.IsVisible = false;
        }
        private void Number_changed(object sender, TextChangedEventArgs e)
        {
            if (Number.Text.Length > 16)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Broj kartice treba imati 16 cifara!";
            }
            else if (Number.Text.Length < 1)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;
            }
        }

        private void Number_unfocused(object sender, TextChangedEventArgs e)
        {
            if (Number.Text == null)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;
            }
        }

        private void Month_changed(object sender, TextChangedEventArgs e)
        {
            if (Month.Text.Length != 2)
            {
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Mozete unijeti samo 2 cifre!";
            }
            else if (Month.Text == null)
            {
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_Month.IsVisible = false;
            }
        }
        private void Month_unfocused(object sender, TextChangedEventArgs e)
        {
            if (Month.Text == null)
            {
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_Month.IsVisible = false;
            }
        }
        private void Year_changed(object sender, TextChangedEventArgs e)
        {
            if (Year.Text.Length != 2)
            {
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Mozete unijeti samo 2 cifre!";
            }
            else if (Year.Text == null)
            {
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_Year.IsVisible = false;
            }
        }
        private void Year_unfocused(object sender, TextChangedEventArgs e)
        {
            if (Year.Text == null)
            {
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_Year.IsVisible = false;
            }
        }

        private void Cvv_changed(object sender, TextChangedEventArgs e)
        {
            if (Cvv.Text.Length != 3)
            {
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "Mozete unijeti samo 3 cifre!";
            }
            else if (Cvv.Text == null)
            {
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_Cvv.IsVisible = false;
            }
        }
        private void Cvv_unfocused(object sender, TextChangedEventArgs e)
        {
            if (Cvv.Text == null)
            {
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "Obavezno polje";
            }
            else
            {
                ErrorLabel_Cvv.IsVisible = false;
            }
        }

        //protected override async void OnDisappearing()
        //{
        //    await Navigation.PopToRootAsync();
        //    base.OnDisappearing();
        //}
    }
}