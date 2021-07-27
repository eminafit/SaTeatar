using System;
using System.Collections.Generic;

#nullable disable

namespace SaTeatar.Database
{
    public partial class TipoviPredstava
    {
        public TipoviPredstava()
        {
            PostavkeObavijestis = new HashSet<PostavkeObavijesti>();
            Predstaves = new HashSet<Predstave>();
        }

        public int TipPredstaveId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<PostavkeObavijesti> PostavkeObavijestis { get; set; }
        public virtual ICollection<Predstave> Predstaves { get; set; }
    }
}
