using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyEmployee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên nhân viên")]
        public string Name { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }
        public int GetIDByUsername(string username)
        {
            return new StoreManagerDBContext().Employees.SingleOrDefault(x => x.username == username).ID;
        }
        public bool CheckExistUsername(string username)
        {
            if (new StoreManagerDBContext().Accounts.SingleOrDefault(x => x.username == username) == null)
            {
                return true;
            }
            else
                return false;
        }
        public int GetNextID()
        {
            List<Employee> list = new StoreManagerDBContext().Employees.OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID + 1;
        }
        public void Insert(ModifyEmployee model)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Employee e = new Employee();
            e.ID = GetNextID();
            e.Name = model.Name;
            e.StatusID = 1;
            e.Birth = new DateTime(model.Year, model.Month, model.Day);
            e.Gender = model.Gender;
            e.Address = model.Address;
            e.username = model.Username;
            e.Phone = model.Phone;
            db.Employees.Add(e);
            db.SaveChanges();
        }
        public List<Employee> GetList()
        {
            return new StoreManagerDBContext().Employees.Where(x => x.StatusID == 1).ToList();
        }
        public Employee GetEmployeeByID(int ID)
        {
            return new StoreManagerDBContext().Employees.SingleOrDefault(x => x.ID == ID);
        }
        public string GetEmployeeInfo(int ID)
        {
            Employee e = GetEmployeeByID(ID);
            return e.Name + "-" + e.Phone + "-" + e.Birth.Day + "-" + e.Birth.Month + "-" + e.Birth.Year + "-" + e.Gender + "-" + e.Address;
        }
        public void Update(ModifyEmployee model)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Employee e = db.Employees.SingleOrDefault(x => x.ID == model.ID);
            e.Name = model.Name;
            e.Birth = new DateTime(model.Year, model.Month, model.Day);
            e.Address = model.Address;
            e.Gender = model.Gender;
            e.Phone = model.Phone;
            db.SaveChanges();
        }
        public void UpdateStatusAndPassword(int employeeID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Employee e = db.Employees.SingleOrDefault(x => x.ID == employeeID);
            new ModifyAccount().UpdatePasswordDeleteEmployee(e.username);
            e.StatusID = 2;
            db.SaveChanges();
        }
    }
}