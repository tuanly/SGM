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
    private GasStationServiceBLL m_bllGasStationService;
    private GasStoreServiceBLL m_bllGasStoreService;
    public Service()
    {
        //Uncomment the following line if using designed components
        //InitializeComponent();
        m_bllSaleGasService = new SaleGasServiceBLL();
        m_bllCustomerService = new CustomerServiceBLL();
        m_bllAdminServcie = new AdminServiceBLL();
        m_bllReportService = new ReportServiceBLL();
        m_bllCardService = new CardService();
        m_bllGasStationService = new GasStationServiceBLL();
        m_bllGasStoreService = new GasStoreServiceBLL();
    }

    [WebMethod]
    public string SGMSaleGas_GetGasStationList()
    {
        return m_bllReportService.GetGasStationList();
    }
      
    [WebMethod]
    public string SGMSaleGas_ValidateGasStationLogin(string stGasStationID, string stGasStationMacAddress)
    {
        return m_bllSaleGasService.ValidateGasStationLogin(stGasStationID, stGasStationMacAddress);
    }

    [WebMethod]
    public string SGMSaleGas_ValidateGasStoreLogin(string stGasStoreID, string stGasStoreMacAddress)
    {
        return m_bllGasStoreService.ValidateGasStoreLogin(stGasStoreID, stGasStoreMacAddress);
    }

    [WebMethod]
    public string SGMSaleGas_ValidateCardId(string strCardId)
    {
        return m_bllSaleGasService.ValidateCardId(strCardId);
    }

    [WebMethod]
    public string SGMSaleGas_GasBuying(string jsonSaleGasDTO, string sysadmin)
    {
        return m_bllSaleGasService.GasBuying(jsonSaleGasDTO, sysadmin);
    }

    [WebMethod]
    public string SGMSaleGas_GetSaleGasReport(string stGasStationID, DateTime dateStart, DateTime dateEnd, string stCardID)
    {
        return m_bllSaleGasService.GetSaleGasReport(stGasStationID, dateStart, dateEnd, stCardID);
    }

    [WebMethod]
    public string SGMSaleGas_GetCardReport(string stGasStationID, DateTime dateStart, DateTime dateEnd, string stCardID)
    {
        return m_bllCardService.GetCardReport(stGasStationID, dateStart, dateEnd, stCardID);
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
    public string SGMSaleGas_GetCustomerList()
    {
        return m_bllReportService.GetCustomerList();
    }
    

    [WebMethod]
    public string SGMManager_CheckCardExist(string stCardID)
    {
        return m_bllCardService.CheckCardExist(stCardID);
    }

    [WebMethod]
    public string SGMManager_GetCurrentPrice(int iGasType)
    {
        return m_bllAdminServcie.GetCurrentPrice(iGasType);
    }

    [WebMethod]
    public string SGMManager_AddNewCard(string jsCardDTO)
    {
        return m_bllCardService.AddNewCard(jsCardDTO);
    }

    [WebMethod]
    public string SGMManager_AddRechargeCard(string jsRechargeDTO)
    {
        return m_bllCardService.AddRechargeCard(jsRechargeDTO);
    }

    [WebMethod]
    public string SGMManager_ChangeCard(string oldCardID, string jsRechargeDTO)
    {
        return m_bllCardService.ChangeCard(oldCardID, jsRechargeDTO);
    }

    [WebMethod]
    public string SGMManager_UpdateRechargeIDForCard(string stCardID)
    {
        return m_bllCardService.UpdateRechargeIDForCard(stCardID);
    }

    [WebMethod]
    public string SGMManager_UpdateMoneyForCard(string stCardID, int iMoney)
    {
        return m_bllCardService.UpdateMoneyForCard(stCardID, iMoney);
    }

    [WebMethod]
    public string SGMManager_GetCardsOfCustomer(string stCusID)
    {
        return m_bllCardService.GetCardsOfCustomer(stCusID);
    }

    [WebMethod]
    public string SGMManager_UpdateCardState(string stCardID, bool bLocked)
    {
        return m_bllCardService.UpdateCardState(stCardID, bLocked);
    }

    [WebMethod]
    public string SGMManager_CheckGasStationExist(string stGasStationID)
    {
        return m_bllGasStationService.CheckGasStationExist(stGasStationID);
    }

    [WebMethod]
    public string SGMManager_AddNewGasStaion(string jsGasStationDTO)
    {
        return m_bllGasStationService.AddNewGasStaion(jsGasStationDTO);
    }

    [WebMethod]
    public string SGMManager_GetGasStation(string stGasStationID)
    {
        return m_bllGasStationService.GetGasStation(stGasStationID);
    }

    [WebMethod]
    public string SGMManager_UpdateGasStation(string jsonCustomerDTO, string stGasStationID)
    {
        return m_bllGasStationService.UpdateGasStation(jsonCustomerDTO, stGasStationID);
    }

    [WebMethod]
    public string SGMManager_DelGasStation(string stGasStationID)
    {
        return m_bllGasStationService.DelGasStation(stGasStationID);
    }

    ///
    [WebMethod]
    public string SGMManager_CheckGasStoreExist(string stGasStoreID)
    {
        return m_bllGasStoreService.CheckGasStoreExist(stGasStoreID);
    }

    [WebMethod]
    public string SGMManager_AddNewGasStore(string jsGasStoreDTO)
    {
        return m_bllGasStoreService.AddNewGasStore(jsGasStoreDTO);
    }

    [WebMethod]
    public string SGMManager_GetGasStore(string stGasStoreID)
    {
        return m_bllGasStoreService.GetGasStore(stGasStoreID);
    }

    // we must use BEGIN TRANSACTION  ....... COMMIT here
    [WebMethod]
    public string SGMManager_UpdateGasStore(string jsonGasStoreDTO) 
    {
        return m_bllGasStoreService.UpdateGasStore(jsonGasStoreDTO);
    }

    [WebMethod]
    public string SGMManager_AddNewGasStoreUpdate(string jsonGasStoreUpdateDTO)
    {
        return m_bllGasStoreService.AddNewGasStoreUpdate(jsonGasStoreUpdateDTO);
    }
    // end must

    [WebMethod]
    public string SGMManager_DelGasStore(string stGasStoreID)
    {
        return m_bllGasStoreService.DelGasStore(stGasStoreID);
    }

    [WebMethod]
    public string SGMManager_GetGasStoreList()
    {
        return m_bllGasStoreService.GetGasStores();
    }

}
    

