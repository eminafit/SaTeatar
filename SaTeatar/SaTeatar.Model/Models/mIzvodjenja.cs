using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mIzvodjenja
    {
        //public Izvodjenja()
        //{
        //    IzvodjenjaZones = new HashSet<IzvodjenjaZone>();
        //    Kartes = new HashSet<Karte>();
        //    Ocjenes = new HashSet<Ocjene>();
        //}

        public int IzvodjenjeId { get; set; }
        public int PredstavaId { get; set; }
        public int PozoristeId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Napomena { get; set; }

        //public virtual mKorisnici Korisnik { get; set; }
        //public virtual mPozorista Pozoriste { get; set; }
        //public virtual Predstave Predstava { get; set; }
        //public virtual ICollection<IzvodjenjaZone> IzvodjenjaZones { get; set; }
        //public virtual ICollection<Karte> Kartes { get; set; }
        //public virtual ICollection<Ocjene> Ocjenes { get; set; }
    }
}
