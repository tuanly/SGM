﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.DTO
{
    public class GasStationDTO
    {
        private string m_stGasStationID;        //primate key
        private string m_stGasStationName;
        private string m_stGasStationAddress;
        private string m_stGasStationDescription;
        private string m_stGasStationMacAddress;
        private string m_stGasStoreID;

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

        public string GasStoreID
        {
            get { return m_stGasStoreID; }
            set { m_stGasStoreID = value; }
        }
    }
}
