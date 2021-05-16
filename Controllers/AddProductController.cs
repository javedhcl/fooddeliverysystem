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
            return View();
        }

        public ActionResult GetProductList()
        {
            List<ProductList> prodList = productRep.GetProductList();
            return View("ProductList", prodList);
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
        public ActionResult AddItem()
        {
            List<ProductList> prodDetail = productRep.GetProductList();
            return PartialView("~/Views/AddProduct/GetProductList", prodDetail);
        }
    }
}