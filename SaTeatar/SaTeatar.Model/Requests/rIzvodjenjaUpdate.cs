using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rIzvodjenjaUpdate
    {
        public int PredstavaId { get; set; }
        public int PozoristeId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Napomena { get; set; }
    }
}
