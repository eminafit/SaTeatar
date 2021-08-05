using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rTipoviPredstavaInsertUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }

    }
}
