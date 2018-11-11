using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Home = "active-menu";
            ViewBag.Login = "menu-style";
            ViewBag.Product = "menu-style";
            ViewBag.Cart = "menu-style";
            if (Session["listIDProduct"] == null || Session["listQuantityProduct"] == null)
            {
                Session["listIDProduct"] = "";
                Session["listQuantityProduct"] = "";
            }
            return View();
        }
    }
}