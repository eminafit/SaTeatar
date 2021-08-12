using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Database
{
    public class Pozorista
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
