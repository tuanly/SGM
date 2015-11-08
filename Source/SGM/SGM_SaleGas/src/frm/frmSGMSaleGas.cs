using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using SGM_Core.DTO;
using SGM_Core.Utils;
using SGM_WaitingIdicator;
using System.Threading;
using System.Threading.Tasks;

namespace SGM_SaleGas
{
    public partial class frmSGMSaleGas : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        private frmSGMMessage frmMsg = null;
        CardDTO _cardDTO;
        RechargeDTO _rechargeDTO;
        GasStationDTO _gasStationDTO;
        SystemAdminDTO _adminDTO;
        JSonHelper m_jsHelper;
        SerialDataReceivedEventHandler serailReaderHandler = null;

        private frmSGMCardDetail frmCardInfo = null;
        private bool m_bCardReaded = false;

        private int m_iCurrentPriceGas92 = 0;
        private int m_iCurrentPriceGas95 = 0;
        private int m_iCurrentPriceGasDO = 0;
      

        private int m_iApplyPrice = 0;
        private int m_iCurrentPrice = 0;
        private float m_iCurrentTotal = 0;
        private bool m_bBuy = false;
        private enum gasTransactType
        {
            gas92,
            gas95,
            gasDO
        }

        private string MONEY_FORMAT = "#,##0";
        private string _cardId = "card0001";
        private int _moneyBuying = 20000;

        public frmSGMSaleGas(SystemAdminDTO adminDTO, GasStationDTO gasStationDTO, int priceGas92, int priceGas95, int priceGasDO)
        {
            InitializeComponent();
            _adminDTO = adminDTO;
            _gasStationDTO = gasStationDTO;
            m_iCurrentPriceGas92 = priceGas92;
            m_iCurrentPriceGas95 = priceGas95;
            m_iCurrentPriceGasDO = priceGasDO;
            m_jsHelper = new JSonHelper();
            frmMsg = new frmSGMMessage();
            frmCardInfo = new frmSGMCardDetail(_cardDTO, _rechargeDTO);
            lblCurrentPrice.Text = SGMText.SALEGAS_CURRENT_PRICE + SGMText.GAS_92_TEXT + " : " +  m_iCurrentPriceGas92 + " , "  + SGMText.GAS_95_TEXT + " : "+ m_iCurrentPriceGas95 + " , " + SGMText.GAS_DO_TEXT + " : " + m_iCurrentPriceGasDO;
        }

        private void frmSGMSaleGas_Load(object sender, EventArgs e)
        {
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);

            serailReaderHandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serailReaderHandler);
            _cardDTO = null;
            _rechargeDTO = null;
           
            
            txtMoney.Text = _moneyBuying.ToString(MONEY_FORMAT);
            lblTitle.Text = _gasStationDTO.GasStationName;
            resetForm();
            lblCurrentPrice.Text = SGMText.SALEGAS_CURRENT_PRICE + SGMText.GAS_92_TEXT + " : " + m_iCurrentPriceGas92 + " - " + SGMText.GAS_95_TEXT + " : " + m_iCurrentPriceGas95 + " - " + SGMText.GAS_DO_TEXT + " : " + m_iCurrentPriceGasDO;
            EnableTransaction(false, true);
        }

        private void EnableTransaction(bool yes, bool choice)
        {
            if (choice)
                rbGas92.Enabled = rbGas95.Enabled = rbGasDO.Enabled = yes;
            txtGasBuying.Enabled = yes;
            btnBuy.Enabled = yes;
            btnCardDetail.Enabled = yes;
            txtMoney.Enabled = yes;
            btnCardDetail.Enabled = yes;
        }

        private void updateGasChoice(gasTransactType t)
        {           
            switch (t)
            {
                case gasTransactType.gas92:
                    txtGasType.Text = SGMText.GAS_92_TEXT;
                    m_iCurrentPrice = m_iCurrentPriceGas92;
                    m_iApplyPrice = m_iCurrentPrice > _rechargeDTO.RechargeGas92Price ? _rechargeDTO.RechargeGas92Price : m_iCurrentPrice;
                    txtPrice.Text = _rechargeDTO.RechargeGas92Price.ToString(MONEY_FORMAT);
                    m_iCurrentTotal = _adminDTO.SysGas92Total;
                    break;
                case gasTransactType.gas95:
                    txtGasType.Text = SGMText.GAS_95_TEXT;
                    m_iCurrentPrice = m_iCurrentPriceGas95;
                    m_iApplyPrice = m_iCurrentPrice > _rechargeDTO.RechargeGas95Price ? _rechargeDTO.RechargeGas95Price : m_iCurrentPrice;
                    txtPrice.Text = _rechargeDTO.RechargeGas95Price.ToString(MONEY_FORMAT);
                    m_iCurrentTotal = _adminDTO.SysGas95Total;
                    break;
                case gasTransactType.gasDO:
                    txtGasType.Text = SGMText.GAS_DO_TEXT;
                    m_iCurrentPrice = m_iCurrentPriceGasDO;
                    m_iApplyPrice = m_iCurrentPrice > _rechargeDTO.RechargeGasDOPrice ? _rechargeDTO.RechargeGasDOPrice : m_iCurrentPrice;
                    txtPrice.Text = _rechargeDTO.RechargeGasDOPrice.ToString(MONEY_FORMAT);
                    m_iCurrentTotal = _adminDTO.SysGasDOTotal;
                    break;
            }
            calculatePay();
        }

        private void calculatePay()
        {
            //EnableTransaction(true, false);
            errorProvider.Clear();
            btnBuy.Enabled = true;
            try
            {
                if (m_iCurrentPrice > 0)
                {
                    _moneyBuying = Int32.Parse(txtMoney.Text, System.Globalization.NumberStyles.Currency);
                    float _totalBuying = (float)_moneyBuying / m_iCurrentPrice;
                    if (_totalBuying <= m_iCurrentTotal)
                    {
                        float _moneyRealBuying = _totalBuying * m_iApplyPrice;
                        float moneyAfter = _cardDTO.CardRemainingMoney - _moneyRealBuying;
                        if (moneyAfter >= 0)
                        {
                            txtMoneyBefore.Text = _cardDTO.CardRemainingMoney.ToString(MONEY_FORMAT);
                            txtGasBuying.Text = Math.Round(_totalBuying, 1).ToString();
                            txtMoneyAfter.Text = moneyAfter.ToString(MONEY_FORMAT);
                            txtMoneyBuying.Text = _moneyRealBuying.ToString(MONEY_FORMAT);
                        }
                        else
                        {
                            errorProvider.SetError(txtMoney, SGMText.GAS_BUYING_INPUT_MONEY_FAIL);
                            btnBuy.Enabled = false;
                        }
                    }
                    else
                    {
                        errorProvider.SetError(txtMoney, SGMText.GAS_BUYING_INPUT_TOTAL_GAS_FAIL);
                        btnBuy.Enabled = false;
                    }
                }

                
 
                
            }
            catch (Exception )
            {
                txtMoneyBefore.Text = "";
                txtGasBuying.Text = "";
                txtMoneyAfter.Text = "";
                txtMoneyBuying.Text = "";
            }
        }

        private void rbGas95_CheckedChanged(object sender, EventArgs e)
        {
            updateGasChoice(gasTransactType.gas95);
        }

        private void rbGas92_CheckedChanged(object sender, EventArgs e)
        {
            updateGasChoice(gasTransactType.gas92);
        }

        private void rbGasDO_CheckedChanged(object sender, EventArgs e)
        {
            updateGasChoice(gasTransactType.gasDO);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtGasType_TextChanged(object sender, EventArgs e)
        {

        }

        private void ScanCard(string cardId)
        {
            SGM_WaitingIdicator.WaitingForm.waitingFrm.ShowMe();
            Task<String> task = Task.Factory.StartNew(() =>
            {
                return service.SGMSaleGas_ValidateCardId(cardId);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                SGM_WaitingIdicator.WaitingForm.waitingFrm.HideMe();
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    EnableTransaction(true, true);
                    
                    using (DataSet ds = dataResponse.ResponseDataSet)
                    {
                        DataTable tblCard = ds.Tables[0];
                        if (tblCard.Rows.Count == 1)
                        {
                            clearForm();
                            _cardDTO = new CardDTO();
                            _rechargeDTO = new RechargeDTO();

                            foreach (DataRow dr in tblCard.Rows)
                            {
                                _cardDTO.CardID = dr["CARD_ID"].ToString(); ;
                                _cardDTO.CardUnlockState = Boolean.Parse(dr["CARD_STATE"].ToString());
                                _cardDTO.CardRemainingMoney = Int32.Parse(dr["CARD_MONEY"].ToString());
                                _cardDTO.CardBuyDate = DateTime.Parse(dr["CARD_BUY_DATE"].ToString());
                                _cardDTO.RechargeID = Int32.Parse(dr["RECHARGE_ID"].ToString());
                                _cardDTO.CustomerID = dr["CUS_ID"].ToString();

                                _rechargeDTO.RechargeID = Int32.Parse(dr["RECHARGE_ID"].ToString());
                                _rechargeDTO.RechargeDate = DateTime.Parse(dr["RECHARGE_DATE"].ToString());
                                _rechargeDTO.RechargeGas92Price = Int32.Parse(dr["RECHARGE_GAS92_PRICE"].ToString());
                                _rechargeDTO.RechargeGas95Price = Int32.Parse(dr["RECHARGE_GAS95_PRICE"].ToString());
                                _rechargeDTO.RechargeGasDOPrice = Int32.Parse(dr["RECHARGE_GASDO_PRICE"].ToString());
                                _rechargeDTO.RechargeMoney = Int32.Parse(dr["RECHARGE_MONEY"].ToString());
                                _rechargeDTO.RechargeNote = dr["RECHARGE_MONEY"].ToString();
                                _rechargeDTO.CardID = dr["CARD_ID"].ToString();
                            }

                            //txtCardID.Text = _cardDTO.CardID;
                            txtCardMoney.Text = _cardDTO.CardRemainingMoney.ToString(MONEY_FORMAT);
                            //updateGasChoice(rbGas92.Checked ? gasTransactType.gas92 : rbGas95.Checked ? gasTransactType.gas95 : gasTransactType.gasDO);
                            if (_cardDTO.CardUnlockState == false)
                            {
                                frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.GAS_CARD_LOCK, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                                //_cardDTO = null;
                                //_rechargeDTO = null;
                                EnableTransaction(false, true);
                            }
                            grBill.Text = SGMText.SALEGAS_MAIN_BILL;
                            btnCardDetail.Enabled = true;
                            m_bBuy = false;
                            updateGasChoice(rbGas92.Checked ? gasTransactType.gas92 : rbGas95.Checked ? gasTransactType.gas95 : gasTransactType.gasDO);
                            txtMoney.Focus();
                        }
                        else
                        {
                            // >>>

                        }
                    }
                }
                else
                {
                    resetForm();
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                    EnableTransaction(false, true);
                    
                }
            }, SynchronizationContext.Current);
        }
       
        private void btnCardDetail_Click(object sender, EventArgs e)
        {
            if (_cardDTO != null && _rechargeDTO != null)
            {
                frmCardInfo = new frmSGMCardDetail(_cardDTO, _rechargeDTO);
                frmCardInfo.ShowDialog();
            }
        }

        private void CardReaderReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            
            try
            {
                if (!frmMsg.Visible && !frmCardInfo.Visible)
                {
                    SerialPort sp = (SerialPort)sender;
                    String data = sp.ReadLine();
                    if (data != null && data.Length > 1) 
                        txtCardID.Invoke(new MethodInvoker(delegate { txtCardID.Text = data.Substring(0, data.Length - 1); }));
                    m_bCardReaded = true;
                }
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtMoney.Text == "0")
            {
                errorProvider.SetError(txtMoney, SGMText.GAS_BUYING_INPUT_MONEY_INVALID);
                return;
            }
            SaleGasDTO dto = new SaleGasDTO();
            dto.CardID = _cardDTO.CardID;
            dto.GasStationID = _gasStationDTO.GasStationID;
            dto.SaleGasType = rbGas92.Checked ? SaleGasDTO.GAS_TYPE_92 : rbGas95.Checked ? SaleGasDTO.GAS_TYPE_95 : SaleGasDTO.GAS_TYPE_DO;
            dto.SaleGasPriceOnCard = Int32.Parse(txtPrice.Text, System.Globalization.NumberStyles.Currency);
            dto.SaleGasCardMoneyBefore = Int32.Parse(txtMoneyBefore.Text, System.Globalization.NumberStyles.Currency);
            dto.SaleGasCardMoneyAfter = Int32.Parse(txtMoneyAfter.Text, System.Globalization.NumberStyles.Currency);
            dto.SaleGasCurrentPrice = m_iCurrentPrice;
            DataTransfer df = new DataTransfer();
            df.ResponseDataSaleGasDTO = dto;
            SGM_WaitingIdicator.WaitingForm.waitingFrm.ShowMe();
            Task<String> task = Task.Factory.StartNew(() =>
            {
                return service.SGMSaleGas_GasBuying(JSonHelper.ConvertObjectToJSon(df), "admin");
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                SGM_WaitingIdicator.WaitingForm.waitingFrm.HideMe();
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    m_bBuy = true;
                    frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.GAS_BUYING_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                   // _cardDTO.CardRemainingMoney = _cardDTO.CardRemainingMoney - _moneyBuying;
                   // txtCardMoney.Text = _cardDTO.CardRemainingMoney.ToString(MONEY_FORMAT);
                   // calculatePay();
                    EnableTransaction(false, false);
                    grBill.Text = SGMText.SALEGAS_MAIN_BILL + txtCardID.Text;
                    txtCardID.Text = "";
                    txtCardMoney.Text = "";
                    txtMoney.Text = "0";
                    
                }
                else
                {
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }

            }, SynchronizationContext.Current);
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if (!m_bBuy)
                calculatePay();
        }

        private void frmSGMSaleGas_FormClosing(object sender, FormClosingEventArgs e)
        {
            RFIDReader.UnRegistryReaderListener(Program.ReaderPort, serailReaderHandler);
        }
        private void resetForm()
        {
            _cardDTO = null;
            _rechargeDTO = null;
            txtCardID.Text = "";
            txtCardMoney.Text = 0.ToString(MONEY_FORMAT);
            rbGas92.Checked = true;
            txtMoney.Text = 0.ToString(MONEY_FORMAT);            
            grBill.Text = SGMText.SALEGAS_MAIN_BILL;
            txtGasBuying.Text = 0.ToString(MONEY_FORMAT);
            txtGasType.Text = "";
            txtPrice.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyBefore.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyBuying.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyAfter.Text = 0.ToString(MONEY_FORMAT);          
            
        }

        private void clearForm()
        {            
            //rbGas92.Checked = true;
            txtMoney.Text = 0.ToString(MONEY_FORMAT);
            grBill.Text = SGMText.SALEGAS_MAIN_BILL;
            txtGasBuying.Text = 0.ToString(MONEY_FORMAT);
            txtGasType.Text = "";
            txtPrice.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyBefore.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyBuying.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyAfter.Text = 0.ToString(MONEY_FORMAT);
            errorProvider.Clear();
            grBill.Text = SGMText.SALEGAS_MAIN_BILL;
        }

        private void timeCardReader_Tick(object sender, EventArgs e)
        {
            if (m_bCardReaded)
            {
                m_bCardReaded = false;
                ScanCard(txtCardID.Text);
            }
        }
        
    }
}
