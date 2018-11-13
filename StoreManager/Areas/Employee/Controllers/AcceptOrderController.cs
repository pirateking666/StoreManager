using StoreManager.Areas.Employee.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Areas.Employee.Controllers
{
    public class AcceptOrderController : Controller
    {
        // GET: Employee/AcceptOrder
        public ActionResult Index()
        {
            if (Session["username"] == null || (int)Session["positionID"] != 2)
            {
                return RedirectToAction("Index", "Login", new { @area = "" });
            }
            ViewBag.Home = "menu-style";
            ViewBag.ChangePassword = "menu-style";
            ViewBag.OfferImportWareHouse = "menu-style";
            
            ViewBag.AcceptOrder = "active-menu";
            ViewBag.ListOrder = new ModifyOrder().GetListForEmployee();
            ViewBag.ListOrderdDetail = new ModifyOrderDetail().GetListOrderDetailForEmployee();
            return View();
        }
        public JsonResult AcceptOrder(int orderID)
        {
            new AcceptOrder().Process(orderID, new ModifyEmployee().GetIDByUsername((string)Session["username"]));
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}