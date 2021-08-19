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
using Microsoft.EntityFrameworkCore;

namespace SaTeatar.Services
{
    public class KupciService : BaseCRUDService<mKupci, Kupci, rKupciSearch, rKupciInsert, rKupciUpdate>
        , IKupciService
    {
        public KupciService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }

        public async Task<mKupci> Authenticate(rKupciAuth request)
        {
            Kupci user = await _context.Kupci.FirstOrDefaultAsync(i => i.KorisnickoIme == request.KorisnickoIme);

            if (user != null)
            {
                var newHash =GenerateSaltHash.GenerateHash(user.LozinkaSalt, request.Lozinka);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<mKupci>(user);
                }
            }
            return null;
        }

        [AllowAnonymous]
        public async Task<mKupci> Registracija(rKupciInsert request)
        {
            var listaUsernameaKorisnika = _context.Korisnici.Select(x => x.KorisnickoIme).ToList();
            var listaUsernameaKupaca = _context.Kupci.Select(x => x.KorisnickoIme).ToList();
            if (listaUsernameaKorisnika.Contains(request.KorisnickoIme) || listaUsernameaKupaca.Contains(request.KorisnickoIme))
            {
                //throw new UserException("Korisnicko ime vec postoji!");
                return null;
            }

            //if (request.Lozinka != request.LozinkaPotvrda)
            //{
            //    throw new UserException("Lozinka nije ispravna");
            //}


            var entitet = _mapper.Map<Kupci>(request);

            entitet.LozinkaSalt = GenerateSaltHash.GenerateSalt();
            entitet.LozinkaHash = GenerateSaltHash.GenerateHash(entitet.LozinkaSalt, request.Lozinka);

            _context.Kupci.Add(entitet);
            _context.SaveChanges();

            return _mapper.Map<mKupci>(entitet);
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

        public override mKupci Update(int id, rKupciUpdate request)
        {
            var kupac = _context.Kupci.AsNoTracking().Where(x => x.KupacId == request.KupacId).FirstOrDefault();

            var entitet = _mapper.Map<Kupci>(request);

            var hash = GenerateSaltHash.GenerateHash(kupac.LozinkaSalt, request.Lozinka);
            if (hash != kupac.LozinkaHash)
            {
                return null;
            }
            entitet.LozinkaSalt = kupac.LozinkaSalt;
            entitet.LozinkaHash = kupac.LozinkaHash;

            _context.Kupci.Update(entitet);
            _context.SaveChanges();

            return _mapper.Map<mKupci>(entitet);
        }

        public async Task<mKupci> Login(string username, string password)
        {
            var entity = _context.Kupci.AsNoTracking().Where(x => x.KorisnickoIme == username).FirstOrDefault();

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
                else
                    return _mapper.Map<mKupci>(entity);
            }
            return null;


            //    TrenutniKorisnik = _mapper.Map<mKorisnici>(entity);
            //      setovan u basicauthandleru

            //return _mapper.Map<mKupci>(entity);

        }
    }
}
