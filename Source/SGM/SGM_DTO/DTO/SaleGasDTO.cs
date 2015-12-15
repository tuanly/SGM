using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_Core.DTO
{
    public class SaleGasDTO
    {
        public static string GAS_TYPE_95 = "95";
        public static string GAS_TYPE_92 = "92";
        public static string GAS_TYPE_DO = "DO";

        private int m_iSaleGasID;
        private string m_stSaleGasType;
        private int m_iCurrentPrice;
        private int m_iPriceOnCard;
        private int m_iCardMoneyBefore;
        private int m_iCardMoneyAfter;
        private int m_iCardMoneySaving;
        private string m_stGasStationID;
        private string m_stCardID;
        private DateTime m_dtSalGasDate;

        public SaleGasDTO()
        {
            m_iSaleGasID = 0;
            m_stSaleGasType = "";
            m_iCurrentPrice = 0;
            m_iPriceOnCard = 0;
            m_iCardMoneyBefore = 0;
            m_iCardMoneyAfter = 0;
            m_stGasStationID = "";
            m_stCardID = "";
            m_dtSalGasDate = DateTime.Now;
        }

        public int SaleGasID
        {
            get { return m_iSaleGasID; }
            set { m_iSaleGasID = value; }
        }

        public string SaleGasType
        {
            get { return m_stSaleGasType; }
            set { m_stSaleGasType = value; }
        }

        public int SaleGasCurrentPrice
        {
            get { return m_iCurrentPrice; }
            set { m_iCurrentPrice = value; }
        }

        public int SaleGasPriceOnCard
        {
            get { return m_iPriceOnCard; }
            set { m_iPriceOnCard = value; }
        }

        public int SaleGasCardMoneyBefore
        {
            get { return m_iCardMoneyBefore; }
            set { m_iCardMoneyBefore = value; }
        }

        public int SaleGasCardMoneyAfter
        {
            get { return m_iCardMoneyAfter; }
            set { m_iCardMoneyAfter = value; }
        }

        public int SaleGasCardMoneySaving
        {
            get { return m_iCardMoneySaving; }
            set { m_iCardMoneySaving = value; }
        }

        public string GasStationID
        {
            get { return m_stGasStationID; }
            set { m_stGasStationID = value; }
        }

        public string CardID
        {
            get { return m_stCardID; }
            set { m_stCardID = value; }
        }

        public DateTime SaleGasDate
        {
            get { return m_dtSalGasDate; }
            set { m_dtSalGasDate = value; }
        }
    }
}
