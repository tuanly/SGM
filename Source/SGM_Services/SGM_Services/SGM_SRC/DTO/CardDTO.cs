using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGM.ServicesCore.DTO
{
    class CardDTO
    {
        private string m_stCardID; //private key
        private bool m_bCardState; //false: lock, true: unlock
        private int m_iCardMoney;  //remaining money in card
        private DateTime m_dCardBuyDate; // Date when card is bought
        private int m_iRechargeID;
        private string m_iCustomerID;

        public CardDTO()
        {
            m_stCardID = "";
            m_bCardState = false;
            m_iCardMoney = 0;
            m_iRechargeID = 0;
        }
        public string CardID
        {
            get { return m_stCardID; }
            set { m_stCardID = value; }
        }

        public bool CardUnlockState
        {
            get { return m_bCardState; }
            set { m_bCardState = value; }
        }

        public int CardRemainingMoney
        {
            get { return m_iCardMoney; }
            set { m_iCardMoney = value; }
        }

        public DateTime CardBuyDate
        {
            get { return m_dCardBuyDate; }
            set { m_dCardBuyDate = value; }
        }

        public int RechargeID
        {
            get { return m_iRechargeID; }
            set { m_iRechargeID = value; }
        }

        public string CustomerID
        {
            get { return m_iCustomerID; }
            set { m_iCustomerID = value; }
        }
        
    }
}
