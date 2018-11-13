using StoreManager.Areas.Admin.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Admin.Controllers
{
    public class EmployeeManagerController : Controller
    {
        // GET: Admin/EmployeeManager
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
            ViewBag.EmployeeManager = "active-menu";
            ViewBag.Statistical = "menu-style";
            ViewBag.ListEmployee = new ModifyEmployee().GetList();
            return View();
        }
        public JsonResult InsertEmployee(EmployeeManager model)
        {
            return Json(new EmployeeManager().InsertEmployee(model), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUpdateInfo(int employeeID)
        {
            return Json(new ModifyEmployee().GetEmployeeInfo(employeeID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateEmployee(EmployeeManager model)
        {
            new EmployeeManager().UpdateEmployee(model);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEmployee(int employeeID)
        {
            new ModifyEmployee().DeleteEmployeeByID(employeeID);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}