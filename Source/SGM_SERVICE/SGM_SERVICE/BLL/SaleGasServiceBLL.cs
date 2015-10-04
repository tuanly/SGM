using System;
using System.Collections.Generic;
using System.Web;
using SGM.ServicesCore.DAL;
using SGM_Core.DTO;
using System.Data;

namespace SGM.ServicesCore.BLL
{
    public class SaleGasServiceBLL
    {
        public string ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
        {
            GasStationDAL dalGasStation = new GasStationDAL();
            DataTransfer response = dalGasStation.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);
            return response.createJSON();
        }

        public string ValidateCardId(string strCardId)
        {
            CardDAL dalCard = new CardDAL();
            DataTransfer response = dalCard.ValidateCardID(strCardId);
            return response.createJSON();
        }
    }
    

}