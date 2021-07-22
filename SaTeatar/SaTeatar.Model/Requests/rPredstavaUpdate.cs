using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rPredstavaUpdate
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int TipPredstaveId { get; set; }
        public bool Status { get; set; }
       // public virtual mTipoviPredstava TipPredstave { get; set; }
    }
}
