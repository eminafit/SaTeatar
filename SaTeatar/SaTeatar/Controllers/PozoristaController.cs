using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.WebAPI.Controllers
{
    public class PozoristaController : BaseCRUDController<mPozorista, rPozoristaSearch, rPozoristaInsert, rPozoristaUpdate>
    {
        public PozoristaController(IPozoristaService service)
            :base(service)
        {

        }
    }
}
