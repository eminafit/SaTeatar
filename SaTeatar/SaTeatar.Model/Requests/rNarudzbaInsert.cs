﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Requests
{
    public class rNarudzbaInsert
    {
        public int KupacId { get; set; }
        public Guid? BrNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
        public string PaymentId { get; set; }
    }
}
