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
            CreateMap<PostavkeObavijesti, mPostavkeObavijesti>();
            CreateMap<rPostavkaObavijestiUpsert, PostavkeObavijesti>();

            CreateMap<PoslaneObavijesti, mPoslaneObavijesti>();
            CreateMap<rPoslaneObavijestiUpdate, PoslaneObavijesti>();
            CreateMap<rPoslaneObavijestiInsert, PoslaneObavijesti>();


            CreateMap<Ocjene, mOcjene>();
            CreateMap<rOcjeneUpdate, Ocjene>();
            CreateMap<rOcjeneInsert, Ocjene>();

            //CreateMap<izvor, destinacija>
            CreateMap<Karte, mKarta>();
            CreateMap<rKartaInsert, Karte>();
            CreateMap<rKartaUpdate, Karte>();

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


            CreateMap<rPozoristaInsert, Pozorista>();
            CreateMap<rPozoristaUpdate, Pozorista>();

            CreateMap<Predstave, mPredstave>();
            CreateMap<rPredstavaInsert, Predstave>();
            CreateMap<rPredstavaUpdate, Predstave>();

            CreateMap<TipoviPredstava, mTipoviPredstava>().ReverseMap();
            CreateMap<rTipoviPredstavaInsert, TipoviPredstava>();
            CreateMap<rTipoviPredstavaUpdate, TipoviPredstava>();

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
