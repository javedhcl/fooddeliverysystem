using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fooddeliverysystem.Models
{
    public class order_tbl
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalBill { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public user_tbl user_Tbl { get; set; }
        public int product_id { get; set; }
        [ForeignKey("product_id")]
        public product_tbl product_Tbl { get; set; }

    }
}