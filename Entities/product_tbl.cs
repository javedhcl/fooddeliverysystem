using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fooddeliverysystem.Models
{
    public class product_tbl
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int price { get; set; }

    }
    
}