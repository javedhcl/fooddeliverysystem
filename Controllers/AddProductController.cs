using fooddeliverysystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace fooddeliverysystem.Controllers
{
    public class AddProductController : Controller
    {
        ProductRepository productRep = new ProductRepository();
        
        public ActionResult Index()
        {
            List<ProductModel> prod = productRep.GetProductList();
            return View(prod);
        }

        public ActionResult GetProductList()
        {
            List<ProductModel> prodList = productRep.GetProductList();
            return View("GetProductList", prodList);
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductRepository model)
        {
            bool isSuccess = productRep.SaveProduct(model);
            return Json(new { IsSuccess = isSuccess });
        }
        [HttpGet]
        public ActionResult GetProductDetail(int prodId)
        {
            ProductList prodDetail = productRep.GetProductDetail(prodId);
            return Json(prodDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int prodId)
        {
            bool isSuccess = productRep.DeleteProduct(prodId);
            return Json(new { IsSuccess = isSuccess });
        }

        [HttpGet]
        public ActionResult AddItem(ProductModel model)
        {
            bool prodDetail = productRep.AddItem(model);
            return PartialView("~/Views/AddProduct/GetProductList", prodDetail);
        }

        [HttpGet]
        public ActionResult UpdateProduct(ProductModel model)
        {
            bool prodDetail = productRep.UpdateProduct(model);
            return PartialView("~/Views/AddProduct/GetProductList", prodDetail);
        }

    }
}