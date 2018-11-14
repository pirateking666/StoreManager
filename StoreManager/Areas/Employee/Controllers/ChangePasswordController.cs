using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Employee.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: Employee/ChangePassword
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "active-menu";
            ViewBag.OfferImportWareHouse = "menu-style";
            ViewBag.AcceptOrder = "menu-style";
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