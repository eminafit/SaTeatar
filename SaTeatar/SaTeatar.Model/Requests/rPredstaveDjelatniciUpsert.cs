using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPredstaveDjelatniciUpsert
    {
        public int PredstavaDjelatnikId { get; set; }
        public int PredstavaId { get; set; }
        public int DjelatnikId { get; set; }
    }
}
