using SaTeatar.WebAPI.Services;
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
    public class KorisniciUlogeService : BaseCRUDService<mKorisniciUloge, KorisniciUloge, rKorisniciUlogeSearch, rKorisniciUlogeUpsert, rKorisniciUlogeUpsert>
        , IKorisniciUlogeService

    {
        public KorisniciUlogeService(SaTeatarDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<mKorisniciUloge> Get(rKorisniciUlogeSearch search)
        {
            var upit =  _context.KorisniciUloge.AsQueryable();
            if (search.KorisnikId != 0)
            {
                upit = upit.Where(x => x.KorisnikId == search.KorisnikId);
            }

            return _mapper.Map<List<mKorisniciUloge>>(upit);
        }
    }
}
