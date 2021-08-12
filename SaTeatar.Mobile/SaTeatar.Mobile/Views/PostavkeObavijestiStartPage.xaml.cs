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
    public partial class PostavkeObavijestiStartPage : ContentPage
    {
        private PostavkaObavijestiViewModel model = null;
        public PostavkeObavijestiStartPage()
        {
            InitializeComponent();
            BindingContext = model = new PostavkaObavijestiViewModel();
        }

        protected async override void OnAppearing()
        {
            await model.Init();
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PostavkaObavijestiPage());
        }
    }
}