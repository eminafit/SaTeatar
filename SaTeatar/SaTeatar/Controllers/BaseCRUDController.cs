using Microsoft.AspNetCore.Mvc;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Controllers
{
    public class BaseCRUDController<TModel, TSearch, TInsert, TUpdate>
        : BaseReadController<TModel, TSearch>
        where TModel : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly ICRUDService<TModel, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> crudService)
            : base(crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public TModel Insert([FromBody] TInsert request)
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update (int id, [FromBody] TUpdate request)
        {
            return _crudService.Update(id, request);
        }

    }
}
