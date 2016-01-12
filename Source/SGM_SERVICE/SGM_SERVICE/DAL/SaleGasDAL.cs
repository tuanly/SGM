using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM.ServicesCore.DAL
{
    public class SaleGasDAL
    {
        private DBConnetionDAL m_dbConnection;

        public SaleGasDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        public SaleGasDTO GetSaleGas(int iSaleGasID)
        {
            SaleGasDTO dtoSaleGas = null;
            string query = string.Format("SELECT * FROM SALE_GAS WHERE SALEGAS_ID = @SALEGAS_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@SALEGAS_ID", SqlDbType.Int);
            sqlParameters[0].Value = iSaleGasID;
            DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
            if (tblResult.Rows.Count > 0)
            {
                dtoSaleGas = new SaleGasDTO();
                foreach (DataRow dr in tblResult.Rows)
                {
                    dtoSaleGas.SaleGasID = Int32.Parse(dr["SALEGAS_ID"].ToString());
                    dtoSaleGas.SaleGasType = dr["SALEGAS_TYPE"].ToString();
                    dtoSaleGas.SaleGasCurrentPrice = Int32.Parse(dr["SALEGAS_CURRENT_PRICE"].ToString());
                    dtoSaleGas.SaleGasPriceOnCard = Int32.Parse(dr["SALEGAS_CARD_PRICE"].ToString());
                    dtoSaleGas.SaleGasCardMoneyBefore = Int32.Parse(dr["SALEGAS_CARD_MONEY_BEFORE"].ToString());
                    dtoSaleGas.SaleGasCardMoneyAfter = Int32.Parse(dr["SALEGAS_CARD_MONEY_AFTER"].ToString());
                    dtoSaleGas.GasStationID = dr["GASSTATION_ID"].ToString();
                    dtoSaleGas.SaleGasDate = DateTime.Parse(dr["SALEGAS_DATE"].ToString());
                    dtoSaleGas.CardID = dr["CARD_ID"].ToString();
                    dtoSaleGas.NumberBuyLit = float.Parse(dr["SALEGAS_LIT"].ToString());
                }
            }
            return dtoSaleGas;
        }

        public DataTransfer AddSaleGas(SaleGasDTO dtoSaleGas)
        {
            bool result = true;
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("INSERT INTO SALE_GAS (SALEGAS_TYPE, SALEGAS_CURRENT_PRICE, SALEGAS_CARD_PRICE, SALEGAS_CARD_MONEY_BEFORE, SALEGAS_CARD_MONEY_AFTER, SALEGAS_CARD_MONEY_SAVING, SALEGAS_LIT, SALEGAS_DATE, GASSTATION_ID, CARD_ID)" +
                                                               " VALUES (@SALEGAS_TYPE, @SALEGAS_CURRENT_PRICE, @SALEGAS_CARD_PRICE, @SALEGAS_CARD_MONEY_BEFORE, @SALEGAS_CARD_MONEY_AFTER, @SALEGAS_CARD_MONEY_SAVING, @SALEGAS_LIT, @SALEGAS_DATE, @GASSTATION_ID, @CARD_ID)");
                SqlParameter[] sqlParameters = new SqlParameter[10];
                sqlParameters[0] = new SqlParameter("@SALEGAS_TYPE", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoSaleGas.SaleGasType);
                sqlParameters[1] = new SqlParameter("@SALEGAS_CURRENT_PRICE", SqlDbType.Int);
                sqlParameters[1].Value = Convert.ToInt32(dtoSaleGas.SaleGasCurrentPrice);
                sqlParameters[2] = new SqlParameter("@SALEGAS_CARD_PRICE", SqlDbType.Int);
                sqlParameters[2].Value = Convert.ToInt32(dtoSaleGas.SaleGasPriceOnCard);
                sqlParameters[3] = new SqlParameter("@SALEGAS_CARD_MONEY_BEFORE", SqlDbType.Int);
                sqlParameters[3].Value = Convert.ToInt32(dtoSaleGas.SaleGasCardMoneyBefore);
                sqlParameters[4] = new SqlParameter("@SALEGAS_CARD_MONEY_AFTER", SqlDbType.Int);
                sqlParameters[4].Value = Convert.ToInt32(dtoSaleGas.SaleGasCardMoneyAfter);
                sqlParameters[5] = new SqlParameter("@SALEGAS_LIT", SqlDbType.Float);
                sqlParameters[5].Value = Convert.ToDouble(dtoSaleGas.NumberBuyLit);
                sqlParameters[6] = new SqlParameter("@SALEGAS_DATE", SqlDbType.DateTime);
                sqlParameters[6].Value = (dtoSaleGas.SaleGasDate);
                sqlParameters[7] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[7].Value = Convert.ToString(dtoSaleGas.GasStationID);
                sqlParameters[8] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                sqlParameters[8].Value = Convert.ToString(dtoSaleGas.CardID);

                sqlParameters[9] = new SqlParameter("@SALEGAS_CARD_MONEY_SAVING", SqlDbType.Int);
                sqlParameters[9].Value = Convert.ToInt32(dtoSaleGas.SaleGasCardMoneySaving);

                result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);
                
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
                dataResult.ResponseErrorMsg = 1 + SGMText.CARD_INSERT_ERR;
            }
            return dataResult;
        }

        public bool UpdateSaleGas(SaleGasDTO dtoSaleGas)
        {
            bool result = true;
            string query = string.Format("UPDATE SALE_GAS SET SALEGAS_TYPE = @SALEGAS_TYPE, SALEGAS_CURRENT_PRICE = @SALEGAS_CURRENT_PRICE, SALEGAS_CARD_PRICE = @SALEGAS_CARD_PRICE, " +
                                                            " SALEGAS_CARD_MONEY_BEFORE = @SALEGAS_CARD_MONEY_BEFORE, SALEGAS_CARD_MONEY_AFTER = @SALEGAS_CARD_MONEY_AFTER, SALEGAS_CARD_MONEY_SAVING = @SALEGAS_CARD_MONEY_SAVING, SALEGAS_LIT = @SALEGAS_LIT, SALEGAS_DATE = @SALEGAS_DATE, GASSTATION_ID = @GASSTATION_ID, CARD_ID = @CARD_ID " +
                                                      " WHERE SALEGAS_ID = @SALEGAS_ID");
            SqlParameter[] sqlParameters = new SqlParameter[11];
            sqlParameters[0] = new SqlParameter("@SALEGAS_ID", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt32(dtoSaleGas.SaleGasID);
            sqlParameters[1] = new SqlParameter("@SALEGAS_TYPE", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoSaleGas.SaleGasType);
            sqlParameters[2] = new SqlParameter("@SALEGAS_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoSaleGas.SaleGasCurrentPrice);
            sqlParameters[3] = new SqlParameter("@SALEGAS_CARD_PRICE", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoSaleGas.SaleGasPriceOnCard);
            sqlParameters[4] = new SqlParameter("@SALEGAS_CARD_MONEY_BEFORE", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoSaleGas.SaleGasCardMoneyBefore);
            sqlParameters[5] = new SqlParameter("@SALEGAS_CARD_MONEY_AFTER", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoSaleGas.SaleGasCardMoneyAfter);
            sqlParameters[6] = new SqlParameter("@SALEGAS_LIT", SqlDbType.Float);
            sqlParameters[6].Value = Convert.ToDouble(dtoSaleGas.NumberBuyLit);
            sqlParameters[7] = new SqlParameter("@SALEGAS_DATE", SqlDbType.DateTime);
            sqlParameters[7].Value = Convert.ToDateTime(dtoSaleGas.GasStationID);
            sqlParameters[8] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
            sqlParameters[8].Value = Convert.ToString(dtoSaleGas.GasStationID);
            sqlParameters[9] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[9].Value = Convert.ToString(dtoSaleGas.CardID);
            sqlParameters[10] = new SqlParameter("@SALEGAS_CARD_MONEY_SAVING", SqlDbType.NVarChar);
            sqlParameters[10].Value = Convert.ToInt32(dtoSaleGas.SaleGasCardMoneySaving);

            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public bool DeleteSaleGas(int iSaleGasID)
        {
            bool result = true;
            string query = string.Format("DELETE FROM SALE_GAS WHERE SALEGAS_ID = @SALEGAS_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@SALEGAS_ID", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToInt32(iSaleGasID);
            result = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }

        public DataTransfer GetSaleGasReport(string stGasStoreID, string stGasStationID, DateTime dateStart, DateTime dateEnd, string stCardID)
        {
            DataTransfer res = new DataTransfer();
            try
            {
                int numParam = 2;
                string query = string.Format("SELECT * FROM SALE_GAS, GAS_STATION, CARD, CUSTOMER WHERE SALEGAS_DATE BETWEEN @STARTDATE AND @ENDDATE AND GAS_STATION.GASSTATION_ID = SALE_GAS.GASSTATION_ID AND SALE_GAS.CARD_ID = CARD.CARD_ID AND CARD.CUS_ID = CUSTOMER.CUS_ID ");

                if (!stGasStationID.Equals(""))
                {
                    numParam++;
                    query += string.Format(" AND GAS_STATION.GASSTATION_ID = @GASSTATION_ID");
                }
                else if (!stGasStoreID.Equals(""))
                {
                    numParam++;
                    query += string.Format(" AND GAS_STATION.GASSTORE_ID = @GASSTORE_ID");
                }
                if (!stCardID.Trim().Equals(""))
                {
                    numParam++;
                    query += string.Format(" AND SALE_GAS.CARD_ID = @CARD_ID");
                }
                //res.ResponseDataString = query;
                SqlParameter[] sqlParameters = new SqlParameter[numParam];
                sqlParameters[0] = new SqlParameter("@STARTDATE", SqlDbType.DateTime);
                sqlParameters[0].Value = dateStart;
                sqlParameters[1] = new SqlParameter("@ENDDATE", SqlDbType.DateTime);
                sqlParameters[1].Value = dateEnd;
                if (numParam == 3)
                {
                    if (!stGasStationID.Equals(""))
                    {
                        sqlParameters[2] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = stGasStationID;
                    }
                    else if (!stGasStoreID.Equals(""))
                    {
                        sqlParameters[2] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = stGasStoreID;
                    }
                    else
                    {
                        sqlParameters[2] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = stCardID;
                    }
                }
                else if (numParam == 4)
                {
                    if (!stGasStationID.Equals(""))
                    {
                        sqlParameters[2] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = stGasStationID;
                    }
                    else
                    {
                        sqlParameters[2] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                        sqlParameters[2].Value = stGasStoreID;
                    }
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
