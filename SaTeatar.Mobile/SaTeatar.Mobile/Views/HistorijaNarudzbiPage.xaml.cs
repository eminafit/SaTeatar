using SaTeatar.Mobile.ViewModels;
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
    }
}