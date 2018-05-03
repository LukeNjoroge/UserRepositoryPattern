using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        void Add(TEntity entity);

        void Edit(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetUsers();

        IEnumerable<TEntity> FindById(Expression<Func<TEntity, bool>> predicate);
    }
}
