using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGM.ServicesCore.DTO
{
    class GasStationDTO
    {
        private string m_stGasStationID;        //primate key
        private string m_stGasStationName;
        private string m_stGasStationAddress;
        private string m_stGasStationDescription;
        private string m_stGasStationMacAddress;

        public GasStationDTO()
        {
            m_stGasStationID = "";
            m_stGasStationName = "";
            m_stGasStationAddress = "";
            m_stGasStationDescription = "";
        }

        public string GasStationID
        {
            get { return m_stGasStationID; }
            set { m_stGasStationID = value; }
        }


        public string GasStationName
        {
            get { return m_stGasStationName; }
            set { m_stGasStationName = value; }
        }

        public string GasStationAddress
        {
            get { return m_stGasStationAddress; }
            set { m_stGasStationAddress = value; }
        }

        public string GasStationDescription
        {
            get { return m_stGasStationDescription; }
            set { m_stGasStationDescription = value; }
        }

        public string GasStationMacAddress
        {
            get { return m_stGasStationMacAddress; }
            set { m_stGasStationMacAddress = value; }
        }
    }
}
