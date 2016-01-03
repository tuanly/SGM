using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;
using SGM_Core.Utils; 

namespace SGM.ServicesCore.DAL
{
    public class SystemAdminDAL
    {
        private DBConnetionDAL m_dbConnection;
      

        public SystemAdminDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        //public DataSet GetSystemAdminInfo(string admin, string pwd)
        //{
        //    string query = string.Format("SELECT * FROM SYSTEM_ADMIN WHERE SYS_ADMIN = @SYS_ADMIN AND SYS_PWD = @SYS_PWD");
        //    SqlParameter[] sqlParameters = new SqlParameter[2];
        //    sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
        //    sqlParameters[0].Value = Convert.ToString(admin);
        //    sqlParameters[1] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
        //    sqlParameters[1].Value = Convert.ToString(pwd);
        //    DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
        //    if (tblResult.Rows.Count > 0)
        //    {
        //        DataSet ds = new DataSet();
        //        ds.Tables.Add(tblResult.Copy());
        //        return ds;
        //    }
        //    return null;
        //}

        public SystemAdminDTO GetSystemAdminInfo(string admin, string pwd)
        {
            SystemAdminDTO dtoSysAdmin = null;
            string query = string.Format("SELECT * FROM SYSTEM_ADMIN WHERE SYS_ADMIN = @SYS_ADMIN AND SYS_PWD = @SYS_PWD");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(admin);
            sqlParameters[1] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(pwd);
            DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
            if (tblResult.Rows.Count > 0)
            {
                dtoSysAdmin = new SystemAdminDTO();
                foreach (DataRow dr in tblResult.Rows)
                {
                    dtoSysAdmin.SysAdminAccount = dr["SYS_ADMIN"].ToString();
                    dtoSysAdmin.SysAdminPwd = dr["SYS_PWD"].ToString();                    
                    dtoSysAdmin.SysGas92CurrentPrice = Int32.Parse(dr["SYS_GAS92_CURRENT_PRICE"].ToString());
                    dtoSysAdmin.SysGas95CurrentPrice = Int32.Parse(dr["SYS_GAS95_CURRENT_PRICE"].ToString());
                    dtoSysAdmin.SysGasDOCurrentPrice = Int32.Parse(dr["SYS_GASDO_CURRENT_PRICE"].ToString());
                    dtoSysAdmin.SysGas92NewPrice = Int32.Parse(dr["SYS_GAS92_NEW_PRICE"].ToString());
                    dtoSysAdmin.SysGas95NewPrice = Int32.Parse(dr["SYS_GAS95_NEW_PRICE"].ToString());
                    dtoSysAdmin.SysGasDONewPrice = Int32.Parse(dr["SYS_GASDO_NEW_PRICE"].ToString());
                    dtoSysAdmin.SysApplyDate = DateTime.Parse(dr["SYS_APPLY_DATE"].ToString());                   
                }
            }
            return dtoSysAdmin;
        }

