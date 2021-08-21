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
    public partial class IzvodjenjaPage : ContentPage
    {
        private IzvodjenjaViewModel model = null;

        public IzvodjenjaPage()
        {
            InitializeComponent();
            BindingContext = model = new IzvodjenjaViewModel();

        }

        protected async override void OnAppearing()
        {
           // NavigationPage.SetHasBackButton(this, false);
            base.OnAppearing();
            await model.Init();
               
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var item = e.SelectedItem as mIzvodjenja;
           await Navigation.PushAsync(new IzvodjenjaDetaljiPage(item));
        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            model.SelectedDan = e.NewDate;
            await model.Init();
        }
    }
}