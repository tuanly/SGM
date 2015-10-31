using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGM_Core.DTO;
using SGM_Core.Utils;
using System.IO.Ports;
namespace SGM_Management
{
    public partial class frmSGMRechargeCard : Form
    {
        private bool m_bRecharge;
        private string m_stCusID;
        private string m_stCardID;
        private int m_iCurrentCardMoney;
        private CardDTO m_cardDTO;
        private int m_iPriceGas95;
        private int m_iPriceGas92;
        private int m_iPriceGasDO;

        private SGM_Service.ServiceSoapClient m_service;
        private frmSGMMessage frmMsg = null;
        private SerialDataReceivedEventHandler serialDatahandler = null;
        public frmSGMRechargeCard()
        {
            InitializeComponent();
            m_bRecharge = false;
            m_stCusID = "";
            m_stCardID = "";
            m_cardDTO = null;
            m_iPriceGas95 = 0;
            m_iPriceGas92 = 0;
            m_iPriceGasDO = 0;
            m_service = new SGM_Service.ServiceSoapClient();
            frmMsg = new frmSGMMessage();
            serialDatahandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }
        public string CusID
        {
            get { return m_stCusID; }
            set { m_stCusID = value; }
        }
        public string CardID
        {
            get { return m_stCardID; }
            set { m_stCardID = value; }
        }
        public CardDTO CardDTO
        {
            get { return m_cardDTO; }
            set { m_cardDTO = value; }
        }
        public bool StateRecharge
        {
            get { return m_bRecharge; }
            set { m_bRecharge = value; }
        }
        public int CurrentCardMoney
        {
            get { return m_iCurrentCardMoney; }
            set { m_iCurrentCardMoney = value; }
        }
        private void ResetInput()
        {
            txtCardID.Text = "";
            txtCardMoney.Text = "";
            txtRechargeGasPrice.Text = "";
            txtRechargeMoney.Text = "";
            txtRechargeNote.Text = "";
            //cbCardLocked.Checked = false;
            dtpRechargeDate.Value = DateTime.Now;
        }

