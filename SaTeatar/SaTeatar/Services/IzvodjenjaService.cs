using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;

namespace SaTeatar.WebAPI.Services
{
    public class IzvodjenjaService : BaseCRUDService<mIzvodjenja, Izvodjenja, rIzvodjenjaSearch, rIzvodjenjaInsert, rIzvodjenjaUpdate>
        , IIzvodjenjaService
    {
        public IzvodjenjaService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }


        public override IList<mIzvodjenja> Get(rIzvodjenjaSearch search)
        {
            var upit = _context.Izvodjenja.Include(s => s.Predstava).Include(o => o.Pozoriste).Include(p => p.Korisnik).AsQueryable();

            if (search.PredstavaId != 0)
            {
                upit = upit.Where(x => x.PredstavaId == search.PredstavaId);
            }

            if (search.TipPredstaveId != 0)
            {
                upit = upit.Where(x => x.Predstava.TipPredstaveId == search.TipPredstaveId);
            }

            if (search.DatumVrijeme.CompareTo(DateTime.MinValue.AddHours(1))>0)
            {
                upit = upit.Where(x => x.DatumVrijeme.CompareTo(search.DatumVrijeme) > 0);
            }

            if (search.NaDatum.CompareTo(DateTime.MinValue.AddHours(1)) > 0)
            {
                upit = upit.Where(x => x.DatumVrijeme.Date.CompareTo(search.NaDatum.Date) == 0);
            }

            var izvodjenja = upit.ToList();
            return _mapper.Map<List<mIzvodjenja>>(izvodjenja);
        }
    }
}
