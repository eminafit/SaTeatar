using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mPredstaveDjelatnici
    {
        public int PredstavaDjelatnikId { get; set; }
        public int PredstavaId { get; set; }
        public int DjelatnikId { get; set; }
        public string DjelatnikIme { get; set; }
        public string DjelatnikPrezime { get; set; }

        public virtual mDjelatnici Djelatnik { get; set; }

    }
}
