using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM.ServicesCore.DAL
{
    public class CustomerDAL
    {
        private DBConnetionDAL m_dbConnection;
        private JSonHelper m_jsHelper;

        public CustomerDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
            m_jsHelper = new JSonHelper();
        }

        public DataTransfer GetCustomers(string value)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query;                
                if (value == null)
                {
                    query = string.Format("SELECT CUS_ID AS STT, * FROM CUSTOMER");                   
                }
                else
                {
                    query = string.Format("SELECT CUS_ID AS STT, * FROM CUSTOMER WHERE CUS_ID LIKE '%" + value + "%' OR CUS_NAME LIKE '%" + value + "%'");                   
                }
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, new SqlParameter[0]);
                dataResult.ResponseDataString = query;
                if (tblResult != null && tblResult.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(tblResult.Copy());
                    dataResult.ResponseDataSet = ds;                    
                }                
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CUSTOMER_GET_CUS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }
        public DataTransfer GetCustomer(string stCusID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                CustomerDTO dtoCustomer = null;
                string query = query = string.Format("SELECT * FROM CUSTOMER WHERE CUS_ID = @CUS_ID");                
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCusID);
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
                if (tblResult.Rows.Count > 0)
                {
                    dtoCustomer = new CustomerDTO();
                    foreach (DataRow dr in tblResult.Rows)
                    {
                        dtoCustomer.CustomerID = dr["CUS_ID"].ToString(); ;
                        dtoCustomer.CustomerName = dr["CUS_NAME"].ToString(); ;
                        dtoCustomer.CustomerVisa = dr["CUS_VISA"].ToString(); ;
                        dtoCustomer.CustomerBirthDate = dr["CUS_BIRTHDATE"].ToString(); ;
                        dtoCustomer.CustomerAddress = dr["CUS_ADDRESS"].ToString(); ;
                        dtoCustomer.CustomerPhone = dr["CUS_PHONE"].ToString(); ;
                        dtoCustomer.CustomerNote = dr["CUS_NOTE"].ToString(); ;
                    }
                }
                dataResult.ResponseDataCustomerDTO = dtoCustomer;
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.CUSTOMER_GET_CUS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }
            
            return dataResult;
        }

        public DataTransfer IsCustomerExisted(string stCusID)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {                
                string query = string.Format("SELECT * FROM CUSTOMER WHERE CUS_ID = @CUS_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCusID);
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
                dataResult.ResponseErrorMsg = SGMText.CUSTOMER_GET_CUS_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public DataTransfer AddNewCustomer(CustomerDTO dtoCustomer)
        {
           
            DataTransfer dataResult = new DataTransfer();
            bool insertResult = true;
            try
            {
                
                string query = string.Format("INSERT INTO CUSTOMER (CUS_ID, CUS_NAME, CUS_VISA, CUS_BIRTHDATE, CUS_ADDRESS, CUS_PHONE, CUS_NOTE) VALUES (@CUS_ID, @CUS_NAME, @CUS_VISA, @CUS_BIRTHDATE, @CUS_ADDRESS, @CUS_PHONE, @CUS_NOTE)");
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoCustomer.CustomerID);
                sqlParameters[1] = new SqlParameter("@CUS_NAME", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(dtoCustomer.CustomerName);
                sqlParameters[2] = new SqlParameter("@CUS_VISA", SqlDbType.NVarChar);
                sqlParameters[2].Value = Convert.ToString(dtoCustomer.CustomerVisa);
                sqlParameters[3] = new SqlParameter("@CUS_BIRTHDATE", SqlDbType.NVarChar);
                sqlParameters[3].Value = Convert.ToString(dtoCustomer.CustomerBirthDate);
                sqlParameters[4] = new SqlParameter("@CUS_ADDRESS", SqlDbType.NVarChar);
                sqlParameters[4].Value = Convert.ToString(dtoCustomer.CustomerAddress);
                sqlParameters[5] = new SqlParameter("@CUS_PHONE", SqlDbType.NVarChar);
                sqlParameters[5].Value = Convert.ToString(dtoCustomer.CustomerPhone);
                sqlParameters[6] = new SqlParameter("@CUS_NOTE", SqlDbType.NVarChar);
                sqlParameters[6].Value = Convert.ToString(dtoCustomer.CustomerNote);

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
                dataResult.ResponseErrorMsg = SGMText.CUSTOMER_ADD_NEW_CUS_ERR;
            }
            return dataResult;
        }

        public DataTransfer UpdateCustomer(CustomerDTO dtoCustomer, string cusID)
        {
            DataTransfer dataResult = new DataTransfer();
            bool updateResult = true;
            try
            {
                string query = string.Format("UPDATE CUSTOMER SET CUS_ID = @CUS_ID_NEW, CUS_NAME = @CUS_NAME, CUS_VISA = @CUS_VISA, CUS_BIRTHDATE = @CUS_BIRTHDATE, CUS_ADDRESS = @CUS_ADDRESS, CUS_PHONE = @CUS_PHONE, CUS_NOTE = @CUS_NOTE WHERE CUS_ID = @CUS_ID_OLD");
                SqlParameter[] sqlParameters = new SqlParameter[8];
                sqlParameters[0] = new SqlParameter("@CUS_ID_NEW", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoCustomer.CustomerID);
                sqlParameters[1] = new SqlParameter("@CUS_NAME", SqlDbType.NVarChar);
                sqlParameters[1].Value = Convert.ToString(dtoCustomer.CustomerName);
                sqlParameters[2] = new SqlParameter("@CUS_VISA", SqlDbType.NVarChar);
                sqlParameters[2].Value = Convert.ToString(dtoCustomer.CustomerVisa);
                sqlParameters[3] = new SqlParameter("@CUS_BIRTHDATE", SqlDbType.NVarChar);
                sqlParameters[3].Value = Convert.ToString(dtoCustomer.CustomerBirthDate);
                sqlParameters[4] = new SqlParameter("@CUS_ADDRESS", SqlDbType.NVarChar);
                sqlParameters[4].Value = Convert.ToString(dtoCustomer.CustomerAddress);
                sqlParameters[5] = new SqlParameter("@CUS_PHONE", SqlDbType.NVarChar);
                sqlParameters[5].Value = Convert.ToString(dtoCustomer.CustomerPhone);
                sqlParameters[6] = new SqlParameter("@CUS_NOTE", SqlDbType.NVarChar);
                sqlParameters[6].Value = Convert.ToString(dtoCustomer.CustomerNote);
                sqlParameters[7] = new SqlParameter("@CUS_ID_OLD", SqlDbType.NVarChar);
                sqlParameters[7].Value = Convert.ToString(cusID);
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
                dataResult.ResponseErrorMsg = SGMText.CUSTOMER_UPDATE_CUS_ERR;
            }
            
            return dataResult;
        }

        public DataTransfer DeleteCustomer(string stCustomerID)
        {
            bool delResult = true;
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("DELETE FROM CUSTOMER WHERE CUS_ID = @CUS_ID");
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(stCustomerID);
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
                dataResult.ResponseErrorMsg = SGMText.CUSTOMER_DEL_CUS_ERR;
            }
            
            
            return dataResult;
        }
    }
}
