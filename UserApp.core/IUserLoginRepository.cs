using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Core
{
    public interface IUserLoginRepository
    {
        IEnumerable<User> GetUsers();

        void Add(User entity);

        void Edit(User entity);

        void Remove(User entity);

        IEnumerable<User> FindById(Expression<Func<User, bool>> predicate);
    }
}
