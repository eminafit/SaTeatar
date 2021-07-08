using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mZone
    {
        //public Zone()
        //{
        //    IzvodjenjaZones = new HashSet<IzvodjenjaZone>();
        //}

        public int ZonaId { get; set; }
        public int PozoristeId { get; set; }
        public string Naziv { get; set; }
        public int UkupanBrojSjedista { get; set; }

        //public virtual Pozorista Pozoriste { get; set; }
        //public virtual ICollection<IzvodjenjaZone> IzvodjenjaZones { get; set; }
    }
}
