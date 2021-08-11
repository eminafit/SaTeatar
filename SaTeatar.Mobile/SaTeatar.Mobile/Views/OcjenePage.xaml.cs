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
    public partial class OcjenePage : ContentPage
    {
        private OcjeneViewModel model = null;
        public OcjenePage()
        {
            InitializeComponent();
            BindingContext = model = new OcjeneViewModel();
        }

        protected async override void OnAppearing()
        {
            //base.OnAppearing();
            await model.Init();
        }

        //private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    await model.Init();

        //}
    }
}