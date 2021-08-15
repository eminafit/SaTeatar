using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Services;
using SaTeatar.WebAPI.Controllers;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.Controllers
{
    public class NarudzbaController : BaseCRUDController<mNarudzba, rNarudzbaSearch, rNarudzbaInsert, rNarudzbaUpdate>
    {
        public NarudzbaController(INarudzbaService service) : base(service)
        {
        }
    }
}
