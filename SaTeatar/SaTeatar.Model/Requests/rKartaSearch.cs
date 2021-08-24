using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rKartaSearch
    {
        public int KartaId { get; set; }
        public int KupacId { get; set; }
        public int IzvodjenjeId { get; set; }
        public Guid? BrKarte { get; set; }
        public bool Placeno { get; set; }
        public byte[] Qrcode { get; set; }
        public int PredstavaId { get; set; }
        public int PozoristeId { get; set; }

        public DateTime DatumOd { get; set; } //= DateTime.MinValue;
        public DateTime DatumDo { get; set; } //= DateTime.MinValue;

        public int IzvodjenjeZonaId { get; set; }

        //public virtual Izvodjenja Izvodjenje { get; set; }
        //public virtual IzvodjenjaZone IzvodjenjeZona { get; set; }
        //public virtual Kupci Kupac { get; set; }
    }
}
