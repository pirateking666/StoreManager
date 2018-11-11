using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["listIDProduct"] == null || Session["listQuantityProduct"] == null)
            {
                Session["listIDProduct"] = "";
                Session["listQuantityProduct"] = "";
            }
            ViewBag.Home = "menu-style";
            ViewBag.Login = "active-menu";
            ViewBag.Product = "menu-style";
            ViewBag.Cart = "menu-style";
            return View();
        }
        public JsonResult VerifyLogin(LoginModel model)
        {
            string check = new LoginModel().VerifyLogin(model);
            if (check == "Admin")
            {
                Session["username"] = model.userName;
                Session["positionID"] = 1;
            }
            else if (check == "Sale")
            {
                Session["username"] = model.userName;
                Session["positionID"] = 2;
                Session["employeeID"] = new ModifyEmployee().GetIDByUsername(model.userName);
            }
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Login", new { @area = "" });
        }
    }
}