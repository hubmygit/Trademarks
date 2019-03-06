using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Trademarks
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

            //bool test = System.DirectoryServices.AccountManagement.UserPrincipal.Current.IsAccountLockedOut();
            //System.DirectoryServices.AccountManagement.UserPrincipal.Current.Context.ConnectedServer

            Intro frmIntro = new Intro();
            frmIntro.Show();

            //frmIntro.setLoginLabel("Checking Configuration File...");

            //if (EncryptAppConfig.ConfigFunctions.IsEncrypted_AppConfig_ConnStrings(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) == false)
            //{
            //    MessageBox.Show("Configuration File Error!\r\n[" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + ".config]");
            //    return;
            //}
            
            frmIntro.setLoginLabel("Checking Application Version...");

            if (!AppVer.IsLatestVersion()) //check version
                return;

            frmIntro.setLoginLabel("Connecting to Domain Controller to get User Info...");
            
            UserInfo.UserLogIn();
            
            frmIntro.setLoginLabel("Starting...");
            
            //add forgotten attachments
            //byte[] attFileBytes = System.IO.File.ReadAllBytes(@"C:\TrademarkApps\Trademarks\246883 - ΕΞ 1627.30.03.2018.pdf");
            //(new SampleFiles()).InertIntoTable_SampleFiles(29, "246883 - ΕΞ 1627.30.03.2018.pdf", attFileBytes);

            frmIntro.closeForm();

            Application.Run(new MainMenu());
        }


    }
}
