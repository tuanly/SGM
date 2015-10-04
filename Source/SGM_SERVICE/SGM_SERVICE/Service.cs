using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using SGM.ServicesCore.BLL;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    private SaleGasServiceBLL m_bllSaleGasService;
    private SaleGasManagerServiceBLL m_bSaleGasManagerService;
    public Service()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
        m_bllSaleGasService = new SaleGasServiceBLL();
        m_bSaleGasManagerService = new SaleGasManagerServiceBLL();
    }
        
      
    [WebMethod]
    public string ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
    {
        return m_bllSaleGasService.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);
    }

    [WebMethod]
    public string ValidateCardId(string strCardId)
    {
        return m_bllSaleGasService.ValidateCardId(strCardId);
    }

    [WebMethod]
    public string GasBuying(string strCardId, int money)
    {
        return m_bllSaleGasService.GasBuying(strCardId, money);
    }
}
    

