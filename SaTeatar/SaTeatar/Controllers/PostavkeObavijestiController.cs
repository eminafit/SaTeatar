using SaTeatar.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Requests;
using SaTeatar.Model.Models;
using SaTeatar.Services;

namespace SaTeatar.Controllers
{
    public class PostavkeObavijestiController : BaseCRUDController<mPostavkeObavijesti, rPostavkaObavijestiSearch, rPostavkaObavijestiUpsert, rPostavkaObavijestiUpsert>
    {
        public PostavkeObavijestiController(IPostavkeObavijestiService service) 
            : base(service)
        {
        }
    }
}
