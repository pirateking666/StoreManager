using StoreManager.Models;
using StoreManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Areas.Employee.Models
{
    public class AcceptOrder
    {
        public void Process(int orderID, int employeeID)
        {
            new ModifyExportWareHouse().Insert(employeeID, new ModifyOrder().GetCustomerPhoneByID(orderID));
            int ExportWareHouseID = new ModifyExportWareHouse().GetLastIDByEmployeeIDAndCustomerPhone(employeeID, new ModifyOrder().GetCustomerPhoneByID(orderID));
            List<OrderDetail> list = new ModifyOrderDetail().GetListByOrderID(orderID);
            for (int i = 0; i < list.Count(); i++)
            {
                new ModifyExportWareHouseDetail().Insert(list[i].ProductID, list[i].Quantity, ExportWareHouseID);
                //Update WareHouse
                new ModifyWareHouse().Update(list[i].ProductID, -1 * list[i].Quantity);
            }
            // Bill
            new ModifyBill().Insert(employeeID, new ModifyOrder().GetCustomerPhoneByID(orderID), orderID, ExportWareHouseID);
            for (int i = 0; i < list.Count(); i++)
            {
                new ModiffyBillDetail().Insert(new ModifyBill().GetLastIDByemployeeIDCustomerPhoneOrderIDExID(employeeID, new ModifyOrder().GetCustomerPhoneByID(orderID), orderID, ExportWareHouseID), list[i].ProductID, list[i].Quantity, list[i].Product.SellPrice * list[i].Quantity);
            }
            new ModifyOrder().UpdateStatusByID(orderID);
        }
    }
}