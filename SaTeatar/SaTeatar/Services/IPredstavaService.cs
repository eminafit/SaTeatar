using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Services
{
    public interface IPredstavaService : ICRUDService<mPredstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
    {
        List<mPredstave> Recommend(int id);
    }
}
