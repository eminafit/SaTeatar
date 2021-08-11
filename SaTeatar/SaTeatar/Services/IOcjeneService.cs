using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Services
{
    public interface IOcjeneService : ICRUDService<mOcjene, rOcjeneSearch, rOcjeneInsert, rOcjeneUpdate>
    { 
    }
}
