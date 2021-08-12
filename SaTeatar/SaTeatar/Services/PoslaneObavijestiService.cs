using SaTeatar.WebAPI.Services;
using SaTeatar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using AutoMapper;

namespace SaTeatar.Services
{
    public class PoslaneObavijestiService : BaseCRUDService<mPoslaneObavijesti, PoslaneObavijesti, rPoslaneObavijestiSearch, rPoslaneObavijestiInsert, rPoslaneObavijestiUpdate>
        , IPoslaneObavijestiService
    {
        public PoslaneObavijestiService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mPoslaneObavijesti> Get(rPoslaneObavijestiSearch search)
        {
            var upit = _context.PoslaneObavijesti.AsQueryable();

            if (search!=null)
            {
                if (search.KupacId!=0)
                {
                    upit = upit.Where(x => x.KupacId == search.KupacId);
                }
            }
            var lista = upit.ToList();
            return _mapper.Map<List<mPoslaneObavijesti>>(lista);
        }
    }
}
