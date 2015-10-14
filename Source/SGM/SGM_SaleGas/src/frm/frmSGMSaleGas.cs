﻿using System;
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

namespace SGM_SaleGas
{
    public partial class frmSGMSaleGas : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        
        CardDTO _cardDTO;
        RechargeDTO _rechargeDTO;
        JSonHelper m_jsHelper;

        private enum gasTransactType
        {
            gas92,
            gas95,
            gasDO
        }

        private string MONEY_FORMAT = "#,##0";
        private string _cardId = "card0001";
        private int _moneyBuying = 20000;

        public frmSGMSaleGas()
        {
            InitializeComponent();
            m_jsHelper = new JSonHelper();
        }

        private void frmSGMSaleGas_Load(object sender, EventArgs e)
        {
            if (Program.ReaderPort != null)
                Program.ReaderPort.DataReceived += new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            
            _cardDTO = null;
            _rechargeDTO = null;

            EnableTransaction(false, true);
            txtMoney.Text = _moneyBuying.ToString(MONEY_FORMAT);
        }

        private void EnableTransaction(bool yes, bool choice)
        {
            if (choice)
                rbGas92.Enabled = rbGas95.Enabled = rbGasDO.Enabled = yes;
            btnBuy.Enabled = yes;
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
            String stResponse = service.SGMSaleGas_ValidateCardId(cardId);
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

                        txtCardID.Text = _cardDTO.CardID;
                        txtCardMoney.Text = _cardDTO.CardRemainingMoney.ToString(MONEY_FORMAT);
                        updateGasChoice(rbGas92.Checked ? gasTransactType.gas92 : rbGas95.Checked ? gasTransactType.gas95 : gasTransactType.gasDO);
                        if (_cardDTO.CardUnlockState == false)
                        {
                            MessageBox.Show(SGMText.GAS_CARD_LOCK, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _cardDTO = null;
                            _rechargeDTO = null;
                            EnableTransaction(false, true);
                        }
                    }
                    else
                    {
                        // >>>
                    }
                }
            }
            else
            {
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableTransaction(false, true);
            }
        }

        private void btnCardDetail_Click(object sender, EventArgs e)
        {
            ScanCard(_cardId);
        }

        private void CardReaderReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            String readData = sp.ReadExisting();
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
            string stResponse = service.SGMSaleGas_GasBuying(JSonHelper.ConvertObjectToJSon(df), "admin");
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                MessageBox.Show(dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _cardDTO.CardRemainingMoney = _cardDTO.CardRemainingMoney - _moneyBuying;
                txtCardMoney.Text = _cardDTO.CardRemainingMoney.ToString(MONEY_FORMAT);
                calculatePay();
            }
            else
            {
                MessageBox.Show(dataResponse.ResponseErrorMsg + "\n" + dataResponse.ResponseErrorMsgDetail, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            calculatePay();
        }
    }
}
