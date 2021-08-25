using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Database;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.Services
{
    public class NarudzbaService : BaseCRUDService<mNarudzba, Narudzba, rNarudzbaSearch, rNarudzbaInsert, rNarudzbaUpdate>
        , INarudzbaService
    {
        public NarudzbaService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mNarudzba> Get(rNarudzbaSearch search)
        {
            if (search.PozoristeId!=0)
            {
                var karte = _context.Karte.Include(x => x.Izvodjenje).AsQueryable();
                karte = karte.Where(x => x.Izvodjenje.PozoristeId == search.PozoristeId);
                List<int> karteIds = karte.Select(x => x.KartaId).ToList();

                List<Narudzba> narudzbe = new List<Narudzba>();
                List<int> narudzbeIds = new List<int>();

                var narudzbestavke = _context.NarudzbaStavke.Include(x=>x.Narudzba).AsQueryable();

                foreach (var id in karteIds)
                {
                    var nar = narudzbestavke.Where(x => x.KartaId == id).Select(x => x.Narudzba.NarudzbaId).FirstOrDefault();
                    if (nar!=0)
                    {
                        narudzbeIds.Add(nar);                   
                    }
                }

                var narIdsDistinct = narudzbeIds.Distinct();

                foreach (var id in narIdsDistinct)
                {
                    var nar = _context.Narudzba.Find(id);
                    narudzbe.Add(nar);
                }

                return _mapper.Map<List<mNarudzba>>(narudzbe);

                if (search.DatumOD.CompareTo(DateTime.Now.AddHours(1))>0 &&
                    search.DatumDO.CompareTo(DateTime.Now.AddHours(1)) > 0)
                {
                    narudzbe = narudzbe.Where(x => x.Datum.CompareTo(search.DatumOD) >= 0 &&
                                                   x.Datum.CompareTo(search.DatumDO) <= 0).ToList();
                }
            }

            var upit = _context.Narudzba.AsQueryable();

            if (search.KupacId!=0)
            {
                upit = upit.Where(x => x.KupacId == search.KupacId);
            }

            var lista = upit.ToList();
            return _mapper.Map<List<mNarudzba>>(lista);
        }
    }
}
