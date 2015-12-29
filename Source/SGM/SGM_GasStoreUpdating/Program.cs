using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace SGM_GasStoreUpdating
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSGMLogin());
        }
        public static SerialPort ReaderPort;
    }
}
