using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaTeatar.Database;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.Services
{
    public class KarteService : BaseCRUDService<mKarta, Karte, rKartaSearch, rKartaInsert, rKartaUpdate>
        , IKarteService
    {
        public KarteService(SaTeatarBpContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override mKarta GetById(int id)
        {
            var upit = _context.Karte.Include(x => x.Izvodjenje.Predstava).Include(x => x.Izvodjenje.Pozoriste).Include(y => y.IzvodjenjeZona.Zona).Include(x => x.Kupac).AsQueryable();
            var karta = upit.Where(x => x.KartaId == id).FirstOrDefaultAsync();

            mKarta mk = new mKarta()
            {
                KartaId = karta.Result.KartaId,
                KupacId=karta.Result.KupacId,
                IzvodjenjeId=karta.Result.IzvodjenjeId,
                IzvodjenjeZonaId=karta.Result.IzvodjenjeZonaId,
                Qrcode=karta.Result.Qrcode,
                PredstavaNaziv = karta.Result.Izvodjenje.Predstava.Naziv,
                PozoristeNaziv = karta.Result.Izvodjenje.Pozoriste.Naziv,
                Cijena = karta.Result.IzvodjenjeZona.Cijena,
                BrKarte = karta.Result.BrKarte,
                ZonaNaziv = karta.Result.IzvodjenjeZona.Zona.Naziv,
                Placeno=karta.Result.Placeno,
                DatumIzvodjenja=karta.Result.Izvodjenje.DatumVrijeme,
               
            };

            return mk;
        }

        public override IList<mKarta> Get(rKartaSearch search)
        {

            if (search.DatumOd.CompareTo(DateTime.MinValue.AddHours(1)) > 0 && search.DatumDo.CompareTo(DateTime.MinValue.AddHours(1)) > 0)
            {
                var upitn = _context.NarudzbaStavke.Include(x => x.Narudzba).Include(x => x.Karta).Include(x=>x.Karta.Kupac).AsQueryable();

                upitn = upitn.Where(x =>x.Karta.Izvodjenje.PozoristeId==search.PozoristeId 
                                    && x.Karta.Placeno==true
                                    && x.Narudzba.Datum.CompareTo(search.DatumOd) >= 0 
                                    && x.Narudzba.Datum.CompareTo(search.DatumDo) <= 0);
                var lk = upitn.Select(x => x.Karta).ToList();
                return _mapper.Map<List<mKarta>>(lk);
            }
            else
            {
                var upit = _context.Karte.Include(x => x.Izvodjenje.Predstava).Include(x => x.Izvodjenje.Pozoriste).Include(y => y.IzvodjenjeZona.Zona).Include(x => x.Kupac).AsQueryable();

                if (search.KupacId != 0)
                {
                    upit = upit.Where(x => x.KupacId == search.KupacId);
                }

                if (search.IzvodjenjeZonaId != 0)
                {
                    upit = upit.Where(x => x.IzvodjenjeZonaId == search.IzvodjenjeZonaId);
                }

                if (search.PredstavaId != 0)
                {
                    upit = upit.Where(x => x.Izvodjenje.PredstavaId == search.PredstavaId);
                }

                if (search.PozoristeId != 0)
                {
                    upit = upit.Where(x => x.Izvodjenje.PozoristeId == search.PozoristeId);
                }



                upit = upit.Where(x => x.Placeno == search.Placeno);


                var lista = upit.ToList();
                var mlista = _mapper.Map<List<mKarta>>(lista);

                foreach (var item in upit)
                {
                    foreach (var k in mlista)
                    {
                        if (item.KartaId == k.KartaId)
                        {
                            k.PredstavaNaziv = item.Izvodjenje.Predstava.Naziv;
                            k.PredstavaId = item.Izvodjenje.Predstava.PredstavaId;
                            k.PozoristeId = item.Izvodjenje.Pozoriste.PozoristeId;
                            k.PozoristeNaziv = item.Izvodjenje.Pozoriste.Naziv;
                            k.ZonaNaziv = item.IzvodjenjeZona.Zona.Naziv;
                            k.Cijena = item.IzvodjenjeZona.Cijena;
                            k.DatumIzvodjenja = item.Izvodjenje.DatumVrijeme;

                        }
                    }
                }

                return mlista;
            }
        }
    }
}
