using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Services
{
    public interface IPostavkeObavijestiService : ICRUDService<mPostavkeObavijesti,rPostavkaObavijestiSearch,rPostavkaObavijestiUpsert,rPostavkaObavijestiUpsert>
    {
    }
}
