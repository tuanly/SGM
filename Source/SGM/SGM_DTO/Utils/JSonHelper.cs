using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SGM_Core.Utils
{
    
    public class JSonHelper 
    {

        public string ConvertObjectToJSon(DataTransfer obj)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DataTransfer));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, obj);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public DataTransfer ConvertJSonToObject(string jsonString)
        {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataTransfer));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            DataTransfer obj = (DataTransfer)serializer.ReadObject(ms);
            return obj;
        }
    }


}
