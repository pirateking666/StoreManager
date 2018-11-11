using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyEmployee
    {
        public int GetIDByUsername(string username)
        {
            return new StoreManagerDBContext().Employees.SingleOrDefault(x => x.username == username).ID;
        }
    }
}