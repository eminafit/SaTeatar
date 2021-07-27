using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.WebAPI.Controllers
{
    public class PredstavaController : BaseCRUDController<mPredstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
    {
        public PredstavaController(IPredstavaService service)
            : base(service)
        {
        }
    }
}
