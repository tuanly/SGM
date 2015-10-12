using System;
using System.Data.SqlClient;
using System.Data;
using SGM_Core.Utils;

namespace SGM.ServicesCore.DAL
{   
    public class DBConnetionDAL
    {
        public static string m_stConnectionStr = "workstation id=gasstoredb.mssql.somee.com;packet size=4096;user id=tuanitct_SQLLogin_1;pwd=chmrqt3v25;data source=gasstoredb.mssql.somee.com;persist security info=False;initial catalog=gasstoredb";
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;
       
        public DBConnetionDAL()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(m_stConnectionStr);
        }
       
        private SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == 
						ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
                
        public DataTable ExecuteSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _query;
                if (sqlParameter != null)
                    myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();                
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return dataTable;
        }

        public bool ExecuteInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return true;
        }

        public bool ExecuteUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return true;
        }

        public bool ExecuteDeleteQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.DeleteCommand = myCommand;
                myCommand.ExecuteNonQuery();
                
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeDeleteQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return true;
        }
    }
}
