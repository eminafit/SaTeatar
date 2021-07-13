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
    public class DjelatniciService : BaseCRUDService<mDjelatnici, Djelatnici, rDjelatniciSearch, rDjelatniciInsert, rDjelatniciUpdate>
        , IDjelatniciService
    {
        public DjelatniciService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mDjelatnici> Get(rDjelatniciSearch search)
        {
            var upit = _context.Djelatnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                upit = upit.Where(x => x.Ime.Contains(search.Ime));
            }


            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                upit = upit.Where(x => x.Prezime.Contains(search.Prezime));
            }


            if (search.VrstaDjelatnikaId!=0)
            {
                upit = upit.Where(x => x.VrstaDjelatnikaId == search.VrstaDjelatnikaId);
            }

            var lista = upit.ToList();

            var rezultat = _mapper.Map<IList<mDjelatnici>>(lista);

            return rezultat;    
        }
    }
}
