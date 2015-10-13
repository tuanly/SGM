using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM.ServicesCore.DAL
{
    public class RechargeDAL
    {
        private DBConnetionDAL m_dbConnection;

        public RechargeDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        public RechargeDTO GetRecharge(int iRechargeID)
        {
            RechargeDTO dtoRecharge = null;
            string query = string.Format("SELECT * FROM RECHARGE WHERE RECHARGE_ID = @RECHARGE_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt32(iRechargeID);
            DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
            if (tblResult.Rows.Count > 0)
            {
                dtoRecharge = new RechargeDTO();
                foreach (DataRow dr in tblResult.Rows)
                {
                    dtoRecharge.RechargeID = Int32.Parse(dr["RECHARGE_ID"].ToString());
                    dtoRecharge.RechargeDate = DateTime.Parse(dr["RECHARGE_DATE"].ToString());
                    dtoRecharge.RechargeGas92Price = Int32.Parse(dr["RECHARGE_GAS92_PRICE"].ToString());
                    dtoRecharge.RechargeGas95Price = Int32.Parse(dr["RECHARGE_GAS95_PRICE"].ToString());
                    dtoRecharge.RechargeGasDOPrice = Int32.Parse(dr["RECHARGE_GASDO_PRICE"].ToString());
                    dtoRecharge.RechargeMoney = Int32.Parse(dr["RECHARGE_MONEY"].ToString());
                    dtoRecharge.RechargeNote = dr["RECHARGE_MONEY"].ToString();
                    dtoRecharge.CardID = dr["CARD_ID"].ToString();                   
                }
            }
            return dtoRecharge;
        }

        public DataTransfer AddRecharge(RechargeDTO dtoRecharge)
        {
            DataTransfer dataResult = new DataTransfer();
            bool insertResult = true;
            try
            {
                string query = string.Format("INSERT INTO RECHARGE (RECHARGE_DATE, RECHARGE_GAS92_PRICE, RECHARGE_GAS95_PRICE, RECHARGE_GASDO_PRICE, RECHARGE_MONEY, RECHARGE_NOTE, CARD_ID)" +
                                                           " VALUES (@RECHARGE_DATE, @RECHARGE_GAS92_PRICE, @RECHARGE_GAS95_PRICE, @RECHARGE_GASDO_PRICE, @RECHARGE_MONEY, @RECHARGE_NOTE, @CARD_ID)");
                
                SqlParameter[] sqlParameters = new SqlParameter[7];               
                sqlParameters[0] = new SqlParameter("@RECHARGE_DATE", SqlDbType.DateTime);
                sqlParameters[0].Value = Convert.ToDateTime(dtoRecharge.RechargeDate);
                sqlParameters[1] = new SqlParameter("@RECHARGE_GAS92_PRICE", SqlDbType.Int);
                sqlParameters[1].Value = Convert.ToInt32(dtoRecharge.RechargeGas92Price);
                sqlParameters[2] = new SqlParameter("@RECHARGE_GAS95_PRICE", SqlDbType.Int);
                sqlParameters[2].Value = Convert.ToInt32(dtoRecharge.RechargeGas95Price);
                sqlParameters[3] = new SqlParameter("@RECHARGE_GASDO_PRICE", SqlDbType.Int);
                sqlParameters[3].Value = Convert.ToInt32(dtoRecharge.RechargeGasDOPrice);
                sqlParameters[4] = new SqlParameter("@RECHARGE_MONEY", SqlDbType.Int);
                sqlParameters[4].Value = Convert.ToInt32(dtoRecharge.RechargeMoney);
                sqlParameters[5] = new SqlParameter("@RECHARGE_NOTE", SqlDbType.NVarChar);
                sqlParameters[5].Value = Convert.ToString(dtoRecharge.RechargeNote);
                sqlParameters[6] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[6].Value = Convert.ToString(dtoRecharge.CardID);
                

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
                dataResult.ResponseErrorMsg = SGMText.CARD_RECHARGE_INSERT_ERR;
            }
            return dataResult;
        }

        public bool UpdateRecharge(RechargeDTO dtoRecharge)
        {
            bool result = true;
            string query = string.Format("UPDATE RECHARGE SET RECHARGE_DATE = @RECHARGE_DATE, RECHARGE_MONEY = @RECHARGE_MONEY, RECHARGE_NOTE = @RECHARGE_NOTE, " + 
                                                            " RECHARGE_GAS92_PRICE = @RECHARGE_GAS92_PRICE, RECHARGE_GAS95_PRICE = @RECHARGE_GAS95_PRICE, RECHARGE_GASDO_PRICE = @RECHARGE_GASDO_PRICE, CARD_ID = @CARD_ID " +
                                                      " WHERE RECHARGE_ID = @RECHARGE_ID"
                                                      );
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt32(dtoRecharge.RechargeID);
            sqlParameters[1] = new SqlParameter("@RECHARGE_DATE", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(dtoRecharge.RechargeDate);
            sqlParameters[4] = new SqlParameter("@RECHARGE_GAS92_PRICE", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoRecharge.RechargeGas92Price);
            sqlParameters[5] = new SqlParameter("@RECHARGE_GAS95_PRICE", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoRecharge.RechargeGas95Price);
            sqlParameters[6] = new SqlParameter("@RECHARGE_GASDO_PRICE", SqlDbType.Int);
            sqlParameters[6].Value = Convert.ToInt32(dtoRecharge.RechargeGasDOPrice);
            sqlParameters[8] = new SqlParameter("@RECHARGE_NOTE", SqlDbType.NVarChar);
            sqlParameters[8].Value = Convert.ToString(dtoRecharge.RechargeNote);
            sqlParameters[9] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[9].Value = Convert.ToString(dtoRecharge.CardID);

            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public bool DeleteCard(int iRechargeID)
        {
            bool result = true;
            string query = string.Format("DELETE FROM RECHARGE WHERE RECHARGE_ID = @RECHARGE_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@RECHARGE_ID", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt32(iRechargeID);
            result = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }
    }
}
