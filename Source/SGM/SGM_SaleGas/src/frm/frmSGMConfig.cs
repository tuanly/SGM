using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;
using System.Xml.XPath;
using SGM_Core.DTO;
using SGM_Core.Utils;

namespace SGM_SaleGas
{
    public partial class frmSGMConfig : Form
    {
        private static string m_stSettingFile = "\\SGMSetting.xml";
        private string m_stCurrentPortName = "";
        private frmSGMMessage frmMsg = null;

        public frmSGMConfig()
        {
            InitializeComponent();
            frmMsg = new frmSGMMessage();
        }

        private void frmSGMConfig_Load(object sender, EventArgs e)
        {
            if (SGMConfig.Flag_DisableReader)
            {
                openLoginFrm();
            }
            m_stSettingFile = Application.StartupPath + m_stSettingFile;
            m_stCurrentPortName = RFIDReader.LoadConfig(m_stSettingFile);
            loadPortsName();
            if (!m_stCurrentPortName.Equals(""))
            {
                for (int i = 0; i < cboPorts.Items.Count; i++)
                {
                    if (cboPorts.Items[i].ToString().Equals(m_stCurrentPortName))
                    {
                        if (InitComPort())
                        {
                            openLoginFrm();
                        }
                        else
                        {
                            frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.FRM_CONFIG_CANT_CONNECT_READER, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
                        }
                    }
                }
                              
            }
            m_stCurrentPortName = cboPorts.Text;  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_stCurrentPortName = cboPorts.Text;
            if (InitComPort())
            {
                if (RFIDReader.SaveConfig(m_stSettingFile, cboPorts.Text))
                {
                    frmMsg.ShowMsg(SGMText.SGM_INFO, SGMText.FRM_CONFIG_SAVE_CONFIG_SUCCESS, SGMMessageType.SGM_MESSAGE_TYPE_INFO);
                    this.Hide();
                    new frmSGMLogin().ShowDialog();
                    this.Close();
                }
                else
                    frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.FRM_CONFIG_SAVE_CONFIG_ERR, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);
            }
            else
                frmMsg.ShowMsg(SGMText.SGM_ERROR, SGMText.FRM_CONFIG_CANT_CONNECT_READER, SGMMessageType.SGM_MESSAGE_TYPE_ERROR);

        }

        private void loadPortsName()
        {
            cboPorts.Items.Clear();
            string[] arrComPortNames = null;
            int index = -1;
            string stComPortName = null;

            //Com Ports
            arrComPortNames = RFIDReader.GetPortsName();
            if (arrComPortNames.Length > 0)
            {
                do
                {
                    index += 1;
                    cboPorts.Items.Add(arrComPortNames[index]);
                }
                while (!((arrComPortNames[index] == stComPortName) || (index == arrComPortNames.GetUpperBound(0))));
                Array.Sort(arrComPortNames);

                if (index == arrComPortNames.GetUpperBound(0))
                {
                    stComPortName = arrComPortNames[0];
                }
                //get first item print in text
                
                cboPorts.Text = arrComPortNames[0];
              
            }
            
        }

        

        public bool InitComPort()
        {
            Program.ReaderPort = RFIDReader.InitComPort(m_stCurrentPortName);
            return (Program.ReaderPort != null);
        }

        private void openLoginFrm()
        {
            this.Hide();
            new frmSGMLogin().ShowDialog();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadPortsName();
        }
    }
}
