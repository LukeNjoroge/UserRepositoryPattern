using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Core
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }

        public System.DateTime Dob { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int GenderID { get; set; }
        public Nullable<int> UserStatus { get; set; }
    }
}
