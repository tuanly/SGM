using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM.ServicesCore.DAL
{
    public class GasStationDAL
    {
        private DBConnetionDAL m_dbConnection;

        public GasStationDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        public DataSet GetGasStationList()
        {
            DataSet ds = null;
            string query = string.Format("SELECT GASSTATION_ID, GASSTATION_NAME FROM GAS_STATION");
            DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, null);
            if (tblResult.Rows.Count > 0)
            {
                ds = new DataSet();
                ds.Tables.Add(tblResult.Copy());
            }
            return ds;
        }

        public DataTransfer GetGasStation(string stGasStationID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                GasStationDTO dtoGasStation = null;
                string query = string.Format("SELECT * FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStationID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dtoGasStation = new GasStationDTO();
                    foreach (DataRow dr in tblResult.Rows)
                    {
                        dtoGasStation.GasStationID = dr["GASSTATION_ID"].ToString();
                        dtoGasStation.GasStationName = dr["GASSTATION_NAME"].ToString();
                        dtoGasStation.GasStationAddress = dr["GASSTATION_ADDRESS"].ToString();
                        dtoGasStation.GasStationDescription = dr["GASSTATION_DESCRIPTION"].ToString();
                        dtoGasStation.GasStationMacAddress = dr["GASSTATION_MACADDRESS"].ToString();
                    }
                }
                dataResult.ResponseDataGasStationDTO = dtoGasStation;
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.GASSTATION_GET_GS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer AddNewGasStation(GasStationDTO dtoGasStation)
        {

            DataTransfer dataResult = new DataTransfer();
            bool insertResult = true;
            try
            {

                string query = string.Format("INSERT INTO GAS_STATION (GASSTATION_ID, GASSTATION_NAME, GASSTATION_ADDRESS, GASSTATION_DESCRIPTION, GASSTORE_ID) VALUES (@GASSTATION_ID, @GASSTATION_NAME, @GASSTATION_ADDRESS, @GASSTATION_DESCRIPTION, @GASSTORE_ID)");
                SqlParameter[] sqlParameters = new SqlParameter[5];
                sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoGasStation.GasStationID);
                sqlParameters[1] = new SqlParameter("@GASSTATION_NAME", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(dtoGasStation.GasStationName);
                sqlParameters[2] = new SqlParameter("@GASSTATION_ADDRESS", SqlDbType.NVarChar);
                sqlParameters[2].Value = Convert.ToString(dtoGasStation.GasStationAddress);
                sqlParameters[3] = new SqlParameter("@GASSTATION_DESCRIPTION", SqlDbType.NVarChar);
                sqlParameters[3].Value = Convert.ToString(dtoGasStation.GasStationDescription);
                sqlParameters[4] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[4].Value = Convert.ToString(dtoGasStation.GasStoreID);
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
                dataResult.ResponseErrorMsg = SGMText.GASSTATION_ADD_NEW_GS_ERR;
            }
            return dataResult;
        }

        public DataTransfer UpdateGasStation(GasStationDTO dtoGasStation, string stGasStationID)
        {           
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE GAS_STATION SET GASSTATION_ID = @GASSTATION_ID_NEW, GASSTATION_NAME = @GASSTATION_NAME, GASSTATION_ADDRESS = @GASSTATION_ADDRESS, GASSTATION_DESCRIPTION = @GASSTATION_DESCRIPTION, GASSTATION_MACADDRESS = @GASSTATION_MACADDRESS, GASSTORE_ID = @GASSTORE_ID WHERE GASSTATION_ID = @GASSTATION_ID_OLD");
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@GASSTATION_ID_NEW", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoGasStation.GasStationID);
                sqlParameters[1] = new SqlParameter("@GASSTATION_NAME", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(dtoGasStation.GasStationName);
                sqlParameters[2] = new SqlParameter("@GASSTATION_ADDRESS", SqlDbType.NVarChar);
                sqlParameters[2].Value = Convert.ToString(dtoGasStation.GasStationAddress);
                sqlParameters[3] = new SqlParameter("@GASSTATION_DESCRIPTION", SqlDbType.NVarChar);
                sqlParameters[3].Value = Convert.ToString(dtoGasStation.GasStationDescription);
                sqlParameters[4] = new SqlParameter("@GASSTATION_MACADDRESS", SqlDbType.NVarChar);
                if (dtoGasStation.GasStationMacAddress.Equals(""))
                    sqlParameters[4].Value = DBNull.Value;
                else
                    sqlParameters[4].Value = Convert.ToString(dtoGasStation.GasStationMacAddress);
                sqlParameters[5] = new SqlParameter("@GASSTORE_ID", SqlDbType.NVarChar);
                sqlParameters[5].Value = Convert.ToString(dtoGasStation.GasStoreID);
                sqlParameters[6] = new SqlParameter("@GASSTATION_ID_OLD", SqlDbType.NVarChar);
                sqlParameters[6].Value = Convert.ToString(stGasStationID);
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
                dataResult.ResponseErrorMsg = SGMText.GASSTATION_UPDATE_ERR;
            }

            return dataResult;
        }
        public DataTransfer DeleteGasStation(string stGasStationID)
        {            
            bool delResult = true;
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("DELETE FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStationID); 
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
                dataResult.ResponseErrorMsg = SGMText.GASSTATION_DEL_ERR;
            }


            return dataResult;
        }
        public DataTransfer ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT ISNULL(GASSTATION_MACADDRESS,'NULL') AS RESULT, * FROM GAS_STATION WHERE (GASSTATION_MACADDRESS IS NULL OR GASSTATION_MACADDRESS = @GASSTATION_MACADDRESS) AND GASSTATION_ID = @GASSTATION_ID");
                SqlParameter[] sqlParameters = new SqlParameter[2];               
                sqlParameters[0] = new SqlParameter("@GASSTATION_MACADDRESS", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStationMacAddress);
                sqlParameters[1] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(stGasStationID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                    DataRow dr = tblResult.Rows[0];                  

                    GasStationDTO dtoGasStation = new GasStationDTO();
                    dtoGasStation.GasStationID = dr["GASSTATION_ID"].ToString();
                    dtoGasStation.GasStationName = dr["GASSTATION_NAME"].ToString();
                    dtoGasStation.GasStationAddress = dr["GASSTATION_ADDRESS"].ToString();
                    dtoGasStation.GasStationDescription = dr["GASSTATION_DESCRIPTION"].ToString();
                    dtoGasStation.GasStationMacAddress = dr["GASSTATION_MACADDRESS"].ToString();
                    dataResult.ResponseDataGasStationDTO = dtoGasStation;

                    string result = dr["RESULT"].ToString();
                    if (result.Equals("NULL")) //insert mac address
                    {
                        SqlParameter[] sqlParametersUpdate = new SqlParameter[2];
                        sqlParametersUpdate[0] = new SqlParameter("@GASSTATION_MACADDRESS", SqlDbType.NVarChar);
                        sqlParametersUpdate[0].Value = Convert.ToString(stGasStationMacAddress);
                        sqlParametersUpdate[1] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                        sqlParametersUpdate[1].Value = Convert.ToString(stGasStationID);
                        query = string.Format("UPDATE GAS_STATION SET GASSTATION_MACADDRESS = @GASSTATION_MACADDRESS WHERE GASSTATION_ID = @GASSTATION_ID");
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
        public DataTransfer GetGasStations()
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT * FROM GAS_STATION");
                
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
                dataResult.ResponseErrorMsg = SGMText.GASSTATION_GET_GS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer IsGasStationExisted(string stGasStationID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT * FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stGasStationID);
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
                dataResult.ResponseErrorMsg = SGMText.GASSTATION_GET_GS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }
    }
}
