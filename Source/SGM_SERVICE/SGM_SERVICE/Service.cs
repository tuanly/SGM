using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
//using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using SGM.ServicesCore.BLL;
using SGM.ServicesCore.DAL;


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
    public string ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
    {
        GasStationDAL dalGasStation = new GasStationDAL();
        DataTransfer response = dalGasStation.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);       
        return response.createJSON();
    }
}
    

