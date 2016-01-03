using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.DTO
{
    public class SystemAdminDTO
    {

        public static int GAS_TYPE_92 = 0;
        public static int GAS_TYPE_95 = 1;
        public static int GAS_TYPE_DO = 2;
        public static int GAS_TYPE_ALL = 3;

        private string m_stSysAdmin;    //admin account, primate key
        private string m_stSysPwd;      //admin password       
        private int m_iSysGas92CurrentPrice;    //current price of gas92
        private int m_iSysGas95CurrentPrice;    //current price of gas95
        private int m_iSysGasDOCurrentPrice;    //current price of gasDO
        private int m_iSysGas92NewPrice;        //new price of gas92
        private int m_iSysGas95NewPrice;        //new price of gas95
        private int m_iSysGasDONewPrice;        //new price of gasDO
        private DateTime m_dSysApplyDate;       //the date will apply new price

        public SystemAdminDTO()
        {
            m_stSysAdmin = "";
            m_stSysPwd = "";           
            m_iSysGas92CurrentPrice = 0;
            m_iSysGas95CurrentPrice = 0;
            m_iSysGasDOCurrentPrice = 0;
            m_iSysGas92NewPrice = 0;
            m_iSysGas95NewPrice = 0;
            m_iSysGasDONewPrice = 0;
            m_dSysApplyDate = DateTime.MinValue;
        }

        public string SysAdminAccount
        {
            get { return m_stSysAdmin; }
            set { m_stSysAdmin = value; }
        }

        public string SysAdminPwd
        {
            get { return m_stSysPwd; }
            set { m_stSysPwd = value; }
        }

        public int SysGas92CurrentPrice
        {
            get { return m_iSysGas92CurrentPrice; }
            set { m_iSysGas92CurrentPrice = value; }
        }

        public int SysGas95CurrentPrice
        {
            get { return m_iSysGas95CurrentPrice; }
            set { m_iSysGas95CurrentPrice = value; }
        }

        public int SysGasDOCurrentPrice
        {
            get { return m_iSysGasDOCurrentPrice; }
            set { m_iSysGasDOCurrentPrice = value; }
        }

        public int SysGas92NewPrice
        {
            get { return m_iSysGas92NewPrice; }
            set { m_iSysGas92NewPrice = value; }
        }

        public int SysGas95NewPrice
        {
            get { return m_iSysGas95NewPrice; }
            set { m_iSysGas95NewPrice = value; }
        }

        public int SysGasDONewPrice
        {
            get { return m_iSysGasDONewPrice; }
            set { m_iSysGasDONewPrice = value; }
        }

        public DateTime SysApplyDate
        {
            get { return m_dSysApplyDate; }
            set { m_dSysApplyDate = value; }
        }
        
    }
}
