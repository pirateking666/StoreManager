﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Employee.Models
{
    public class ListOrderDetail
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int orderID { get; set; }
    }
}