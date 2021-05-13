using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooddeliverysystem.Models
{
    public class ProductModel
    {
        Crud_Context cd = new Crud_Context();
        public List<ProductList> GetProductList()
        {
            var prod = cd.Product_TBL.Select(a => new ProductList
            {
                ProductName = a.ProductName,
                Price = a.Price,
                CatId = a.CatId
            }).ToList();
            return prod;
        }

        //ProductList ob = new ProductList();
        //public ProductList GetProductList()
        //{

        //    ob.ProductName = "Burger";
        //    ob.Price = 50;
        //    ob.CatId = 2;
        //    return ob;
        //}

        public bool DeleteProduct(int prodId)
        {
            ProductList prodItem = cd.Product_TBL.SingleOrDefault(a => a.ProductId == prodId);
            cd.Product_TBL.Remove(prodItem);
            cd.SaveChanges();

            return true;
        }

        public ProductList GetProductDetail(int prodId)
        {
            var prodDetail = cd.Product_TBL.SingleOrDefault(a => a.ProductId == prodId);
            if (prodDetail != null)
            {
                return new ProductList
                {
                    ProductName = prodDetail.ProductName,
                    Price = prodDetail.Price,
                    CatId = prodDetail.CatId,
                };
            }
            else
            {
                return null;
            }
        }

        public bool SaveProduct(ProductList model)
        {

            if (model.ProductId == 0)
            {
                return AddItem(model);
            }
            else
            {
                return UpdateProduct(model);
            }
        }
        public bool AddItem(ProductList model)
        {
            ProductList pl = new ProductList();
            var pls = cd.Product_TBL.Select(a => a.ProductId);
            pl.ProductName = model.ProductName;
            pl.Price = model.Price;
            pl.CatId = model.CatId;
            cd.Product_TBL.Add(pl);
            cd.SaveChanges();

            return true;
        }

        public bool UpdateProduct(ProductList model)
        {
            ProductList pl = cd.Product_TBL.SingleOrDefault(a => a.ProductId == model.ProductId);
            pl.ProductName = model.ProductName;
            pl.Price = model.Price;
            pl.CatId = model.CatId;

            cd.SaveChanges();

            return true;
        }

    }
}
