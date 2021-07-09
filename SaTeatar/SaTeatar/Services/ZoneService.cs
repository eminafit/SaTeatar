﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;

namespace SaTeatar.WebAPI.Services
{
    public class ZoneService : BaseCRUDService<mZone, Zone, rZoneSearch, rZoneInsert, rZoneUpdate>
        , IZoneService
    {
        public ZoneService(SaTeatarDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override IList<mZone> Get(rZoneSearch search)
        {
            var upit = _context.Zone.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                upit = upit.Where(x => x.Naziv.Contains(search.Naziv));
            }

            var lista = upit.ToList();
            var rezultat = _mapper.Map<List<mZone>>(lista);
            return rezultat;   
        }
    }
}
