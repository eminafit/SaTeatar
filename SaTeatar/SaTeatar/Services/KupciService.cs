using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.WebAPI.Services;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using AutoMapper;
using SaTeatar.Exceptions;
using Microsoft.AspNetCore.Authorization;
using SaTeatar.Security;

namespace SaTeatar.Services
{
    public class KupciService : BaseCRUDService<mKupci, Kupci, rKupciSearch, rKupciInsert, rKupciUpdate>
        , IKupciService
    {
        public KupciService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }

        public override IList<mKupci> Get(rKupciSearch search)
        {
            var upit = _context.Kupci.AsQueryable();

            if (!string.IsNullOrWhiteSpace( search.KorisnickoIme))
            {
                upit = upit.Where(x => x.KorisnickoIme == search.KorisnickoIme);
            }


            var lista = upit.ToList();
            return _mapper.Map<List<mKupci>>(lista);
           // return base.Get(search);
        }

        public override mKupci Insert (rKupciInsert request)
        {
            var listaUsernameaKorisnika = _context.Korisnici.Select(x => x.KorisnickoIme).ToList();
            var listaUsernameaKupaca = _context.Kupci.Select(x => x.KorisnickoIme).ToList();
            if (listaUsernameaKorisnika.Contains(request.KorisnickoIme) || listaUsernameaKupaca.Contains(request.KorisnickoIme))
            {
                throw new UserException("Korisnicko ime vec postoji!");
            }

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new UserException("Lozinka nije ispravna");
            }
            
            
            var entitet = _mapper.Map<Kupci>(request);

            entitet.LozinkaSalt = GenerateSaltHash.GenerateSalt();
            entitet.LozinkaHash = GenerateSaltHash.GenerateHash(entitet.LozinkaSalt, request.Lozinka);

            _context.Kupci.Add(entitet);
            _context.SaveChanges();

            return _mapper.Map<mKupci>(entitet);
        
        }

        public async Task<mKupci> Login(string username, string password)
        {
            var entity = _context.Kupci.Where(x => x.KorisnickoIme == username).FirstOrDefault();

            //if (entity == null)
            //{
            //    throw new UserException("Pogresan username ili password");
            //}
            if (entity!=null)
            {
                var hash = GenerateSaltHash.GenerateHash(entity.LozinkaSalt, password);
                if (hash != entity.LozinkaHash)
                {
                    throw new UserException("Pogresan username ili password");
                }
            }


            //    TrenutniKorisnik = _mapper.Map<mKorisnici>(entity);
            //      setovan u basicauthandleru

            return _mapper.Map<mKupci>(entity);

        }
    }
}
