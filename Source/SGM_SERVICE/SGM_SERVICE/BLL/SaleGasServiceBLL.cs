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
        public SaleGasServiceBLL()
        {
        }
        public string ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
        {
            GasStationDAL dalGasStation = new GasStationDAL();
            DataTransfer response = dalGasStation.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);
            return JSonHelper.ConvertObjectToJSon(response);
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
            return JSonHelper.ConvertObjectToJSon(dataResult);
        }

        public string GasBuying(String jsonSaleGasDTO, string sys_admin)
        {
            DataTransfer dataInput = JSonHelper.ConvertJSonToObject(jsonSaleGasDTO);
            SystemAdminDAL dalSystemAd = new SystemAdminDAL();
            SaleGasDTO saleGasDTO = dataInput.ResponseDataSaleGasDTO;
            DataTransfer response = GasBuyingAddSaleGas(saleGasDTO);
            if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                response = GasBuyingUpdateCard(saleGasDTO.CardID, saleGasDTO.SaleGasCardMoneyAfter);
                if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    response = GasBuyingUpdateSysAdmin(sys_admin, saleGasDTO);
                    if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                        response.ResponseErrorMsg = SGMText.GAS_BUYING_SUCCESS;
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
            return JSonHelper.ConvertObjectToJSon(response);
        }

        private DataTransfer GasBuyingUpdateSysAdmin(string sys_admin, SaleGasDTO saleGasDTO)
        {
            SystemAdminDAL dal = new SystemAdminDAL();
            float money = saleGasDTO.SaleGasCardMoneyBefore - saleGasDTO.SaleGasCardMoneyAfter;
            float amount = money / saleGasDTO.SaleGasCurrentPrice;
            DataTransfer res = dal.UpdateSaleGas(sys_admin, saleGasDTO.SaleGasType, amount);
            return res;
        }

        private DataTransfer GasBuyingAddSaleGas(SaleGasDTO saleGasDTO)
        {
            SaleGasDAL dal = new SaleGasDAL();
            return dal.AddSaleGas(saleGasDTO);
        }
        private DataTransfer GasBuyingUpdateCard(string strCardId, int money)
        {
            CardDAL dalCard = new CardDAL();
            CardDTO dtoCard = new CardDTO();
            dtoCard.CardID = strCardId;
            dtoCard.CardRemainingMoney = money;
            return dalCard.UpdateSaleGas(dtoCard);
        }

        public string GetSaleGasReport(string stGasStationID, string dateStart, string dateEnd)
        {
            throw new NotImplementedException();
            //CardDAL dalCard = new CardDAL();
            //DataTable tblCard = dalCard.GetSaleGasReport(stGasStationID, dateStart, dateEnd);
            //DataTransfer dataResult = new DataTransfer();
            //if (tblCard.Rows.Count > 0)
            //{
            //    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            //    DataSet ds = new DataSet();
            //    ds.Tables.Add(tblCard.Copy());
            //    dataResult.ResponseDataSet = ds;
            //}
            //else
            //{
            //    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
            //    dataResult.ResponseErrorMsg = SGMText.GAS_STATION_CARD_ID_NOT_EXIST;
            //}
            //return JSonHelper.ConvertObjectToJSon(dataResult);
        }
    }
    

}