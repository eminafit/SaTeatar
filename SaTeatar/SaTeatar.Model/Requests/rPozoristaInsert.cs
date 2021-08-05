using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPozoristaInsert
    {
        //public Pozorista()
        //{
        //    Izvodjenjas = new HashSet<Izvodjenja>();
        //    Zones = new HashSet<Zone>();
        //}

        //public int PozoristeId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public byte[] Logo { get; set; }

        //public virtual ICollection<Izvodjenja> Izvodjenjas { get; set; }
        //public virtual ICollection<Zone> Zones { get; set; }
    }
}
