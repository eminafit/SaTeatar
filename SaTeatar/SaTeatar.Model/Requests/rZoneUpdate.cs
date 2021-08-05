using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rZoneUpdate
    {
        public int PozoristeId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public int UkupanBrojSjedista { get; set; }
    }
}
