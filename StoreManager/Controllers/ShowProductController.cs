using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Controllers
{
    public class ShowProductController : Controller
    {
        // GET: ShowProduct
        public ActionResult Index()
        {
            if (Session["listIDProduct"] == null || Session["listQuantityProduct"] == null)
            {
                Session["listIDProduct"] = "";
                Session["listQuantityProduct"] = "";
            }
            ViewBag.Home = "menu-style";
            ViewBag.Login = "menu-style";
            ViewBag.Product = "active-menu";
            ViewBag.Cart = "menu-style";
            ViewBag.ListProduct = new ModifyProduct().GetList();
            ViewBag.ListCart = Session["listIDProduct"].ToString().Split('-');
            return View();
        }
        public JsonResult UpdateCart(string ID, string Quantity)
        {
            if (Session["listIDProduct"].ToString().Split('-').Count() == 6 && Session["listIDProduct"] != null)
            {
                return Json("Giỏ hàng không thể chứa quá 6 sản phẩm", JsonRequestBehavior.AllowGet);
            }
            Session["listIDProduct"] += ID;
            Session["listQuantityProduct"] += Quantity;
            string s = (string)Session["listIDProduct"];
            string ss = (string)Session["listQuantityProduct"];
            return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}