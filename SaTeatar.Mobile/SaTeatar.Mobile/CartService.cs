using SaTeatar.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Mobile
{
    public static class CartService
    {
        public static Dictionary<int, IzvodjenjeDetaljiViewModel> Cart { get; set; } = new Dictionary<int, IzvodjenjeDetaljiViewModel>(); 
    }
}
