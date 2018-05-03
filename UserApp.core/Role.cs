using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Core
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> RoleStatus { get; set; }
    }
}
