using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Services;
using SaTeatar.WebAPI.Controllers;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Controllers
{
    public class KarteController : BaseCRUDController<mKarta, rKartaSearch, rKartaInsert, rKartaUpdate>
    {
        public KarteController(IKarteService service) : 
            base(service)
        {
        }
    }
}
