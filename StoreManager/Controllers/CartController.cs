using StoreManager.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["listIDProduct"] == null || Session["listQuantityProduct"] == null)
            {
                Session["listIDProduct"] = "";
                Session["listQuantityProduct"] = "";
            }
            ViewBag.Home = "menu-style";
            ViewBag.Login = "menu-style";
            ViewBag.Product = "menu-style";
            ViewBag.Cart = "active-menu";
            ViewBag.ListShoppingCart = new ModifyWareHouse().GetListProductForCart((string)Session["listIDProduct"]);
            return View();
        }
        public JsonResult RemoveCart(int productID)
        {
            Session["listIDProduct"] = new Cart().RemoveCart(productID, (string)Session["listIDProduct"]);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateQuantityCart(string listQuantity)
        {
            if (listQuantity == null)
            {
                //
            }
            else
            {
                Session["listQuantityProduct"] = listQuantity;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckCustomer(string phoneNumber)
        {
            if (new ModifyCustomer().GetCustomerByPhone(phoneNumber) == null)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Customer c = new ModifyCustomer().GetCustomerByPhone(phoneNumber);
                string InfoCus = c.Name + "-" + c.Birth.Day + "-" + c.Birth.Month + "-" + c.Birth.Year + "-" + c.Gender + "-" + c.Phone + "-" + c.Address;
                return Json(InfoCus, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult NewCustomerCheckOut(CustomerModel model)
        {
            new CheckOut().NewCustomerCheckOut(model, (string)Session["listIDProduct"], (string)Session["listQuantityProduct"]);
            Session["listIDProduct"] = null;
            Session["listQuantityProduct"] = null;
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult OldCustomerCheckOut(CustomerModel model)
        {
            new CheckOut().OldCustomerCheckOut(model, (string)Session["listIDProduct"], (string)Session["listQuantityProduct"]);
            Session["listIDProduct"] = null;
            Session["listQuantityProduct"] = null;
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}