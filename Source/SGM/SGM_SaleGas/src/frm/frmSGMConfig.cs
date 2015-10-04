using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;
using System.Xml.XPath;
using SGM_Core.DTO;

namespace SGM_SaleGas
{
    public partial class frmSGMConfig : Form
    {
        private string m_stSettingFile = "\\SGMSetting.xml";
        private string m_stCurrentPortName = "";

        public frmSGMConfig()
        {
            InitializeComponent();
        }

        private void frmSGMConfig_Load(object sender, EventArgs e)
        {
            m_stSettingFile = Application.StartupPath + m_stSettingFile;
            loadConfig(m_stSettingFile);
            loadPortsName();
            if (!m_stCurrentPortName.Equals(""))
            {
                for (int i = 0; i < cboPorts.Items.Count; i++)
                {
                    if (cboPorts.Items[i].ToString().Equals(m_stCurrentPortName))
                    {
                        if (InitComPort())
                        {
                            //Close();
                        }
                        else
                        {
                            MessageBox.Show(SGMText.FRM_CONFIG_CANT_CONNECT_READER);                            
                        }
                    }
                }
                              
            }
            m_stCurrentPortName = cboPorts.Text;  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (InitComPort())
            {
                if (saveConfig(m_stSettingFile))
                    MessageBox.Show(SGMText.FRM_CONFIG_SAVE_CONFIG_SUCCESS);
                else
                    MessageBox.Show(SGMText.FRM_CONFIG_SAVE_CONFIG_ERR);
            }
            else
                MessageBox.Show(SGMText.FRM_CONFIG_CANT_CONNECT_READER);
        }

        private void loadPortsName()
        {
            string[] arrComPortNames = null;
            int index = -1;
            string stComPortName = null;

            //Com Ports
            arrComPortNames = SerialPort.GetPortNames();
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

        public bool saveConfig(string stFileName)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            bool flag;
            try
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stFileName, (Encoding)unicodeEncoding);
                xmlTextWriter.WriteRaw("<?xml version=\"1.0\"?>");
                xmlTextWriter.WriteComment("SGM - Version 1.0");
                ((XmlWriter)xmlTextWriter).WriteStartElement("Config");
                xmlTextWriter.WriteElementString("PortName", cboPorts.Text);                
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(SGMText.FRM_CONFIG_SAVE_CONFIG_ERR + "\n" + ex.Message + " : " + ex.StackTrace);
            }   
            flag = true;       
            return flag;
        }

        public bool loadConfig(string stFileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();            
            bool flag = false;
            try
            {
                xmlDocument.Load(stFileName);
                XPathNodeIterator xpathNodeIterator = xmlDocument.CreateNavigator().Select("Config");            
                if (xpathNodeIterator.MoveNext())
                {
                    xpathNodeIterator.Current.MoveToFirstAttribute();
                    do
                    {
                        xpathNodeIterator.Current.MoveToFirstChild();
                        do
                        {
                            string name = xpathNodeIterator.Current.Name;
                            if (name.Equals("PortName"))
                            {
                                m_stCurrentPortName = xpathNodeIterator.Current.Value;
                                flag = true;
                            }
                        }
                        while (xpathNodeIterator.Current.MoveToNext());
                    }
                    while (xpathNodeIterator.Current.MoveToNextAttribute());
                }   
            }
            catch (Exception )
            {
                //MessageBox.Show(SGMText.FRM_CONFIG_LOAD_CONFIG_ERR + "\n" + ex.Message + " : " + ex.StackTrace);
            }
            return flag;
        }

        public bool InitComPort()
        {
            try
            {
                Program.ReaderPort = new SerialPort(m_stCurrentPortName);

                Program.ReaderPort.BaudRate = 9600;
                Program.ReaderPort.Parity = Parity.None;
                Program.ReaderPort.StopBits = StopBits.One;
                Program.ReaderPort.DataBits = 8;
                Program.ReaderPort.Handshake = Handshake.None;
                Program.ReaderPort.RtsEnable = true;

                //Program.ReaderPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                Program.ReaderPort.Open();
            }
            catch (Exception )
            {
                return false;
            }
            return true;
        }
    }
}
