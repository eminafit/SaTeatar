using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class Ocjene
    {
        public int OcjenaId { get; set; }
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }

        public virtual Kupci Kupac { get; set; }
        public virtual Predstave Predstava { get; set; }
    }
}
