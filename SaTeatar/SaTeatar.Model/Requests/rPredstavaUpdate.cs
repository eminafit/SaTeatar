using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPredstavaUpdate
    {
        public int PredstavaId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int TipPredstaveId { get; set; }
        public bool Status { get; set; }

        //public virtual mTipoviPredstava TipPredstave { get; set; }
    }
}
