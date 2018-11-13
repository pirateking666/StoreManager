using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyExportWareHouseDetail
    {
        public void Insert(int productID, int quantity, int ID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            ExportWareHouseDetail ewhd = new ExportWareHouseDetail();
            ewhd.ID = 0;
            ewhd.ProductID = productID;
            ewhd.Quantity = quantity;
            ewhd.ExportWareHouseID = ID;
            db.ExportWareHouseDetails.Add(ewhd);
            db.SaveChanges();
        }
    }
}