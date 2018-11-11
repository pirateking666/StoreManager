using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ListWareHouse
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string producer { get; set; }
        public byte[] productImage { get; set; }
    }
}