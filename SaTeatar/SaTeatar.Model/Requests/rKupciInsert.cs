﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rKupciInsert
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string LozinkaPotvrda { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Status { get; set; }
    }
}
