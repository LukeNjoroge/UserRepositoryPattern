using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApp.Core;

namespace UserRepositoryPattern.ViewModels
{
    public class UserViewModel
    {
        public User UserAdd { get; set; }

        public List<SelectListItem> ListRoles { get; set; }
        public int RoleID { get; set; }

        public List<SelectListItem> ListGender { get; set; }

        [NotMapped]
        public List<Role> RoleList { get; set; }
        [NotMapped]
        public List<Gender> GenderList { get; set; }
    }
}