using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class Djelatnici
    {
        public Djelatnici()
        {
            PredstaveDjelatnicis = new HashSet<PredstaveDjelatnici>();
        }

        public int DjelatnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Biografija { get; set; }
        public byte[] Slika { get; set; }
        public bool Status { get; set; }
        public int VrstaDjelatnikaId { get; set; }

        public virtual VrsteDjelatnika VrstaDjelatnika { get; set; }
        public virtual ICollection<PredstaveDjelatnici> PredstaveDjelatnicis { get; set; }
    }
}
