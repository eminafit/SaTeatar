using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rDjelatniciUpdate
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Prezime { get; set; }

        public string Biografija { get; set; }
        public byte[] Slika { get; set; }
        public bool Status { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int VrstaDjelatnikaId { get; set; }
    }
}
