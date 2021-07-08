using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mPozorista
    {
        //public Pozorista()
        //{
        //    Izvodjenjas = new HashSet<Izvodjenja>();
        //    Zones = new HashSet<Zone>();
        //}

        public int PozoristeId { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public byte[] Logo { get; set; }

        public virtual ICollection<mIzvodjenja> Izvodjenjas { get; set; }
        public virtual ICollection<mZone> Zones { get; set; }
    }
}
