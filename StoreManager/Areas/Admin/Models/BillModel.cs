using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Admin.Models
{
    public class BillModel
    {
        public int IDBill { get; set; }
        public int IDProduct { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerPhone { get; set; }
        public int IDOrder { get; set; }
        public int IDExport { get; set; }
        public DateTime ModifyDay { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}