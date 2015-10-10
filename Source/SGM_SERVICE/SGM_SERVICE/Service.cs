using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using SGM.ServicesCore.BLL;
using SGM_Core.DTO;



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
    public string SGMSaleGas_ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
    {
        return m_bllSaleGasService.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);
    }

    [WebMethod]
    public string SGMSaleGas_ValidateCardId(string strCardId)
    {
        return m_bllSaleGasService.ValidateCardId(strCardId);
    }

    [WebMethod]
    public string SGMSaleGas_GasBuying(string strCardId, int money)
    {
        return m_bllSaleGasService.GasBuying(strCardId, money);
    }

    [WebMethod]
    public string SGMManager_ValidateAdminLogin(string admin, string pwd)
    {
        return m_bSaleGasManagerService.SGMLogin_ValidateAdminLogin(admin, pwd);
    }

    [WebMethod]
    public string SGMManager_UpdateAdminAccount(string admin, string admin_new, string pwd)
    {
        return m_bSaleGasManagerService.SGMUpdateAccount_UpdateAdminAccount(admin, admin_new, pwd);
    }

    [WebMethod]
    public string SGMManager_UpdateSystemPrice(String jsonSysAdminDTO)
    {
        return m_bSaleGasManagerService.UpdateSystemPrice(jsonSysAdminDTO);
    }

    [WebMethod]
    public string SGMManager_CheckCustomerExist(string stCusID)
    {
        return m_bSaleGasManagerService.SGMCustomer_AddNewCustomer(stCusID);
    }

    [WebMethod]
    public string SGMManager_AddNewCustomer(string jsonCustomerDTO)
    {
        return m_bSaleGasManagerService.SGMCustomer_AddNewCustomer(jsonCustomerDTO);
    }

    [WebMethod]
    public string SGMManager_GetCustomer(string stCusID)
    {
        return m_bSaleGasManagerService.SGMCustomer_GetCustomer(stCusID);
    }

}
    

