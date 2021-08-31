using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;


namespace SaTeatar.WebAPI.Services
{
    public interface IKorisniciService : ICRUDService<mKorisnici, rKorisniciSearch, rKorisniciInsert, rKorisniciUpdate>
    {
        Task<mKorisnici> Login(string username, string password);

        mKorisnici GetTrenutniKorisnik();
    }
}
