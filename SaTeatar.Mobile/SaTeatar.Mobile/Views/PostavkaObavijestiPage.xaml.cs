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
    public partial class PostavkaObavijestiPage : ContentPage
    {
        private PostavkaObavijestiViewModel model = null;
        public PostavkaObavijestiPage()
        {
            InitializeComponent();
            BindingContext = model = new PostavkaObavijestiViewModel();
        }

        protected async override void OnAppearing()
        {
            await model.Init();
            base.OnAppearing();
        }
    }
}