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
    public class PostavkeObavijestiService : BaseCRUDService<mPostavkeObavijesti, PostavkeObavijesti, rPostavkaObavijestiSearch, rPostavkaObavijestiUpsert, rPostavkaObavijestiUpsert>
        , IPostavkeObavijestiService
    {
        public PostavkeObavijestiService(SaTeatarBpContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mPostavkeObavijesti> Get(rPostavkaObavijestiSearch search)
        {
            var upit = _context.PostavkeObavijesti.Include(x=>x.TipPredstave).AsQueryable();
            if (search!=null)
            {
                if (search.KupacId!=0)
                {
                    upit = upit.Where(x => x.KupacId == search.KupacId);
                }

                if (search.TipPredstaveId!=0)
                {
                    upit = upit.Where(x => x.TipPredstaveId == search.TipPredstaveId);

                }
            }
            var list = upit.ToList();
            return _mapper.Map<List<mPostavkeObavijesti>>(list);
        }
    }
}
