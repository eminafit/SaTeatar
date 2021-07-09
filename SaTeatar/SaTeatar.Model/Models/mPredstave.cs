using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mPredstave
    {
        //public Predstave()
        //{
        //    Izvodjenjas = new HashSet<Izvodjenja>();
        //    PoslaneObavijestis = new HashSet<PoslaneObavijesti>();
        //    PredstaveDjelatnicis = new HashSet<PredstaveDjelatnici>();
        //}

        public int PredstavaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public int TipPredstaveId { get; set; }
        public bool Status { get; set; }

       // public virtual mTipoviPredstava TipPredstave { get; set; }
        //public virtual ICollection<mIzvodjenja> Izvodjenjas { get; set; }
        //public virtual ICollection<PoslaneObavijesti> PoslaneObavijestis { get; set; }
        //public virtual ICollection<PredstaveDjelatnici> PredstaveDjelatnicis { get; set; }
    }
}
