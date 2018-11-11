using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class CheckOut
    {
        public string CheckCustomerByPhone(string phone)
        {
            if (new ModifyCustomer().CheckExistCustomerByPhone(phone))
            {
                return new ModifyCustomer().GetCustomerByPhone(phone).Name;
            }
            else
                return "false";
        }
        public void NewCustomerCheckOut(CustomerModel model, string listProduct, string listQuantity)
        {
            DateTime dt = new DateTime(model.NewCustomer.year, model.NewCustomer.month, model.NewCustomer.day);
            new ModifyCustomer().Insert(model.NewCustomer.name, model.NewCustomer.address, model.NewCustomer.gender, dt, model.NewCustomer.phone);
            new ModifyOrder().Insert(model.NewCustomer.phone);
            //process list product
            ModifyOrderDetail mod = new ModifyOrderDetail();
            int OrderId = new ModifyOrder().GetIDByCustomerPhone(model.NewCustomer.phone);
            string[] listProductSplit = listProduct.Split('-');
            string[] listQuantitySplit = listQuantity.Split('-');
            for (int i = 0; i < listProductSplit.Length; i++)
            {
                mod.Insert(OrderId, int.Parse(listProductSplit[i]), int.Parse(listQuantitySplit[i]));
            }
        }
        public void OldCustomerCheckOut(CustomerModel model, string listProduct, string listQuantity)
        {
            if (CheckUpdateOldCustomer(model))
            {
                DateTime dt = new DateTime(model.OldCustomer.year, model.OldCustomer.month, model.OldCustomer.day);
                new ModifyCustomer().Update(model.OldCustomer.name, model.OldCustomer.address, model.OldCustomer.gender, dt, model.OldCustomer.phone);
            }
            new ModifyOrder().Insert(model.OldCustomer.phone);
            //process list product
            ModifyOrderDetail mod = new ModifyOrderDetail();
            int OrderId = new ModifyOrder().GetIDByCustomerPhone(model.OldCustomer.phone);
            string[] listProductSplit = listProduct.Split('-');
            string[] listQuantitySplit = listQuantity.Split('-');
            for (int i = 0; i < listProductSplit.Length; i++)
            {
                mod.Insert(OrderId, int.Parse(listProductSplit[i]), int.Parse(listQuantitySplit[i]));
            }
        }
        public bool CheckUpdateOldCustomer(CustomerModel model)
        {
            DateTime dt = new DateTime(model.OldCustomer.year, model.OldCustomer.month, model.OldCustomer.day);
            Customer c = new ModifyCustomer().GetCustomerByPhone(model.OldCustomer.phone);
            if (c.Name != model.OldCustomer.name || c.Gender != model.OldCustomer.gender || c.Birth != dt || c.Address != model.OldCustomer.address)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}