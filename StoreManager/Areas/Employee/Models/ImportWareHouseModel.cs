using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Employee.Models
{
    public class ImportWareHouseModel
    {
        public int Product_1 { get; set; }
        public int Product_2 { get; set; }
        public int Product_3 { get; set; }
        public int Product_4 { get; set; }
        public int Product_5 { get; set; }
        public int Product_6 { get; set; }
        public void OfferImportWareHouse(string listProduct, string listQuantity, string username)
        {
            string[] listProductSplit = listProduct.Split('-');
            string[] listQuantitySplit = listQuantity.Split('-');
            new ModifyImportWareHouse().Insert(new ModifyEmployee().GetIDByUsername(username));
            for (int i = 0; i < listProductSplit.Length; i++)
            {
                new ModifyImportWareHouseDetail().Insert(int.Parse(listProductSplit[i]), int.Parse(listQuantitySplit[i]), new ModifyProduct().GetOriginalPriceByID(int.Parse(listProductSplit[i])) * int.Parse(listQuantitySplit[i]), new ModifyEmployee().GetIDByUsername(username));
            }
        }
    }
}