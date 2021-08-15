using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class Kupci
    {
        public Kupci()
        {
            Kartes = new HashSet<Karte>();
            Narudzbas = new HashSet<Narudzba>();
            Ocjenes = new HashSet<Ocjene>();
            PoslaneObavijestis = new HashSet<PoslaneObavijesti>();
            PostavkeObavijestis = new HashSet<PostavkeObavijesti>();
        }

        public int KupacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Karte> Kartes { get; set; }
        public virtual ICollection<Narudzba> Narudzbas { get; set; }
        public virtual ICollection<Ocjene> Ocjenes { get; set; }
        public virtual ICollection<PoslaneObavijesti> PoslaneObavijestis { get; set; }
        public virtual ICollection<PostavkeObavijesti> PostavkeObavijestis { get; set; }
    }
}
