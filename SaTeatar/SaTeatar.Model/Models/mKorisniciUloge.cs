using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public partial class mKorisniciUloge
    {
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        //public virtual Korisnici Korisnik { get; set; }
        public virtual mUloge Uloga { get; set; }
    }
}
