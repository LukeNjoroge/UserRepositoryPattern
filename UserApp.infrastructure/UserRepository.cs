using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Core;
using System.Linq.Expressions;

namespace UserApp.Infrastructure
{
    public class UserRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UserContext context = new UserContext();
        
        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Edit(TEntity entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<TEntity> FindById(Expression<Func<TEntity, bool>> predicate)
        {
            var result = context.Set<TEntity>().Where(predicate);
            return result;
        }

        public IEnumerable<TEntity> GetUsers()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
