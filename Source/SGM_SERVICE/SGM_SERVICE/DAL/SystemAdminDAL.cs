using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SGM_Core.DTO;

namespace SGM.ServicesCore.DAL
{
    public class SystemAdminDAL
    {
        private DBConnetionDAL m_dbConnection;

        public SystemAdminDAL()
        {     
            m_dbConnection = new DBConnetionDAL();
        }

        public SystemAdminDTO GetSystemAdminInfo(string stAdminAcount)
        {
            SystemAdminDTO dtoSysAdmin = null;
            string query = string.Format("SELECT * FROM SYSTEM_ADMIN WHERE SYS_ADMIN = @SYS_ADMIN");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(stAdminAcount);
            DataTable tblResult = m_dbConnection.ExecuteSelectQuery(query, sqlParameters);
            if (tblResult.Rows.Count > 0)
            {
                dtoSysAdmin = new SystemAdminDTO();
                foreach (DataRow dr in tblResult.Rows)
                {
                    dtoSysAdmin.SysAdminAccount = dr["SYS_ADMIN"].ToString();
                    dtoSysAdmin.SysAdminPwd = dr["SYS_PWD"].ToString();
                    dtoSysAdmin.SysGas92Total = Int32.Parse(dr["SYS_GAS92_TOTAL"].ToString());
                    dtoSysAdmin.SysGas95Total = Int32.Parse(dr["SYS_GAS95_TOTAL"].ToString());
                    dtoSysAdmin.SysGasDOTotal = Int32.Parse(dr["SYS_GASDO_TOTAL"].ToString());
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
            string query = string.Format("INSERT INTO SYSTEM_ADMIN (SYS_ADMIN, SYS_PWD, SYS_GAS92_TOTAL, SYS_GAS95_TOTAL, SYS_GASDO_TOTAL, SYS_GAS92_CURRENT_PRICE, SYS_GAS95_CURRENT_PRICE, SYS_GASDO_CURRENT_PRICE, SYS_GAS92_NEW_PRICE, SYS_GAS95_NEW_PRICE, SYS_GASDO_NEW_PRICE, SYS_APPLY_DATE) " +
                                                          " VALUES (@SYS_ADMIN, @SYS_PWD, @SYS_GAS92_TOTAL, @SYS_GAS95_TOTAL, @SYS_GASDO_TOTAL, @SYS_GAS92_CURRENT_PRICE, @SYS_GAS95_CURRENT_PRICE, @SYS_GASDO_CURRENT_PRICE, @SYS_GAS92_NEW_PRICE, @SYS_GAS95_NEW_PRICE, @SYS_GASDO_NEW_PRICE, @SYS_APPLY_DATE)");
            SqlParameter[] sqlParameters = new SqlParameter[12];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoSysAdmin.SysAdminAccount);
            sqlParameters[1] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoSysAdmin.SysAdminPwd);
            sqlParameters[2] = new SqlParameter("@SYS_GAS92_TOTAL", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoSysAdmin.SysGas92Total);
            sqlParameters[3] = new SqlParameter("@SYS_GAS95_TOTAL", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoSysAdmin.SysGas95Total);
            sqlParameters[4] = new SqlParameter("@SYS_GASDO_TOTAL", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOTotal);
            sqlParameters[5] = new SqlParameter("@SYS_GAS92_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoSysAdmin.SysGas92CurrentPrice);
            sqlParameters[6] = new SqlParameter("@SYS_GAS95_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[6].Value = Convert.ToInt32(dtoSysAdmin.SysGas95CurrentPrice);
            sqlParameters[7] = new SqlParameter("@SYS_GASDO_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOCurrentPrice);
            sqlParameters[8] = new SqlParameter("@SYS_GAS92_NEW_PRICE", SqlDbType.Int);
            sqlParameters[8].Value = Convert.ToInt32(dtoSysAdmin.SysGas92NewPrice);
            sqlParameters[9] = new SqlParameter("@SYS_GAS95_NEW_PRICE", SqlDbType.Int);
            sqlParameters[9].Value = Convert.ToInt32(dtoSysAdmin.SysGas95NewPrice);
            sqlParameters[10] = new SqlParameter("@SYS_GASDO_NEW_PRICE", SqlDbType.Int);
            sqlParameters[10].Value = Convert.ToInt32(dtoSysAdmin.SysGasDONewPrice);
            sqlParameters[11] = new SqlParameter("@SYS_APPLY_DATE", SqlDbType.DateTime);
            sqlParameters[11].Value = Convert.ToDateTime(dtoSysAdmin.SysApplyDate);

            result = m_dbConnection.ExecuteInsertQuery(query, sqlParameters);           
            return result;
        }

        public bool UpdateSystemAdmin(SystemAdminDTO dtoSysAdmin)
        {
            bool result = true;
            string query = string.Format("UPDATE SYSTEM_ADMIN SET SYS_PWD = @SYS_PWD, SYS_GAS92_TOTAL = @SYS_GAS92_TOTAL, SYS_GAS95_TOTAL = @SYS_GAS95_TOTAL, SYS_GASDO_TOTAL = @SYS_GASDO_TOTAL, " +
                                                                 "SYS_GAS92_CURRENT_PRICE = @SYS_GAS92_CURRENT_PRICE, SYS_GAS95_CURRENT_PRICE = @SYS_GAS95_CURRENT_PRICE, SYS_GASDO_CURRENT_PRICE = @SYS_GASDO_CURRENT_PRICE " +
                                                                 "SYS_GAS92_NEW_PRICE = @SYS_GAS92_NEW_PRICE, SYS_GAS95_NEW_PRICE = @SYS_GAS95_NEW_PRICE, SYS_GASDO_NEW_PRICE = @SYS_GASDO_NEW_PRICE, SYS_APPLY_DATE = @SYS_APPLY_DATE " +
                                                            " WHERE SYS_ADMIN = @SYS_ADMIN");
            SqlParameter[] sqlParameters = new SqlParameter[12];
            sqlParameters[0] = new SqlParameter("@SYS_ADMIN", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(dtoSysAdmin.SysAdminAccount);
            sqlParameters[1] = new SqlParameter("@SYS_PWD", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(dtoSysAdmin.SysAdminPwd);
            sqlParameters[2] = new SqlParameter("@SYS_GAS92_TOTAL", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToInt32(dtoSysAdmin.SysGas92Total);
            sqlParameters[3] = new SqlParameter("@SYS_GAS95_TOTAL", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToInt32(dtoSysAdmin.SysGas95Total);
            sqlParameters[4] = new SqlParameter("@SYS_GASDO_TOTAL", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOTotal);
            sqlParameters[5] = new SqlParameter("@SYS_GAS92_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToInt32(dtoSysAdmin.SysGas92CurrentPrice);
            sqlParameters[6] = new SqlParameter("@SYS_GAS95_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[6].Value = Convert.ToInt32(dtoSysAdmin.SysGas95CurrentPrice);
            sqlParameters[7] = new SqlParameter("@SYS_GASDO_CURRENT_PRICE", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(dtoSysAdmin.SysGasDOCurrentPrice);
            sqlParameters[8] = new SqlParameter("@SYS_GAS92_NEW_PRICE", SqlDbType.Int);
            sqlParameters[8].Value = Convert.ToInt32(dtoSysAdmin.SysGas92NewPrice);
            sqlParameters[9] = new SqlParameter("@SYS_GAS95_NEW_PRICE", SqlDbType.Int);
            sqlParameters[9].Value = Convert.ToInt32(dtoSysAdmin.SysGas95NewPrice);
            sqlParameters[10] = new SqlParameter("@SYS_GASDO_NEW_PRICE", SqlDbType.Int);
            sqlParameters[10].Value = Convert.ToInt32(dtoSysAdmin.SysGasDONewPrice);
            sqlParameters[11] = new SqlParameter("@SYS_APPLY_DATE", SqlDbType.DateTime);
            sqlParameters[11].Value = Convert.ToDateTime(dtoSysAdmin.SysApplyDate);

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
    }
}
