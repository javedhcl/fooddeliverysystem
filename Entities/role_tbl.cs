using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace fooddeliverysystem.Models
{
    public class role_tbl
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }


    }
}