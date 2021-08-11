using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mKarta
    {
        public int KartaId { get; set; }
        public int KupacId { get; set; }
        public int IzvodjenjeId { get; set; }
        public string Sifra { get; set; }
        public bool Placeno { get; set; }
        public int IzvodjenjeZonaId { get; set; }

        public string PredstavaNaziv { get; set; }
        public int PredstavaId { get; set; }
        public string PozoristeNaziv { get; set; }
        public int PozoristeId { get; set; }

        public string ZonaNaziv { get; set; }
        public decimal Cijena { get; set; }

        //public virtual mIzvodjenja Izvodjenje { get; set; }
        //public virtual mIzvodjenjaZone IzvodjenjeZona { get; set; }
        //public virtual mKupci Kupac { get; set; }
    }
}
