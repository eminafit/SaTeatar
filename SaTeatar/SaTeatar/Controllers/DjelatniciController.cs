using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.WebAPI.Controllers
{
    public class DjelatniciController : BaseCRUDController<mDjelatnici, rDjelatniciSearch, rDjelatniciInsert, rDjelatniciUpdate>
    {
        public DjelatniciController(IDjelatniciService service) 
            : base(service)
        {
        }
    }
}
