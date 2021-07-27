using AutoMapper;
using SaTeatar.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI.Services
{
    public class BaseCRUDService <TModel, TDatabase, TSearch, TInsert, TUpdate>
        : BaseReadService<TModel,TDatabase,TSearch>
        , ICRUDService<TModel, TSearch, TInsert, TUpdate>
        where TModel: class where TDatabase: class where TSearch: class where TInsert: class where TUpdate: class
    {
        public BaseCRUDService(SaTeatarDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var set = _context.Set<TDatabase>();
            TDatabase entity = _mapper.Map<TDatabase>(request);
            set.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var set = _context.Set<TDatabase>();
            var entity = set.Find(id);
            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Delete(int Id)
        {
            var entity = _context.Set<TDatabase>().Find(Id);
            if (entity == null)
                throw new ArgumentNullException();
            var x = entity;
            _context.Set<TDatabase>().Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(x);
        }


    }
}
