using System;
using System.Collections.Generic;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;
using System.Web;
using SGM.ServicesCore.DAL;

namespace SGM.ServicesCore.BLL
{
    public class AdminServiceBLL
    {
        public string ValidateAdminLogin(string admin, string pwd)
        {
            SystemAdminDAL dalSysAdmin = new SystemAdminDAL();
            DataTransfer response = new DataTransfer();
            SystemAdminDTO dto = dalSysAdmin.GetSystemAdminInfo(admin, pwd);
            if (dto != null)
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                response.ResponseDataSystemAdminDTO = dto;
            }
            else
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                response.ResponseErrorMsg = SGMText.ADMIN_LOGON_ERROR;
            }
            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string UpdateAdminAccount(string admin, string admin_new, string pwd)
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
            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string UpdateSystemPrice(String jsonSysAdminDTO)
        {
            DataTransfer dataInput = JSonHelper.ConvertJSonToObject(jsonSysAdminDTO);
            SystemAdminDAL dalSystemAd = new SystemAdminDAL();
            DataTransfer response = dalSystemAd.UpdateSystemAdminPrice(dataInput.ResponseDataSystemAdminDTO);
            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string UpdateSystemStore(String jsonSysAdminDTO)
        {
            DataTransfer dataInput = JSonHelper.ConvertJSonToObject(jsonSysAdminDTO);
            SystemAdminDAL dalSystemAd = new SystemAdminDAL();
            DataTransfer response = dalSystemAd.UpdateSystemAdminStore(dataInput.ResponseDataSystemAdminDTO);
            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string GetCurrentPrice(int iGasType)
        {            
            SystemAdminDAL dalSystemAd = new SystemAdminDAL();
            DataTransfer response = dalSystemAd.GetCurrentPrice(iGasType);
            return JSonHelper.ConvertObjectToJSon(response);
        }
    }
}