using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public partial class mUloge
    {
        //public Uloge()
        //{
        //    KorisniciUloges = new HashSet<KorisniciUloge>();
        //}

        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        //public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
    }
}
