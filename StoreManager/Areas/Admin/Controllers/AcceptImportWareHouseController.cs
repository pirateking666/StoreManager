using StoreManager.Areas.Admin.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Admin.Controllers
{
    public class AcceptImportWareHouseController : Controller
    {
        // GET: Admin/AcceptImportWareHouse
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.AcceptImportWareHouse = "active-menu";
            ViewBag.ProductManager = "menu-style";
            ViewBag.EmployeeManager = "menu-style";
            ViewBag.Statistical = "menu-style";
            ViewBag.ListAcceptImport = new ModifyImportWareHouse().GetListImportWareHouseForAdmin();
            ViewBag.DropSupplier = new SelectList(new ModifySupplier().GetList(), "ID", "Name");
            ViewBag.ListImportDetail = new ModifyImportWareHouseDetail().GetListImportDetailForAdmin();
            return View();
        }
        public JsonResult AcceptImport(int importID, int supplierID)
        {
            new ProcessImportWareHouse().AcceptImport(importID, supplierID);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemoveImport(int importID)
        {
            new ProcessImportWareHouse().RemoveImport(importID);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}