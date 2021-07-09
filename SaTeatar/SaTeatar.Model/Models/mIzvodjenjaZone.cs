using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mIzvodjenjaZone
    {
        public int IzvodjenjeZonaId { get; set; }
        public int IzvodjenjeId { get; set; }
        public int ZonaId { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }
    }
}
