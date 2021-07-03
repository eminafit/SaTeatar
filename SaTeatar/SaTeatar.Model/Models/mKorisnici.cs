using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public partial class mKorisnici
    {
        public mKorisnici()
        {
            //Izvodjenjas = new HashSet<Izvodjenja>();
            //KorisniciUloges = new HashSet<KorisniciUloge>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        //public string LozinkaHash { get; set; }
        //public string LozinkaSalt { get; set; }
        public bool Status { get; set; }

        //public virtual ICollection<Izvodjenja> Izvodjenjas { get; set; }
        public virtual ICollection<mKorisniciUloge> KorisniciUloges { get; set; }
    }
}
