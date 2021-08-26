using AutoMapper;
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
    public class NarudzbeStavkeService : BaseCRUDService<mNarudzbaStavke, NarudzbaStavke, rNarudzbaStavkeSearch, rNarudzbaStavkeInsert, rNarudzbaStavkeUpdate>
        , INarudzbeStavkeService
    {
        public NarudzbeStavkeService(SaTeatarBpContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<mNarudzbaStavke> Get(rNarudzbaStavkeSearch search)
        {
            var upit = _context.NarudzbaStavke.AsQueryable();
            if (search.NarudzbaId!=0)
            {
                upit = upit.Where(x => x.NarudzbaId == search.NarudzbaId);
            }
            var lista = upit.ToList();
            return _mapper.Map<List<mNarudzbaStavke>>(lista);
        }
    }
}
