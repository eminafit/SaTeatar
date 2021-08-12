using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rTipoviPredstavaUpdate
    {
        public int TipPredstaveId { get; set; }
        public string Naziv { get; set; }

    }
}
