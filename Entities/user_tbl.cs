using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fooddeliverysystem.Models
{
    public class user_tbl
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public role_tbl role_Tbls { get; set; }
        public List<Login_tbl> login_Tbls { get; set; }

        public List<UserRole> userRoles { get; set; }


    }
}