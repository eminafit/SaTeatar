using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rDjelatniciSearch
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string ImePrezime { get; set; }

        public int VrstaDjelatnikaId { get; set; }

    }
}
