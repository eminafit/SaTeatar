using SaTeatar.Mobile.ViewModels;
using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SaTeatar.Mobile.ViewModels.HistorijaNarudzbiViewModel;

namespace SaTeatar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorijaNarudzbiPage : ContentPage
    {
        private HistorijaNarudzbiViewModel model =null;
        public HistorijaNarudzbiPage()
        {
            InitializeComponent();
            BindingContext = model = new HistorijaNarudzbiViewModel();
        }

        protected override void OnAppearing()
        {
            model.Init();
            base.OnAppearing(); 
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var xnar = e.SelectedItem as XNaruzba;
            var narudzba = new mNarudzba()
            {
                KupacId=xnar.KupacId,
                BrojNarudzbe=xnar.BrojNarudzbe,
                Datum=xnar.Datum,
                Iznos=xnar.Iznos,
                NarudzbaId=xnar.NarudzbaId,
                PaymentId=xnar.PaymentId
            };
            await Navigation.PushAsync(new NarudzbaStavkePage(xnar));
        }


    }
}