using System;
using System.Collections.Generic;
using System.Web;
using SGM.ServicesCore.DAL;
using SGM_Core.DTO;
using System.Data;

namespace SGM.ServicesCore.BLL
{
    public class SaleGasManagerServiceBLL
    {
        public string ValidateAdminLogin(string admin, string pwd)
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
            return response.createJSON();
        }
    }
}