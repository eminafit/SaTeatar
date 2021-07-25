using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BaseReadController<TModel, TSearch>
        : ControllerBase
        where TModel: class where TSearch: class
    {
        protected readonly IReadService<TModel, TSearch> _service;

        public BaseReadController(IReadService<TModel, TSearch> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public virtual IEnumerable<TModel>Get([FromQuery] TSearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public virtual TModel GetById (int id)
        {
            return _service.GetById(id);          
        }
    }
}
