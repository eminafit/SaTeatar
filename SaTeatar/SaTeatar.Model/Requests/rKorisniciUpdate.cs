using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rKorisniciUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Lozinka { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string LozinkaPotvrda { get; set; }

        public bool? Status { get; set; }

        public List<int> Uloge { get; set; } = new List<int>();
    }
}
