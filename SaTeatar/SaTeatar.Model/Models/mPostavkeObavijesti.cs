using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mPostavkeObavijesti
    {
        public int PostavkaObavijestiId { get; set; }
        public int KupacId { get; set; }
        public int TipPredstaveId { get; set; }
        public string TipPredstaveNaziv { get; set; }
        //public virtual mKupci Kupac { get; set; }
        //public virtual mTipoviPredstava TipPredstave { get; set; }
    }
}
