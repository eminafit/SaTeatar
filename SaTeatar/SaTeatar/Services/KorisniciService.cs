using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Requests;
using SaTeatar.Model.Models;
using SaTeatar.Database;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using SaTeatar.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Exceptions;
using SaTeatar.Security;

namespace SaTeatar.WebAPI.Services
{
    public class KorisniciService
        : BaseCRUDService<mKorisnici, Korisnici, rKorisniciSearch, rKorisniciInsert, rKorisniciUpdate>
        , IKorisniciService
    {
        public KorisniciService(SaTeatarBpContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        static Korisnici TrenutniKorisnik = null;

        public override mKorisnici Insert(rKorisniciInsert request)
        {
            var listaUsernameaKorisnika = _context.Korisnici.Select(x => x.KorisnickoIme).ToList();
            var listaUsernameaKupaca = _context.Kupci.Select(x => x.KorisnickoIme).ToList();
            if (listaUsernameaKorisnika.Contains( request.KorisnickoIme) || listaUsernameaKupaca.Contains(request.KorisnickoIme))
            {
                throw new UserException("Korisnicko ime vec postoji!");
            }

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new UserException("Lozinka se ne podudaraju");
            }

            var entity = _mapper.Map<Korisnici>(request);

            entity.LozinkaSalt = GenerateSaltHash.GenerateSalt();
            entity.LozinkaHash = GenerateSaltHash.GenerateHash(entity.LozinkaSalt, request.Lozinka); 
            
            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                KorisniciUloge korisniciUloge = new KorisniciUloge();
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.UlogaId = uloga;
                korisniciUloge.DatumIzmjene = DateTime.Now;

                _context.KorisniciUloge.Add(korisniciUloge);
            }

            _context.SaveChanges();

            return _mapper.Map<mKorisnici>(entity);
        }

        public override IList<mKorisnici> Get ( [FromQuery] rKorisniciSearch search)
        {
            var query = _context.Korisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.Contains(search.Ime));
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.Contains(search.Prezime));
            }

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.Contains(search.KorisnickoIme));
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<mKorisnici>>(entities);

            return result;
        }
        //za add i update treba lozinka

        public override mKorisnici Update(int id, rKorisniciUpdate request)
        {
            Korisnici korisnik = new Korisnici();
            if (request.KorisnikId != TrenutniKorisnik.KorisnikId)
            {

                korisnik = _context.Korisnici.AsNoTracking().Where(x => x.KorisnikId == request.KorisnikId).FirstOrDefault();
            }
            else
            {
                korisnik = TrenutniKorisnik;
            }

            var entitet = _mapper.Map<Korisnici>(request);
            var hash = GenerateSaltHash.GenerateHash(korisnik.LozinkaSalt, request.Lozinka);
            if (hash!=korisnik.LozinkaHash)
            {             
                return null;
            }
            entitet.LozinkaSalt = korisnik.LozinkaSalt;
            entitet.LozinkaHash = korisnik.LozinkaHash;

            _context.Korisnici.Update(entitet);
            _context.SaveChanges();

            return _mapper.Map<mKorisnici>(entitet);
        }

        //autorizacija
        public async Task<mKorisnici>Login(string username, string password)
        {
            var entity = await _context.Korisnici.AsNoTracking().Include("KorisniciUloges.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity!=null)
            {
                var hash = GenerateSaltHash.GenerateHash(entity.LozinkaSalt, password);
                if (hash != entity.LozinkaHash)
                {
                    throw new UserException("Pogresan username ili password");
                }
            }
            
            
                SetTrenutniKorisnik(entity);
            

            return _mapper.Map<mKorisnici>(entity);

        }

        public mKorisnici GetTrenutniKorisnik()
        {
            return _mapper.Map<mKorisnici>(TrenutniKorisnik);
        }

        public void SetTrenutniKorisnik(Korisnici korisnik)
        {
            TrenutniKorisnik = korisnik;
        }
    }
}
