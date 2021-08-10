using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mKupci
    {
        public int KupacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Status { get; set; }
    }
}
