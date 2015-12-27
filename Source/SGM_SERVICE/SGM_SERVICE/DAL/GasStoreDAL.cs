using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM.ServicesCore.DAL
{
    public class GasStoreDAL
    {
        private DBConnetionDAL m_dbConnection;

        public GasStoreDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }


        public DataTransfer GetGasStore(string stGasStoreID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                GasStoreDTO dtoGasStore = null;
                string query = string.Format("SELECT * FROM GAS_STORE WHERE GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dtoGasStore = new GasStoreDTO();
                    foreach (DataRow dr in tblResult.Rows)
                    {
                        dtoGasStore.GasStoreID = dr["GASSTORE_ID"].ToString();
                        dtoGasStore.GasStoreName = dr["GASSTORE_NAME"].ToString();
                        dtoGasStore.GasStoreAddress = dr["GASSTORE_ADDRESS"].ToString();
                        dtoGasStore.GasStoreDescription = dr["GASSTORE_DESCRIPTION"].ToString();
                        dtoGasStore.GasStoreMacAddress = dr["GASSTORE_MACADDRESS"].ToString();
                        dtoGasStore.GasStoreGas92Total = Int32.Parse(dr["GASSTORE_GAS92_TOTAL"].ToString());
                        dtoGasStore.GasStoreGas95Total = Int32.Parse(dr["GASSTORE_GAS95_TOTAL"].ToString());
                        dtoGasStore.GasStoreGasDOTotal = Int32.Parse(dr["GASSTORE_GASDO_TOTAL"].ToString());
                    }
                }
                dataResult.ResponseDataGasStoreDTO = dtoGasStore;
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_GET_GS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer AddNewGasStore(GasStoreDTO dtoGasStore)
        {

            DataTransfer dataResult = new DataTransfer();
            bool insertResult = true;
            try
            {

                string query = string.Format("INSERT INTO GAS_STORE (GASSTORE_ID, GASSTORE_NAME, GASSTORE_ADDRESS, GASSTORE_DESCRIPTION, GASSTORE_GAS92_TOTAL, GASSTORE_GAS95_TOTAL, GASSTORE_GASDO_TOTAL) VALUES (@GASSTORE_ID, @GASSTORE_NAME, @GASSTORE_ADDRESS, @GASSTORE_DESCRIPTION, @GASSTORE_GAS92_TOTAL, @GASSTORE_GAS95_TOTAL, @GASSTORE_GASDO_TOTAL)");
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoGasStore.GasStoreID);
                sqlParameters[1] = new SqlParameter("@GASSTORE_NAME", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(dtoGasStore.GasStoreName);
                sqlParameters[2] = new SqlParameter("@GASSTORE_ADDRESS", SqlDbType.NVarChar);
                sqlParameters[2].Value = Convert.ToString(dtoGasStore.GasStoreAddress);
                sqlParameters[3] = new SqlParameter("@GASSTORE_DESCRIPTION", SqlDbType.NVarChar);
                sqlParameters[3].Value = Convert.ToString(dtoGasStore.GasStoreDescription);
                sqlParameters[4] = new SqlParameter("@GASSTORE_GAS92_TOTAL", SqlDbType.Int);
                sqlParameters[4].Value = dtoGasStore.GasStoreGas92Total;
                sqlParameters[5] = new SqlParameter("@GASSTORE_GAS95_TOTAL", SqlDbType.Int);
                sqlParameters[5].Value = dtoGasStore.GasStoreGas95Total;
                sqlParameters[6] = new SqlParameter("@GASSTORE_GASDO_TOTAL", SqlDbType.Int);
                sqlParameters[6].Value = dtoGasStore.GasStoreGasDOTotal;
                
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
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_ADD_NEW_GS_ERR;
            }
            return dataResult;
        }

        public DataTransfer UpdateGasStore(GasStoreDTO dtoGasStore, string stGasStoreID)
        {           
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE GAS_STORE SET GASSTORE_ID = @GASSTORE_ID_NEW, GASSTORE_NAME = @GASSTORE_NAME, GASSTORE_ADDRESS = @GASSTORE_ADDRESS, GASSTORE_DESCRIPTION = @GASSTORE_DESCRIPTION, GASSTORE_MACADDRESS = @GASSTORE_MACADDRESS, GASSTORE_GAS92_TOTAL = @GASSTORE_GAS92_TOTAL, GASSTORE_GAS95_TOTAL = @GASSTORE_GAS95_TOTAL, GASSTORE_GASDO_TOTAL = @GASSTORE_GASDO_TOTAL WHERE GASSTORE_ID = @GASSTORE_ID_OLD");
                SqlParameter[] sqlParameters = new SqlParameter[9];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID_NEW", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoGasStore.GasStoreID);
                sqlParameters[1] = new SqlParameter("@GASSTORE_NAME", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(dtoGasStore.GasStoreName);
                sqlParameters[2] = new SqlParameter("@GASSTORE_ADDRESS", SqlDbType.NVarChar);
                sqlParameters[2].Value = Convert.ToString(dtoGasStore.GasStoreAddress);
                sqlParameters[3] = new SqlParameter("@GASSTORE_DESCRIPTION", SqlDbType.NVarChar);
                sqlParameters[3].Value = Convert.ToString(dtoGasStore.GasStoreDescription);
                sqlParameters[4] = new SqlParameter("@GASSTORE_MACADDRESS", SqlDbType.NVarChar);
                if (dtoGasStore.GasStoreMacAddress.Equals(""))
                    sqlParameters[4].Value = DBNull.Value;
                else
                    sqlParameters[4].Value = Convert.ToString(dtoGasStore.GasStoreMacAddress);
                sqlParameters[5] = new SqlParameter("@GASSTORE_GAS92_TOTAL", SqlDbType.Int);
                sqlParameters[5].Value = dtoGasStore.GasStoreGas92Total;
                sqlParameters[6] = new SqlParameter("@GASSTORE_GAS95_TOTAL", SqlDbType.Int);
                sqlParameters[6].Value = dtoGasStore.GasStoreGas95Total;
                sqlParameters[7] = new SqlParameter("@GASSTORE_GASDO_TOTAL", SqlDbType.Int);
                sqlParameters[7].Value = dtoGasStore.GasStoreGasDOTotal;
                sqlParameters[8] = new SqlParameter("@GASSTORE_ID_OLD", SqlDbType.NVarChar);
                sqlParameters[8].Value = Convert.ToString(stGasStoreID);
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
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_UPDATE_ERR;
            }

            return dataResult;
        }
        public DataTransfer DeleteGasStore(string stGasStoreID)
        {            
            bool delResult = true;
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("DELETE FROM GAS_STORE WHERE GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreID); 
                delResult = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            }
            catch (Exception ex)
            {
                delResult = false;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            if (delResult)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            else
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_DEL_ERR;
            }


            return dataResult;
        }
        public DataTransfer ValidateGasStoreLogin(string stGasStoreID, string stGasStoreMacAddress)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT ISNULL(GASSTORE_MACADDRESS,'NULL') AS RESULT, * FROM GAS_STORE WHERE (GASSTORE_MACADDRESS IS NULL OR GASSTORE_MACADDRESS = @GASSTORE_MACADDRESS) AND GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[2];               
                sqlParameters[0] = new SqlParameter("@GASSTATION_MACADDRESS", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreMacAddress);
                sqlParameters[1] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(stGasStoreID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                    DataRow dr = tblResult.Rows[0];                  

                    GasStationDTO dtoGasStore = new GasStationDTO();
                    dtoGasStore.GasStationID = dr["GASSTORE_ID"].ToString();
                    dtoGasStore.GasStationName = dr["GASSTORE_NAME"].ToString();
                    dtoGasStore.GasStationAddress = dr["GASSTORE_ADDRESS"].ToString();
                    dtoGasStore.GasStationDescription = dr["GASSTORE_DESCRIPTION"].ToString();
                    dtoGasStore.GasStationMacAddress = dr["GASSTORE_MACADDRESS"].ToString();
                    dataResult.ResponseDataGasStationDTO = dtoGasStore;

                    string result = dr["RESULT"].ToString();
                    if (result.Equals("NULL")) //insert mac address
                    {
                        SqlParameter[] sqlParametersUpdate = new SqlParameter[2];
                        sqlParametersUpdate[0] = new SqlParameter("@GASSTORE_MACADDRESS", SqlDbType.NVarChar);
                        sqlParametersUpdate[0].Value = Convert.ToString(stGasStoreMacAddress);
                        sqlParametersUpdate[1] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                        sqlParametersUpdate[1].Value = Convert.ToString(stGasStoreID);
                        query = string.Format("UPDATE GAS_STORE SET GASSTORE_MACADDRESS = @GASSTORE_MACADDRESS WHERE GASSTORE_ID = @GASSTORE_ID");
                        if (!m_dbConnection.ExecuteUpdateQuery(query, sqlParametersUpdate))
                        {
                            dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                            dataResult.ResponseErrorMsg = SGMText.GAS_STATION_LOGON_UPDATE_MACADR_ERR;
                        }
                    }                    
                }
                else
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                    dataResult.ResponseErrorMsg = SGMText.GAS_STATION_LOGON_ID_INVALID;
                }
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GAS_STATION_LOGON_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            
            
            return dataResult;
        }
        public DataTransfer GetGasStores()
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT * FROM GAS_STORE");
            
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, new SqlParameter[0]);
                if (tblResult.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblResult.Copy());
                    dataResult.ResponseDataSet = ds;
                }
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_GET_GS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer IsGasStoreExisted(string stGasStoreID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT * FROM GAS_STORE WHERE GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreID);
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
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_GET_GS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }
    }
}