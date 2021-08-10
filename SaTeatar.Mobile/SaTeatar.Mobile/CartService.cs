using SaTeatar.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Mobile
{
    public static class CartService
    {
        public static Dictionary<string, IzvodjenjeDetaljiViewModel> Cart { get; set; } = new Dictionary<string, IzvodjenjeDetaljiViewModel>(); 
    }
}
