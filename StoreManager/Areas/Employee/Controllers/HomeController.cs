using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        // GET: Employee/Home
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "active-menu";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.OfferImportWareHouse = "menu-style";
            ViewBag.ExportWareHouse = "menu-style";
            ViewBag.AddBill = "menu-style";
            ViewBag.AcceptOrder = "menu-style";
            return View();
        }
    }
}