        public bool AddSystemAdmin(SystemAdminDTO dtoSysAdmin)
        {
            bool result = true;
            string query = string.Format("INSERT INTO SYSTEM_ADMIN (SYS_ADMIN, SYS_PWD, SYS_GAS92_CURRENT_PRICE, SYS_GAS95_CURRENT_PRICE, SYS_GASDO_CURRENT_PRICE, SYS_GAS92_NEW_PRICE, SYS_GAS95_NEW_PRICE, SYS_GASDO_NEW_PRICE, SYS_APPLY_DATE) " +
                                                          " VALUES (@SYS_ADMIN, @SYS_PWD, @SYS_GAS92_TOTAL, @SYS_GAS95_TOTAL, @SYS_GASDO_TOTAL, @SYS_GAS92_CURRENT_PRICE, @SYS_GAS95_CURRENT_PRICE, @SYS_GASDO_CURRENT_PRICE, @SYS_GAS92_NEW_PRICE, @SYS_GAS95_NEW_PRICE, @SYS_GASDO_NEW_PRICE, @SYS_APPLY_DATE)");
            SqlParameter[] sqlParameters = new SqlParameter[9];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoSysAdmin.SysAdminAccount);
            sqlParameters[1] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoSysAdmin.SysAdminPwd);           
            sqlParameters[2] = new SqlParameter("@SYS_GAS92_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoSysAdmin.SysGas92CurrentPrice);
            sqlParameters[3] = new SqlParameter("@SYS_GAS95_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoSysAdmin.SysGas95CurrentPrice);
            sqlParameters[4] = new SqlParameter("@SYS_GASDO_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOCurrentPrice);
            sqlParameters[5] = new SqlParameter("@SYS_GAS92_NEW_PRICE", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoSysAdmin.SysGas92NewPrice);
            sqlParameters[6] = new SqlParameter("@SYS_GAS95_NEW_PRICE", SqlDbType.Int);
            sqlParameters[6].Value = Convert.ToInt32(dtoSysAdmin.SysGas95NewPrice);
            sqlParameters[7] = new SqlParameter("@SYS_GASDO_NEW_PRICE", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(dtoSysAdmin.SysGasDONewPrice);
            sqlParameters[8] = new SqlParameter("@SYS_APPLY_DATE", SqlDbType.DateTime);
            sqlParameters[8].Value = Convert.ToDateTime(dtoSysAdmin.SysApplyDate);

            result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);           
            return result;
        }

        public bool UpdateSystemAdmin(SystemAdminDTO dtoSysAdmin)
        {
            bool result = true;
            string query = string.Format("UPDATE SYSTEM_ADMIN SET SYS_PWD = @SYS_PWD, SYS_GAS92_CURRENT_PRICE = @SYS_GAS92_CURRENT_PRICE, SYS_GAS95_CURRENT_PRICE = @SYS_GAS95_CURRENT_PRICE, SYS_GASDO_CURRENT_PRICE = @SYS_GASDO_CURRENT_PRICE " +
                                                                 "SYS_GAS92_NEW_PRICE = @SYS_GAS92_NEW_PRICE, SYS_GAS95_NEW_PRICE = @SYS_GAS95_NEW_PRICE, SYS_GASDO_NEW_PRICE = @SYS_GASDO_NEW_PRICE, SYS_APPLY_DATE = @SYS_APPLY_DATE " +
                                                            " WHERE SYS_ADMIN = @SYS_ADMIN");
            SqlParameter[] sqlParameters = new SqlParameter[9];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoSysAdmin.SysAdminAccount);
            sqlParameters[1] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoSysAdmin.SysAdminPwd);           
            sqlParameters[2] = new SqlParameter("@SYS_GAS92_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoSysAdmin.SysGas92CurrentPrice);
            sqlParameters[3] = new SqlParameter("@SYS_GAS95_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoSysAdmin.SysGas95CurrentPrice);
            sqlParameters[4] = new SqlParameter("@SYS_GASDO_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOCurrentPrice);
            sqlParameters[5] = new SqlParameter("@SYS_GAS92_NEW_PRICE", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoSysAdmin.SysGas92NewPrice);
            sqlParameters[6] = new SqlParameter("@SYS_GAS95_NEW_PRICE", SqlDbType.Int);
            sqlParameters[6].Value = Convert.ToInt32(dtoSysAdmin.SysGas95NewPrice);
            sqlParameters[7] = new SqlParameter("@SYS_GASDO_NEW_PRICE", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(dtoSysAdmin.SysGasDONewPrice);
            sqlParameters[8] = new SqlParameter("@SYS_APPLY_DATE", SqlDbType.DateTime);
            sqlParameters[8].Value = Convert.ToDateTime(dtoSysAdmin.SysApplyDate);

            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

       

        public DataTransfer UpdateSystemAdminPrice(SystemAdminDTO dtoSysAdmin)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("UPDATE SYSTEM_ADMIN SET SYS_GAS92_CURRENT_PRICE = @SYS_GAS92_CURRENT_PRICE, SYS_GAS95_CURRENT_PRICE = @SYS_GAS95_CURRENT_PRICE, SYS_GASDO_CURRENT_PRICE = @SYS_GASDO_CURRENT_PRICE, " +
                                                                     "SYS_GAS92_NEW_PRICE = @SYS_GAS92_NEW_PRICE, SYS_GAS95_NEW_PRICE = @SYS_GAS95_NEW_PRICE, SYS_GASDO_NEW_PRICE = @SYS_GASDO_NEW_PRICE, SYS_APPLY_DATE = @SYS_APPLY_DATE " +
                                                                " WHERE SYS_ADMIN = @SYS_ADMIN");
                SqlParameter[] sqlParameters = new SqlParameter[8];
                sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
                sqlParameters[0].Value = Convert.ToString(dtoSysAdmin.SysAdminAccount);
                sqlParameters[1] = new SqlParameter("@SYS_GAS92_CURRENT_PRICE", SqlDbType.Int);
                sqlParameters[1].Value = Convert.ToInt32(dtoSysAdmin.SysGas92CurrentPrice);
                sqlParameters[2] = new SqlParameter("@SYS_GAS95_CURRENT_PRICE", SqlDbType.Int);
                sqlParameters[2].Value = Convert.ToInt32(dtoSysAdmin.SysGas95CurrentPrice);
                sqlParameters[3] = new SqlParameter("@SYS_GASDO_CURRENT_PRICE", SqlDbType.Int);
                sqlParameters[3].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOCurrentPrice);
                sqlParameters[4] = new SqlParameter("@SYS_GAS92_NEW_PRICE", SqlDbType.Int);
                sqlParameters[4].Value = Convert.ToInt32(dtoSysAdmin.SysGas92NewPrice);
                sqlParameters[5] = new SqlParameter("@SYS_GAS95_NEW_PRICE", SqlDbType.Int);
                sqlParameters[5].Value = Convert.ToInt32(dtoSysAdmin.SysGas95NewPrice);
                sqlParameters[6] = new SqlParameter("@SYS_GASDO_NEW_PRICE", SqlDbType.Int);
                sqlParameters[6].Value = Convert.ToInt32(dtoSysAdmin.SysGasDONewPrice);
                sqlParameters[7] = new SqlParameter("@SYS_APPLY_DATE", SqlDbType.DateTime);
                sqlParameters[7].Value = Convert.ToDateTime(dtoSysAdmin.SysApplyDate);

                bool result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
                if (result)
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                    dataResult.ResponseErrorMsg = SGMText.ADMIN_UPDATE_PRICE_SUCCESS;
                }
                else
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                    dataResult.ResponseErrorMsg = SGMText.ADMIN_UPDATE_PRICE_ERR;
                }
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.ADMIN_UPDATE_PRICE_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }

        public bool UpdateAdminAccount(string admin, string admin_new, string pass)
        {
            bool result = true;
            string query = string.Format("UPDATE SYSTEM_ADMIN SET SYS_PWD = @SYS_PWD, SYS_ADMIN = @SYS_ADMIN_NEW WHERE SYS_ADMIN = @SYS_ADMIN");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(admin);
            sqlParameters[1] = new SqlParameter("@SYS_ADMIN_NEW", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(admin_new);
            sqlParameters[2] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(pass);

            result = m_dbConnection.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        

        public bool DeleteSystemAdmin(string stAdminAcount)
        {
            bool result = true;
            string query = string.Format("DELETE FROM SYSTEM_ADMIN WHERE SYS_ADMIN = @SYS_ADMIN");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stAdminAcount);            
            result = m_dbConnection.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }

        public DataTransfer GetCurrentPrice(int iGasType)
        {
            DataTransfer dataResult = new DataTransfer();
            try
            {
                string query = string.Format("SELECT (CAST(SYS_APPLY_DATE AS FLOAT) - CAST(GETDATE() AS FLOAT)) AS RESULT_DATE, * FROM SYSTEM_ADMIN");
                DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, new SqlParameter[0]);

                if (tblResult.Rows.Count > 0)
                {
                    double resultDate = Double.Parse(tblResult.Rows[0]["RESULT_DATE"].ToString());
                    if (resultDate >= 0)
                    {
                        if (iGasType == SystemAdminDTO.GAS_TYPE_92)
                        {
                            dataResult.ResponseDataInt = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_NEW_PRICE"].ToString());
                        }
                        else if (iGasType == SystemAdminDTO.GAS_TYPE_95)
                        {
                            dataResult.ResponseDataInt = Int32.Parse(tblResult.Rows[0]["SYS_GAS95_NEW_PRICE"].ToString());
                        }
                        else if (iGasType == SystemAdminDTO.GAS_TYPE_DO)
                        {
                            dataResult.ResponseDataInt = Int32.Parse(tblResult.Rows[0]["SYS_GASDO_NEW_PRICE"].ToString());
                        }
                        else
                        {
                            dataResult.ResponseCurrentPriceGas92 = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_NEW_PRICE"].ToString());
                            dataResult.ResponseCurrentPriceGas95 = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_NEW_PRICE"].ToString());
                            dataResult.ResponseCurrentPriceGasDO = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_NEW_PRICE"].ToString());
                        }
                    }
                    else
                    {
                        if (iGasType == SystemAdminDTO.GAS_TYPE_92)
                        {
                            dataResult.ResponseDataInt = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_CURRENT_PRICE"].ToString());
                        }
                        else if (iGasType == SystemAdminDTO.GAS_TYPE_95)
                        {
                            dataResult.ResponseDataInt = Int32.Parse(tblResult.Rows[0]["SYS_GAS95_CURRENT_PRICE"].ToString());
                        }
                        else if (iGasType == SystemAdminDTO.GAS_TYPE_DO)
                        {
                            dataResult.ResponseDataInt = Int32.Parse(tblResult.Rows[0]["SYS_GASDO_CURRENT_PRICE"].ToString());
                        }
                        else
                        {
                            dataResult.ResponseCurrentPriceGas92 = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_CURRENT_PRICE"].ToString());
                            dataResult.ResponseCurrentPriceGas95 = Int32.Parse(tblResult.Rows[0]["SYS_GAS95_CURRENT_PRICE"].ToString());
                            dataResult.ResponseCurrentPriceGasDO = Int32.Parse(tblResult.Rows[0]["SYS_GASDO_CURRENT_PRICE"].ToString());
                        }
                    }
                    SystemAdminDTO dtoSysAdmin = new SystemAdminDTO();
                    dtoSysAdmin.SysAdminAccount = tblResult.Rows[0]["SYS_ADMIN"].ToString();
                    dtoSysAdmin.SysAdminPwd = tblResult.Rows[0]["SYS_PWD"].ToString();                    
                    dtoSysAdmin.SysGas92CurrentPrice = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_CURRENT_PRICE"].ToString());
                    dtoSysAdmin.SysGas95CurrentPrice = Int32.Parse(tblResult.Rows[0]["SYS_GAS95_CURRENT_PRICE"].ToString());
                    dtoSysAdmin.SysGasDOCurrentPrice = Int32.Parse(tblResult.Rows[0]["SYS_GASDO_CURRENT_PRICE"].ToString());
                    dtoSysAdmin.SysGas92NewPrice = Int32.Parse(tblResult.Rows[0]["SYS_GAS92_NEW_PRICE"].ToString());
                    dtoSysAdmin.SysGas95NewPrice = Int32.Parse(tblResult.Rows[0]["SYS_GAS95_NEW_PRICE"].ToString());
                    dtoSysAdmin.SysGasDONewPrice = Int32.Parse(tblResult.Rows[0]["SYS_GASDO_NEW_PRICE"].ToString());
                    dtoSysAdmin.SysApplyDate = DateTime.Parse(tblResult.Rows[0]["SYS_APPLY_DATE"].ToString());

                    dataResult.ResponseDataSystemAdminDTO = dtoSysAdmin;
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
                }
                else
                {
                    dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                    dataResult.ResponseErrorMsg = SGMText.SYS_ADMIN_GET_PRICE_ERR;
                }
            }
            catch (Exception ex)
            {
                dataResult.ResponseCode = DataTransfer.RESPONSE_CODE_FAIL;
                dataResult.ResponseErrorMsg = SGMText.SYS_ADMIN_GET_PRICE_ERR;
                dataResult.ResponseErrorMsgDetail = ex.Message + " : " + ex.StackTrace;
            }

            return dataResult;
        }
    }
}
