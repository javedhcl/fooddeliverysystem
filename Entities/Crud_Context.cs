using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace fooddeliverysystem.Models
{
    public class Crud_Context : DbContext
    {
        public Crud_Context() : base("SQLCONN")
        {

        }
        public DbSet<Login_tbl> Login_tbls { get; set; }
        public DbSet<order_tbl> order_tbls { get; set; }
        public DbSet<product_tbl> product_tbls { get; set; }
        public DbSet<role_tbl> role_tbls { get; set; }
        public DbSet<user_tbl> user_tbls { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<UserRole> userRoles { get; set; }

        public DbSet<ProductList> Product_TBL { get; set; }


    }

}