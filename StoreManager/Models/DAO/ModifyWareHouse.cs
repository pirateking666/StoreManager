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
        public void Update(int productID, int quantity)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            WareHouse wh = db.WareHouses.SingleOrDefault(x => x.ProductID == productID);
            wh.Quantity += quantity;
            db.SaveChanges();
        }
        public void Insert(int productID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            WareHouse wh = new WareHouse();
            wh.ProductID = productID;
            wh.Quantity = 0;
            db.WareHouses.Add(wh);
            db.SaveChanges();
        }
        public bool CheckWareHouseQuantity(int productID)
        {
            if (new StoreManagerDBContext().WareHouses.SingleOrDefault(x => x.ProductID == productID) != null)
            {
                if (new StoreManagerDBContext().WareHouses.SingleOrDefault(x => x.ProductID == productID).Quantity != 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}