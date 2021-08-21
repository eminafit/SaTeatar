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
    public partial class PreporucenePredstavePage : ContentPage
    {
        private readonly APIService _predstavaService = new APIService("predstava");

        private PreporucenePredstaveViewModel model = null;
        public PreporucenePredstavePage()
        {
            InitializeComponent();
            BindingContext = model = new PreporucenePredstaveViewModel();
        }

        protected async override void OnAppearing()
        {
            await model.Init();
           // base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PreporucenePredstaveViewModel.PreporucenePredstaveClass;
            mPredstave predstava =  await _predstavaService.GetById<mPredstave>(item.PredstavaId);

            await Navigation.PushAsync(new  IzvodjenjaPreporucenoPage(predstava));

        }
    }
}