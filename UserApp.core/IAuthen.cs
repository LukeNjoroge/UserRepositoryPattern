using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.core
{
    public interface IAuthen
    {
        bool CheckLogin(String Username, String Password);
        bool Logout();
    }
}
