using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class PoslaneObavijesti
    {
        public int PoslanaObavijestId { get; set; }
        public int KupacId { get; set; }
        public int PrestavaId { get; set; }
        public DateTime VrijemeSlanja { get; set; }
        public string Poruka { get; set; }
        public bool Procitano { get; set; }
        public DateTime DatumVazenja { get; set; }

        public virtual Kupci Kupac { get; set; }
        public virtual Predstave Prestava { get; set; }
    }
}
