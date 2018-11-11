using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyWareHouse
    {
        public List<ListWareHouse> GetListWareHouse()
        {
            return new StoreManagerDBContext().WareHouses.Select(x => new ListWareHouse { ID = x.ProductID, productName = x.Product.Name, productType = x.Product.ProductType.Name, quantity = x.Quantity }).ToList();
        }
        public List<ListWareHouse> GetListProductForCart(string listIDProduct)
        {
            if (listIDProduct == "" || listIDProduct == null)
            {
                return null;
            }
            else
            {
                int[] list = listIDProduct.Split('-').Select(int.Parse).ToArray();
                return new StoreManagerDBContext().WareHouses.Where(x => list.Contains(x.ProductID)).Select(x => new ListWareHouse { ID = x.ProductID, productName = x.Product.Name, productType = x.Product.ProductType.Name, producer = x.Product.Producer.Name, quantity = x.Quantity, price = x.Product.SellPrice, productImage = x.Product.ProductImage }).ToList();
            }
        }
    }
}