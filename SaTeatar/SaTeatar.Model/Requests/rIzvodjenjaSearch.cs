using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rIzvodjenjaSearch
    {
        public bool naziviZaXamarin { get; set; } = false;
      //  public DateTime NaDan { get; set; }
        public int TipPredstaveId { get; set; }

        public int IzvodjenjeId { get; set; }
        public int PredstavaId { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public DateTime NaDatum { get; set; }
        public DateTime DatumOD { get; set; }
        public DateTime DatumDO { get; set; }
    }
}
