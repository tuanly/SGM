using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM.ServicesCore.DTO;

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
                    dtoSaleGas.CardID = dr["CARD_ID"].ToString();                   
                }
            }
            return dtoSaleGas;
        }

        public bool AddSaleGas(SaleGasDTO dtoSaleGas)
        {
            bool result = true;
            string query = string.Format("INSERT INTO SALE_GAS (SALEGAS_ID, SALEGAS_TYPE, SALEGAS_CURRENT_PRICE, SALEGAS_CARD_PRICE, SALEGAS_CARD_MONEY_BEFORE, SALEGAS_CARD_MONEY_AFTER, GASSTATION_ID, CARD_ID)" +
                                                           " VALUES (@SALEGAS_ID, @SALEGAS_TYPE, @SALEGAS_CURRENT_PRICE, @SALEGAS_CARD_PRICE, @SALEGAS_CARD_MONEY_BEFORE, @SALEGAS_CARD_MONEY_AFTER, @GASSTATION_ID, @CARD_ID)");
            SqlParameter[] sqlParameters = new SqlParameter[8];
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
            sqlParameters[6] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(dtoSaleGas.GasStationID);
            sqlParameters[7] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[7].Value = Convert.ToString(dtoSaleGas.CardID);

            result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);           
            return result;
        }

        public bool UpdateSaleGas(SaleGasDTO dtoSaleGas)
        {
            bool result = true;
            string query = string.Format("UPDATE SALE_GAS SET SALEGAS_TYPE = @SALEGAS_TYPE, SALEGAS_CURRENT_PRICE = @SALEGAS_CURRENT_PRICE, SALEGAS_CARD_PRICE = @SALEGAS_CARD_PRICE, " +
                                                            " SALEGAS_CARD_MONEY_BEFORE = @SALEGAS_CARD_MONEY_BEFORE, SALEGAS_CARD_MONEY_AFTER = @SALEGAS_CARD_MONEY_AFTER, GASSTATION_ID = @GASSTATION_ID, CARD_ID = @CARD_ID " +
                                                      " WHERE SALEGAS_ID = @SALEGAS_ID");
            SqlParameter[] sqlParameters = new SqlParameter[8];
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
            sqlParameters[6] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(dtoSaleGas.GasStationID);
            sqlParameters[7] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[7].Value = Convert.ToString(dtoSaleGas.CardID);

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
    }
}
