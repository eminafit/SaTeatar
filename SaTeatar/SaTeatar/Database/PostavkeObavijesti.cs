using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class PostavkeObavijesti
    {
        public int PostavkaObavijestiId { get; set; }
        public int KupacId { get; set; }
        public int TipPredstaveId { get; set; }

        public virtual Kupci Kupac { get; set; }
        public virtual TipoviPredstava TipPredstave { get; set; }
    }
}
