using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class UlogeService : BaseCRUDService<mUloge, Uloge, rUlogeSearch, rUlogeUpsert, rUlogeUpsert>
        , IUlogeService
    {
        public UlogeService(SaTeatarBpContext context, IMapper mapper) : base(context, mapper)
        {
        }

       // [HttpGet("{KorisnikId}")]
        public override IList<mUloge> Get(rUlogeSearch search)
        {
            var upit = _context.KorisniciUloge.Include(x=>x.Uloga).AsQueryable();

            if (search.KorisnikId!=0)
            {
                upit = upit.Where(x => x.KorisnikId == search.KorisnikId);
            }

            var entities = upit.Select(x => x.Uloga).ToList();
            //var distinct = entities.Distinct();

            return _mapper.Map<IList<mUloge>>(entities);
        }

    }
}
