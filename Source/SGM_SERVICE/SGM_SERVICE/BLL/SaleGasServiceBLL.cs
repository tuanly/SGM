using System;
using System.Collections.Generic;
using System.Web;
using SGM.ServicesCore.DAL;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;

namespace SGM.ServicesCore.BLL
{
    public class SaleGasServiceBLL
    {
        private JSonHelper m_jsHelper;
        public SaleGasServiceBLL()
        {
            m_jsHelper = new JSonHelper();
        }
        public string ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
        {
            GasStationDAL dalGasStation = new GasStationDAL();
            DataTransfer response = dalGasStation.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);
            return m_jsHelper.ConvertObjectToJSon(response);
        }

        public string ValidateCardId(string strCardId)
        {
            CardDAL dalCard = new CardDAL();
            DataTable tblCard = dalCard.ValidateCardID(strCardId);
            DataTransfer dataResult = new DataTransfer();
            if (tblCard.Rows.Count > 0)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                DataSet ds = new DataSet();
                ds.Tables.Add(tblCard.Copy());
                dataResult.ResponseDataSet = ds;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GAS_STATION_CARD_ID_NOT_EXIST;
            }
            return m_jsHelper.ConvertObjectToJSon(dataResult);
        }

        public string GasBuying(string strCardId, int money)
        {
            CardDAL dalCard = new CardDAL();
            CardDTO dtoCard = new CardDTO();
            dtoCard.CardID = strCardId;
            dtoCard.CardRemainingMoney = money;
            DataTransfer response = new DataTransfer();
            bool b = dalCard.UpdateCardBuying(dtoCard);
            if (b)
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                response.ResponseErrorMsg = SGMText.GAS_BUYING_SUCCESS;
            }
            else
            {
                response.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                response.ResponseErrorMsg = SGMText.GAS_BUYING_FAIL;
            }
            return m_jsHelper.ConvertObjectToJSon(response);
        }
    }
    

}