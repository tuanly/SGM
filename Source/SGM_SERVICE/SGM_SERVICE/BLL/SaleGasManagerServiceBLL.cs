using System;
using System.Collections.Generic;
using System.Web;
using SGM.ServicesCore.DAL;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;

namespace SGM.ServicesCore.BLL
{
    public class SaleGasManagerServiceBLL
    {
        private JSonHelper m_jsHelper;
        public SaleGasManagerServiceBLL()
        {
            m_jsHelper = new JSonHelper();
        }
        public string SGMLogin_ValidateAdminLogin(string admin, string pwd)
        {
            SystemAdminDAL dalSysAdmin = new SystemAdminDAL();
            DataTransfer response = new DataTransfer();
            DataSet ds = dalSysAdmin.GetSystemAdminInfo(admin, pwd);
            if (ds != null)
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                response.ResponseDataSet = ds;
            }
            else
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                response.ResponseErrorMsg = SGMText.ADMIN_LOGON_ERROR;
            }
            return m_jsHelper.ConvertObjectToJSon(response);
        }

        public string SGMUpdateAccount_UpdateAdminAccount(string admin, string admin_new, string pwd)
        {
            SystemAdminDAL dalSysAdmin = new SystemAdminDAL();
            DataTransfer response = new DataTransfer();
            bool res = dalSysAdmin.UpdateAdminAccount(admin, admin_new, pwd);
            if (res == true)
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                response.ResponseErrorMsg = SGMText.SYS_ADMIN_CHANGE_SUCCESS;
            }
            else
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                response.ResponseErrorMsg = SGMText.SYS_ADMIN_CHANGE_FAIL;
            }
            return m_jsHelper.ConvertObjectToJSon(response);
        }

        public string SGMCustomer_AddNewCustomer(String jsonCustomerDTO)
        {
            DataTransfer dataInput = m_jsHelper.ConvertJSonToObject(jsonCustomerDTO);           
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response = dalCustomer.AddNewCustomer(dataInput.ResponseDataCustomerDTO);
            return m_jsHelper.ConvertObjectToJSon(response);
        }

        public string SGMCustomer_CheckCustomerExist(string stCustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response = dalCustomer.IsCustomerExisted(stCustomerID);
            return m_jsHelper.ConvertObjectToJSon(response);
        }

        public string SGMCustomer_GetCustomer(string stCustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response = dalCustomer.GetCustomer(stCustomerID);
            return m_jsHelper.ConvertObjectToJSon(response);
        }
    }
}