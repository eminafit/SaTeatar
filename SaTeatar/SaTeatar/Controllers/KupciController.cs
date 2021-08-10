using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Services;
using SaTeatar.WebAPI.Controllers;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.Controllers
{
    public class KupciController : BaseCRUDController<mKupci, rKupciSearch, rKupciInsert, rKupciUpdate>
    {
        public KupciController(IKupciService service) 
            : base(service)
        {
        }

    }
}
