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

            Intro frmIntro = new Intro();
            frmIntro.Show();

            frmIntro.setLoginLabel("Checking Application Version...");

            if (!AppVer.IsLatestVersion()) //check version
                return;

            frmIntro.setLoginLabel("Connecting to Domain Controller to get User Info...");
            
            UserInfo.UserLogIn();

            frmIntro.setLoginLabel("Checking Configuration File...");
            if (EncryptAppConfig.ConfigFunctions.IsEncrypted_AppConfig_ConnStrings(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) == false)
            {
                MessageBox.Show("Configuration File Error!");
                return;
            }

            frmIntro.setLoginLabel("Starting...");

            frmIntro.closeForm();

            Application.Run(new MainMenu());
        }
    }
}
