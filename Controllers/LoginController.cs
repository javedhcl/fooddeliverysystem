using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fooddeliverysystem.Models;

namespace fooddeliverysystem.Controllers
{
    public class LoginController : Controller
    {
        Account _account = new Account();
        SessionManager _session = new SessionManager();



        [HttpGet]
        public ActionResult Login()
        {
            Login_tbl model = new Login_tbl();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Login_tbl model)
        {
            if (ModelState.IsValid)
            {
                int? userId = _account.ValidateLogin(model);
                if (userId != null)
                {
                    var userDetail = _account.GetUserDetail(Convert.ToInt32(userId));

                    //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    // Setting userId and User name in session after successful login
                    _session.UserId = userDetail.UserID;
                    _session.UserName = userDetail.Name;
                    _session.isAdmin = userDetail.isAdmin;



                    if (userDetail.isAdmin)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Products", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Username or password");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Username and password is required!!");
            }
            return View(model);
        }



        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            Register model = new Register();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                _account.Register(model);
                return Redirect("/Login/Login");
            }

            return View(model);
        }
    }
}