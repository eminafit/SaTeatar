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
    public class IzvodjenjaController : BaseCRUDController<mIzvodjenja, rIzvodjenjaSearch, rIzvodjenjaInsert, rIzvodjenjaUpdate>
    {
        public IzvodjenjaController(IIzvodjenjaService service) : base(service)
        {
        }
    }
}
