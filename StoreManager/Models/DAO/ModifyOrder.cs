using StoreManager.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyOrder
    {
        public List<ListOrder> GetListForEmployee()
        {
            return new StoreManagerDBContext().Orders.Where(x => x.StatusID == 1).Select(x => new ListOrder { ID = x.ID, customerPhone = x.CustomerPhone, customerName = x.Customer.Name, customerAddress = x.Customer.Address, modifyDay = x.ModifyDay }).ToList();
        }
        public void Insert(string customerPhone)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Order o = new Order();
            o.ID = 0;
            o.ModifyDay = DateTime.Now;
            o.CustomerPhone = customerPhone;
            o.StatusID = 1;
            db.Orders.Add(o);
            db.SaveChanges();
        }
        public int GetIDByCustomerPhone(string customerPhone)
        {
            List<Order> list = new StoreManagerDBContext().Orders.Where(x => x.CustomerPhone == customerPhone).OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID;
        }
        public string GetCustomerPhoneByID(int ID)
        {
            return new StoreManagerDBContext().Orders.SingleOrDefault(x => x.ID == ID).CustomerPhone;
        }
        public void UpdateStatusByID(int orderID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Order o = db.Orders.SingleOrDefault(x => x.ID == orderID);
            o.StatusID = 2;
            db.SaveChanges();
        }
    }
}