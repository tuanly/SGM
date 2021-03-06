﻿using System;
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

        public DataTransfer ValidateGasStoreLogin(string stGasStoreID, string stGasStoreMacAddress)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT ISNULL(GASSTORE_MACADDRESS,'NULL') AS RESULT, * FROM GAS_STORE WHERE (GASSTORE_MACADDRESS IS NULL OR GASSTORE_MACADDRESS = @GASSTORE_MACADDRESS) AND GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@GASSTORE_MACADDRESS", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreMacAddress);
                sqlParameters[1] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(stGasStoreID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                    DataRow dr = tblResult.Rows[0];

                    GasStoreDTO dtoGasStore = new GasStoreDTO();
                    dtoGasStore.GasStoreID = dr["GASSTORE_ID"].ToString();
                    dtoGasStore.GasStoreName = dr["GASSTORE_NAME"].ToString();
                    dtoGasStore.GasStoreAddress = dr["GASSTORE_ADDRESS"].ToString();
                    dtoGasStore.GasStoreDescription = dr["GASSTORE_DESCRIPTION"].ToString();
                    dtoGasStore.GasStoreMacAddress = dr["GASSTORE_MACADDRESS"].ToString();
                    dtoGasStore.GasStoreGas92Total = float.Parse(dr["GASSTORE_GAS92_TOTAL"].ToString());
                    dtoGasStore.GasStoreGas95Total = float.Parse(dr["GASSTORE_GAS95_TOTAL"].ToString());
                    dtoGasStore.GasStoreGasDOTotal = float.Parse(dr["GASSTORE_GASDO_TOTAL"].ToString());
                    dataResult.ResponseDataGasStoreDTO = dtoGasStore;

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
        public DataTransfer GetGasStoreFromGasStation(string stGasStationID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                GasStoreDTO dtoGasStore = null;
                string query = string.Format("SELECT GAS_STORE.* FROM GAS_STORE, GAS_STATION WHERE GAS_STORE.GASSTORE_ID = GAS_STATION.GASSTORE_ID AND GASSTATION_ID = @GASSTATION_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStationID);
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
                        dtoGasStore.GasStoreGas92Total = float.Parse(dr["GASSTORE_GAS92_TOTAL"].ToString());
                        dtoGasStore.GasStoreGas95Total = float.Parse(dr["GASSTORE_GAS95_TOTAL"].ToString());
                        dtoGasStore.GasStoreGasDOTotal = float.Parse(dr["GASSTORE_GASDO_TOTAL"].ToString());
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
                        dtoGasStore.GasStoreGas92Total = float.Parse(dr["GASSTORE_GAS92_TOTAL"].ToString());
                        dtoGasStore.GasStoreGas95Total = float.Parse(dr["GASSTORE_GAS95_TOTAL"].ToString());
                        dtoGasStore.GasStoreGasDOTotal = float.Parse(dr["GASSTORE_GASDO_TOTAL"].ToString());
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
                sqlParameters[4] = new SqlParameter("@GASSTORE_GAS92_TOTAL", SqlDbType.Float);
                sqlParameters[4].Value = dtoGasStore.GasStoreGas92Total;
                sqlParameters[5] = new SqlParameter("@GASSTORE_GAS95_TOTAL", SqlDbType.Float);
                sqlParameters[5].Value = dtoGasStore.GasStoreGas95Total;
                sqlParameters[6] = new SqlParameter("@GASSTORE_GASDO_TOTAL", SqlDbType.Float);
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

        public DataTransfer UpdateGasStoreTotal(string stGasStoreID, string stType, float fAmount)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("UPDATE GAS_STORE SET XX = XX - @YY WHERE GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreID);
                sqlParameters[1] = new SqlParameter("@YY", SqlDbType.Float);
                sqlParameters[1].Value = (fAmount);
                if (stType.CompareTo(SaleGasDTO.GAS_TYPE_92) == 0)
                {
                    query = query.Replace("XX", "GASSTORE_GAS92_TOTAL");
                }
                else if (stType.CompareTo(SaleGasDTO.GAS_TYPE_95) == 0)
                {
                    query = query.Replace("XX", "GASSTORE_GAS95_TOTAL");
                }
                else if (stType.CompareTo(SaleGasDTO.GAS_TYPE_DO) == 0)
                {
                    query = query.Replace("XX", "GASSTORE_GASDO_TOTAL");
                }
                dataResult.ResponseDataString = query;
                bool result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
                if (result)
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                    dataResult.ResponseErrorMsg = SGMText.GASSTORE_UPDATE_TOTAL_SUCCESS;
                }
                else
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                    dataResult.ResponseErrorMsg = SGMText.GASSTORE_UPDATE_TOTAL_ERR;
                }
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_UPDATE_TOTAL_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
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
                sqlParameters[5] = new SqlParameter("@GASSTORE_GAS92_TOTAL", SqlDbType.Float);
                sqlParameters[5].Value = dtoGasStore.GasStoreGas92Total;
                sqlParameters[6] = new SqlParameter("@GASSTORE_GAS95_TOTAL", SqlDbType.Float);
                sqlParameters[6].Value = dtoGasStore.GasStoreGas95Total;
                sqlParameters[7] = new SqlParameter("@GASSTORE_GASDO_TOTAL", SqlDbType.Float);
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

        public DataTransfer GetGasStoresFilter(string stGasStoreID, DateTime fromDate, DateTime toDate)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT GS_UPDATE_ID as 'LẦN THỨ',GS_GAS92_TOTAL as 'XĂNG 92 CÒN',GS_GAS95_TOTAL as 'XĂNG 95 CÒN',GS_GASDO_TOTAL as 'DẦU DO CÒN',GS_GAS92_ADD as 'NHẬP XĂNG 92',GS_GAS95_ADD as 'NHẬP XĂNG 95',GS_GASDO_ADD as 'NHẬP DẦU DO',GS_UPDATE_DATE as 'NGÀY NHẬP',GS_DESCRIPTION as 'GHI CHÚ'"
                                            + " FROM GAS_STORE_UPDATE WHERE GASSTORE_ID = @GASSTORE_ID AND GS_UPDATE_DATE BETWEEN @STARTDATE AND @ENDDATE");
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreID);
                sqlParameters[1] = new SqlParameter("@STARTDATE", SqlDbType.DateTime);
                sqlParameters[1].Value = fromDate;
                sqlParameters[2] = new SqlParameter("@ENDDATE", SqlDbType.DateTime);
                sqlParameters[2].Value = toDate;
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
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

        public DataTransfer GetGasStoreUpdateHistory(string stGasStoreID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                GasStoreUpdateDTO dtoGasStoreUpdate = null;
                string query = string.Format("SELECT * FROM GAS_STORE_UPDATE WHERE GASSTORE_ID = @GASSTORE_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStoreID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dtoGasStoreUpdate = new GasStoreUpdateDTO();
                    foreach (DataRow dr in tblResult.Rows)
                    {
                        dtoGasStoreUpdate.GasStoreID = dr["GASSTORE_ID"].ToString();
                        dtoGasStoreUpdate.GSUpdateGas92Total = float.Parse(dr["GS_GAS92_TOTAL"].ToString());
                        dtoGasStoreUpdate.GSUpdateGas95Total = float.Parse(dr["GS_GAS95_TOTAL"].ToString());
                        dtoGasStoreUpdate.GSUpdateGasDOTotal = float.Parse(dr["GS_GASDO_TOTAL"].ToString());
                        dtoGasStoreUpdate.GSUpdateGas92Add = float.Parse(dr["GS_GAS92_ADD"].ToString());
                        dtoGasStoreUpdate.GSUpdateGas95Add = float.Parse(dr["GS_GAS95_ADD"].ToString());
                        dtoGasStoreUpdate.GSUpdateGasDOAdd = float.Parse(dr["GS_GASDO_ADD"].ToString());
                        dtoGasStoreUpdate.GSUpdateDate = DateTime.Parse(dr["GS_UPDATE_DATE"].ToString());
                        dtoGasStoreUpdate.GSUpdateDescription = dr["GS_DESCRIPTION"].ToString();
                    }
                }
                dataResult.ResponseDataGasStoreUpdateDTO = dtoGasStoreUpdate;
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_GET_GSUPDATE_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer AddNewGasStoreUpdate(GasStoreUpdateDTO dtoGasStoreUpdate)
        {

            DataTransfer dataResult = new DataTransfer();
            bool insertResult = true;
            try
            {

                string query = string.Format("INSERT INTO GAS_STORE_UPDATE (GS_GAS92_TOTAL, GS_GAS95_TOTAL, GS_GASDO_TOTAL, GS_GAS92_ADD, GS_GAS95_ADD, GS_GASDO_ADD, GS_UPDATE_DATE, GS_DESCRIPTION, GASSTORE_ID) VALUES (@GS_GAS92_TOTAL, @GS_GAS95_TOTAL, @GS_GASDO_TOTAL, @GS_GAS92_ADD, @GS_GAS95_ADD, @GS_GASDO_ADD, @GS_UPDATE_DATE, @GS_DESCRIPTION, @GASSTORE_ID)");
                SqlParameter[] sqlParameters = new SqlParameter[9];
                sqlParameters[0] = new SqlParameter("@GS_GAS92_TOTAL", SqlDbType.Float);
                sqlParameters[0].Value = dtoGasStoreUpdate.GSUpdateGas92Total;
                sqlParameters[1] = new SqlParameter("@GS_GAS95_TOTAL", SqlDbType.Float);
                sqlParameters[1].Value = dtoGasStoreUpdate.GSUpdateGas95Total;
                sqlParameters[2] = new SqlParameter("@GS_GASDO_TOTAL", SqlDbType.Float);
                sqlParameters[2].Value = dtoGasStoreUpdate.GSUpdateGasDOTotal;
                sqlParameters[3] = new SqlParameter("@GS_GAS92_ADD", SqlDbType.NVarChar);
                sqlParameters[3].Value = dtoGasStoreUpdate.GSUpdateGas92Add;
                sqlParameters[4] = new SqlParameter("@GS_GAS95_ADD", SqlDbType.Float);
                sqlParameters[4].Value = dtoGasStoreUpdate.GSUpdateGas95Add;
                sqlParameters[5] = new SqlParameter("@GS_GASDO_ADD", SqlDbType.Float);
                sqlParameters[5].Value = dtoGasStoreUpdate.GSUpdateGasDOAdd;
                sqlParameters[6] = new SqlParameter("@GS_UPDATE_DATE", SqlDbType.DateTime);
                sqlParameters[6].Value = Convert.ToDateTime(dtoGasStoreUpdate.GSUpdateDate);
                sqlParameters[7] = new SqlParameter("@GS_DESCRIPTION", SqlDbType.NVarChar);
                sqlParameters[7].Value = Convert.ToString(dtoGasStoreUpdate.GSUpdateDescription);
                sqlParameters[8] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[8].Value = Convert.ToString(dtoGasStoreUpdate.GasStoreID);

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
                dataResult.ResponseErrorMsg = SGMText.GASSTORE_ADD_NEW_GSUPDATE_ERR;
            }
            return dataResult;
        }
    }
}