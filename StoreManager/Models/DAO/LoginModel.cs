using SoftwareTechnology.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tên tài khoản")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string passWord { get; set; }
        public string VerifyLogin(LoginModel model)
        {
            Md5Function md5 = new Md5Function();
            string pass = md5.MD5HashFunction(model.passWord);
            if (!new ModifyAccount().CheckUsername(model.userName))
                return "Tài khoản không tồn tại";
            else
            {
                string s = new ModifyAccount().CheckAccount(model.userName, pass);
                if (s == "false")
                    return "Sai mật khẩu";
                else
                    return s;
            }
        }
    }
}