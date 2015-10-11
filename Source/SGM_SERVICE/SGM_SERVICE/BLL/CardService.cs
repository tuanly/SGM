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
        //private DataTransfer m_dataRequest;
        private DataTransfer m_dataResponse;

        public CardService()
        {
            m_dalCard = new CardDAL();
            //m_dataRequest = null;
            m_dataResponse = null;
        }

        public string CheckCardExist(string stCaradID)
        {
            m_dataResponse = m_dalCard.IsCardExisted(stCaradID);
            return JSonHelper.ConvertObjectToJSon(m_dataResponse);
        }
    }
}