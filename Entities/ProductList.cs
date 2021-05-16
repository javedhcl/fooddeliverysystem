using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fooddeliverysystem.Models
{
    public class ProductList
    {
        public ProductList()
        {
            
        }
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public Category_tbl category_tbl { get; set; }

    }

}