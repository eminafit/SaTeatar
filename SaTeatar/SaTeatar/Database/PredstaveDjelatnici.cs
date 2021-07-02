using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.WebAPI.Database
{
    public partial class PredstaveDjelatnici
    {
        public int PredstavaDjelatnik { get; set; }
        public int PredstavaId { get; set; }
        public int DjelatnikId { get; set; }

        public virtual Djelatnici Djelatnik { get; set; }
        public virtual Predstave Predstava { get; set; }
    }
}
