using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class PredstaveDjelatnici
    {
        public int PredstavaDjelatnikId { get; set; }
        public int PredstavaId { get; set; }
        public int DjelatnikId { get; set; }

        public virtual Djelatnici Djelatnik { get; set; }
        public virtual Predstave Predstava { get; set; }
    }
}
