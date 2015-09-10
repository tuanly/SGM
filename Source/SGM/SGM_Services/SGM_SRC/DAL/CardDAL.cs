using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM.ServicesCore.DTO;


namespace SGM.ServicesCore.DAL
{
    class CardDAL
    {        
        private DBConnetionDAL m_dbConnection;

        public CardDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        public CardDTO GetCard(string stCardID)
        {
            CardDTO dtoCard = null;
            string query = string.Format("SELECT * FROM CARD WHERE CARD_ID = @CARD_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stCardID);
            DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
            if (tblResult.Rows.Count > 0)
            {
                dtoCard = new CardDTO();
                foreach (DataRow dr in tblResult.Rows)
                {
                    dtoCard.CardID = dr["CARD_ID"].ToString(); ;
                    dtoCard.CardUnlockState = Boolean.Parse(dr["CARD_STATE"].ToString());
                    dtoCard.CardRemainingMoney = Int32.Parse(dr["CARD_MONEY"].ToString());
                    dtoCard.RechargeID = Int32.Parse(dr["RECHARGE_ID"].ToString());
                    dtoCard.CustomerID = dr["CUS_ID"].ToString();
                }
            }
            return dtoCard;
        }

        public bool AddNewCard(CardDTO dtoCard)
        {
            bool result = true;
            string query = string.Format("INSERT INTO CARD (CARD_ID, CARD_STATE, CARD_MONEY, RECHARGE_ID, CUS_ID) VALUES (@CARD_ID, @CARD_STATE, @CARD_MONEY, @RECHARGE_ID, @CUS_ID)");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoCard.CardID);
            sqlParameters[1] = new SqlParameter("@CARD_STATE", SqlDbType.Bit);
            sqlParameters[1].Value = Convert.ToBoolean(dtoCard.CardUnlockState);
            sqlParameters[2] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoCard.CardRemainingMoney);
            sqlParameters[3] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoCard.RechargeID);
            sqlParameters[4] = new SqlParameter("@CUS_ID", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoCard.CustomerID);
            result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);           
            return result;
        }

        public bool UpdateCard(CardDTO dtoCard)
        {
            bool result = true;
            string query = string.Format("UPDATE CARD SET CARD_STATE = @CARD_STATE, CARD_MONEY = @CARD_MONEY, RECHARGE_ID = @RECHARGE_ID WHERE CARD_ID = @CARD_ID");
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoCard.CardID);
            sqlParameters[1] = new SqlParameter("@CARD_STATE", SqlDbType.Bit);
            sqlParameters[1].Value = Convert.ToBoolean(dtoCard.CardUnlockState);
            sqlParameters[2] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoCard.CardRemainingMoney);
            sqlParameters[3] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoCard.RechargeID);
            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public bool DeleteCard(string stCardID)
        {
            bool result = true;
            string query = string.Format("DELETE FROM CARD WHERE CARD_ID = @CARD_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stCardID);            
            result = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }

    }
}
