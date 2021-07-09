using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rDjelatniciUpdate
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Biografija { get; set; }
        public byte[] Slika { get; set; }
        public bool Status { get; set; }
        public int VrstaDjelatnikaId { get; set; }
    }
}
