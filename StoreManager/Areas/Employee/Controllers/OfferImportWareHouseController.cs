﻿using StoreManager.Areas.Employee.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Employee.Controllers
{
    public class OfferImportWareHouseController : Controller
    {
        // GET: Employee/OfferImportWareHouse
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.OfferImportWareHouse = "active-menu";
            
            ViewBag.AcceptOrder = "menu-style";
            ViewBag.ListWareHouse = new ModifyWareHouse().GetListWareHouse();
            ViewBag.ListProduct = new SelectList(new ModifyProduct().GetList(), "ID", "Name");
            return View();
        }
        public JsonResult OfferImport(string listProduct, string listQuantity)
        {
            new ImportWareHouseModel().OfferImportWareHouse(listProduct,listQuantity,(string)Session["username"]);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}