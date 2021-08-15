using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class NarudzbaStavke
    {
        public int NarudzbaStavkeId { get; set; }
        public int NarudzbaId { get; set; }
        public int KartaId { get; set; }

        public virtual Karte Karta { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}
