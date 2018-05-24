using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserApp.Infrastructure;

namespace UserRepositoryPattern.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UserContext _context = new UserContext();
        public IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Edit(TEntity entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> FindById(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _context.Set<TEntity>().Where(predicate);
            return result;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}