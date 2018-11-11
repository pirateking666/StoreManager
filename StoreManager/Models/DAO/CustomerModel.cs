using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class CustomerModel
    {
        public ModifyCustomer NewCustomer { get; set; }
        public ModifyCustomer OldCustomer { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string phone { get; set; }
    }
}