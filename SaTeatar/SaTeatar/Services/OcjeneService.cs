using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Database;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Services
{
    public class OcjeneService : BaseCRUDService<mOcjene, Ocjene, rOcjeneSearch, rOcjeneInsert, rOcjeneUpdate>
        , IOcjeneService
    {
        public OcjeneService(SaTeatarBpContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mOcjene> Get(rOcjeneSearch search)
        {
            var upit = _context.Ocjene.Include(x=>x.Predstava).AsQueryable();

            
            if (search.PredstavaId != 0)
            {
                upit = upit.Where(x => x.PredstavaId == search.PredstavaId);
            }

            if (search.KupacId!=0)
            {
                upit = upit.Where(x=>x.KupacId==search.KupacId);
            }
            

            var list = upit.ToList();
            return _mapper.Map<List<mOcjene>>(list);
        }
    }
}
