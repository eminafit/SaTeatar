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

        public override IList<mIzvodjenja> Get(rIzvodjenjaSearch search)
        {
            if (search.naziviZaXamarin) 
            {

                var upit = _context.Izvodjenja.AsQueryable();

                //if (search.NaDan!=default(DateTime))
                //{
                //    upit = upit.Where(x => x.DatumVrijeme.Date == search.NaDan.Date);
                //}

                if (search.TipPredstaveId != 0)
                {
                    upit = upit.Where(x => x.Predstava.TipPredstaveId == search.TipPredstaveId);
                }
                var izvodjenja = upit.ToList();
                var mizvodjenja = _mapper.Map<List<mIzvodjenja>>(izvodjenja);
                var predstave = _context.Predstave.ToList();
                var pozoriste = _context.Pozorista.ToList();

                //imam problem sa json deserijalizacijom ako radim klasicni query nad bazom sa includanjem pozorista i predstave

                foreach (var mi in mizvodjenja)
                {
                    foreach (var p in predstave)
                    {
                        if (mi.PredstavaId == p.PredstavaId)
                        {
                            mi.PredstavaNaziv = p.Naziv;
                            mi.PredstavaSlika = p.Slika;
                        }
                    }
                }

                foreach (var mi in mizvodjenja)
                {
                    foreach (var p in pozoriste)
                    {
                        if (mi.PozoristeId == p.PozoristeId)
                        {
                            mi.PozoristeNaziv = p.Naziv;
                        }
                    }
                }



                return mizvodjenja;
            }

            return base.Get(search);

        }
    }
}
