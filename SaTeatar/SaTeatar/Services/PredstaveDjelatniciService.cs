using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;

namespace SaTeatar.WebAPI.Services
{
    public class PredstaveDjelatniciService : BaseCRUDService<mPredstaveDjelatnici, PredstaveDjelatnici, rPredstaveDjelatnicSearch, rPredstaveDjelatniciUpsert, rPredstaveDjelatniciUpsert>
        , IPredstaveDjelatniciService
    {
        public PredstaveDjelatniciService(SaTeatarBpContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<mPredstaveDjelatnici> Get(rPredstaveDjelatnicSearch search)
        {
            var query = _context.PredstaveDjelatnici.Include(x=>x.Djelatnik).AsQueryable();
            if (search?.PredstavaId!=0)
            {
                query = query.Where(x => x.PredstavaId == search.PredstavaId);
            }

            var list = query.ToList();
            var result = _mapper.Map<IList<mPredstaveDjelatnici>>(list);
            return result;
           // return base.Get(search);    
        }
    }
}
