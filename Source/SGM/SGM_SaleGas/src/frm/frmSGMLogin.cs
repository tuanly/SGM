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

namespace SGM_SaleGas
{
    public partial class frmSGMLogin : Form
    {
        private ServiceReference1.ServiceSoapClient service = new ServiceReference1.ServiceSoapClient();

        public frmSGMLogin()
        {
            InitializeComponent();
        }

        private void frmSGMLogin_Load(object sender, EventArgs e)
        {
            if (Program.ReaderPort != null)
                Program.ReaderPort.DataReceived += new SerialDataReceivedEventHandler(CardReaderReceivedHandler);
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

            String stResponse = service.ValidateGasStationLogin(GASSTATION_ID, GASSTATION_MACADDRESS);
            DataTransfer dataResponse = new DataTransfer(stResponse);          
            if (dataResponse.ResponseCode == DataTransfer.RESPONSE_CODE_SUCCESS)
            {
                this.Hide();
                new frmSGMSaleGas().ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show(dataResponse.ResponseErrorMsg);
        }

        private bool ValidateLoginCode()
        {
            if (string.IsNullOrEmpty(txtLoginCode.Text))
            {
                errorProvider.SetError(txtLoginCode, "Mã cây xăng ?");
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
            SerialPort sp = (SerialPort)sender;           
            txtLoginCode.Text = sp.ReadExisting();
        }
    }
}
