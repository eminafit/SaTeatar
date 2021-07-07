using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.WebAPI.Database
{
    public partial class Pozorista
    {
        public Pozorista()
        {
            Izvodjenjas = new HashSet<Izvodjenja>();
            Zones = new HashSet<Zone>();
        }

        public int PozoristeId { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public byte[] Logo { get; set; }

        public virtual ICollection<Izvodjenja> Izvodjenjas { get; set; }
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
