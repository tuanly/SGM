using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
//using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
    }

    [WebMethod]
    public int Add(int x, int y)
    {
        return x + y;
    }

    [WebMethod]
    public int Subtract(int x, int y)
    {
        return x - y;
    }

    [WebMethod]
    public int Multiply(int x, int y)
    {
        return x * y;
    }

    string connectionStr = "workstation id=gasstoredb.mssql.somee.com;packet size=4096;user id=tuanitct_SQLLogin_1;pwd=chmrqt3v25;data source=gasstoredb.mssql.somee.com;persist security info=False;initial catalog=gasstoredb";
    [WebMethod]
    public void WB_HR_InsertMethod(string id, bool state, int money, int rechargeid)
    {
        // getting connection string
        string conStr = connectionStr;// WebConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
        int rowsInserted = 0;
        // Creating Sql Connection
        using (SqlConnection conn = new SqlConnection(conStr))
        {
            // Creating insert statement
            string sql = string.Format(@"INSERT INTO [gasstoredb].[dbo].[CARD]([CARD_ID],[CARD_STATE],[CARD_MONEY],[RECHARGE_ID])VALUES('" + id + "','" + state + "','" + money + "','" + rechargeid + "')");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            rowsInserted = cmd.ExecuteNonQuery();
            conn.Close();
            cmd = null;
        }

    }

    // get management information from database
    //List<Table1> listM = new List<Table1>();

    //[WebMethod]
    //public List<Table1> GetSampleData()
    //{
    //    // getting connection string
    //    string conStr = WebConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

    //    DataTable dt = new DataTable();
    //    SqlDataReader dr = null;
    //    using (SqlConnection conn = new SqlConnection(conStr))
    //    {
    //        // Creating insert statement
    //        string sql = string.Format(@"select * from CARD");
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.Connection = conn;
    //        cmd.CommandText = sql;
    //        cmd.CommandType = CommandType.Text;
    //        conn.Open();

    //        dr = cmd.ExecuteReader();
    //        dt.Load(dr);

    //        conn.Close();
    //        cmd = null;

    //    }

    //    int countRow = dt.Rows.Count;

    //    foreach (DataRow drEmp in dt.Rows)
    //    {
    //        Table1 objemployee = new Table1();
    //        objemployee.id = Convert.ToInt32(drEmp["id"].ToString());
    //        objemployee.name = drEmp["name"].ToString();
    //        objemployee.salary = Convert.ToInt32(drEmp["value1"].ToString());
    //        listM.Add(objemployee);
    //    }
    //    return listM;
    //}

    [WebMethod]
    public DataSet ViewDB(string tableName)
    {
      // getting connection string
      string conStr = connectionStr;

      DataTable dt = new DataTable();
      SqlDataReader dr = null;
      using (SqlConnection conn = new SqlConnection(conStr))
      {
         // Creating insert statement
            string sql = string.Format(@"select * from @TABLE");
            sql = sql.Replace("@TABLE", tableName);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            
            conn.Open();
            dr = cmd.ExecuteReader();
            dt.Load(dr);

            conn.Close();
            cmd = null;

        }
        DataSet dsReturn = new DataSet();
        dsReturn.Tables.Add(dt);
        return dsReturn;
    }
    
    [WebMethod]
    public bool ValidateGasStationLoginCode(string GASSTATION_ID, string GASSTATION_MACADDRESS)
    {
      // getting connection string
      string conStr = connectionStr;

      //string queryText = @"SELECT ISNULL(GASSTATION_MACADDRESS,@GASSTATION_MACADDRESS) FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID AND GASSTATION_MACADDRESS= @GASSTATION_MACADDRESS";
string queryText = @"SELECT GASSTATION_ID FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID";

        DataTable dt = new DataTable();
        SqlDataReader dr = null;
        using(SqlConnection cn = new SqlConnection(conStr))
        using(SqlCommand cmd = new SqlCommand(queryText, cn))
        {
            cn.Open();  
            cmd.Parameters.AddWithValue("@GASSTATION_ID", GASSTATION_ID);
            //cmd.Parameters.AddWithValue("@GASSTATION_MACADDRESS", GASSTATION_MACADDRESS);

            dr = cmd.ExecuteReader();
            dt.Load(dr); 
            cn.Close();
            return (dt.Rows.Count > 0);
        }
    }
}
    

