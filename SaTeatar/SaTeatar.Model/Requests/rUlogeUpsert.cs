using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rUlogeUpsert
    {
        public int UlogaId { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
