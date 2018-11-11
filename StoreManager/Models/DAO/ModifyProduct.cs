using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyProduct
    {
        public List<Product> GetList()
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            return db.Products.ToList();
        }
    }
}