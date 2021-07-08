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
        //IList<Model.Korisnici> GetAll(KorisniciSearchRequest search);

        //Model.Korisnici GetById(int id);

        //Model.Korisnici Insert(KorisniciInsertRequest korisnici);

        //Model.Korisnici Update(int id, KorisniciUpdateRequest korisnici);

        //Task<Model.Korisnici> Login(string username, string password);
    }
}
