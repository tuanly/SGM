﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace SGM_Core.DTO
{
    public class DataTransfer
    {
        public static int RESPONSE_CODE_NONE = -1;
        public static int RESPONSE_CODE_SUCCESS = 0;
        public static int RESPONSE_CODE_FAIL = 1;

        private int m_stResponseCode;
        private string m_stResponseErrorMsg;
        private string m_stResponseErrorMsgDetail;
        private string m_stResponseDataString;
        private bool m_bResponseDataBool;
        private Object m_dtoResponseDataDTO;
        private DataSet m_dsResponseDataSet;


        public DataTransfer()
        {
            m_stResponseCode = RESPONSE_CODE_NONE;
            m_stResponseErrorMsg = "";
            m_stResponseErrorMsgDetail = "";
            m_stResponseDataString = "";
            m_bResponseDataBool = false;
            m_dtoResponseDataDTO = null;
            m_dsResponseDataSet = null;
        }
        public DataTransfer(string json)
        {
            parseJSON(json);
        }
        public int ResponseCode
        {
            get { return m_stResponseCode; }
            set { m_stResponseCode = value; }
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
        public Object ResponseDataDTO
        {
            get { return m_dtoResponseDataDTO; }
            set { m_dtoResponseDataDTO = value; }
        }
        public DataSet ResponseDataSet
        {
            get { return m_dsResponseDataSet; }
            set { m_dsResponseDataSet = value; }
        }

       

        public string createJSON()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataTransfer));
            string jsonString = "";
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, this);
                jsonString = Encoding.UTF8.GetString(stream.ToArray());
            }
            return jsonString;
        }

        public void parseJSON(String jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataTransfer));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataTransfer data = (DataTransfer)serializer.ReadObject(stream);
                m_stResponseErrorMsg = data.ResponseErrorMsg;
                m_stResponseDataString = data.ResponseDataString;
                m_stResponseErrorMsgDetail = data.ResponseErrorMsgDetail;
                m_stResponseCode = data.ResponseCode;
                m_bResponseDataBool = data.ResponseDataBool;
                m_dtoResponseDataDTO = data.ResponseDataDTO;
                m_dsResponseDataSet = data.ResponseDataSet;

            }
        }
    }
}