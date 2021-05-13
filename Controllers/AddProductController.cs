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
        ProductModel prod = new ProductModel();
        public Crud_Context cd = new Crud_Context();

        public ActionResult Index()
        {
            //List<ProductList> product = prod.GetProductList();
            return View();
            //return View(cd.Product_TBL.ToList());
        }

        public ActionResult GetProductList()
        {
            List<ProductList> prodList = prod.GetProductList();
            return View("ProductList", prodList);
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductList model)
        {
            bool isSuccess = prod.SaveProduct(model);
            return Json(new { IsSuccess = isSuccess });
        }
        [HttpGet]
        public ActionResult GetProductDetail(int prodId)
        {
            ProductList prodDetail = prod.GetProductDetail(prodId);
            return Json(prodDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeletePlan(int prodId)
        {
            bool isSuccess = prod.DeleteProduct(prodId);
            return Json(new { IsSuccess = isSuccess });
        }

        [HttpGet]
        public ActionResult AddItem()
        {
            List<ProductList> prodDetail = prod.GetProductList();
            return PartialView("~/Views/AddProduct/GetProductList", prodDetail);
        }
    }
}