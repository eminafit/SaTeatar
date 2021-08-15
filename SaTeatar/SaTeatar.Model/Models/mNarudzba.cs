using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mNarudzba
    {
        public int NarudzbaId { get; set; }
        public int KupacId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
        public string PaymentId { get; set; }

        //public virtual Kupci Kupac { get; set; }
        //public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
    }
}
