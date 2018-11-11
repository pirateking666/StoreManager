using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models.DAO
{
    public class Cart
    {
        public string RemoveCart(int productID, string listIDProduct)
        {
            string result = "";
            int[] list = listIDProduct.Split('-').Select(int.Parse).ToArray();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == productID)
                {
                    //
                }
                else
                {
                    if (result == "")
                    {
                        result += list[i].ToString();
                    }
                    else
                    {
                        result += "-" + list[i];
                    }
                }
            }
            return result;
        }
    }
}