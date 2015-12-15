using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.DTO
{
    public class GasStoreDTO
    {
        private string m_stGasStoreID;        //primate key
        private string m_stGasStoreName;
        private string m_stGasStoreAddress;
        private string m_stGasStoreDescription;
        private string m_stGasStoreMacAddress;    
    
         public GasStoreDTO()
        {
            m_stGasStoreID = "";
            m_stGasStoreName = "";
            m_stGasStoreAddress = "";
            m_stGasStoreMacAddress = "";
        }

        public string GasStoreID
        {
            get { return m_stGasStoreID; }
            set { m_stGasStoreID = value; }
        }


        public string GasStoreName
        {
            get { return m_stGasStoreName; }
            set { m_stGasStoreName = value; }
        }

        public string GasStoreAddress
        {
            get { return m_stGasStoreAddress; }
            set { m_stGasStoreAddress = value; }
        }

        public string GasStoreDescription
        {
            get { return m_stGasStoreDescription; }
            set { m_stGasStoreDescription = value; }
        }

        public string GasStoreMacAddress
        {
            get { return m_stGasStoreMacAddress; }
            set { m_stGasStoreMacAddress = value; }
        }
    }
}
