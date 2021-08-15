using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Database;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;

namespace SaTeatar.Services
{
    public class NarudzbaService : BaseCRUDService<mNarudzba, Narudzba, rNarudzbaSearch, rNarudzbaInsert, rNarudzbaUpdate>
        , INarudzbaService
    {
        public NarudzbaService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
