using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rIzvodjenjaZoneInsert
    {
        public int IzvodjenjeId { get; set; }
        public int ZonaId { get; set; }
        public string ZonaNaziv { get; set; }

        [Required(AllowEmptyStrings = false)]
        public decimal Cijena { get; set; }
    }
}
