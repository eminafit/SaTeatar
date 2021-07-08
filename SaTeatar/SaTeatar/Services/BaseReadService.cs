﻿using AutoMapper;
using SaTeatar.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Services
{
    public class BaseReadService <TModel, TDatabase, TSearch>
        : IReadService<TModel, TSearch>
        where TModel : class where TDatabase : class where TSearch: class
    {
        protected readonly SaTeatarDbContext _context;
        protected readonly IMapper _mapper;
        public BaseReadService(SaTeatarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //search se overridea ako treba
        public virtual IList<TModel> Get(TSearch search) 
        {
            var entity = _context.Set<TDatabase>();
            var list = entity.ToList();

            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var set = _context.Set<TDatabase>();
            var entity = set.Find(id);

            return _mapper.Map<TModel>(entity);
        }
    }
}
