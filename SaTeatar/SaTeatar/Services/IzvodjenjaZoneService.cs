using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using Microsoft.EntityFrameworkCore;

namespace SaTeatar.WebAPI.Services
{
    public class IzvodjenjaZoneService : BaseCRUDService<mIzvodjenjaZone, IzvodjenjaZone, rIzvodjenjaZoneSearch, rIzvodjenjaZoneInsert, rIzvodjenjaZoneUpdate>
        , IIzvodjenjaZoneService
    {
        public IzvodjenjaZoneService(SaTeatarBpContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<mIzvodjenjaZone> Get(rIzvodjenjaZoneSearch search)
        {
            var upit = _context.IzvodjenjaZone.Include(x=>x.Zona).AsQueryable();
            if (search.ZonaId!=0 )
            {
                upit = upit.Where(x => x.ZonaId == search.ZonaId);
            }
            if (search.IzvodjenjeId != 0)
            {
                upit = upit.Where(x => x.IzvodjenjeId == search.IzvodjenjeId);
            }

            var list = upit.ToList();
            return _mapper.Map<List<mIzvodjenjaZone>>(list); //vratiti ce samo jedan obj zapravo
        }
    }
}
