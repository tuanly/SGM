using System;
using System.Collections.Generic;
using SGM_Core.DTO;
using System.Data;
using SGM_Core.Utils;
using SGM.ServicesCore.DAL;
using System.Web;

namespace SGM.ServicesCore.BLL
{
    public class CardService
    {
        private CardDAL m_dalCard;
        private RechargeDAL m_dalRecharge;
        private SaleGasDAL m_dalSaleGas;
        private DataTransfer m_dataRequest;
        private DataTransfer m_dataResponse;

        public CardService()
        {
            m_dalCard = new CardDAL();
            m_dalRecharge = new RechargeDAL();
            m_dalSaleGas = new SaleGasDAL();
            m_dataRequest = null;
            m_dataResponse = null;
        }

        public string CheckCardExist(string stCardID)
        {
            m_dataResponse = m_dalCard.IsCardExisted(stCardID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string AddNewCard(string jsCardDTO)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsCardDTO);
            m_dataResponse = m_dalCard.AddNewCard(m_dataRequest.ResponseDataCardDTO);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string AddRechargeCard(string jsRechargeDTO)
        {
            m_dataRequest = JSonHelper.ConvertJSonToObject(jsRechargeDTO);
            m_dataResponse = m_dalRecharge.AddRecharge(m_dataRequest.ResponseDataRechargeDTO);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string UpdateRechargeIDForCard(string stCardID)
        {           
            m_dataResponse = m_dalCard.UpdateRechargeIDForCard(stCardID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
		
		public string UpdateMoneyForCard(string stCardID, int iMoney)
		{
			m_dataResponse = m_dalCard.UpdateMoneyForCard(stCardID, iMoney);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
		}

        public string GetCardsOfCustomer(string stCusID)
        {
            m_dataResponse = m_dalCard.GetCardsOfCustomer(stCusID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }

        public string UpdateCardState(string stCardID, bool bLocked)
        {
            m_dataResponse = m_dalCard.UpdateCardState(stCardID, bLocked);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
       
    }
}