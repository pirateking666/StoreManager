using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Admin.Models
{
    public class ProductManager
    {
        public ListProduct Insert { get; set; }
        public ListProduct Update { get; set; }
        public HttpPostedFileWrapper ImageGet { get; set; }
        public void InsertProduct(ProductManager model)
        {
            if (model.ImageGet != null)
            {
                model.Insert.Image = GetByteArray(model.ImageGet);
            }
            new ModifyProduct().Insert(model.Insert);
        }
        public void UpdateProduct(ProductManager model)
        {
            if (model.ImageGet != null)
            {
                model.Update.Image = GetByteArray(model.ImageGet);
            }
            new ModifyProduct().Update(model.Update);
        }
        public string DeleteProduct(int productID)
        {
            if(new ModifyWareHouse().CheckWareHouseQuantity(productID))
            {
                return "Kho vẫn còn hàng không thể xóa sản phẩm";
            }
            else
            {
                new ModifyProduct().ChangeStatus(productID);
                return "true";
            }
        }
        public byte[] GetByteArray(HttpPostedFileWrapper file)
        {
            var files = file;
            byte[] imagebyte = null;
            BinaryReader reader = new BinaryReader(files.InputStream);
            imagebyte = reader.ReadBytes(files.ContentLength);
            return imagebyte;
        }
    }
}