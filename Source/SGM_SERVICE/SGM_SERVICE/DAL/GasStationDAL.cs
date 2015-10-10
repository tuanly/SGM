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

        public GasStationDTO GetGasStation(string stGasStationID)
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
            return dtoGasStation;
        }

        public bool AddNewGasStation(GasStationDTO dtoGasStation)
        {
            bool result = true;
            string query = string.Format("INSERT INTO GAS_STATION (GASSTATION_ID, GASSTATION_NAME, GASSTATION_ADDRESS, GASSTATION_DESCRIPTION, GASSTATION_MACADDRESS) VALUES (@GASSTATION_ID, @GASSTATION_NAME, @GASSTATION_ADDRESS, @GASSTATION_DESCRIPTION, @GASSTATION_MACADDRESS)");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@CARD_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoGasStation.GasStationID);
            sqlParameters[1] = new SqlParameter("@CARD_STATE", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoGasStation.GasStationName);
            sqlParameters[2] = new SqlParameter("@CARD_MONEY", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(dtoGasStation.GasStationAddress);
            sqlParameters[3] = new SqlParameter("@RECHARGE_ID", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(dtoGasStation.GasStationDescription);
            sqlParameters[4] = new SqlParameter("@GASSTATION_MACADDRESS", SqlDbType.NVarChar);
            sqlParameters[4].Value = Convert.ToString(dtoGasStation.GasStationMacAddress);
            result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);           
            return result;
        }

        public bool UpdateGasStation(GasStationDTO dtoGasStation)
        {
            bool result = true;
            string query = string.Format("UPDATE GAS_STATION SET GASSTATION_NAME = @GASSTATION_NAME, GASSTATION_ADDRESS = @GASSTATION_ADDRESS, GASSTATION_DESCRIPTION = @GASSTATION_DESCRIPTION, GASSTATION_MACADDRESS = @GASSTATION_MACADDRESS WHERE GASSTATION_ID = @GASSTATION_ID");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoGasStation.GasStationID);
            sqlParameters[1] = new SqlParameter("@GASSTATION_NAME", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoGasStation.GasStationName);
            sqlParameters[2] = new SqlParameter("@GASSTATION_ADDRESS", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(dtoGasStation.GasStationAddress);
            sqlParameters[3] = new SqlParameter("@GASSTATION_DESCRIPTION", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(dtoGasStation.GasStationDescription);
            sqlParameters[4] = new SqlParameter("@GASSTATION_MACADDRESS", SqlDbType.NVarChar);
            sqlParameters[4].Value = Convert.ToString(dtoGasStation.GasStationMacAddress);
            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public bool DeleteGasStation(string stGasStationID)
        {
            bool result = true;
            string query = string.Format("DELETE FROM GASSTATION_NAME WHERE GASSTATION_ID = @GASSTATION_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@GASSTATION_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stGasStationID);            
            result = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }

        public DataTransfer ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT ISNULL(GASSTATION_MACADDRESS,'NULL') AS RESULT FROM GAS_STATION WHERE (GASSTATION_MACADDRESS IS NULL OR GASSTATION_MACADDRESS = @GASSTATION_MACADDRESS) AND GASSTATION_ID = @GASSTATION_ID");
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
    }
}
