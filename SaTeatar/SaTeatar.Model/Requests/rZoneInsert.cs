using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rZoneInsert
    {
        public int PozoristeId { get; set; }
        public string Naziv { get; set; }
        public int UkupanBrojSjedista { get; set; }
    }
}
