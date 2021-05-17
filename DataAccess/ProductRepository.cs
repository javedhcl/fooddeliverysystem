using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooddeliverysystem.Models
{
    public class ProductRepository
    {
        Crud_Context cd = new Crud_Context();
        public List<ProductModel> GetProductList()
        {
            var prod = cd.Product_TBL.Select(a => new ProductModel
            {
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                Price = a.Price,
                CatId = a.CatId
            }).ToList();
            return prod;
        }

        public bool DeleteProduct(int prodId)
        {
            ProductList prodItem = cd.Product_TBL.SingleOrDefault(a => a.ProductId == prodId);
            cd.Product_TBL.Remove(prodItem);
            cd.SaveChanges();

            return true;
        }

        //internal bool SaveProduct(ProductRepository model)
        //{
        //    throw new NotImplementedException();
        //}

        public ProductList GetProductDetail(int prodId)
        {
            var prodDetail = cd.Product_TBL.FirstOrDefault(a => a.ProductId == prodId);
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

        public bool SaveProduct(ProductModel model)
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
        public bool AddItem(ProductModel model)
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

        public bool UpdateProduct(ProductModel model)
        {
            ProductList pl = cd.Product_TBL.FirstOrDefault(a => a.ProductId == model.ProductId);
            pl.ProductName = model.ProductName;
            pl.Price = model.Price;
            pl.CatId = model.CatId;

            cd.SaveChanges();

            return true;
        }

    }
}
