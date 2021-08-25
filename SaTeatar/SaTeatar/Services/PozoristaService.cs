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
    public class PozoristaService : BaseCRUDService <mPozorista, Pozorista, rPozoristaSearch, rPozoristaInsert, rPozoristaUpdate>
        , IPozoristaService
    {
        public PozoristaService(SaTeatarDbContext context, IMapper mapper)
            :base(context, mapper)
        {

        }

        public override IList<mPozorista> Get(rPozoristaSearch search)
        {
            var upit = _context.Pozorista.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                upit = upit.Where(x => x.Naziv.Contains(search.Naziv));
            }
            var lista = upit.ToList();
            return _mapper.Map<List<mPozorista>>(lista);
        }
    }
}
