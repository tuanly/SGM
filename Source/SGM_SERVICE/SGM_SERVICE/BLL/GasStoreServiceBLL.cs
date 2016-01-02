using System;
using System.Collections.Generic;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;
using SGM.ServicesCore.DAL;
using System.Web;

namespace SGM.ServicesCore.BLL
{
    public class GasStoreServiceBLL
    {
        private DataTransfer m_dataRequest;
        private DataTransfer m_dataResponse;
        private GasStoreDAL m_dalGasStore;

        public GasStoreServiceBLL()
        {
            m_dataRequest = null;
            m_dataResponse = null;
            m_dalGasStore = new GasStoreDAL();
        }

        public string CheckGasStoreExist(string stGasStoreID)
        {
            m_dataResponse = m_dalGasStore.IsGasStoreExisted(stGasStoreID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string AddNewGasStore(string jsGasStoreDTO)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsGasStoreDTO);
            m_dataResponse = m_dalGasStore.AddNewGasStore(m_dataRequest.ResponseDataGasStoreDTO);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string GetGasStore(string stGasStoreID)
        {
            if (stGasStoreID == null)
                m_dataResponse = m_dalGasStore.GetGasStores();
            else
                m_dataResponse = m_dalGasStore.GetGasStore(stGasStoreID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string GetGasStores()
        {
            m_dataResponse = m_dalGasStore.GetGasStores();
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string GetGasStoresFilter(string stGasStoreID, DateTime fromDate, DateTime toDate)
        {
            m_dataResponse = m_dalGasStore.GetGasStoresFilter(stGasStoreID, fromDate, toDate);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string UpdateGasStore(string jsonCustomerDTO, string stGasStoreID)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsonCustomerDTO);
            m_dataResponse = m_dalGasStore.UpdateGasStore(m_dataRequest.ResponseDataGasStoreDTO, stGasStoreID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
       

        public string DelGasStore(string stGasStoreID)
        {
            m_dataResponse = m_dalGasStore.DeleteGasStore(stGasStoreID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string ValidateGasStoreLogin(string stGasStoreID, string stGasStoreMacAddress)
        {
            m_dataResponse = m_dalGasStore.ValidateGasStoreLogin(stGasStoreID, stGasStoreMacAddress);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string AddNewGasStoreUpdate(string jsGasStoreUpdateDTO)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsGasStoreUpdateDTO);
            m_dataResponse = m_dalGasStore.AddNewGasStoreUpdate(m_dataRequest.ResponseDataGasStoreUpdateDTO);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }


        
        
    }
}