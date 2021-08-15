﻿using SaTeatar.Mobile.ViewModels;
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
        private NarudzbaViewModel model = null;
        public NarudzbaPage()
        {
            InitializeComponent();
            BindingContext = model = new NarudzbaViewModel();

           // model.Init();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();

            if (model!=null & model.UkupniIznos==0)
                if (model != null)
                {
                    if (model.UkupniIznos == 0)
                    {
                        Btn_Placanje.IsVisible = false;
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

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IzvodjenjaPage());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IzvodjenjaPage());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlacanjePage(model));

        }

    }
}