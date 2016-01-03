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
using System.Threading.Tasks;

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
            serialDatahandler = new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
            RFIDReader.RegistryReaderListener(Program.ReaderPort, serialDatahandler);
        }

        private void frmSGMLogin_Load(object sender, EventArgs e)
        {
            SGM_WaitingIdicator.WaitingForm.waitingFrm.SetParentForm(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // validate user input
            if (ValidateLoginCode() == false)
                return;
            
            // request server
            string GASSTATION_ID = txtLoginCode.Text;
            string GASSTATION_MACADDRESS = GetMacAddress();
            Task<String> task = SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterTask(
            () => {
                return service.SGMSaleGas_ValidateGasStationLogin(GASSTATION_ID, GASSTATION_MACADDRESS);
            });
            SGM_WaitingIdicator.WaitingForm.waitingFrm.progressReporter.RegisterContinuation(task, () =>
            {
                String stResponse = task.Result as String;
                DataTransfer dataResponse = JSonHelper.ConvertJSonToObject(stResponse);
                if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
                {
                    this.Hide();
                    if (Program.ReaderPort != null)
                        Program.ReaderPort.DataReceived -= serialDatahandler;

                    new frmSGMSaleGas(dataResponse.ResponseDataSystemAdminDTO, dataResponse.ResponseDataGasStationDTO, dataResponse.ResponseCurrentPriceGas92, dataResponse.ResponseCurrentPriceGas95, dataResponse.ResponseCurrentPriceGasDO, dataResponse.ResponseGasStoreGas92Total, dataResponse.ResponseGasStoreGas95Total, dataResponse.ResponseGasStoreGasDOTotal).ShowDialog();
                    this.Close();
                }
                else
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, dataResponse.ResponseErrorMsg, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }, SynchronizationContext.Current);
        }

        private bool ValidateLoginCode()
        {
            bool check = true;
            if (string.IsNullOrEmpty(txtLoginCode.Text))
            {
                SGMHelper.ShowToolTip(txtLoginCode, SGMText.SALEGAS_LOGIN_INPUT_ERROR);
                check = false;
            }
            //else if (!Regex.IsMatch(txtLoginCode.Text, @"[A-Za-z][A-Za-z0-9]{2,7}"))
            //{
            //    SGMHelper.ShowToolTip(txtLoginCode, "Invalid format!");
            //}
            else
            {
                SGMHelper.ShowToolTip(txtLoginCode, "");
            }
            return check;
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
                String data = sp.ReadLine();
                if (data != null && data.Length > 1)
                    txtLoginCode.Invoke(new MethodInvoker(delegate { txtLoginCode.Text = data.Substring(0, data.Length - 1); }));
               // txtLoginCode.Invoke(new MethodInvoker(delegate { txtLoginCode.Text = sp.ReadLine(); }));
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
