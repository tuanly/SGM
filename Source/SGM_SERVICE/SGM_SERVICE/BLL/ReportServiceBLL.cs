using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGM.ServicesCore.DAL;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;

namespace SGM.ServicesCore.BLL
{
    public class ReportServiceBLL
    {
        public string GetGasStationList()
        {
            GasStationDAL dalGasStation = new GasStationDAL();
            DataTransfer response = new DataTransfer();
            DataSet ds = dalGasStation.GetGasStationList();
            if (ds != null)
            {
                response.ResponseDataSet = ds;
                response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
            }

            return JSonHelper.ConvertObjectToJSon(response);
        }

        public string GetCustomerList()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            DataTransfer response = dalCustomer.GetCustomerList();
            return JSonHelper.ConvertObjectToJSon(response);
        }
    }
}