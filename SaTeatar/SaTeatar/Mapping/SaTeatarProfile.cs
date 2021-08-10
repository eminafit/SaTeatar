using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;

namespace SaTeatar.WebAPI.Mapping
{
    public class SaTeatarProfile : Profile
    {
        public SaTeatarProfile()
        {
            //CreateMap<izvor, destinacija>

            CreateMap<Korisnici, mKorisnici>();
            CreateMap<Uloge, mUloge>();
            CreateMap<KorisniciUloge, mKorisniciUloge>();
            CreateMap<rKorisniciUlogeUpsert, KorisniciUloge>();

            CreateMap<rKorisniciInsert, Korisnici>();
            CreateMap<rKorisniciUpdate, Korisnici>();

            CreateMap<Kupci, mKupci>();
            CreateMap<rKupciInsert, Kupci>();
            CreateMap<rKupciUpdate, Kupci>();


            CreateMap<Pozorista, mPozorista>();
            CreateMap<Zone, mZone>();
            CreateMap<Izvodjenja, mIzvodjenja>();
                //.ForMember(x => x.PozoristeNaziv, y => y.MapFrom(z => z.Pozoriste.Naziv))
                //.ForMember(x => x.PredstavaNaziv, y => y.MapFrom(z => z.Predstava.Naziv));

            //           CreateMap<Azmoon, AzmoonViewModel>()
            //           .ForMember(d => d.CreatorUserName, m => m.MapFrom(s =>
            //s.CreatedBy.UserName))

            CreateMap<rPozoristaInsert, Pozorista>();
            CreateMap<rPozoristaUpdate, Pozorista>();

            CreateMap<Predstave, mPredstave>();
            CreateMap<TipoviPredstava, mTipoviPredstava>().ReverseMap();
            CreateMap<rPredstavaInsert, Predstave>();
            CreateMap<rPredstavaUpdate, Predstave>();

            CreateMap<Djelatnici, mDjelatnici>();
            CreateMap<rDjelatniciInsert, Djelatnici>();
            CreateMap<rDjelatniciUpdate, Djelatnici>();

            CreateMap<rPredstaveDjelatniciUpsert, PredstaveDjelatnici>();
            CreateMap<PredstaveDjelatnici, mPredstaveDjelatnici>();

            CreateMap<VrsteDjelatnika, mVrsteDjelatnika>().ReverseMap();


            CreateMap<Izvodjenja, mIzvodjenja>();
            CreateMap<rIzvodjenjaInsert, Izvodjenja>();
            CreateMap<rIzvodjenjaUpdate, Izvodjenja>();

            CreateMap<Zone, mZone>();
            CreateMap<rZoneInsert, Zone>();
            CreateMap<rZoneUpdate, Zone>();

            CreateMap<IzvodjenjaZone, mIzvodjenjaZone>();
            CreateMap<rIzvodjenjaZoneInsert, IzvodjenjaZone>();
            CreateMap<rIzvodjenjaZoneUpdate, IzvodjenjaZone>();
        }
    }
}
