﻿using System;
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

        //public static string GenerateSalt()
        //{
        //    var buf = new byte[16];
        //    (new RNGCryptoServiceProvider()).GetBytes(buf);
        //    return Convert.ToBase64String(buf);
        //}
        //public static string GenerateHash(string salt, string password)
        //{
        //    byte[] src = Convert.FromBase64String(salt);
        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] dst = new byte[src.Length + bytes.Length];

        //    System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        //    System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    return Convert.ToBase64String(inArray);
        //}

        static mKorisnici TrenutniKorisnik = null;

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
                throw new UserException("Lozinka nije ispravna");
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


        //autorizacija
        public async Task<mKorisnici>Login(string username, string password)
        {
            var entity = await _context.Korisnici.Include("KorisniciUloges.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            //if (entity==null)
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

            return _mapper.Map<mKorisnici>(entity);

        }

        public mKorisnici GetTrenutniKorisnik()
        {
            return TrenutniKorisnik;
            //throw new NotImplementedException();
        }

        public void SetTrenutniKorisnik(mKorisnici korisnik)
        {
            TrenutniKorisnik = korisnik;
            //throw new NotImplementedException();
        }
    }
}
