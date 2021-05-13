using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace fooddeliverysystem.Models
{
    public class Category_tbl
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; }

    }
}