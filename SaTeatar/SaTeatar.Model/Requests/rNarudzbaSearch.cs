using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rNarudzbaSearch
    {
        public int NarudzbaId { get; set; }
        public int KupacId { get; set; }
        public Guid? BrNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
        public string PaymentId { get; set; }
        public int PozoristeId { get; set; }

        public DateTime DatumOD { get; set; }
        public DateTime DatumDO { get; set; }

    }
}
