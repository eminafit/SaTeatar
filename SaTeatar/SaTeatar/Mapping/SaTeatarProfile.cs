using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;

namespace SaTeatar.WebAPI.Mapping
{
    public class SaTeatarProfile : Profile
    {
        public SaTeatarProfile()
        {
            CreateMap<Korisnici, mKorisnici>();
            CreateMap<Uloge, mUloge>();
            CreateMap<KorisniciUloge, mKorisniciUloge>();
            CreateMap<rKorisniciInsert, Korisnici>();
            CreateMap<rKorisniciUpdate, Korisnici>();
        }
    }
}
