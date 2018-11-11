using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyOrderDetail
    {
        public void Insert(int orderID, int productID, int quantity)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            OrderDetail od = new OrderDetail();
            od.ID = 0;
            od.OrderID = orderID;
            od.ProductID = productID;
            od.Quantity = quantity;
            db.OrderDetails.Add(od);
            db.SaveChanges();
        }
    }
}