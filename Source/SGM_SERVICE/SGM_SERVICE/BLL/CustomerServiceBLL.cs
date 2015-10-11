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
        private CustomerDAL m_dalCustomer;
        private DataTransfer m_dataRequest;
        private DataTransfer m_dataResponse;
        public CustomerServiceBLL()
        {
            m_dalCustomer = new CustomerDAL();
            m_dataRequest = null;
            m_dataResponse = null;

        }
        public string AddNewCustomer(string jsonCustomerDTO)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsonCustomerDTO);
            m_dataResponse = m_dalCustomer.AddNewCustomer(m_dataRequest.ResponseDataCustomerDTO);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string CheckCustomerExist(string stCustomerID)
        {
            m_dataResponse = m_dalCustomer.IsCustomerExisted(stCustomerID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string GetCustomer(string stCustomerID, bool bExactly)
        {            
            if (bExactly)
                m_dataResponse = m_dalCustomer.GetCustomer(stCustomerID);
            else
                m_dataResponse = m_dalCustomer.GetCustomers(stCustomerID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
        public string UpdateCustomer(string jsonCustomerDTO, string stCustomerID)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsonCustomerDTO);
            m_dataResponse = m_dalCustomer.UpdateCustomer(m_dataRequest.ResponseDataCustomerDTO, stCustomerID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
        public string DelCustomer(string stCustomerID)
        {
            m_dataResponse = m_dalCustomer.DeleteCustomer(stCustomerID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
    }
}