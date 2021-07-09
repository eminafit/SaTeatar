using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Services
{
    public interface IDjelatniciService : ICRUDService <mDjelatnici, rDjelatniciSearch, rDjelatniciInsert, rDjelatniciUpdate>
    {
    }
}