        private void btnUpdateCard_Click(object sender, EventArgs e)
        {
            if (ValidateDataInput())
            {
                DataTransfer response = null;
                DataTransfer request = new DataTransfer();
                string jsResult = "";
                if (m_bRecharge)
                {
                    RechargeDTO dtoRecharge = new RechargeDTO();
                    dtoRecharge.RechargeDate = dtpRechargeDate.Value;
                    dtoRecharge.RechargeGas92Price = m_iPriceGas92;
                    dtoRecharge.RechargeGas95Price = m_iPriceGas95;
                    dtoRecharge.RechargeGasDOPrice = m_iPriceGasDO;
                    dtoRecharge.RechargeMoney = Int32.Parse(txtCardMoney.Text.Trim());
                    dtoRecharge.RechargeNote = txtRechargeNote.Text.Trim();
                    dtoRecharge.CardID = txtCardID.Text.Trim();
                    request.ResponseDataRechargeDTO = dtoRecharge;
                    jsResult = m_service.SGMManager_AddRechargeCard(JSonHelper.ConvertObjectToJSon(request));
                    response = JSonHelper.ConvertJSonToObject(jsResult);
                    if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        jsResult = m_service.SGMManager_UpdateRechargeIDForCard(txtCardID.Text.Trim());
                        response = JSonHelper.ConvertJSonToObject(jsResult);
                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            jsResult = m_service.SGMManager_UpdateMoneyForCard(txtCardID.Text.Trim(), m_iCurrentCardMoney + Int32.Parse(txtCardMoney.Text.Trim()));
                            response = JSonHelper.ConvertJSonToObject(jsResult);
                            if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                            {
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    CardDTO dtoCard = new CardDTO();
                    dtoCard.CardID = txtCardID.Text.Trim();
                    dtoCard.CardUnlockState = true;
                    dtoCard.CardRemainingMoney = Int32.Parse(txtCardMoney.Text.Trim());
                    dtoCard.CardBuyDate = dtpRechargeDate.Value;
                    dtoCard.RechargeID = -1;
                    dtoCard.CustomerID = m_stCusID;

                    request.ResponseDataCardDTO = dtoCard;
                    jsResult = m_service.SGMManager_AddNewCard(JSonHelper.ConvertObjectToJSon(request));
                    response = JSonHelper.ConvertJSonToObject(jsResult);
                    if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        RechargeDTO dtoRecharge = new RechargeDTO();
                        dtoRecharge.RechargeDate = dtpRechargeDate.Value;
                        dtoRecharge.RechargeGas92Price = m_iPriceGas92;
                        dtoRecharge.RechargeGas95Price = m_iPriceGas95;
                        dtoRecharge.RechargeGasDOPrice = m_iPriceGasDO;
                        dtoRecharge.RechargeMoney = Int32.Parse(txtCardMoney.Text.Trim());
                        dtoRecharge.RechargeNote = txtRechargeNote.Text.Trim();
                        dtoRecharge.CardID = txtCardID.Text.Trim();
                        request.ResponseDataRechargeDTO = dtoRecharge;
                        jsResult = m_service.SGMManager_AddRechargeCard(JSonHelper.ConvertObjectToJSon(request));
                        response = JSonHelper.ConvertJSonToObject(jsResult);
                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            jsResult = m_service.SGMManager_UpdateRechargeIDForCard(txtCardID.Text.Trim());
                            response = JSonHelper.ConvertJSonToObject(jsResult);
                        }
                    }
                }
                
                if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    this.Close();
                }
                else
                {
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, response.ResponseErrorMsg + " : " + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }
            }
        }

        private void frmSGMRechargeCard_Load(object sender, EventArgs e)
        {
            if (m_bRecharge)
            {               
                txtCardID.Enabled = false;
                txtCardID.Text = m_stCardID;
            }
            else
            {
                txtCardID.Enabled = true;
                ResetInput();
                txtCardID.Focus();
            }
            GetPriceGas();
        }

        private bool ValidateDataInput()
        {
            bool bValidate = true;
            errProvider.Clear();
            if (txtCardID.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCardID, SGMText.CARD_DATA_INPUT_CARD_ID_ERR);
                bValidate = false;
            }
            else if (!m_bRecharge)
            {
                String jsonResponse = m_service.SGMManager_CheckCardExist(txtCardID.Text.Trim());
                DataTransfer response = JSonHelper.ConvertJSonToObject(jsonResponse);
                if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    if (response.ResponseDataBool)
                    {
                        errProvider.SetError(txtCardID, SGMText.CARD_DATA_INPUT_EXIST_CARD_ID_ERR);
                        bValidate = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtCardID, SGMText.CARD_GET_CARD_ERR);
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.CARD_GET_CARD_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                    bValidate = false;
                }
            }
            if (txtCardMoney.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCardMoney, SGMText.CARD_DATA_INPUT_CARD_MONEY_ERR);
                bValidate = false;
            }
            else if (txtRechargeMoney.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtRechargeMoney, SGMText.CARD_DATA_INPUT_CARD_PRICE_ERR);
                bValidate = false;
            }
            else if (Int32.Parse(txtCardMoney.Text.Trim()) < Int32.Parse(txtRechargeMoney.Text.Trim()))
            {
                errProvider.SetError(txtRechargeMoney, SGMText.CARD_DATA_INPUT_CARD_MONEY_PRICE_ERR);
                bValidate = false;
            }
            //if (!m_bStateUpdate)
            {
                if (dtpRechargeDate.Value.Date < DateTime.Now.Date)
                {
                    errProvider.SetError(dtpRechargeDate, SGMText.CARD_DATA_INPUT_DATE_ERR);
                    bValidate = false;
                }
            }
            
            return bValidate;
        }

        private void txtCardMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void txtRechargeMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void GetPriceGas()
        {
           bool bHasErr = true;
                DataTransfer dataResult = JSonHelper.ConvertJSonToObject(m_service.SGMManager_GetCurrentPrice(SystemAdminDTO.GAS_TYPE_92));

                if (dataResult.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    m_iPriceGas92 = dataResult.ResponseDataInt;
                    dataResult = JSonHelper.ConvertJSonToObject(m_service.SGMManager_GetCurrentPrice(SystemAdminDTO.GAS_TYPE_95));
                    if (dataResult.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        m_iPriceGas95 = dataResult.ResponseDataInt;
                        dataResult = JSonHelper.ConvertJSonToObject(m_service.SGMManager_GetCurrentPrice(SystemAdminDTO.GAS_TYPE_DO));
                        if (dataResult.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            m_iPriceGasDO = dataResult.ResponseDataInt;
                            bHasErr = false;
                        }
                    }                    
                }
                if (bHasErr)
                {
                    m_iPriceGas92 = m_iPriceGas95 = m_iPriceGasDO = 0;
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.SYS_ADMIN_GET_PRICE_ERR + "\n" + dataResult.ResponseErrorMsg + ":" + dataResult.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                }

                txtRechargeGasPrice.Text = SGMText.GAS_92_TEXT + " : " + m_iPriceGas92 + "đ - " + SGMText.GAS_95_TEXT + " : " + m_iPriceGas95 + "đ - " + SGMText.GAS_DO_TEXT + " : " + m_iPriceGasDO + "đ";
        }
        private void CardReaderReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                if (txtCardID.Enabled == true)
                {
                    txtCardID.Invoke(new MethodInvoker(delegate { txtCardID.Text = sp.ReadLine(); }));
                }
            }
            catch (TimeoutException)
            {
            }



        }

        private void frmSGMRechargeCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            RFIDReader.UnRegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }

    }
}
