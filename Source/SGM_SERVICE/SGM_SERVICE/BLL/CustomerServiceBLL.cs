using System;
using System.Collections.Generic;
using System.Web;
using SGM.ServicesCore.DAL;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;

namespace SGM.ServicesCore.BLL
{
    public class CustomerServiceBLL
    {
        public string AddNewCustomer(String jsonCustomerDTO)
        {
            DataTransfer dataInput = JSonHelper.ConvertJSonToObject(jsonCustomerDTO);
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response = dalCustomer.AddNewCustomer(dataInput.ResponseDataCustomerDTO);
            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string CheckCustomerExist(string stCustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response = dalCustomer.IsCustomerExisted(stCustomerID);
            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string GetCustomer(string stCustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response;
            if (stCustomerID == null)
                response = dalCustomer.GetCustomers();
            else
                response = dalCustomer.GetCustomer(stCustomerID);
            return JSonHelper.ConvertObjectToJSon(response);
        }
    }
}