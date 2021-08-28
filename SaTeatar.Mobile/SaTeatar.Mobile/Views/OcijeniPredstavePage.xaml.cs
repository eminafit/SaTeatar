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
    public partial class OcijeniPredstavePage : ContentPage
    {
        public OcjeneViewModel model = null;
        public OcijeniPredstavePage()
        {
            InitializeComponent();
            BindingContext = model = new OcjeneViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}