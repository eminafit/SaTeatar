using SaTeatar.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using SaTeatar.Services;

namespace SaTeatar.Controllers
{
    public class KorisniciUlogeController : BaseCRUDController<mKorisniciUloge, rKorisniciUlogeSearch,rKorisniciUlogeUpsert,rKorisniciUlogeUpsert>
    {
        public KorisniciUlogeController(IKorisniciUlogeService service) : base(service)
        {
        }
    }
}
