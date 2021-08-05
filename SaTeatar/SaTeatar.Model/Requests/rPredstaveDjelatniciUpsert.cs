using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPredstaveDjelatniciUpsert
    {
        public int PredstavaDjelatnikId { get; set; }
       
        [Required(AllowEmptyStrings = false)]
        public int PredstavaId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public int DjelatnikId { get; set; }
    }
}
