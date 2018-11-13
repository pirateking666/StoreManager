using StoreManager.Areas.Employee.Models;
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
        public List<ListOrderDetail> GetListOrderDetailForEmployee()
        {
            return new StoreManagerDBContext().OrderDetails.Where(x => x.Order.StatusID == 1).Select(x => new ListOrderDetail { productID = x.ProductID, orderID = x.OrderID, productName = x.Product.Name, quantity = x.Quantity }).ToList();
        }
        public List<OrderDetail> GetListByOrderID(int OrderID)
        {
            return new StoreManagerDBContext().OrderDetails.Where(x => x.OrderID == OrderID).ToList();
        }
    }
}