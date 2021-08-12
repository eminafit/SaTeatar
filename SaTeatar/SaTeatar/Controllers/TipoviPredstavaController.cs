using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.WebAPI.Controllers
{
    public class TipoviPredstavaController : BaseCRUDController<mTipoviPredstava, rTipoviPredstavaSearch, rTipoviPredstavaInsert, rTipoviPredstavaUpdate>
    {
        public TipoviPredstavaController(ITipoviPredstavaService service) : base(service)
        {
        }
    }
}
