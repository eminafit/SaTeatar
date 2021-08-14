using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Services;
using SaTeatar.WebAPI.Controllers;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.Controllers
{
    public class KupciController : BaseCRUDController<mKupci, rKupciSearch, rKupciInsert, rKupciUpdate>
    {
        private readonly IKupciService _service;
        public KupciController(IKupciService service) 
            : base(service)
        {
            _service = service;
        }

        [HttpPost("Authenticate")]
        public async Task<mKupci> Authenticate(rKupciAuth request)
        {
            return await _service.Authenticate(request);
        }

        [HttpPost("Login")]
        public async Task<mKupci> Login(string username, string password )
        {
            return await _service.Login(username,password);
        }
    }
}
