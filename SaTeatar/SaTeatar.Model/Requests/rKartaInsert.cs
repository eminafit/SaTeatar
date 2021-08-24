using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rKartaInsert
    {
        //public int KartaId { get; set; }
        public int KupacId { get; set; }
        public int IzvodjenjeId { get; set; }
        public Guid? BrKarte { get; set; }
        public byte[] Qrcode { get; set; }

        public bool Placeno { get; set; }
        public int IzvodjenjeZonaId { get; set; }

        //public virtual Izvodjenja Izvodjenje { get; set; }
        //public virtual IzvodjenjaZone IzvodjenjeZona { get; set; }
        //public virtual Kupci Kupac { get; set; }
    }
}
