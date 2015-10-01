using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;


namespace SGM_SaleGas
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



        public DataTransfer()
        {
            m_stResponseCode = RESPONSE_CODE_NONE;
            m_stResponseErrorMsg = "";
            m_stResponseErrorMsgDetail = "";
            m_stResponseDataString = "";
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
            }
        }
    }
}