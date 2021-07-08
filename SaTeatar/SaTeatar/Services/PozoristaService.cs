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
    public class PozoristaService : BaseCRUDService <mPozorista, Pozorista, rPozoristaSearch, rPozoristaInsert, rPozoristaUpdate>
        , IPozoristaService
    {
        public PozoristaService(SaTeatarDbContext context, IMapper mapper)
            :base(context, mapper)
        {

        }
    }
}
