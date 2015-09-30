using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
//using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using SGM.ServicesCore.BLL;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
    }

    

    string connectionStr = "workstation id=gasstoredb.mssql.somee.com;packet size=4096;user id=tuanitct_SQLLogin_1;pwd=chmrqt3v25;data source=gasstoredb.mssql.somee.com;persist security info=False;initial catalog=gasstoredb";
    
      
    [WebMethod]
    public string ValidateGasStationLoginCode(string GASSTATION_ID, string GASSTATION_MACADDRESS)
    {
      //// getting connection string
      // string conStr = connectionStr;

      ////string queryText = @"SELECT ISNULL(GASSTATION_MACADDRESS,@GASSTATION_MACADDRESS) FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID AND GASSTATION_MACADDRESS= @GASSTATION_MACADDRESS";
      //  string queryText = @"SELECT GASSTATION_ID FROM GAS_STATION WHERE GASSTATION_ID = @GASSTATION_ID";

      //  DataTable dt = new DataTable();
      //  SqlDataReader dr = null;
      //  using(SqlConnection cn = new SqlConnection(conStr))
      //  using(SqlCommand cmd = new SqlCommand(queryText, cn))
      //  {
      //      cn.Open();  
      //      cmd.Parameters.AddWithValue("@GASSTATION_ID", GASSTATION_ID);
      //      //cmd.Parameters.AddWithValue("@GASSTATION_MACADDRESS", GASSTATION_MACADDRESS);

      //      dr = cmd.ExecuteReader();
      //      dt.Load(dr); 
      //      cn.Close();
      //      return (dt.Rows.Count > 0);
      //  }
        DataTransfer response = new DataTransfer();
        response.ResponseCode = DataTransfer.RESPONSE_CODE_SUCCESS;
        response.ResponseData = "ok men";
        return response.createJSON();
    }
}
    

