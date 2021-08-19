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
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _korisniciService = new APIService("korisnici");
        private readonly APIService _kupciService = new APIService("kupci");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Prijava());
            RegisterCommand = new Command(() => Register());
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
        public ICommand RegisterCommand { get; set; }

        void Register()
        {
             Application.Current.MainPage = new RegistracijaPage();

        }

        bool _RegVisible = true;
        public bool RegVisible
        {
            get { return _RegVisible; }
            set { SetProperty(ref _RegVisible, value); }
        }

        public async Task Prijava()
        {
            IsBusy = true;
            RegVisible = false;
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
                IsBusy = false;

                PrijavljeniKupac.Kupac = kupac;
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Greska", "Pogresno korisnicko ime ili lozinka", "OK");

            }
            KorisnickoIme = string.Empty;
            Lozinka = string.Empty;
            RegVisible = true;

        }
    }
}
