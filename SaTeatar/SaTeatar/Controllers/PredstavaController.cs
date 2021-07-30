using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using SaTeatar.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SaTeatar.WebAPI.Controllers
{
    public class PredstavaController : BaseCRUDController<mPredstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
    {
        public PredstavaController(IPredstavaService service)
            : base(service)
        {
        }

        [AllowAnonymous]
        [HttpGet("Recommend/{id}")]
        public List<mPredstave> Recommend(int id)
        {
            return (_service as IPredstavaService).Recommend(id);
        }
    }
}
