using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPozoristaUpdate
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public byte[] Logo { get; set; }
    }
}
