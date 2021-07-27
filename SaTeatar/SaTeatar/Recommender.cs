using SaTeatar.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar
{
    public class Recommender
    {
        SaTeatarDbContext _context = new SaTeatarDbContext();
        Dictionary<int, List<Ocjene>> predstave = new Dictionary<int, List<Ocjene>>();

        public List<Predstave> GetSlicnePredstave(int predstavaId)  //trenutno posmatrana predstava 
        {
            //ucitati sve predstave koji se razlikuju od trenutno posmatrane
            UcitajPredstave(predstavaId);
            List<Ocjene> ocjenePosmatranePredstave = _context.Ocjene.Where(x => x.PredstavaId == predstavaId).OrderBy(x=>x.KupacId).ToList();
            //35 min.. zajednicke ocjene?
            return new List<Predstave>();
        }

        private void UcitajPredstave(int predstavaID) //filtriranje samo najslicinijih predstava
        {
            List<Predstave> aktivnePredstava = _context.Predstave.Where(x => x.PredstavaId != predstavaID && x.Status == true).ToList();
            List<Ocjene> ocjene;
            foreach (Predstave p in aktivnePredstava)
            {
                ocjene = _context.Ocjene.Where(x => x.PredstavaId == p.PredstavaId).OrderBy(x => x.KupacId).ToList();
                if (ocjene.Count>0)
                {
                    predstave.Add(p.PredstavaId, ocjene);
                }
                //kljuc - predstava
                //vrijednost - sve ocjene
            }
            throw new NotImplementedException();
        }
    }
}
