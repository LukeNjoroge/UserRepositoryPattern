using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using UserApp.Core;

namespace UserRepositoryPattern.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "FullName Required")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "PhoneNo Required")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        public System.DateTime Dob { get; set; }
        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role Required")]
        public int RoleID { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Required")]
        public int GenderID { get; set; }
        public Nullable<int> UserStatus { get; set; }

        public List<SelectListItem> ListRoles { get; set; }

        public List<SelectListItem> ListGender { get; set; }

        [NotMapped]
        public List<Role> RoleList { get; set; }
        [NotMapped]
        public List<Gender> GenderList { get; set; }
    }
}