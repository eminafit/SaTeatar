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
    public class KupciViewModel : BaseViewModel
    {
        private readonly APIService _kupciService = new APIService("kupci");

        public KupciViewModel()
        {
            RegistrujSeCommand = new Command(async () => await Registracija());
        }
        public rKupciInsert KupacInsert { get; set; }

        public ICommand RegistrujSeCommand { get; set; }

        async Task Registracija()
        {

            IsBusy = true;
            KupacInsert.Status = true;
            KupacInsert.DatumRegistracije = DateTime.Now;

            try
            {
                await _kupciService.Insert<mKupci>(this.KupacInsert);
                await Application.Current.MainPage.DisplayAlert("Zavrsena registracija", "Registracija uspjesna!", "OK");
                // await Navigation.PushAsync(new IzvodjenjaDetaljiPage(item));

                //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

                await Shell.Current.Navigation.PushAsync(new Login());

            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Registracija nije uspjesna!", "OK");

                throw;
            }
        }
    }
}
