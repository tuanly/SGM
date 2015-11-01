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

namespace SGM_SaleGas
{
    public partial class frmSGMSaleGas : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        private frmSGMMessage frmMsg = null;
        CardDTO _cardDTO;
        RechargeDTO _rechargeDTO;
        GasStationDTO _gasStationDTO;
        JSonHelper m_jsHelper;
        SerialDataReceivedEventHandler serailReaderHandler = null;

        private WaitingForm scanWaitingFrm;
        private WaitingForm buyWaitingFrm;
        private frmSGMCardDetail frmCardInfo = null;
        private bool m_bCardReaded = false;

        private int m_iCurrentPriceGas92 = 0;
        private int m_iCurrentPriceGas95 = 0;
        private int m_iCurrentPriceGasDO = 0;
        private enum gasTransactType
        {
            gas92,
            gas95,
            gasDO
        }

        private string MONEY_FORMAT = "#,##0";
        private string _cardId = "card0001";
        private int _moneyBuying = 20000;

        public frmSGMSaleGas(GasStationDTO gasStationDTO, int priceGas92, int priceGas95, int priceGasDO)
        {
            InitializeComponent();
            _gasStationDTO = gasStationDTO;
            m_iCurrentPriceGas92 = priceGas92;
            m_iCurrentPriceGas95 = priceGas95;
            m_iCurrentPriceGasDO = priceGasDO;
            m_jsHelper = new JSonHelper();
            frmMsg = new frmSGMMessage();
            frmCardInfo = new frmSGMCardDetail(_cardDTO, _rechargeDTO);
            scanWaitingFrm = new WaitingForm(this);
            scanWaitingFrm._bw.DoWork += DoScan;
            scanWaitingFrm._bw.RunWorkerCompleted += DoScanCompleted;
            
            buyWaitingFrm = new WaitingForm(this);
            buyWaitingFrm._bw.DoWork += DoBuy;
            buyWaitingFrm._bw.RunWorkerCompleted += DoBuyCompleted;

            
        }

        private void frmSGMSaleGas_Load(object sender, EventArgs e)
        {

            serailReaderHandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serailReaderHandler);
            _cardDTO = null;
            _rechargeDTO = null;
           
