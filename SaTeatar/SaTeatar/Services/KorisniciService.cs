﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Requests;
using SaTeatar.Model.Models;
using SaTeatar.WebAPI.Database;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using SaTeatar.WebAPI.Filters;

namespace SaTeatar.WebAPI.Services
{
    public class KorisniciService
        : BaseCRUDService<mKorisnici, Korisnici, object, rKorisniciInsert, rKorisniciUpdate>
        , IKorisniciService
    {
        public KorisniciService(SaTeatarContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public override mKorisnici Insert(rKorisniciInsert request)
        {
            var entity = _mapper.Map<Korisnici>(request);
            //_context.Korisnicis.Add(entity);
            if (request.Password != request.PasswordPotvrda)
            {
                //throw new NotImplementedException();
                throw new UserException("Lozinka nije ispravna");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password); 
            _context.Korisnicis.Add(entity);

            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new KorisniciUloge();
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.UlogaId = uloga;
                korisniciUloge.DatumIzmjene = DateTime.Now;

                _context.KorisniciUloges.Add(korisniciUloge);
            }

            _context.SaveChanges();

            return _mapper.Map<mKorisnici>(entity);

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

    }
}
