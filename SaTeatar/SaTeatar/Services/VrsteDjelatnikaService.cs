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
    public class VrsteDjelatnikaService : BaseCRUDService<mVrsteDjelatnika, VrsteDjelatnika, object, rVrsteDjelatnikaUpsert, rVrsteDjelatnikaUpsert>
        , IVrsteDjelatnikaService
    {
        public VrsteDjelatnikaService(SaTeatarBpContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
