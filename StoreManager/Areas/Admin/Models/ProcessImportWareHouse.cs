using StoreManager.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Admin.Models
{
    public class ProcessImportWareHouse
    {
        public void AcceptImport(int importID, int supplierID)
        {
            List<ImportWareHouseDetail> list = new ModifyImportWareHouseDetail().GetListByIWHID(importID);
            for (int i = 0; i < list.Count(); i++)
            {
                new ModifyWareHouse().Update(list[i].ProductID, list[i].Quantity);
            }
            new ModifyImportWareHouse().UpdateStatus(importID, 2);
        }
        public void RemoveImport(int importID)
        {
            new ModifyImportWareHouse().UpdateStatus(importID, 3);
        }
    }
}