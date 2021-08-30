using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.WebAPI.Controllers
{
    public class KorisniciController
        : BaseCRUDController<mKorisnici,rKorisniciSearch,rKorisniciInsert,rKorisniciUpdate>      
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
            :base(service)
        {
            _service = service;
        }

        [HttpGet("GetTrenutniKorisnik")]
        public mKorisnici GetTrenutniKorisnik()
        {
            return _service.GetTrenutniKorisnik();
        }

        [HttpPost("Login")]
        public async Task<mKorisnici> Login(rKorisniciSearch request)
        {
            return await _service.Login(request.KorisnickoIme, request.Prezime);
        }
    }
}
