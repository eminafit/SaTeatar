using SaTeatar.Mobile.Helpers;
using SaTeatar.Mobile.Views;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace SaTeatar.Mobile.ViewModels
{
    public class KupciViewModel : BaseViewModel
    {
        private readonly APIService _kupciService = new APIService("kupci");

        public KupciViewModel()
        {
            RegistrujSeCommand = new Command(async () => await Registracija());
            UpdateProfilaCommand = new Command(async () => await UpdateProfila());
            PovratakNaLoginCommand = new Command(() => PovratakNaLogin());
          //  InitCommand = new Command(() => Init());
        }
        public rKupciInsert KupacInsert { get; set; }
        public rKupciUpdate KupacUpdate { get; set; }


        public ICommand RegistrujSeCommand { get; set; }
        public ICommand UpdateProfilaCommand { get; set; }
        // public ICommand InitCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChangedEH;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChangedEH != null)
            {
                PropertyChangedEH(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set 
            {
                if (value!=this._ime)
                {
                    this._ime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set 
            {
                if (value != this._prezime)
                {
                    this._prezime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != this._email)
                {
                    this._email = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set
            {
                if (value != this._korisnickoIme)
                {
                    this._korisnickoIme = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set
            {
                if (value != this._lozinka)
                {
                    this._lozinka = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand PovratakNaLoginCommand { get; set; }

        void PovratakNaLogin()
        {
            Application.Current.MainPage = new LoginPage();

        }

        public async Task Registracija()
        {

            IsBusy = true;
            KupacInsert.Status = true;
            KupacInsert.DatumRegistracije = DateTime.Now;

            var k = await _kupciService.Registracija(KupacInsert);
            if (k!=null)
            { 
                await Application.Current.MainPage.DisplayAlert("Zavrseno", "Registracija uspjesna!", "OK");
                Application.Current.MainPage = new LoginPage();
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Korisnicko ime vec postoji!", "OK");
            }
            IsBusy = false;
        }

        public async Task UpdateProfila()
        {
            IsBusy = true;
            var kupac = PrijavljeniKupac.Kupac;
            KupacUpdate = new rKupciUpdate();
            KupacUpdate.Ime = Ime;
            KupacUpdate.Prezime = Prezime;
            KupacUpdate.Email = Email;
            KupacUpdate.Lozinka = Lozinka;
            KupacUpdate.KorisnickoIme =kupac.KorisnickoIme;
            KupacUpdate.Status = kupac.Status;
            KupacUpdate.KupacId = kupac.KupacId;
            KupacUpdate.DatumRegistracije = kupac.DatumRegistracije;


            var k = await _kupciService.Update<mKupci>(KupacUpdate.KupacId, KupacUpdate);

            if (k!=null)
            {

                await Application.Current.MainPage.DisplayAlert("Zavrseno", "Izmjena profila uspjesna!", "OK");
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Pogresna lozinka!", "OK");
            }
            IsBusy = false;
            Lozinka = string.Empty;
        }

        //public void Init()
        //{
        //    var kupac = PrijavljeniKupac.Kupac;
        //    Ime = kupac.Ime;
        //    Prezime = kupac.Prezime;
        //    Email = kupac.Email;
        //    KorisnickoIme = kupac.KorisnickoIme;
        //}
    }
}
