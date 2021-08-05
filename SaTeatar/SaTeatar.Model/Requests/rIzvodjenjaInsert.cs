using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rIzvodjenjaInsert
    {
        [Required(AllowEmptyStrings = false)]
        public int PredstavaId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int PozoristeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int KorisnikId { get; set; }

        public DateTime DatumVrijeme { get; set; }

        public string Napomena { get; set; }
    }
}
