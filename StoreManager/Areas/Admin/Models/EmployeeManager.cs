using SoftwareTechnology.Common;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Admin.Models
{
    public class EmployeeManager
    {
        public ModifyEmployee Insert { get; set; }
        public ModifyEmployee Update { get; set; }
        public string InsertEmployee(EmployeeManager model)
        {
            if(new ModifyEmployee().CheckExistUsername(model.Insert.Username))
            {
                Md5Function md5 = new Md5Function();
                string pass = md5.MD5HashFunction(model.Insert.Password);
                new ModifyAccount().Insert(model.Insert.Username, pass);
                new ModifyEmployee().Insert(model.Insert);
                return "true";
            }
            else
            {
                return "Tên tài khoản đã tồn tại";
            }
        }
        public void UpdateEmployee(EmployeeManager model)
        {
            new ModifyEmployee().Update(model.Update);
        }
    }
}