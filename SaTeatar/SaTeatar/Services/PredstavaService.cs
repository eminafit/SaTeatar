using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;

namespace SaTeatar.WebAPI.Services
{
    public class PredstavaService : BaseCRUDService<mPredstave, Predstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
        , IPredstavaService
    {
        public PredstavaService(SaTeatarDbContext context, IMapper mapper)
            :base(context,mapper)
        {

        }


        public override IList<mPredstave> Get(rPredstavaSearch search)
        {
            var query = _context.Predstave.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search?.TipPredstaveId != 0)
            {
                query = query.Where(x => x.TipPredstaveId == search.TipPredstaveId);

            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<mPredstave>>(entities);

            return result;
        }
    }
}
