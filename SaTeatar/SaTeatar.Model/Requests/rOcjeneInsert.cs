﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rOcjeneInsert
    {
        public int KupacId { get; set; }
        public int PredstavaId { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }

    }
}
