using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyCustomer
    {
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        public string name { get; set; }
        public string gender { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime birth { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string phone { get; set; }
        public bool CheckExistCustomerByPhone(string phone)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Customer c = db.Customers.SingleOrDefault(x => x.Phone == phone);
            if (c == null)
                return false;
            else
                return true;
        }
        public Customer GetCustomerByPhone(string phone)
        {
            return new StoreManagerDBContext().Customers.SingleOrDefault(x => x.Phone == phone);
        }
        public void Insert(string name, string address, string gender, DateTime birth, string phone)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Customer c = new Customer();
            c.Name = name;
            c.Address = address;
            c.Gender = gender;
            c.Birth = birth;
            c.Phone = phone;
            db.Customers.Add(c);
            db.SaveChanges();
        }
        public void Update(string name, string address, string gender, DateTime birth, string phone)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Customer c = db.Customers.SingleOrDefault(x => x.Phone == phone);
            c.Name = name;
            c.Gender = gender;
            c.Birth = birth;
            c.Address = address;
            db.SaveChanges();
        }
    }
}