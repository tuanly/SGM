using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils;
namespace SGM.ServicesCore.DAL
{
    public class CardDAL
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
                    dtoCard.CardMoneyEx = Int32.Parse(dr["CARD_MONEY_EX"].ToString());
                    dtoCard.CardBuyDate = DateTime.Parse(dr["CARD_BUY_DATE"].ToString());
                    dtoCard.RechargeID = Int32.Parse(dr["RECHARGE_ID"].ToString());
                    dtoCard.CustomerID = dr["CUS_ID"].ToString();
                }
            }
            return dtoCard;
        }



        public DataTransfer AddNewCard(CardDTO dtoCard)
        {
            DataTransfer dataResult = new DataTransfer();
            bool insertResult = true;
            try
            {
                string query = string.Format("INSERT INTO CARD (CARD_ID, CARD_STATE, CARD_MONEY, CARD_MONEY_EX, CARD_BUY_DATE, RECHARGE_ID, CUS_ID) VALUES (@CARD_ID, @CARD_STATE, @CARD_MONEY, @CARD_MONEY_EX, @CARD_BUY_DATE, @RECHARGE_ID, @CUS_ID)");
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoCard.CardID);
                sqlParameters[1] = new SqlParameter("@CARD_STATE", SqlDbType.Bit);
                sqlParameters[1].Value = Convert.ToBoolean(dtoCard.CardUnlockState);
                sqlParameters[2] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
                sqlParameters[2].Value = Convert.ToInt32(dtoCard.CardRemainingMoney);
                sqlParameters[3] = new SqlParameter("@CARD_MONEY_EX", SqlDbType.Int);
                sqlParameters[3].Value = Convert.ToInt32(dtoCard.CardMoneyEx);
                sqlParameters[4] = new SqlParameter("@CARD_BUY_DATE", SqlDbType.DateTime);
                sqlParameters[4].Value = Convert.ToDateTime(dtoCard.CardBuyDate);
                sqlParameters[5] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
                sqlParameters[5].Value = Convert.ToInt32(dtoCard.RechargeID);
                sqlParameters[6] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                sqlParameters[6].Value = Convert.ToString(dtoCard.CustomerID);
                insertResult = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                insertResult = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (insertResult)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_INSERT_ERR;
            }
            
            return dataResult;
        }

        public bool UpdateCard(CardDTO dtoCard)
        {
            bool result = true;
            string query = string.Format("UPDATE CARD SET CARD_STATE = @CARD_STATE, CARD_MONEY = @CARD_MONEY, CARD_MONEY_EX = @CARD_MONEY_EX, CARD_BUY_DATE = @CARD_BUY_DATE, RECHARGE_ID = @RECHARGE_ID WHERE CARD_ID = @CARD_ID");
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoCard.CardID);
            sqlParameters[1] = new SqlParameter("@CARD_STATE", SqlDbType.Bit);
            sqlParameters[1].Value = Convert.ToBoolean(dtoCard.CardUnlockState);
            sqlParameters[2] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoCard.CardRemainingMoney);
            sqlParameters[3] = new SqlParameter("@CARD_MONEY_EX", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoCard.CardMoneyEx);
            sqlParameters[4] = new SqlParameter("@CARD_BUY_DATE", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToDateTime(dtoCard.CardBuyDate);
            sqlParameters[5] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoCard.RechargeID);
            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public DataTransfer UpdateSaleGas(CardDTO dtoCard)
        {
            DataTransfer dataResult = new DataTransfer();
            bool result = true;
            try
            {
                string query = string.Format("UPDATE CARD SET CARD_MONEY = @CARD_MONEY, CARD_MONEY_EX = @CARD_MONEY_EX WHERE CARD_ID = @CARD_ID");
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoCard.CardID);
                sqlParameters[1] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
                sqlParameters[1].Value = Convert.ToInt32(dtoCard.CardRemainingMoney);
                sqlParameters[2] = new SqlParameter("@CARD_MONEY_EX", SqlDbType.Int);
                sqlParameters[3].Value = Convert.ToInt32(dtoCard.CardMoneyEx);
                result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                result = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (result)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_INSERT_ERR;
            }
            
            return dataResult;
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
        public DataTable ValidateCardID(string stCardID)
        {            
            string query = string.Format("SELECT * FROM CARD c, RECHARGE r, CUSTOMER cu WHERE c.CARD_ID = @CARD_ID AND c.RECHARGE_ID = r.RECHARGE_ID AND cu.CUS_ID = c.CUS_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stCardID);
            DataTable tblCard = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
            return tblCard;
        }

        public DataTransfer IsCardExisted(string stCardID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT * FROM CARD WHERE CARD_ID = @CARD_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCardID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dataResult.ResponseDataBool = true;
                }
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_DATA_INPUT_EXIST_CARD_ID_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer UpdateRechargeIDForCard(string stCardID)
        {
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE CARD SET RECHARGE_ID = (SELECT MAX (RECHARGE_ID) FROM RECHARGE) WHERE CARD_ID = @CARD_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCardID);
                updateResult = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);                
            }
            catch (Exception ex)
            {
                updateResult = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (updateResult)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_UPDATE_RECHARGE_ID_ERR;
            }
            return dataResult;
        }
		
		public DataTransfer UpdateMoneyForCard(string stCardID, int iMoney)
        {
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE CARD SET CARD_MONEY = @CARD_MONEY, CARD_MONEY_EX = @CARD_MONEY_EX WHERE CARD_ID = @CARD_ID");
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCardID);
				sqlParameters[1] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
                sqlParameters[1].Value = Convert.ToInt32(iMoney);
                sqlParameters[2] = new SqlParameter("@CARD_MONEY_EX", SqlDbType.Int);
                sqlParameters[2].Value = Convert.ToInt32(0);
                updateResult = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);                
            }
            catch (Exception ex)
            {
                updateResult = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (updateResult)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_UPDATE_MONEY_ERR;
            }
            return dataResult;
        }

        public DataTransfer UpdateMoneyForCard(string stCardID, int iMoney, int iMoneyEx)
        {
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE CARD SET CARD_MONEY = @CARD_MONEY, CARD_MONEY_EX = @CARD_MONEY_EX WHERE CARD_ID = @CARD_ID");
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCardID);
                sqlParameters[1] = new SqlParameter("@CARD_MONEY", SqlDbType.Int);
                sqlParameters[1].Value = Convert.ToInt32(iMoney);
                sqlParameters[2] = new SqlParameter("@CARD_MONEY_EX", SqlDbType.Int);
                sqlParameters[2].Value = Convert.ToInt32(iMoneyEx);
                updateResult = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                updateResult = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (updateResult)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_UPDATE_MONEY_ERR;
            }
            return dataResult;
        }

        public DataTransfer GetCardsOfCustomer(string stCusID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT * FROM CARD, RECHARGE WHERE CARD.CARD_ID = RECHARGE.CARD_ID AND RECHARGE.RECHARGE_ID = CARD.RECHARGE_ID AND CUS_ID = @CUS_ID"); ;
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCusID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);                
                if (tblResult.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblResult.Copy());
                    dataResult.ResponseDataSet = ds;
                }
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_GET_CARDS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer UpdateCardState(string stCardID, bool bLocked)
        {
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE CARD SET CARD_STATE = @CARD_STATE WHERE CARD_ID = @CARD_ID");
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCardID);
                sqlParameters[1] = new SqlParameter("@CARD_STATE", SqlDbType.Bit);
                sqlParameters[1].Value = Convert.ToBoolean(bLocked);
                updateResult = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                updateResult = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (updateResult)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CARD_UPDATE_CARD_STATE_ERR;
            }
            return dataResult;
        }

        public DataTransfer GetCardReport(string strCusId, DateTime dateStart, DateTime dateEnd, string stCardID)
        {
            DataTransfer res = new DataTransfer();
            try
            {
                int numParam = 2;
                string query = string.Format("SELECT * FROM CARD, CUSTOMER, RECHARGE WHERE CARD.CARD_ID = RECHARGE.CARD_ID AND CUSTOMER.CUS_ID = CARD.CUS_ID AND CARD_BUY_DATE BETWEEN @STARTDATE AND @ENDDATE");
                if (!strCusId.Equals(""))
                {
                    numParam++;
                    query += string.Format(" AND CUSTOMER.CUS_ID = @CUS_ID");
                }
                if (!stCardID.Trim().Equals(""))
                {
                    numParam++;
                    query += string.Format(" AND CARD.CARD_ID = @CARD_ID");
                }
                res.ResponseDataString = query;
                SqlParameter[] sqlParameters = new SqlParameter[numParam];               
                sqlParameters[0] = new SqlParameter("@STARTDATE", SqlDbType.DateTime);
                sqlParameters[0].Value = dateStart;
                sqlParameters[1] = new SqlParameter("@ENDDATE", SqlDbType.DateTime);
                sqlParameters[1].Value = dateEnd;

                if (numParam == 3)
                {
                    if (!strCusId.Equals(""))
                    {
                        sqlParameters[2] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = strCusId;
                    }
                    else
                    {
                        sqlParameters[2] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = stCardID;
                    }
                }
                else if (numParam == 4)
                {
                    sqlParameters[2] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                    sqlParameters[2].Value = strCusId;
                    sqlParameters[3] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                    sqlParameters[3].Value = stCardID;
                }
               
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                res.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                if (tblResult != null && tblResult.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblResult.Copy());
                    res.ResponseDataSet = ds;
                }
            }
            catch (Exception e)
            {
                res.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                res.ResponseErrorMsg = e.StackTrace;
            }
            return res;
        }
    }   
}
