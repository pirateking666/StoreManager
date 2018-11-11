using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SoftwareTechnology.Common
{
    public class Md5Function
    {
        public string MD5HashFunction(string passWord)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passWord));

            byte[] result = md5.Hash;

            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuild.Append(result[i].ToString("x2"));
            }

            return strBuild.ToString();
        }
    }
}