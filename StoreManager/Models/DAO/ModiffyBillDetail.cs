using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModiffyBillDetail
    {
        public void Insert(int billID, int productID, int quantity, decimal price)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            BillDetail bd = new BillDetail();
            bd.ID = 0;
            bd.BillID = billID;
            bd.ProductID = productID;
            bd.Quantity = quantity;
            bd.Price = price;
            db.BillDetails.Add(bd);
            db.SaveChanges();
        }
    }
}