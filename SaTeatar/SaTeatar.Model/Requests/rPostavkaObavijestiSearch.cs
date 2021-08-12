using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPostavkaObavijestiSearch
    {
        public int PostavkaObavijestiId { get; set; }
        public int KupacId { get; set; }
        public int TipPredstaveId { get; set; }
    }
}
