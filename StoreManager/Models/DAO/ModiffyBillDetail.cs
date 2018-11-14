using StoreManager.Areas.Admin.Models;
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
        public List<BillModel> GetListForStatistical()
        {
            return new StoreManagerDBContext().BillDetails.Where(x => x.Bill.ModifyDay.Month == DateTime.Now.Month).Select(x => new BillModel { IDBill = x.BillID, IDExport = x.Bill.ExportWareHouseID, IDOrder = (int)x.Bill.OrderID, IDProduct = x.ProductID, Quantity = x.Quantity, Price = x.Price, EmployeeName = x.Bill.Employee.Name, ModifyDay = x.Bill.ModifyDay, CustomerPhone = x.Bill.CustomerPhone }).ToList();
        }
    }
}