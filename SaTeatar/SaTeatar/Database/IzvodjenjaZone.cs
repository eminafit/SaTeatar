using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class IzvodjenjaZone
    {
        public IzvodjenjaZone()
        {
            Kartes = new HashSet<Karte>();
        }

        public int IzvodjenjeZonaId { get; set; }
        public int IzvodjenjeId { get; set; }
        public int ZonaId { get; set; }
        public decimal Cijena { get; set; }

        public virtual Izvodjenja Izvodjenje { get; set; }
        public virtual Zone Zona { get; set; }
        public virtual ICollection<Karte> Kartes { get; set; }
    }
}
