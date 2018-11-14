using StoreManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyImportWareHouseDetail
    {
        public void Insert(int productID, int quantity, decimal price, int employeeID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            ImportWareHouseDetail iwhd = new ImportWareHouseDetail();
            iwhd.ID = 0;
            iwhd.ImportWareHouseID = new ModifyImportWareHouse().GetLastIDByEmployeeID(employeeID);
            iwhd.ProductID = productID;
            iwhd.Quantity = quantity;
            iwhd.Price = price;
            db.ImportWareHouseDetails.Add(iwhd);
            db.SaveChanges();
        }
        public List<ListImportDetail> GetListImportDetailForAdmin()
        {
            return new StoreManagerDBContext().ImportWareHouseDetails.Where(x => x.ImportWareHouse.StatusID == 1).Select(x => new ListImportDetail { ID = x.ImportWareHouseID, productID = x.ProductID, Name = x.Product.Name, Quantity = x.Quantity }).ToList();
        }
        public List<ImportWareHouseDetail> GetListByIWHID(int ImportID)
        {
            return new StoreManagerDBContext().ImportWareHouseDetails.Where(x => x.ImportWareHouseID == ImportID).ToList();
        }
        public List<ImportWareHouseModel> GetListForStatistical()
        {
            return new StoreManagerDBContext().ImportWareHouseDetails.Where(x => x.ImportWareHouse.ModifyDay.Month == DateTime.Now.Month && x.ImportWareHouse.StatusID == 2).Select(x => new ImportWareHouseModel { IDImport = x.ImportWareHouseID, IDProduct = x.ProductID, ModifyDay = x.ImportWareHouse.ModifyDay, Quantity = x.Quantity, Price = x.Price }).ToList();
        }
    }
}