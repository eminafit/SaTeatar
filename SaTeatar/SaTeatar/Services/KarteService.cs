using AutoMapper;
using SaTeatar.Database;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Services
{
    public class KarteService : BaseCRUDService<mKarta, Karte, rKartaSearch, rKartaInsert, rKartaUpdate>
        , IKarteService
    {
        public KarteService(SaTeatarDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
