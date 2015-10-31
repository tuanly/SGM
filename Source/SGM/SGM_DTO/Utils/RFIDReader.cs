using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace SGM_Core.Utils
{
    public class RFIDReader
    {
        public static SerialPort InitComPort(String portName)
        {
            SerialPort port = null;
            try
            {
                port = new SerialPort(portName);

                port.BaudRate = 9600;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.DataBits = 8;
                port.Handshake = Handshake.None;
                port.RtsEnable = true;

                //Program.ReaderPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                port.Open();
            }
            catch (Exception)
            {
                port = null;
            }
            return port;
        }
        public static bool SaveConfig(string stFileName, string value)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            bool flag = false;
            try
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stFileName, (Encoding)unicodeEncoding);
                xmlTextWriter.WriteRaw("<?xml version=\"1.0\"?>");
                xmlTextWriter.WriteComment("SGM - Version 1.0");
                ((XmlWriter)xmlTextWriter).WriteStartElement("Config");
                xmlTextWriter.WriteElementString("PortName", value);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.Close();
            }
            catch (Exception)
            {
                
            }
            flag = true;
            return flag;
        }

        public static String LoadConfig(string stFileName)
        {
            string portName = "";
            XmlDocument xmlDocument = new XmlDocument();
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();            ;
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
                                portName = xpathNodeIterator.Current.Value;                               
                            }
                        }
                        while (xpathNodeIterator.Current.MoveToNext());
                    }
                    while (xpathNodeIterator.Current.MoveToNextAttribute());
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(SGMText.FRM_CONFIG_LOAD_CONFIG_ERR + "\n" + ex.Message + " : " + ex.StackTrace);
            }
            return portName;
        }

        public static string[] GetPortsName()
        {
            return SerialPort.GetPortNames();
        }

        public static void RegistryReaderListener(SerialPort port, SerialDataReceivedEventHandler listener)
        {
            if (port != null && listener != null)
                port.DataReceived += listener;
        }

        public static void UnRegistryReaderListener(SerialPort port, SerialDataReceivedEventHandler listener)
        {
            if (port != null && listener != null)
                port.DataReceived -= listener;
        }
    }
    
}
