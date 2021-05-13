using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fooddeliverysystem.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> UserID { get; set; }
        [ForeignKey("UserID")]
        public user_tbl user_tbls { get; set; }
        public Nullable<int> RoleID { get; set; }
        [ForeignKey("RoleID")]
        public role_tbl role_Tbls { get; set; }
    }
}