using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "active-menu";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.AcceptImportWareHouse = "menu-style";
            ViewBag.ProductManager = "menu-style";
            ViewBag.EmployeeManager = "menu-style";
            ViewBag.Statistical = "menu-style";
            return View();
        }
    }
}