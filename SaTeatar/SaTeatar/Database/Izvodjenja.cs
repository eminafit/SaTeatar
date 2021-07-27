using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class Izvodjenja
    {
        public Izvodjenja()
        {
            IzvodjenjaZones = new HashSet<IzvodjenjaZone>();
            Kartes = new HashSet<Karte>();
        }

        public int IzvodjenjeId { get; set; }
        public int PredstavaId { get; set; }
        public int PozoristeId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Napomena { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        public virtual Pozorista Pozoriste { get; set; }
        public virtual Predstave Predstava { get; set; }
        public virtual ICollection<IzvodjenjaZone> IzvodjenjaZones { get; set; }
        public virtual ICollection<Karte> Kartes { get; set; }
    }
}
