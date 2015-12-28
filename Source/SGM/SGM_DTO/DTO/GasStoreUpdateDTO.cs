using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.DTO
{
    public class GasStoreUpdateDTO
    {
        private int m_iGSUpdateID;        //primate key       
        private float m_iGSUpdateGas92Add;   //added gas92 in store
        private float m_iGSUpdateGas95Add;   //added gas95 in store
        private float m_iGSUpdateGasDOAdd;   //added gasDO in store
        private DateTime m_dGSUpdateDate;
        private string m_stGSUpdateDescription;
        private string m_stGasStoreID;

        public GasStoreUpdateDTO()
        {
            m_iGSUpdateID = 0;
            m_iGSUpdateGas92Add = 0;
            m_iGSUpdateGas95Add = 0;
            m_iGSUpdateGasDOAdd = 0;
            m_dGSUpdateDate = DateTime.Now;
            m_stGSUpdateDescription = "";
            m_stGasStoreID = "";
        }

        public int GSUpdateID
        {
            get { return m_iGSUpdateID; }
            set { m_iGSUpdateID = value; }
        }

        public float GSUpdateGas92Add
        {
            get { return m_iGSUpdateGas92Add; }
            set { m_iGSUpdateGas92Add = value; }
        }

        public float GSUpdateGas95Add
        {
            get { return m_iGSUpdateGas95Add; }
            set { m_iGSUpdateGas95Add = value; }
        }

        public float GSUpdateGasDOAdd
        {
            get { return m_iGSUpdateGasDOAdd; }
            set { m_iGSUpdateGasDOAdd = value; }
        }

        public DateTime GSUpdateDate
        {
            get { return m_dGSUpdateDate; }
            set { m_dGSUpdateDate = value; }
        }

        public string GSUpdateDescription
        {
            get { return m_stGSUpdateDescription; }
            set { m_stGSUpdateDescription = value; }
        }

        public string GasStoreID
        {
            get { return m_stGasStoreID; }
            set { m_stGasStoreID = value; }
        }

    }
}
