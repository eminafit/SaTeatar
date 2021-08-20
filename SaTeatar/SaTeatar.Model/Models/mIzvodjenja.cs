using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mIzvodjenja
    {
        public int IzvodjenjeId { get; set; }
        public int PredstavaId { get; set; }
        public string PredstavaNaziv { get; set; }
        public int PozoristeId { get; set; }
        public string PozoristeNaziv { get; set; }
        public byte[] PredstavaSlika { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Datum { get; set; }
        public string Vrijeme { get; set; }
        public string Napomena { get; set; }
    }
}
