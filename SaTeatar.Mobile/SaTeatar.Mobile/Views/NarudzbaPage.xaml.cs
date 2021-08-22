using SaTeatar.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaTeatar.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NarudzbaPage : ContentPage
    {
        private KorpaViewModel model = null;
        public NarudzbaPage()
        {
            InitializeComponent();
            BindingContext = model = new KorpaViewModel();
            NavigationPage.SetHasNavigationBar(this, false); //get your navbar back
            NavigationPage.SetHasBackButton(this, false); //get your back button bac
                                                          // model.Init();
        }

        protected override async void OnAppearing()
        {
            //await Navigation.PopToRootAsync();
            //NavigationPage.SetHasNavigationBar(this, false); //get your navbar back
            //NavigationPage.SetHasBackButton(this, false); //get your back button bac
            model.Init();

            if (model!=null & model.UkupniIznos==0)
                if (model != null)
                {
                    if (model.UkupniIznos == 0)
                    {
                        Btn_Isprazni.IsVisible = false;
                        Btn_Rezervacija.IsVisible = false;
                    }
                }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            model.PromijenjenaKolicina();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            model.PromijenjenaKolicina();
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            //nastavi kupovinu
            //await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new IzvodjenjaPage());

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            //potvrdi narudzbu??
            Navigation.PushAsync(new IzvodjenjaPage());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            //ispraznite korpu
            Navigation.PushAsync(new PlacanjePage(model));

        }

    }
}