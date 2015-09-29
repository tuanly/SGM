using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;


namespace SGM.ServicesCore
{
    class DataTransfer
    {
        public static int RESPONSE_CODE_NONE = -1;
        public static int RESPONSE_CODE_SUCCESS = 0;
        public static int RESPONSE_CODE_FAIL = 1;

        private int m_stResponseCode;
        private string m_stResponseData;

        public DataTransfer()
        {
            m_stResponseCode = RESPONSE_CODE_NONE;            
            m_stResponseData = "";
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

        public string ResponseData
        {
            get { return m_stResponseData; }
            set { m_stResponseData = value; }
        }

        public string createJSON()
        {
            var serializer = new DataContractJsonSerializer(typeof(DataTransfer));
            string jsonString = "";
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, this);
                jsonString = Encoding.UTF8.GetString(stream.ToArray());
            }
            return jsonString;
        }

        public void parseJSON(String jsonString)
        {
            var serializer = new DataContractJsonSerializer(typeof(DataTransfer));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                var data = (DataTransfer)serializer.ReadObject(stream);
                m_stResponseData = data.ResponseData;
                m_stResponseCode = data.ResponseCode;
            }
        }
    }
}