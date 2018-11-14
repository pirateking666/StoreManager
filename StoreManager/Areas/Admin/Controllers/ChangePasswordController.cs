using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Admin.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: Admin/ChangePassword
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "active-menu";
            ViewBag.AcceptImportWareHouse = "menu-style";
            ViewBag.ProductManager = "menu-style";
            ViewBag.EmployeeManager = "menu-style";
            ViewBag.Statistical = "menu-style";
            return View();
        }
        public JsonResult ChangePasswordVerify(ChangePassword model)
        {
            string username = Session["username"].ToString();
            ChangePassword cp = new ChangePassword();
            model.username = username;
            string check = cp.ChangePasswordVeri(model);
            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}