using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.WebAPI.Database
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            Izvodjenjas = new HashSet<Izvodjenja>();
            KorisniciUloges = new HashSet<KorisniciUloge>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Izvodjenja> Izvodjenjas { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
    }
}
