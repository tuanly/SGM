﻿using System;
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
            
            SystemAdminDAL dalSystemAdmin = new SystemAdminDAL();
            DataTransfer responseAdmin = dalSystemAdmin.GetCurrentPrice(SystemAdminDTO.GAS_TYPE_ALL);
            response.ResponseCurrentPriceGas92 = responseAdmin.ResponseCurrentPriceGas92;
            response.ResponseCurrentPriceGas95 = responseAdmin.ResponseCurrentPriceGas95;
            response.ResponseCurrentPriceGasDO = responseAdmin.ResponseCurrentPriceGasDO;
            response.ResponseDataSystemAdminDTO = responseAdmin.ResponseDataSystemAdminDTO;

            GasStoreDAL dalGasStore = new GasStoreDAL();
            DataTransfer responseGasStore = dalGasStore.GetGasStoreFromGasStation(stGasStationID);
            response.ResponseGasStoreGas92Total = responseGasStore.ResponseGasStoreGas92Total;
            response.ResponseGasStoreGas95Total = responseGasStore.ResponseGasStoreGas95Total;
            response.ResponseGasStoreGasDOTotal = responseGasStore.ResponseGasStoreGasDOTotal;
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
                    
                }
              
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

        public string GetSaleGasReport(string stGasStationID, DateTime dateStart, DateTime dateEnd, string stCardID)
        {
            SaleGasDAL dal = new SaleGasDAL();
            DataTransfer dataResult = dal.GetSaleGasReport(stGasStationID, dateStart, dateEnd, stCardID);
            return JSonHelper.ConvertObjectToJSon(dataResult);
        }
    }
    

}