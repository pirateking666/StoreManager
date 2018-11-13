using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifySupplier
    {
        public List<Supplier> GetList()
        {
            return new StoreManagerDBContext().Suppliers.ToList();
        }
    }
}