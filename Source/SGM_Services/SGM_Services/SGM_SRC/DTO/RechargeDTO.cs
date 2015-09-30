using System;
using System.Collections.Generic;
using System.Text;

namespace SGM.ServicesCore.DTO
{
    public class RechargeDTO
    {
        private int m_iRechargeID;  //primey key
        private DateTime m_dRechargeDate;       //sale date
        private int m_iRechargeGas92Price;      //price of gas 92 when recharge
        private int m_iRechargeGas95Price;      //price of gas 95 when recharge
        private int m_iRechargeGasDOPrice;      //price of gas Do when recharge
        private int m_iRechargeMoney;
        private string m_stRechargeNote;
        private string m_stCardID;  //forgein key

        public RechargeDTO()
        {
            m_iRechargeID = 0;
            m_dRechargeDate = DateTime.MinValue;
            m_iRechargeGas92Price = 0;
            m_iRechargeGas95Price = 0;
            m_iRechargeGasDOPrice = 0;
            m_stCardID = "";
        }

        public int RechargeID
        {
            get { return m_iRechargeID; }
            set { m_iRechargeID = value; }
        }

        public DateTime RechargeDate
        {
            get { return m_dRechargeDate; }
            set { m_dRechargeDate = value; }
        }

        public int RechargeGas92Price
        {
            get { return m_iRechargeGas92Price; }
            set { m_iRechargeGas92Price = value; }
        }
       
        public int RechargeGas95Price
        {
            get { return m_iRechargeGas95Price; }
            set { m_iRechargeGas95Price = value; }
        }

        public int RechargeGasDOPrice
        {
            get { return m_iRechargeGasDOPrice; }
            set { m_iRechargeGasDOPrice = value; }
        }

        public int RechargeMoney
        {
            get { return m_iRechargeMoney; }
            set { m_iRechargeMoney = value; }
        }

        public string RechargeNote
        {
            get { return m_stRechargeNote; }
            set { m_stRechargeNote = value; }
        }

        public string CardID
        {
            get { return m_stCardID; }
            set { m_stCardID = value; }
        }

        
    }
}
