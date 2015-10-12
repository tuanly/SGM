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

namespace SGM_Management
{
    public partial class frmSGMRechargeCard : Form
    {
        private bool m_bStateUpdate;
        private string m_stCusID;
        private string m_stCardID;
        private CardDTO m_cardDTO;
        private int m_iPriceGas95;
        private int m_iPriceGas92;
        private int m_iPriceGasDO;

        private SGM_Service.ServiceSoapClient m_service;

        public frmSGMRechargeCard()
        {
            InitializeComponent();
            m_bStateUpdate = false;
            m_stCusID = "";
            m_stCardID = "";
            m_cardDTO = null;
            m_iPriceGas95 = 0;
            m_iPriceGas92 = 0;
            m_iPriceGasDO = 0;
            m_service = new SGM_Service.ServiceSoapClient();
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
        public bool StateUpdate
        {
            get { return m_bStateUpdate; }
            set { m_bStateUpdate = value; }
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
                int a = 0;
            }
        }

        private void frmSGMRechargeCard_Load(object sender, EventArgs e)
        {
            if (m_bStateUpdate)
            {
                ResetInput();
                txtCardID.Focus();
            }
            else
            {
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
            else if (!m_bStateUpdate)
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
                    MessageBox.Show(SGMText.CARD_GET_CARD_ERR + "\n" + response.ResponseErrorMsg + ":\n" + response.ResponseErrorMsgDetail);
                    bValidate = false;
                }
            }
            if (txtCardMoney.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtCardMoney, SGMText.CARD_DATA_INPUT_CARD_MONEY_ERR);
                bValidate = false;
            }
            if (txtRechargeMoney.Text.Trim().Equals(""))
            {
                errProvider.SetError(txtRechargeMoney, SGMText.CARD_DATA_INPUT_CARD_PRICE_ERR);
                bValidate = false;
            }
            if (Int32.Parse(txtCardMoney.Text.Trim()) < Int32.Parse(txtRechargeMoney.Text.Trim()))
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
                    MessageBox.Show(SGMText.SYS_ADMIN_GET_PRICE_ERR + "\n" + dataResult.ResponseErrorMsg + ":" + dataResult.ResponseErrorMsgDetail);
                }

                txtRechargeGasPrice.Text = SGMText.GAS_92_TEXT + " : " + m_iPriceGas92 + "đ - " + SGMText.GAS_95_TEXT + " : " + m_iPriceGas95 + "đ - " + SGMText.GAS_DO_TEXT + " : " + m_iPriceGasDO + "đ";
        }

    }
}
