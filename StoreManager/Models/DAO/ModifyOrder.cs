using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyOrder
    {
        public void Insert(string customerPhone)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Order o = new Order();
            o.ID = 0;
            o.ModifyDay = DateTime.Now;
            o.CustomerPhone = customerPhone;
            db.Orders.Add(o);
            db.SaveChanges();
        }
        public int GetIDByCustomerPhone(string customerPhone)
        {
            List<Order> list = new StoreManagerDBContext().Orders.Where(x => x.CustomerPhone == customerPhone).OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID;
        }
    }
}