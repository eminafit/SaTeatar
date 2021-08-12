using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;

namespace SaTeatar.Services
{
    public interface IPoslaneObavijestiService : ICRUDService<mPoslaneObavijesti,rPoslaneObavijestiSearch,rPoslaneObavijestiInsert,rPoslaneObavijestiUpdate>
    {
    }
}
