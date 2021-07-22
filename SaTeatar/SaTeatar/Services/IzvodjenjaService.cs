using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;

namespace SaTeatar.WebAPI.Services
{
    public class IzvodjenjaService : BaseCRUDService<mIzvodjenja, Izvodjenja, rIzvodjenjaSearch, rIzvodjenjaInsert, rIzvodjenjaUpdate>
        , IIzvodjenjaService
    {
        public IzvodjenjaService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        //public override IList<mIzvodjenja> Get(rIzvodjenjaSearch search)
        //{
        //    //var entity = _context.Izvodjenja;

        //    var query = _context.Izvodjenja.Include(s => s.Predstava).Include(o => o.Pozoriste).Include(p => p.Korisnik).AsQueryable();
        //    var list = query.ToList();
        //    var rez = _mapper.Map<List<mIzvodjenja>>(list);

        //    //_mapper.Map<destinacija>(izvor);

        //    return rez;
        //    // return base.Get(search);    
        //}
    }
}