            EnableTransaction(false, true);
            txtMoney.Text = _moneyBuying.ToString(MONEY_FORMAT);
            lblTitle.Text = _gasStationDTO.GasStationName;
            resetForm();
            tblCurrentPrice.Text = SGMText.SALEGAS_CURRENT_PRICE + SGMText.GAS_92_TEXT + " : " + m_iCurrentPriceGas92 + " - " + SGMText.GAS_95_TEXT + " : " + m_iCurrentPriceGas95 + " - " + SGMText.GAS_DO_TEXT + " : " + m_iCurrentPriceGasDO;
        }

        private void EnableTransaction(bool yes, bool choice)
        {
            if (choice)
                rbGas92.Enabled = rbGas95.Enabled = rbGasDO.Enabled = yes;
            txtGasBuying.Enabled = yes;
            btnBuy.Enabled = yes;
            btnCardDetail.Enabled = yes;
        }

        private void updateGasChoice(gasTransactType t)
        {
            int price = 0;
            switch (t)
            {
                case gasTransactType.gas92:
                    txtGasType.Text = SGMText.GAS_92_TEXT;
                    price = _rechargeDTO.RechargeGas92Price;
                    txtPrice.Text = price.ToString(MONEY_FORMAT);
                    break;
                case gasTransactType.gas95:
                    txtGasType.Text = SGMText.GAS_95_TEXT;
                    price = _rechargeDTO.RechargeGas95Price;
                    txtPrice.Text = price.ToString(MONEY_FORMAT);
                    break;
                case gasTransactType.gasDO:
                    txtGasType.Text = SGMText.GAS_DO_TEXT;
                    price = _rechargeDTO.RechargeGasDOPrice;
                    txtPrice.Text = price.ToString(MONEY_FORMAT);
                    break;
            }
            calculatePay();
        }

        private void calculatePay()
        {
            EnableTransaction(true, false);
            try
            {
                _moneyBuying = Int32.Parse(txtMoney.Text, System.Globalization.NumberStyles.Currency);
                int moneyAfter = _cardDTO.CardRemainingMoney - _moneyBuying;
                if (moneyAfter < 0)
                    EnableTransaction(false, false);
                decimal price = rbGas92.Checked ? _rechargeDTO.RechargeGas92Price : rbGas95.Checked ? _rechargeDTO.RechargeGas95Price : _rechargeDTO.RechargeGasDOPrice;
                txtMoneyBuying.Text = txtMoney.Text;
                
                txtMoneyAfter.Text = moneyAfter.ToString(MONEY_FORMAT);
                decimal galon = _moneyBuying / price;
                txtGasBuying.Text = Math.Round(galon,1).ToString();
            }
            catch (Exception )
            {
                txtGasBuying.Text = "###";
                txtMoneyAfter.Text = "###";
                txtMoneyBuying.Text = "###";
            }
        }

        private void rbGas95_CheckedChanged(object sender, EventArgs e)
        {
           // updateGasChoice(gasTransactType.gas95);
        }

        private void rbGas92_CheckedChanged(object sender, EventArgs e)
        {
         //   updateGasChoice(gasTransactType.gas92);
        }

        private void rbGasDO_CheckedChanged(object sender, EventArgs e)
        {
          //  updateGasChoice(gasTransactType.gasDO);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtGasType_TextChanged(object sender, EventArgs e)
        {

        }

        private void DoScan(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            String cardId = (String) doWorkEventArgs.Argument;
            doWorkEventArgs.Result = service.SGMSaleGas_ValidateCardId(cardId);
        }
        private void DoScanCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            scanWaitingFrm.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                EnableTransaction(true, true);
                using (DataSet ds = dataResponse.ResponseDataSet)
                {
                    DataTable tblCard = ds.Tables[0];
                    if (tblCard.Rows.Count == 1)
                    {
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
                        btnCardDetail.Enabled = true;
                    }
                    else
                    {
                        // >>>
                        
                    }
                }
            }
            else
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                EnableTransaction(false, true);
            }
        }

        private void DoBuy(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            String jsonSale = (String)doWorkEventArgs.Argument;
            doWorkEventArgs.Result = service.SGMSaleGas_GasBuying(jsonSale, "admin");
        }
        private void DoBuyCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buyWaitingFrm.HideMe();
            String stResponse = e.Result as String;
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.GAS_BUYING_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                _cardDTO.CardRemainingMoney = _cardDTO.CardRemainingMoney - _moneyBuying;
                txtCardMoney.Text = _cardDTO.CardRemainingMoney.ToString(MONEY_FORMAT);
                calculatePay();
            }
            else
            {
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }
        }
        private void ScanCard(string cardId)
        {
            scanWaitingFrm.ShowMe();
            scanWaitingFrm._bw.RunWorkerAsync(cardId);
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
                    if (data != null && data.Length > 1) ;
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
            SaleGasDTO dto = new SaleGasDTO();
            dto.CardID = _cardDTO.CardID;
            dto.GasStationID = "000002";
            dto.SaleGasType = rbGas92.Checked ? SaleGasDTO.GAS_TYPE_92 : rbGas95.Checked ? SaleGasDTO.GAS_TYPE_95 : SaleGasDTO.GAS_TYPE_DO;
            dto.SaleGasPriceOnCard = 100;
            dto.SaleGasCardMoneyBefore = _cardDTO.CardRemainingMoney;
            dto.SaleGasCardMoneyAfter = _cardDTO.CardRemainingMoney - _moneyBuying;
            dto.SaleGasCurrentPrice = rbGas92.Checked ? _rechargeDTO.RechargeGas92Price : rbGas95.Checked ? _rechargeDTO.RechargeGas95Price : _rechargeDTO.RechargeGasDOPrice;
            DataTransfer df = new DataTransfer();
            df.ResponseDataSaleGasDTO = dto;
            buyWaitingFrm.ShowMe();
            buyWaitingFrm._bw.RunWorkerAsync(JSonHelper.ConvertObjectToJSon(df));
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
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
            btnBuy.Enabled = false;
            grBill.Text = SGMText.SALEGAS_MAIN_BILL;
            txtGasBuying.Text = 0.ToString(MONEY_FORMAT);
            txtGasType.Text = "";
            txtPrice.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyBefore.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyBuying.Text = 0.ToString(MONEY_FORMAT);
            txtMoneyAfter.Text = 0.ToString(MONEY_FORMAT);
            btnCardDetail.Enabled = false;
            tblCurrentPrice.Text = "";
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
