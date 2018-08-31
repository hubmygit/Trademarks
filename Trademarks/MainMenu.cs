using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;

namespace Trademarks
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            tsStatusLblUser.Text = "User: " + UserInfo.WindowsUser + " - " + UserInfo.FullName;
        }

        private void btnQuickInsert_Click(object sender, EventArgs e)
        {
            QuickInsert frmQuickIns = new QuickInsert();
            frmQuickIns.ShowDialog();

            while(frmQuickIns.GoToNext)
            {
                frmQuickIns.GoToNext = false;

                frmQuickIns = new QuickInsert();
                frmQuickIns.ShowDialog();
            }
        }

        private void btnQuickView_Click(object sender, EventArgs e)
        {
            QuickView frmQuickView = new QuickView();
            frmQuickView.ShowDialog();
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            AlertsView frmAlertsView = new AlertsView();
            frmAlertsView.ShowDialog();
        }

        private void btnEncryptConfig_Click(object sender, EventArgs e)
        {
            // Takes the executable file name without the .config extension.
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

                if (section.SectionInformation.IsProtected)
                {
                    MessageBox.Show("Config File Is Already Protected!");
                    //DialogResult dlg = MessageBox.Show("Config File Is Already Protected!\r\nDo you want to Dencrypt it?", "", MessageBoxButtons.YesNo);
                    //if (dlg == DialogResult.Yes)
                    //{
                    //    //Remove encryption.
                    //    section.SectionInformation.UnprotectSection();
                    //}
                }
                else
                {
                    DialogResult dlg = MessageBox.Show("Config File Is Not Protected!\r\nDo you want to Encrypt it?", "", MessageBoxButtons.YesNo);
                    if (dlg == DialogResult.Yes)
                    {
                        // Encrypt the section.
                        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }
                }

                MessageBox.Show("Protected: " + section.SectionInformation.IsProtected);

                // Save the current configuration.
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public static class AppVer
    {
        public static bool IsLatestVersion() //Compare app version with db version (2 digits only)
        {
            bool ret = true;
            string CurrentVersion = getCurrentAppVersion();
            string LatestVersion = getLatestAppVersionFromDB();

            string[] CurVer2Dig = CurrentVersion.Split('.');
            string[] LatVer2Dig = LatestVersion.Split('.');

            //if (CurrentVersion < LatestVersion)
            if ((CurVer2Dig[0] + "." + CurVer2Dig[1]) != (LatVer2Dig[0] + "." + LatVer2Dig[1]))
            {
                ret = false;
                MessageBox.Show("Your application version is older than the current version! \r\nIt is necessary to upgrade to continue.");
            }
            else if (CurrentVersion != LatestVersion)
            {
                MessageBox.Show("Your application version is older than the current version! \r\nPlease upgrade as soon as possible.");
            }

            return ret;
        }

        public static string getCurrentAppVersion()
        {
            //this is 'File Version' - for 'Assembly Version' use System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() 
            //int ret = 0;
            //string appVer = Application.ProductVersion.Replace(".", "");
            //bool succeeded = Int32.TryParse(appVer, out ret);

            string ret = Application.ProductVersion;

            return ret;
        }

        public static string getLatestAppVersionFromDB()
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT AppVersion FROM [dbo].[AppVersion] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["AppVersion"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
    }

    public static class SqlDBInfo
    {
        static SqlDBInfo()
        {
            //default values
            /*
            string server = "DELIGEEL\\SQLEXPRESS";
            string database = "Trademarks";
            string username = "sa";
            string password = "motoroil";
            connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;
            */
            connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }

        public static string connectionString { get; set; }
        //public static string passPhrase = "Use this passPhrase to decrypt!";
    }

}
