using System;
using System.Collections.Generic;
using System.Text;

namespace SaTeatar.Model.Models
{
    public class mTipoviPredstava
    {
        //public TipoviPredstava()
        //{
        //    PostavkeObavijestis = new HashSet<PostavkeObavijesti>();
        //    Predstaves = new HashSet<Predstave>();
        //}

        public int TipPredstaveId { get; set; }
        public string Naziv { get; set; }

        public bool Checkirano { get; set; } = false;

        //public virtual ICollection<PostavkeObavijesti> PostavkeObavijestis { get; set; }
        //public virtual ICollection<Predstave> Predstaves { get; set; }
    }
}
