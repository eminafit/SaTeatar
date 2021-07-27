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
using SaTeatar.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SaTeatar.WebAPI.Services
{
    public class KorisniciService
        : BaseCRUDService<mKorisnici, Korisnici, rKorisniciSearch, rKorisniciInsert, rKorisniciUpdate>
        , IKorisniciService
    {
        public KorisniciService(SaTeatarDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override mKorisnici Insert(rKorisniciInsert request)
        {
            var entity = _mapper.Map<Korisnici>(request);

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new UserException("Lozinka nije ispravna");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka); 
            
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
                query = query.Where(x => x.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime == search.Prezime);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<mKorisnici>>(entities);

            return result;
        }
        //za add i update treba lozinka


        //autorizacija
        public async Task<mKorisnici>Login(string username, string password)
        {
            var entity = await _context.Korisnici.Include("KorisniciUloges.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity==null)
            {
                throw new UserException("Pogresan username ili password");
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);
            if (hash!=entity.LozinkaHash)
            {
                throw new UserException("Pogresan username ili password");
            }

            return _mapper.Map<mKorisnici>(entity);

        }
    }
}
