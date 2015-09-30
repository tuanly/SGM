using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM.ServicesCore.DTO;

namespace SGM.ServicesCore.DAL
{
    public class CustomerDAL
    {
        private DBConnetionDAL m_dbConnection;

        public CustomerDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        public CustomerDTO GetCustomer(int stCusID)
        {
            CustomerDTO dtoCustomer = null;
            string query = string.Format("SELECT * FROM CUSTOMER WHERE CUS_ID = @CUS_ID");
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
            return dtoCustomer;
        }

        public bool AddNewCustomer(CustomerDTO dtoCustomer)
        {
            bool result = true;
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
           
            result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }

        public bool UpdateCard(CustomerDTO dtoCustomer)
        {
            bool result = true;
            string query = string.Format("UPDATE CUSTOMER SET CUS_NAME = @CUS_NAME, CUS_VISA = @CUS_VISA, CUS_BIRTHDATE = @CUS_BIRTHDATE, CUS_ADDRESS = @CUS_ADDRESS, CUS_PHONE = @CUS_PHONE, CUS_NOTE = @CUS_NOTE WHERE CUS_ID = @CUS_ID");
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
            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public bool DeleteCustomer(string stCustomerID)
        {
            bool result = true;
            string query = string.Format("DELETE FROM CUSTOMER WHERE CUS_ID = @CUS_ID");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CUS_ID", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stCustomerID);
            result = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }
    }
}
