using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;

namespace SaTeatar.WebAPI.Services
{
    public class IzvodjenjaZoneService : BaseCRUDService<mIzvodjenjaZone, IzvodjenjaZone, rIzvodjenjaZoneSearch, rIzvodjenjaZoneInsert, rIzvodjenjaZoneUpdate>
        , IIzvodjenjaZoneService
    {
        public IzvodjenjaZoneService(SaTeatarDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
