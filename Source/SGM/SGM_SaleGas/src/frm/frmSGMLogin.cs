using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Resources;
using System.IO.Ports;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM_SaleGas
{
    public partial class frmSGMLogin : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        private frmSGMMessage frmMsg = null;
        private SerialDataReceivedEventHandler serialDatahandler = null;

        public frmSGMLogin()
        {
            InitializeComponent();
            frmMsg = new frmSGMMessage();
        }

        private void frmSGMLogin_Load(object sender, EventArgs e)
        {
            serialDatahandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serialDatahandler);
            
            errorProvider.SetIconAlignment(txtLoginCode, ErrorIconAlignment.TopRight);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // validate user input
            if (ValidateLoginCode() == false)
                return;
            
            // request server
            string GASSTATION_ID = txtLoginCode.Text;
            string GASSTATION_MACADDRESS = GetMacAddress();

            String stResponse = service.SGMSaleGas_ValidateGasStationLogin(GASSTATION_ID, GASSTATION_MACADDRESS);
            DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);     
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                this.Hide();
                if (Program.ReaderPort != null)
                    Program.ReaderPort.DataReceived -= serialDatahandler;
                new frmSGMSaleGas().ShowDialog();
                this.Close();
            }
            else
                frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
        }

        private bool ValidateLoginCode()
        {
            if (string.IsNullOrEmpty(txtLoginCode.Text))
            {
                errorProvider.SetError(txtLoginCode, SGMText.SALEGAS_LOGIN_INPUT_ERROR);
            }
            //else if (!Regex.IsMatch(txtLoginCode.Text, @"[A-Za-z][A-Za-z0-9]{2,7}"))
            //{
            //    errorProvider.SetError(txtLoginCode, "Invalid format!");
            //}
            else
            {
                errorProvider.SetError(txtLoginCode, null);
            }
            return string.IsNullOrEmpty(errorProvider.GetError(txtLoginCode));
        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        private void CardReaderReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;           
                
                txtLoginCode.Invoke(new MethodInvoker(delegate { txtLoginCode.Text = sp.ReadLine(); }));
            }
            catch (TimeoutException)
            {
            }
        
           

        }

        private void frmSGMLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            RFIDReader.UnRegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }
    }
}
