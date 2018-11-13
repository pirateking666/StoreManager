using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyProductType
    {
        public List<ProductType> GetList()
        {
            return new StoreManagerDBContext().ProductTypes.ToList();
        }
    }
}