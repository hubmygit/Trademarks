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

            if (!AppVer.IsLatestVersion()) //check version
                return;

            UserInfo.UserLogIn();
            
            Application.Run(new MainMenu());
        }
    }
}
