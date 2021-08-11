using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mHistorijaKarti
    {
        public int KupacId { get; set; }
        public string PredstavaNaziv { get; set; }
        public string PozoristeNaziv { get; set; }
        public List<KarteInfo> Karte { get; set; }

        public class KarteInfo
        {
            public string Sifra { get; set; }
            public string ZonaNaziv { get; set; }
            public decimal Cijena { get; set; }
        }
    }
}
