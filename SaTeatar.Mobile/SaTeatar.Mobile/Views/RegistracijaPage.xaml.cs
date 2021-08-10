using SaTeatar.Mobile.ViewModels;
using SaTeatar.Model.Requests;
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
    public partial class RegistracijaPage : ContentPage
    {
        private KupciViewModel model = null;
        public RegistracijaPage()
        {
            InitializeComponent();
            BindingContext = model = new KupciViewModel()
            {
                KupacInsert = new rKupciInsert()
            };
        }
    }
}