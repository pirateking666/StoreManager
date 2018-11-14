using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyAccount
    {
        public bool CheckUsername(string username)
        {
            if (new StoreManagerDBContext().Accounts.SingleOrDefault(x => x.username == username) == null)
            {
                return false;
            }
            else
                return true;
        }
        public string CheckAccount(string username, string password)
        {
            Account acc = new StoreManagerDBContext().Accounts.SingleOrDefault(x => x.username == username && x.password == password);
            if (acc == null)
                return "false";
            else
                return acc.Position.Name;
        }
        public void Insert(string username, string password)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Account a = new Account();
            a.username = username;
            a.password = password;
            a.PositionID = 2;
            db.Accounts.Add(a);
            db.SaveChanges();
        }
        public void UpdatePasswordDeleteEmployee(string username)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Account a = db.Accounts.SingleOrDefault(x => x.username == username);
            a.password = "NULL";
            db.SaveChanges();
        }
        public Account Select(string username)
        {
            return new StoreManagerDBContext().Accounts.SingleOrDefault(x => x.username == username);
        }
        public void UpdatePasswordChange(string username, string password)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Account a = db.Accounts.SingleOrDefault(x => x.username == username);
            a.password = password;
            db.SaveChanges();
        }
    }
}