﻿using System;
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
using System.Threading;
using System.Threading.Tasks;

namespace SGM_Management
{
    public partial class frmSGMRechargeCard : Form
    {
        private bool m_bRecharge;
        private bool m_bChangeCard;
        private string m_stCusID;
        private string m_stCardID;
        private int m_iCurrentCardMoney;
        private int m_iExCardMoney;
        private CardDTO m_cardDTO;
        private int m_iPriceGas95;
        private int m_iPriceGas92;
        private int m_iPriceGasDO;

        private SGM_Service.ServiceSoapClient m_service;
        private frmSGMMessage frmMsg = null;
        private SerialDataReceivedEventHandler serialDatahandler = null;
        private frmSGMCustomer frmParent;
        public frmSGMRechargeCard()
        {
            InitializeComponent();
            m_bRecharge = false;
            m_bChangeCard = false;
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
        public bool StateChangeCard
        {
            get { return m_bChangeCard; }
            set { m_bChangeCard = value; }
        }
        public int CurrentCardMoney
        {
            get { return m_iCurrentCardMoney; }
            set { m_iCurrentCardMoney = value; }
        }
        public int ExCardMoney
        {
            get { return m_iExCardMoney; }
            set { m_iExCardMoney = value; }
        }
        private void ResetInput()
        {
            txtCardID.Text = "";
            txtCardMoney.Text = "";
            txtRechargeGasPrice.Text = "";
            txtExMoney.Text = "0";
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
                Task<String> task;
                if (m_bRecharge)
                {
                    RechargeDTO dtoRecharge = new RechargeDTO();
                    dtoRecharge.RechargeDate = dtpRechargeDate.Value;
                    dtoRecharge.RechargeGas92Price = m_iPriceGas92;
                    dtoRecharge.RechargeGas95Price = m_iPriceGas95;
                    dtoRecharge.RechargeGasDOPrice = m_iPriceGasDO;
                    dtoRecharge.RechargeMoney = Int32.Parse(txtCardMoney.Text.Trim());
                    dtoRecharge.RechargeMoneyEx = Int32.Parse(txtExMoney.Text.Trim());
                    dtoRecharge.RechargeNote = txtRechargeNote.Text.Trim();
                    dtoRecharge.CardID = txtCardID.Text.Trim();
                    request.ResponseDataRechargeDTO = dtoRecharge;
                    task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_AddRechargeCard(JSonHelper.ConvertObjectToJSon(request));
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                    {
	                    String stResponse = task.Result as String;
                        response = JSonHelper.ConvertJSonToObject(stResponse);
                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                        {
                            task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                            () =>
                            {
                                return m_service.SGMManager_UpdateRechargeIDForCard(txtCardID.Text.Trim());
                            });
                            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                            {
	                            stResponse = task.Result as String;
                                response = JSonHelper.ConvertJSonToObject(stResponse);
                                if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                                {
                                    task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                                    () =>
                                    {
                                        return m_service.SGMManager_UpdateMoneyForCard(txtCardID.Text.Trim(), m_iCurrentCardMoney + Int32.Parse(txtCardMoney.Text.Trim()) + Int32.Parse(txtExMoney.Text.Trim()));
                                    });
                                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                                    {
	                                    stResponse = task.Result as String;
                                        response = JSonHelper.ConvertJSonToObject(stResponse);
                                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                                        {
                                            this.Close();
                                        }
                                    }, SynchronizationContext.Current);
                                    
                                }
                            }, SynchronizationContext.Current);
                            
                        }
                    }, SynchronizationContext.Current);
                    
                }
                else
                {
                    CardDTO dtoCard = new CardDTO();
                    dtoCard.CardID = txtCardID.Text.Trim();
                    dtoCard.CardUnlockState = true;
                    dtoCard.CardRemainingMoney = Int32.Parse(txtCardMoney.Text.Trim());
                    dtoCard.CardMoneyEx = 0;
                    dtoCard.CardBuyDate = dtpRechargeDate.Value;
                    dtoCard.RechargeID = -1;
                    dtoCard.CustomerID = m_stCusID;

                    request.ResponseDataCardDTO = dtoCard;
                    task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                    () =>
                    {
                        return m_service.SGMManager_AddNewCard(JSonHelper.ConvertObjectToJSon(request));
                    });
                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                    {
	                    String stResponse = task.Result as String;
                        response = JSonHelper.ConvertJSonToObject(stResponse);
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
                            task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                            () =>
                            {
                                if (m_bChangeCard)
                                    return m_service.SGMManager_ChangeCard(m_stCardID, JSonHelper.ConvertObjectToJSon(request));
                                else
                                    return m_service.SGMManager_AddRechargeCard(JSonHelper.ConvertObjectToJSon(request));
                            });
                            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                            {
	                            stResponse = task.Result as String;
                                response = JSonHelper.ConvertJSonToObject(stResponse);
                                if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                                {
                                    task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                                    () =>
                                    {
                                        return m_service.SGMManager_UpdateRechargeIDForCard(txtCardID.Text.Trim());
                                    });
                                    SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                                    {
	                                    stResponse = task.Result as String;
                                        response = JSonHelper.ConvertJSonToObject(stResponse);
                                        if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                                        {
                                            this.Close();
                                        }
                                        else
                                        {
                                            frmMsg.ShowMsg(SGMText.SGM_ERROR, response.ResponseErrorMsg + " : " + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                                        }
                                    }, SynchronizationContext.Current);
                                }
                            }, SynchronizationContext.Current);
                        }
                    }, SynchronizationContext.Current);
                }
            }
        }

        private void frmSGMRechargeCard_Load(object sender, EventArgs e)
        {
            
        }

        private bool ValidateDataInput()
        {
            bool bValidate = true;
            
            SGMHelper.ShowToolTip(txtCardID, "");
            SGMHelper.ShowToolTip(txtCardMoney, "");
            SGMHelper.ShowToolTip(txtExMoney, "");
            SGMHelper.ShowToolTip(dtpRechargeDate, "");
            
            if (txtCardID.Text.Trim().Equals(""))
            {
                SGMHelper.ShowToolTip(txtCardID, SGMText.CARD_DATA_INPUT_CARD_ID_ERR);
                bValidate = false;
            }
            else if (!m_bRecharge)
            {
                Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
                () =>
                {
                    return m_service.SGMManager_CheckCardExist(txtCardID.Text.Trim());
                });
                SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
                {
	                String stResponse = task.Result as String;
                    DataTransfer response = JSonHelper.ConvertJSonToObject(stResponse);
                    if (response.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                    {
                        if (response.ResponseDataBool)
                        {
                            SGMHelper.ShowToolTip(txtCardID, SGMText.CARD_DATA_INPUT_EXIST_CARD_ID_ERR);
                            bValidate = false;
                        }
                    }
                    else
                    {
                        SGMHelper.ShowToolTip(txtCardID, SGMText.CARD_GET_CARD_ERR);
                        frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.CARD_GET_CARD_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        bValidate = false;
                    }
                }, SynchronizationContext.Current);
                
            }
            if (txtCardMoney.Text.Trim().Equals(""))
            {
                SGMHelper.ShowToolTip(txtCardMoney, SGMText.CARD_DATA_INPUT_CARD_MONEY_ERR);
                bValidate = false;
            }
            //else if (txtRechargeMoney.Text.Trim().Equals(""))
            //{
            //    SGMHelper.ShowToolTip(txtRechargeMoney, SGMText.CARD_DATA_INPUT_CARD_PRICE_ERR);
            //    bValidate = false;
            //}
            //else if (Int32.Parse(txtCardMoney.Text.Trim()) < Int32.Parse(txtExMoney.Text.Trim()))
            //{
            //    SGMHelper.ShowToolTip(txtExMoney, SGMText.CARD_DATA_INPUT_CARD_MONEY_PRICE_ERR);
            //    bValidate = false;
            //}
            //if (!m_bStateUpdate)
            {
                if (dtpRechargeDate.Value.Date < DateTime.Now.Date)
                {
                    SGMHelper.ShowToolTip(dtpRechargeDate, SGMText.CARD_DATA_INPUT_DATE_ERR);
                    bValidate = false;
                }
            }
            
            return bValidate;
        }

        private void txtCardMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                int isNumber = 0;
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            }
        }

        private void txtRechargeMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                int isNumber = 0;
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            }
        }

        private void GetPriceGas()
        {
           
           Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
               () =>
               {
                   return m_service.SGMManager_GetCurrentPrice(SystemAdminDTO.GAS_TYPE_92);
               });
           SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
           {
               bool bHasErr = true;
               String stResponse = task.Result as String;
               DataTransfer dataResult = JSonHelper.ConvertJSonToObject(stResponse);
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
               this.Enabled = true;
               ShowDialog();
           }, SynchronizationContext.Current);

               
                
        }
        private void CardReaderReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
		String data = sp.ReadLine();
                if (txtCardID.Enabled == true && this.Visible)
                {
		    if (data != null && data.Length > 1)
                    	txtCardID.Invoke(new MethodInvoker(delegate { txtCardID.Text = data.Substring(0, data.Length - 1); }));
                }
            }
            catch (TimeoutException)
            {
            }



        }

        private void frmSGMRechargeCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            RFIDReader.UnRegistryReaderListener(Program.ReaderPort, serialDatahandler);
            frmParent.LoadCardList();
        }
        
        public void ShowRecharge(frmSGMCustomer frmParent)
        {
            this.frmParent = frmParent;
          
            if (m_bRecharge)
            {
                txtCardID.Enabled = false;
                txtCardID.Text = m_stCardID;
                txtExMoney.Text = m_iExCardMoney.ToString();
            }
            else
            {
                
                txtCardID.Enabled = true;
                ResetInput();
                if (m_bChangeCard)
                {
                    txtCardMoney.Enabled = false;
                    //txtExMoney.Enabled = false;
                    txtCardMoney.Text = m_iCurrentCardMoney.ToString();
                    txtExMoney.Text = m_iExCardMoney.ToString();
                }
                else
                {
                    txtCardMoney.Enabled = true;
                    //txtExMoney.Enabled = true;
                   
                }
                txtCardID.Focus();
            }
            GetPriceGas();
        }

    }
}
