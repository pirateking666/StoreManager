using StoreManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class ModifyProduct
    {
        public List<Product> GetList()
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            return db.Products.Where(x => x.StatusID == 1).ToList();
        }
        public List<ListProduct> GetListForStatistical()
        {
            return new StoreManagerDBContext().Products.Select(x => new ListProduct { ID = x.ID, Name = x.Name, Producer = x.Producer.Name, ProductType = x.ProductType.Name, OriginalPrice = x.OriginalPrice, SellPrice = x.SellPrice, Image = x.ProductImage, statusID = (int)x.StatusID }).ToList();
        }
        public decimal GetOriginalPriceByID(int ID)
        {
            return new StoreManagerDBContext().Products.SingleOrDefault(x => x.ID == ID).OriginalPrice;
        }
        public List<ListProduct> GetListForAdmin()
        {
            return new StoreManagerDBContext().Products.Where(x => x.StatusID == 1).Select(x => new ListProduct { ID = x.ID, Name = x.Name, Producer = x.Producer.Name, ProductType = x.ProductType.Name, OriginalPrice = x.OriginalPrice, SellPrice = x.SellPrice, Image = x.ProductImage }).ToList();
        }
        public void Insert(ListProduct model)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Product p = new Product();
            int ID = GetNextID();
            p.ID = GetNextID();
            p.Name = model.Name;
            p.ProducerID = int.Parse(model.Producer);
            p.ProductTypeID = int.Parse(model.ProductType);
            p.StatusID = 1;
            p.OriginalPrice = model.OriginalPrice;
            p.SellPrice = model.SellPrice;
            p.ProductImage = model.Image;
            db.Products.Add(p);
            db.SaveChanges();
            new ModifyWareHouse().Insert(ID);
        }
        public void Update(ListProduct model)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Product p = db.Products.SingleOrDefault(x => x.ID == model.ID);
            p.Name = model.Name;
            p.ProducerID = int.Parse(model.Producer);
            p.ProductTypeID = int.Parse(model.ProductType);
            p.OriginalPrice = model.OriginalPrice;
            p.SellPrice = model.SellPrice;
            if (model.Image != null)
            {
                p.ProductImage = model.Image;
            }
            db.SaveChanges();
        }
        public void ChangeStatus(int productID)
        {
            StoreManagerDBContext db = new StoreManagerDBContext();
            Product p = db.Products.SingleOrDefault(x => x.ID == productID);
            p.StatusID = 2;
            db.SaveChanges();
        }
        public int GetNextID()
        {
            List<Product> list = new StoreManagerDBContext().Products.OrderByDescending(x => x.ID).Take(1).ToList();
            return list[0].ID + 1;
        }
        public string GetInfo(int ID)
        {
            Product p = new StoreManagerDBContext().Products.SingleOrDefault(x => x.ID == ID);
            if (p.ProductImage != null)
            {
                string imagesrc = Convert.ToBase64String(p.ProductImage);
                return p.Name + "-" + p.ProducerID + "-" + p.ProductTypeID + "-" + double.Parse(p.OriginalPrice.ToString()) + "-" + double.Parse(p.SellPrice.ToString()) + "-" + "data:image;base64," + imagesrc;
            }
            else
            {
                return p.Name + "-" + p.ProducerID + "-" + p.ProductTypeID + "-" + double.Parse(p.OriginalPrice.ToString()) + "-" + double.Parse(p.SellPrice.ToString()) + "-" + "/Content/Image/null_img.jpg";
            }
        }
    }
}