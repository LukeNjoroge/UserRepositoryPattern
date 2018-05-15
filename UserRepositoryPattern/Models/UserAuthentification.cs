using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserApp.core;
using UserApp.Infrastructure;

namespace UserRepositoryPattern.Models
{
    public class UserAuthentification : IAuthen
    {
        private readonly UserContext _context;
        public UserAuthentification(UserContext context)
        {
            _context = context;
        }

        public bool CheckLogin(string Username, string Password)
        {
            return _context.Users.SingleOrDefault(x => x.Username == Username && x.Password == Password) != null;
        }

        public bool Logout()
        {
            return true;
        }
    }
}