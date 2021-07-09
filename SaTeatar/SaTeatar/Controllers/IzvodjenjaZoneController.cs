using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.WebAPI.Controllers
{
    public class IzvodjenjaZoneController : BaseCRUDController<mIzvodjenjaZone, rIzvodjenjaZoneSearch, rIzvodjenjaZoneInsert, rIzvodjenjaZoneUpdate>
    {
        public IzvodjenjaZoneController(IIzvodjenjaZoneService service) : base(service)
        {
        }
    }
}
