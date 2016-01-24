using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.XtraBars.Docking2010.Customization;

namespace SGM_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Mvvm.CommandBase.DefaultUseCommandManager = false;

            SkinManager.EnableFormSkins();

            ((DevExpress.LookAndFeel.Design.UserLookAndFeelDefault)DevExpress.LookAndFeel.Design.UserLookAndFeelDefault.Default).LoadSettings(() =>
            {
                SkinCreator skinCreator = new SkinBlobXmlCreator("HybridApp",
                    "SGM_Management.SkinData.", typeof(Program).Assembly, null);
                SkinManager.Default.RegisterSkin(skinCreator);
            });
            AsyncAdornerBootStrapper.RegisterLookAndFeel(
                "MetroBlack", "DevExpress.RealtorWorld.Win.SkinData.", typeof(Program).Assembly);

            UserLookAndFeel.Default.SetSkinStyle("HybridApp");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        public static SerialPort ReaderPort;
    }
}
