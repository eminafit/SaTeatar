using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rKorisniciInsert
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Prezime { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string KorisnickoIme { get; set; }

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
             ErrorMessage = "Lozinka treba imati bar 8 karaktera, sadrzavati bar jedan broj, jedno malo slovo, jedno veliko slovo i jedan specijalni karakter!")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Compare("Lozinka", ErrorMessage ="Lozinke se ne podudaraju!")]
        public string LozinkaPotvrda { get; set; }

        public bool? Status { get; set; }

        public List<int> Uloge { get; set; } = new List<int>();
    }
}
