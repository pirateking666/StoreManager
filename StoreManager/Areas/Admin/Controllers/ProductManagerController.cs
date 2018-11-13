using StoreManager.Areas.Admin.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Admin.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: Admin/ProductManager
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 1)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.AcceptImportWareHouse = "menu-style";
            ViewBag.ProductManager = "active-menu";
            ViewBag.EmployeeManager = "menu-style";
            ViewBag.Statistical = "menu-style";
            ViewBag.ListProduct = new ModifyProduct().GetListForAdmin();
            ViewBag.ListProducer = new SelectList(new ModifyProducer().GetList(), "ID", "Name");
            ViewBag.ListProductType = new SelectList(new ModifyProductType().GetList(), "ID", "Name");
            return View();
        }
        public JsonResult InsertProduct(ProductManager model)
        {
            new ProductManager().InsertProduct(model);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInfo(int ID)
        {
            return Json(new ModifyProduct().GetInfo(ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateProduct(ProductManager model)
        {
            new ProductManager().UpdateProduct(model);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProduct(int productID)
        {
            return Json(new ProductManager().DeleteProduct(productID), JsonRequestBehavior.AllowGet);
        }
    }
}