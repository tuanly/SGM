using System;
using System.Collections.Generic;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;
using SGM.ServicesCore.DAL;
using System.Web;

namespace SGM.ServicesCore.BLL
{
    public class GasStationServiceBLL
    {
        private DataTransfer m_dataRequest;
        private DataTransfer m_dataResponse;
        private GasStationDAL m_dalGasStation;

        public GasStationServiceBLL()
        {
            m_dataRequest = null;
            m_dataResponse = null;
            m_dalGasStation = new GasStationDAL();
        }

        public string CheckGasStationExist(string stGasStationID)
        {
            m_dataResponse = m_dalGasStation.IsGasStationExisted(stGasStationID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string AddNewGasStaion(string jsGasStationDTO)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsGasStationDTO);
            m_dataResponse = m_dalGasStation.AddNewGasStation(m_dataRequest.ResponseDataGasStationDTO);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string GetGasStation(string stGasStationID)
        {
            if (stGasStationID == null)
                m_dataResponse = m_dalGasStation.GetGasStations();
            else
                m_dataResponse = m_dalGasStation.GetGasStation(stGasStationID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
        public string UpdateGasStation(string jsonCustomerDTO, string stGasStationID)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsonCustomerDTO);
            m_dataResponse = m_dalGasStation.UpdateGasStation(m_dataRequest.ResponseDataGasStationDTO, stGasStationID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
        public string DelGasStation(string stGasStationID)
        {
            m_dataResponse = m_dalGasStation.DeleteGasStation(stGasStationID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
    }
}