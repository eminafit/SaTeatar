using SaTeatar.Mobile.ViewModels;
using SaTeatar.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SaTeatar.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
            //await Shell.Current.GoToAsync("//LoginPage");
            //await Shell.Current.GoToAsync("//Login");
        }
    }
}
