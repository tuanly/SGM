using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;

namespace SGM_Core.Utils
{
    public class DataTransfer
    {
        public static int RESPONSE_CODE_NONE = -1;
        public static int RESPONSE_CODE_SUCCESS = 0;
        public static int RESPONSE_CODE_FAIL = 1;

        private int m_iResponseCode;
        private string m_stResponseErrorMsg;
        private string m_stResponseErrorMsgDetail;
        private string m_stResponseDataString;
        private bool m_bResponseDataBool;
        private int m_bResponseDataInt;
        private CustomerDTO m_dtoResponseDataCustomerDTO;
        private CardDTO m_dtoResponseDataCardDTO;
        private GasStationDTO m_dtoResponseDataGasStationDTO;
        private RechargeDTO m_dtoResponseDataRechargeDTO;
        private SaleGasDTO m_dtoResponseDataSaleGasDTO;
        private SystemAdminDTO m_dtoResponseDataSystemAdminDTO;
        private GasStoreDTO m_dtoResponseDataGasStoreDTO;
        private DataSet m_dsResponseDataSet;

        private int m_iCurrentPriceGas92;
        private int m_iCurrentPriceGas95;
        private int m_iCurrentPriceGasDO;
        
        public DataTransfer()
        {
            m_iResponseCode = RESPONSE_CODE_NONE;
            m_stResponseErrorMsg = "";
            m_stResponseErrorMsgDetail = "";
            m_stResponseDataString = "";
            m_bResponseDataBool = false;
            m_dtoResponseDataCustomerDTO = null;
            m_dtoResponseDataCardDTO = null;
            m_dtoResponseDataGasStationDTO = null;
            m_dtoResponseDataRechargeDTO = null;
            m_dtoResponseDataSaleGasDTO = null;
            m_dtoResponseDataSystemAdminDTO = null;
            m_dtoResponseDataGasStoreDTO = null;
            m_dsResponseDataSet = null;

            m_iCurrentPriceGas92 = 0;
            m_iCurrentPriceGas95 = 0;
            m_iCurrentPriceGasDO = 0;
        }
        //public DataTransfer(string json)
        //{
        //    parseJSON(json);
        //}
        public int ResponseCode
        {
            get { return m_iResponseCode; }
            set { m_iResponseCode = value; }
        }

        public int ResponseCurrentPriceGas92
        {
            get { return m_iCurrentPriceGas92; }
            set { m_iCurrentPriceGas92 = value; }
        }

        public int ResponseCurrentPriceGas95
        {
            get { return m_iCurrentPriceGas95; }
            set { m_iCurrentPriceGas95 = value; }
        }

        public int ResponseCurrentPriceGasDO
        {
            get { return m_iCurrentPriceGasDO; }
            set { m_iCurrentPriceGasDO = value; }
        }

        public string ResponseErrorMsg
        {
            get { return m_stResponseErrorMsg; }
            set { m_stResponseErrorMsg = value; }
        }

        public string ResponseErrorMsgDetail
        {
            get { return m_stResponseErrorMsgDetail; }
            set { m_stResponseErrorMsgDetail = value; }
        }

        public string ResponseDataString
        {
            get { return m_stResponseDataString; }
            set { m_stResponseDataString = value; }
        }
        public bool ResponseDataBool
        {
            get { return m_bResponseDataBool; }
            set { m_bResponseDataBool = value; }
        }
        public int ResponseDataInt
        {
            get { return m_bResponseDataInt; }
            set { m_bResponseDataInt = value; }
        }
        public CustomerDTO ResponseDataCustomerDTO
        {
            get { return m_dtoResponseDataCustomerDTO; }
            set { m_dtoResponseDataCustomerDTO = value; }
        }
        public CardDTO ResponseDataCardDTO
        {
            get { return m_dtoResponseDataCardDTO; }
            set { m_dtoResponseDataCardDTO = value; }
        }
        public GasStationDTO ResponseDataGasStationDTO
        {
            get { return m_dtoResponseDataGasStationDTO; }
            set { m_dtoResponseDataGasStationDTO = value; }
        }
        public RechargeDTO ResponseDataRechargeDTO
        {
            get { return m_dtoResponseDataRechargeDTO; }
            set { m_dtoResponseDataRechargeDTO = value; }
        }
        public SaleGasDTO ResponseDataSaleGasDTO
        {
            get { return m_dtoResponseDataSaleGasDTO; }
            set { m_dtoResponseDataSaleGasDTO = value; }
        }
        public SystemAdminDTO ResponseDataSystemAdminDTO
        {
            get { return m_dtoResponseDataSystemAdminDTO; }
            set { m_dtoResponseDataSystemAdminDTO = value; }
        }
        public GasStoreDTO ResponseDataGasStoreDTO
        {
            get { return m_dtoResponseDataGasStoreDTO; }
            set { m_dtoResponseDataGasStoreDTO = value; }
        }
        
        public DataSet ResponseDataSet
        {
            get { return m_dsResponseDataSet; }
            set { m_dsResponseDataSet = value; }
        }
        
    }
}