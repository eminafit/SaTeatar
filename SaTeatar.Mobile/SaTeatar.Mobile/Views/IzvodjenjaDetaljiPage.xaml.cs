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
    public partial class IzvodjenjaDetaljiPage : ContentPage
    {
        private IzvodjenjeDetaljiViewModel model = null;
        public IzvodjenjaDetaljiPage(mIzvodjenja izvodjenje)
        {
            InitializeComponent();
            BindingContext = model = new IzvodjenjeDetaljiViewModel()
            {
                Izvodjenje = izvodjenje
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }
    }
}