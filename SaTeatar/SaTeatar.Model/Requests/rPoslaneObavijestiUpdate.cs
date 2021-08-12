using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPoslaneObavijestiUpdate
    {
        public int PoslanaObavijestId { get; set; }
        public int KupacId { get; set; }
        public int PrestavaId { get; set; }
        public DateTime VrijemeSlanja { get; set; }
        public string Poruka { get; set; }
        public bool Procitano { get; set; }
        public DateTime DatumVazenja { get; set; }
    }
}
