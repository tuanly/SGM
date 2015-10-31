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
using SGM_WaitingIdicator;
using System.Threading;

namespace SGM_SaleGas
{
    public partial class frmSGMLogin : Form
    {
        private SGM_Service.ServiceSoapClient service = new SGM_Service.ServiceSoapClient();
        private frmSGMMessage frmMsg = null;
        private SerialDataReceivedEventHandler serialDatahandler = null;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private WaitingForm waitingFrm;

        public frmSGMLogin()
        {
            InitializeComponent();
            frmMsg = new frmSGMMessage();
            serialDatahandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serialDatahandler);
            waitingFrm = new WaitingForm(this);
        }

        private void frmSGMLogin_Load(object sender, EventArgs e)
        {
            errorProvider.SetIconAlignment(txtLoginCode, ErrorIconAlignment.TopRight);

            _bw.DoWork += Login;
            _bw.RunWorkerCompleted += LoginCompleted;
        }

        private void LoginCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waitingFrm.HideMe();
            String stResponse = e.Result as String;
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

        private void Login(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            List<string> list = doWorkEventArgs.Argument as List<string>;
            String gasid = list[0];
            String gasmac = list[1];
            doWorkEventArgs.Result = service.SGMSaleGas_ValidateGasStationLogin(gasid, gasmac);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // validate user input
            if (ValidateLoginCode() == false)
                return;
            
            // request server
            string GASSTATION_ID = txtLoginCode.Text;
            string GASSTATION_MACADDRESS = GetMacAddress();
            List<string> args = new List<string>();
            args.Add(GASSTATION_ID);
            args.Add(GASSTATION_MACADDRESS);
            
            waitingFrm.ShowMe();
            _bw.RunWorkerAsync(args);
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
