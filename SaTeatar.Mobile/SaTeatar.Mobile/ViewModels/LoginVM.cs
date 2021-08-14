using SaTeatar.Mobile.Helpers;
using SaTeatar.Mobile.Views;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    public class LoginVM : BaseViewModel
    {
        private readonly APIService _korisniciService = new APIService("korisnici");
        private readonly APIService _kupciService = new APIService("kupci");
        public LoginVM()
        {
            LoginCommand = new Command(async () => await Prijava());
        }

        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Prijava()
        {
            IsBusy = true;
            APIService.Username = KorisnickoIme;
            APIService.Password = Lozinka;

            var zahtjev = new rKupciAuth()
            {
                KorisnickoIme = APIService.Username,
                Lozinka = APIService.Password
            };

            var kupac = await _kupciService.Authenticate(zahtjev);

            if (kupac!=null)
            {
                PrijavljeniKupac.Kupac = kupac;
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Pogresno korisnicko ime ili lozinka", "OK");
            }

        }
    }
}
