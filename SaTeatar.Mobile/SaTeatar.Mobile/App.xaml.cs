using SaTeatar.Mobile.Helpers;
using SaTeatar.Mobile.Services;
using SaTeatar.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaTeatar.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
            //NavigationDispatcher.Instance.Initialize(MainPage.Navigation);
            // MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
