using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.WebAPI.Database
{
    public partial class VrsteDjelatnika
    {
        public VrsteDjelatnika()
        {
            Djelatnicis = new HashSet<Djelatnici>();
        }

        public int VrstaDjelatnikaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Djelatnici> Djelatnicis { get; set; }
    }
}
