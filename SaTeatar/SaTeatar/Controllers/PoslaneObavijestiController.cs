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
    public class PoslaneObavijestiController : BaseCRUDController<mPoslaneObavijesti, rPoslaneObavijestiSearch, rPoslaneObavijestiInsert, rPoslaneObavijestiUpdate>
    {
        public PoslaneObavijestiController(IPoslaneObavijestiService service) 
            : base(service)
        {
        }
    }
}
