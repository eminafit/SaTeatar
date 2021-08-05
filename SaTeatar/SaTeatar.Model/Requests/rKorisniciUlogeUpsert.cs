using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rKorisniciUlogeUpsert
    {
        public int KorisnikUlogaId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int KorisnikId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
