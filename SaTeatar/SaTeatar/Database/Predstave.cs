using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.WebAPI.Database
{
    public partial class Predstave
    {
        public Predstave()
        {
            Izvodjenjas = new HashSet<Izvodjenja>();
            PoslaneObavijestis = new HashSet<PoslaneObavijesti>();
            PredstaveDjelatnicis = new HashSet<PredstaveDjelatnici>();
        }

        public int PredstavaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int TipPredstaveId { get; set; }
        public bool Status { get; set; }

        public virtual TipoviPredstava TipPredstave { get; set; }
        public virtual ICollection<Izvodjenja> Izvodjenjas { get; set; }
        public virtual ICollection<PoslaneObavijesti> PoslaneObavijestis { get; set; }
        public virtual ICollection<PredstaveDjelatnici> PredstaveDjelatnicis { get; set; }
    }
}
