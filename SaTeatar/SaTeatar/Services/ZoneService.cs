using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;

namespace SaTeatar.WebAPI.Services
{
    public class ZoneService : BaseCRUDService<mZone, Zone, rZoneSearch, rZoneInsert, rZoneUpdate>
        , IZoneService
    {
        public ZoneService(SaTeatarBpContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mZone> Get(rZoneSearch search)
        {
            var upit = _context.Zone.AsQueryable();

            if (search.PozoristeId!=0)
            {
                upit = upit.Where(x => x.PozoristeId==search.PozoristeId);
            }

            var lista = upit.ToList();
            var rezultat = _mapper.Map<IList<mZone>>(lista);
            return rezultat;   
        }
    }
}
