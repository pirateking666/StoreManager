using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Admin.Models
{
    public class ImportWareHouseModel
    {
        public int IDImport { get; set; }
        public int IDProduct { get; set; }
        public DateTime ModifyDay { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int StatusID { get; set; }
    }
}