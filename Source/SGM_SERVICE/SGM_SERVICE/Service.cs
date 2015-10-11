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
    private AdminServiceBLL m_bllAdminServcie;
    private CustomerServiceBLL m_bllCustomerService;
    private ReportServiceBLL m_bllReportService;
    private CardService m_bllCardService;
    public Service()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
        m_bllSaleGasService = new SaleGasServiceBLL();
        m_bllCustomerService = new CustomerServiceBLL();
        m_bllAdminServcie = new AdminServiceBLL();
        m_bllReportService = new ReportServiceBLL();
        m_bllCardService = new CardService();
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
        return m_bllAdminServcie.ValidateAdminLogin(admin, pwd);
    }

    [WebMethod]
    public string SGMManager_UpdateAdminAccount(string admin, string admin_new, string pwd)
    {
        return m_bllAdminServcie.UpdateAdminAccount(admin, admin_new, pwd);
    }

    [WebMethod]
    public string SGMManager_UpdateSystemPrice(String jsonSysAdminDTO)
    {
        return m_bllAdminServcie.UpdateSystemPrice(jsonSysAdminDTO);
    }

    [WebMethod]
    public string SGMManager_UpdateSystemStore(String jsonSysAdminDTO)
    {
        return m_bllAdminServcie.UpdateSystemStore(jsonSysAdminDTO);
    }

    [WebMethod]
    public string SGMManager_CheckCustomerExist(string stCusID)
    {
        return m_bllCustomerService.CheckCustomerExist(stCusID);
    }

    [WebMethod]
    public string SGMManager_AddNewCustomer(string jsonCustomerDTO)
    {
        return m_bllCustomerService.AddNewCustomer(jsonCustomerDTO);
    }

    [WebMethod]
    public string SGMManager_GetCustomer(string stCusID, bool bExactly)
    {
        return m_bllCustomerService.GetCustomer(stCusID, bExactly);
    }

    [WebMethod]
    public string SGMManager_UpdateCustomer(string jsonCustomerDTO, string stCusID)
    {
        return m_bllCustomerService.UpdateCustomer(jsonCustomerDTO, stCusID);
    }

    [WebMethod]
    public string SGMManager_DelCustomer(string stCusID)
    {
        return m_bllCustomerService.DelCustomer(stCusID);
    }

    [WebMethod]
    public string SGMManager_CheckCardExist(string stCardID)
    {
        return m_bllCardService.CheckCardExist(stCardID);
    }

}
    

