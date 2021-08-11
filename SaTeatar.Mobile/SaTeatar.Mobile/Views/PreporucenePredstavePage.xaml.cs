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
    public partial class PreporucenePredstavePage : ContentPage
    {
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
    }
}