using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UserRepositoryPattern.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> FindById(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Remove(TEntity entity);
    }
}
