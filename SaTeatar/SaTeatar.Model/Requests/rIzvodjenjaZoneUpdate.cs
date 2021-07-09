using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rIzvodjenjaZoneUpdate
    {
        public int IzvodjenjeId { get; set; }
        public int ZonaId { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }
    }
}
