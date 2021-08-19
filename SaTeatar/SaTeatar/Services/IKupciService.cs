using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Services
{
    public interface IKupciService : ICRUDService<mKupci,rKupciSearch, rKupciInsert, rKupciUpdate>
    {
        Task<mKupci> Login(string username, string password);
        Task<mKupci> Authenticate(rKupciAuth request);
        Task<mKupci> Registracija(rKupciInsert request);


    }

}
