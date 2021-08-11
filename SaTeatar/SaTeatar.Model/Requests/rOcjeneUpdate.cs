using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rOcjeneUpdate
    {
        public int OcjenaId { get; set; }
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }

    }
}
