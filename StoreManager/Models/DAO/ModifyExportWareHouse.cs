using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyExportWareHouse
    {
        public void Insert(int employeeID, string customerPhone)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            ExportWareHouse ewh = new ExportWareHouse();
            ewh.ID = 0;
            ewh.ModifyDay = DateTime.Now;
            ewh.EmployeeID = employeeID;
            ewh.CustomerPhone = customerPhone;
            db.ExportWareHouses.Add(ewh);
            db.SaveChanges();
        }
        public int GetLastIDByEmployeeIDAndCustomerPhone(int employeeID, string customerPhone)
        {
            List<ExportWareHouse> list = new StoreManagerDBContext().ExportWareHouses.Where(x => x.EmployeeID == employeeID && x.CustomerPhone == customerPhone).OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID;
        }
    }
}