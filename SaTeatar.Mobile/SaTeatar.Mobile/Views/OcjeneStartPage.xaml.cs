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
    public partial class OcjeneStartPage : ContentPage
    {
        public OcjeneViewModel model = null;
        public OcjeneStartPage()
        {
            InitializeComponent();
            BindingContext = model = new OcjeneViewModel();
        }

        protected async override void OnAppearing()
        {
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ocjena = e.SelectedItem as mOcjene;
            await Navigation.PushAsync(new OcjenePage(ocjena));
        }
    }
}