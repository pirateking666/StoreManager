using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Employee.Models
{
    public class ListOrder
    {
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string customerAddress { get; set; }
        public DateTime modifyDay { get; set; }
        public int ID { get; set; }
    }
}