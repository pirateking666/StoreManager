using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyBill
    {
        public void Insert(int employeeID, string customerPhone, int orderID, int exportWareHouseID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Bill b = new Bill();
            b.ID = 0;
            b.ModifyDay = DateTime.Now;
            b.EmployeeID = employeeID;
            b.CustomerPhone = customerPhone;
            b.OrderID = orderID;
            b.ExportWareHouseID = exportWareHouseID;
            db.Bills.Add(b);
            db.SaveChanges();
        }
        public int GetLastIDByemployeeIDCustomerPhoneOrderIDExID(int employeeID, string customerPhone, int orderID, int exportWareHouseID)
        {
            List<Bill> list = new StoreManagerDBContext().Bills.Where(x => x.EmployeeID == employeeID && x.CustomerPhone == customerPhone && x.ExportWareHouseID == exportWareHouseID && x.OrderID == orderID).OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID;
        }
    }
}