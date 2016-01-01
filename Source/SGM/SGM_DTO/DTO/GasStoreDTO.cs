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
        private float m_fGasStoreGas92Total;   //total gas92 in store
        private float m_fGasStoreGas95Total;   //total gas95 in store
        private float m_fGasStoreGasDOTotal;   //total gasDO in store
    
         public GasStoreDTO()
        {
            m_stGasStoreID = "";
            m_stGasStoreName = "";
            m_stGasStoreAddress = "";
            m_stGasStoreMacAddress = "";
            m_fGasStoreGas92Total = 0;
            m_fGasStoreGas95Total = 0;
            m_fGasStoreGasDOTotal = 0;
        }
        public GasStoreDTO(GasStoreDTO other)
        {
            GasStoreID = other.GasStoreID ;
            GasStoreName = other.GasStoreName;
            GasStoreAddress = other.GasStoreAddress;
            GasStoreMacAddress = other.GasStoreMacAddress;
            GasStoreDescription = other.GasStoreDescription ;
            GasStoreGas92Total = other.GasStoreGas92Total;
            GasStoreGas95Total = other.GasStoreGas95Total;
            GasStoreGasDOTotal = other.GasStoreGasDOTotal;
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

        public float GasStoreGas92Total
        {
            get { return m_fGasStoreGas92Total; }
            set { m_fGasStoreGas92Total = value; }
        }

        public float GasStoreGas95Total
        {
            get { return m_fGasStoreGas95Total; }
            set { m_fGasStoreGas95Total = value; }
        }

        public float GasStoreGasDOTotal
        {
            get { return m_fGasStoreGasDOTotal; }
            set { m_fGasStoreGasDOTotal = value; }
        }
    }
}
