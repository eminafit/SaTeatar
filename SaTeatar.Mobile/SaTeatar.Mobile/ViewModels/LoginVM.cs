using SaTeatar.Mobile.Views;
using SaTeatar.Model.Models;
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

            try
            {
                await _kupciService.Get<List<mKorisnici>>(null);
             //   await _korisniciService.Get<List<mKorisnici>>(null);
                // Application.Current.MainPage = new MainPage();
                //await Shell.Current.GoToAsync("//AppShell");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
