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

        //public virtual Korisnici Korisnik { get; set; } //cirkularna referenca
        //drugi nacin za rjesiti je u startup klasi na
        //.AddNewonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 

        public virtual mUloge Uloga { get; set; }
    }
}
