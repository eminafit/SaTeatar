using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mOcjene
    {
        public int OcjenaId { get; set; }
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }
        public string PredstavaNaziv { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }

        //public virtual mKupci Kupac { get; set; }
        //public virtual mPredstave Predstava { get; set; }
    }
}
