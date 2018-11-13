using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyProducer
    {
        public List<Producer> GetList()
        {
            return new StoreManagerDBContext().Producers.ToList();
        }
    }
}