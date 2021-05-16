using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace fooddeliverysystem.Models
{
    public class ProductModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CatId { get; set; }
    }
}