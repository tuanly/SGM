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

namespace SGM_SaleGas
{
    public partial class frmSGMSaleGas : Form
    {
        private ServiceReference1.ServiceSoapClient service = new ServiceReference1.ServiceSoapClient();
        
        CardDTO _cardDTO;
        RechargeDTO _rechargeDTO;

        private enum gasTransactType
        {
            gas92,
            gas95,
            gasDO
        }

        private string MONEY_FORMAT = "#,##0";

        public frmSGMSaleGas()
        {
            InitializeComponent();
        }

        private void frmSGMSaleGas_Load(object sender, EventArgs e)
        {
            if (Program.ReaderPort != null)
                Program.ReaderPort.DataReceived += new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            
            _cardDTO = null;
            _rechargeDTO = null;

            EnableTransaction(false);
        }

        private void EnableTransaction(bool yes)
        {
            rbGas92.Enabled = rbGas95.Enabled = rbGasDO.Enabled = btnBuy.Enabled = yes;
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
            try
            {
                int money = Int32.Parse(txtMoney.Text, System.Globalization.NumberStyles.Currency);
                decimal price = rbGas92.Checked ? _rechargeDTO.RechargeGas92Price : rbGas95.Checked ? _rechargeDTO.RechargeGas95Price : _rechargeDTO.RechargeGasDOPrice;
                txtMoneyBuying.Text = txtMoney.Text;
                txtMoneyAfter.Text = (_cardDTO.CardRemainingMoney - money).ToString(MONEY_FORMAT);
                decimal galon = money / price;
                txtGasBuying.Text = Math.Round(galon,1).ToString();
            }
            catch (Exception ex)
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
            String stResponse = service.ValidateCardId(cardId);
            DataTransfer dataResponse = new DataTransfer(stResponse);
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                EnableTransaction(true);
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
                        if (_cardDTO.CardUnlockState == false)
                        {
                            MessageBox.Show(SGMText.GAS_CARD_LOCK, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _cardDTO = null;
                            _rechargeDTO = null;
                            EnableTransaction(false);
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
                MessageBox.Show("Lỗi : " + dataResponse.ResponseErrorMsg, "SGM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableTransaction(false);
            }
        }

        private void btnCardDetail_Click(object sender, EventArgs e)
        {
            ScanCard("card0001");
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

        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            calculatePay();
        }
    }
}
