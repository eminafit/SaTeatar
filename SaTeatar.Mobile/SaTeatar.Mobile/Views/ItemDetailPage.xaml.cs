using SaTeatar.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SaTeatar.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}