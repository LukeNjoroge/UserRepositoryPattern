using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Core;

namespace UserApp.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=UserAppConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Gender> Gender { get; set; }
    }
}
