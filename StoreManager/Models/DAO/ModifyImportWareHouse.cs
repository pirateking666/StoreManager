using StoreManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyImportWareHouse
    {
        public void Insert(int employeeID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            ImportWareHouse iwh = new ImportWareHouse();
            iwh.ID = 0;
            iwh.ModifyDay = DateTime.Now;
            iwh.StatusID = 1;
            iwh.EmployeeID = employeeID;
            iwh.SupplierID = null;
            db.ImportWareHouses.Add(iwh);
            db.SaveChanges();
        }
        public int GetLastIDByEmployeeID(int employeeID)
        {
            List<ImportWareHouse> list = new StoreManagerDBContext().ImportWareHouses.Where(x => x.EmployeeID == employeeID).OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID;
        }
        public List<ListImportWareHouse> GetListImportWareHouseForAdmin()
        {
            return new StoreManagerDBContext().ImportWareHouses.Where(x => x.StatusID == 1).Select(x => new ListImportWareHouse { ID = x.ID, employeeName = x.Employee.Name, modifyDay = x.ModifyDay }).ToList();
        }
        public void UpdateStatus(int ImportID, int statusID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            ImportWareHouse iwh = db.ImportWareHouses.SingleOrDefault(x => x.ID == ImportID);
            iwh.StatusID = statusID;
            db.SaveChanges();
        }
    }
}