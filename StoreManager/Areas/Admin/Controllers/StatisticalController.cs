using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        // GET: Admin/Statistical
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.AcceptImportWareHouse = "menu-style";
            ViewBag.ProductManager = "menu-style";
            ViewBag.EmployeeManager = "menu-style";
            ViewBag.Statistical = "active-menu";
            ViewBag.ListProduct = new ModifyProduct().GetListForStatistical();
            ViewBag.ListWareHouseImport = new ModifyImportWareHouseDetail().GetListForStatistical();
            ViewBag.ListBill = new ModiffyBillDetail().GetListForStatistical();
            return View();
        }
    }
}