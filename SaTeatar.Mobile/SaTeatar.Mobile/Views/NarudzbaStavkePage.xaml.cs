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
    public partial class NarudzbaStavkePage : ContentPage
    {
        public NarudzbaStavkeViewModel model = null;
        private XNaruzba _narudzba = null;
        private readonly APIService _narudzbaService = new APIService("narudzba");


        public NarudzbaStavkePage(XNaruzba narudzba)
        {
            InitializeComponent();
            _narudzba = narudzba;
            BindingContext = model = new NarudzbaStavkeViewModel()
            {
                Narudzba = narudzba
            };
            

        }

        protected override void OnAppearing()
        {
            model.Init();
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var narudzba = await _narudzbaService.GetById<mNarudzba>(_narudzba.NarudzbaId);
            await Navigation.PushAsync(new PlacanjePage(narudzba));
        }
    }
}