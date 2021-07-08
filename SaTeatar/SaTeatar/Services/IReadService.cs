using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Services
{
    public interface IReadService<TModel, TSearch>
        where TModel : class where TSearch : class
    {
        IList<TModel> Get(TSearch search = null);
        TModel GetById(int id);
    }
}
