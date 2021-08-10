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
    public class IzvodjenjaZoneService : BaseCRUDService<mIzvodjenjaZone, IzvodjenjaZone, rIzvodjenjaZoneSearch, rIzvodjenjaZoneInsert, rIzvodjenjaZoneUpdate>
        , IIzvodjenjaZoneService
    {
        public IzvodjenjaZoneService(SaTeatarDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<mIzvodjenjaZone> Get(rIzvodjenjaZoneSearch search)
        {
            var upit = _context.IzvodjenjaZone.AsQueryable();
            if (search.ZonaId!=0 && search.IzvodjenjeId!=0)
            {
                upit = upit.Where(x => x.IzvodjenjeId == search.IzvodjenjeId && x.ZonaId == search.ZonaId);
            }
            var list = upit.ToList();
            return _mapper.Map<List<mIzvodjenjaZone>>(list); //vratiti ce samo jedan obj zapravo
        }
    }
}
