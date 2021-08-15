using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class Karte
    {
        public Karte()
        {
            NarudzbaStavkes = new HashSet<NarudzbaStavke>();
        }

        public int KartaId { get; set; }
        public int KupacId { get; set; }
        public int IzvodjenjeId { get; set; }
        public string Sifra { get; set; }
        public bool Placeno { get; set; }
        public int IzvodjenjeZonaId { get; set; }

        public virtual Izvodjenja Izvodjenje { get; set; }
        public virtual IzvodjenjaZone IzvodjenjeZona { get; set; }
        public virtual Kupci Kupac { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
    }
}
