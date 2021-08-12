using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;

namespace SaTeatar.WebAPI.Services
{
    public class TipoviPredstavaService : BaseCRUDService<mTipoviPredstava, TipoviPredstava, rTipoviPredstavaSearch, rTipoviPredstavaInsert, rTipoviPredstavaUpdate>
        , ITipoviPredstavaService
    {
        public TipoviPredstavaService(SaTeatarDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
