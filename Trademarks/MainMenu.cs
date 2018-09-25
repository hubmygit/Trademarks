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

using System.Security.Cryptography;

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

        /*
        void EncryptAppConfig(string sectionName) //"connectionStrings"
        {
            // Takes the executable file name without the .config extension.
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                //ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
                ConnectionStringsSection section = config.GetSection(sectionName) as ConnectionStringsSection;

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
        */

        /*
        void EncryptAppConfig_ConnStrings() //"connectionStrings"
        {
            string sectionName = "connectionStrings";
            // Takes the executable file name without the .config extension.
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
                //ConnectionStringsSection section = config.GetSection(sectionName) as ConnectionStringsSection;

                //AppSettingsSection section = config.GetSection("appSettings") as AppSettingsSection;

                if (section.SectionInformation.IsProtected)
                {
                    MessageBox.Show(sectionName + ": Config File Is Already Protected!");
                    //DialogResult dlg = MessageBox.Show("Config File Is Already Protected!\r\nDo you want to Dencrypt it?", "", MessageBoxButtons.YesNo);
                    //if (dlg == DialogResult.Yes)
                    //{
                    //    //Remove encryption.
                    //    section.SectionInformation.UnprotectSection();
                    //}
                }
                else
                {
                    DialogResult dlg = MessageBox.Show(sectionName + ": Config File Is Not Protected!\r\nDo you want to Encrypt it?", "", MessageBoxButtons.YesNo);
                    if (dlg == DialogResult.Yes)
                    {
                        // Encrypt the section.
                        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }
                }

                MessageBox.Show(sectionName + ": Protected -> " + section.SectionInformation.IsProtected);

                // Save the current configuration.
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */

        private void tsmiTM_ins_Click(object sender, EventArgs e)
        {
            QuickInsert frmQuickIns = new QuickInsert();
            frmQuickIns.ShowDialog();

            while (frmQuickIns.GoToNext)
            {
                frmQuickIns.GoToNext = false;

                frmQuickIns = new QuickInsert();
                frmQuickIns.ShowDialog();
            }
        }

        private void tsmiTM_View_Click(object sender, EventArgs e)
        {
            QuickView frmQuickView = new QuickView();
            frmQuickView.ShowDialog();
        }

        private void tsmiAlerts_View_Click(object sender, EventArgs e)
        {
            AlertsView frmAlertsView = new AlertsView();
            frmAlertsView.ShowDialog();
        }

        private void tsmiAdmin_Encrypt_Click(object sender, EventArgs e)
        {
            //EncryptAppConfig("connectionStrings");
            //EncryptAppConfig_ConnStrings();
        }

        private void tsmiAlerts_ViewGrouped_Click(object sender, EventArgs e)
        {
            AlertsViewGrouped frmAlertsViewGrouped = new AlertsViewGrouped();
            frmAlertsViewGrouped.ShowDialog();
        }

        private void btnAlertsGrouped_Click(object sender, EventArgs e)
        {
            AlertsViewGrouped frmAlertsViewGrouped = new AlertsViewGrouped();
            frmAlertsViewGrouped.ShowDialog();
        }

        private void insertTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertTM frmInsTm = new InsertTM();
            frmInsTm.ShowDialog();
        }

        private void decisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trademark tm = new Trademark() { Id = 9, TMNo = "777", TMName = "test", DepositDt = new DateTime(2018, 09, 19, 16, 3, 15), ResponsibleLawyerId = 2 };

            Decision frmDecision = new Decision(tm);
            frmDecision.ShowDialog();
        }

        private void appealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trademark tm = new Trademark() { Id = 9, TMNo = "777", TMName = "test", DepositDt = new DateTime(2018, 09, 19, 16, 3, 15) };

            TM_Status tms = new TM_Status();
            tms = TM_Status.getLastStatus(tm.Id);

            //check oti exei aporriptiki apofasi
            if (tms.StatusId != 3 && tms.StatusId != 4)
            {
                MessageBox.Show("Προσοχή! Δεν υπάρχει Aπορριπτική Aπόφαση σε εκκρεμότητα.\r\nΠαρακαλώ καταχωρήστε πρώτα την απόφαση.");
                return;
            }

            Appeal frmAppeal = new Appeal(tm, tms);
            frmAppeal.ShowDialog();
        }

        private void terminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trademark tm = new Trademark() { Id = 9, TMNo = "777", TMName = "test", DepositDt = new DateTime(2018, 09, 19, 16, 3, 15) };

            TM_Status tms = new TM_Status();
            tms = TM_Status.getLastStatus(tm.Id);

            //check oti exei apofasi
            if (tms.StatusId != 2 && tms.StatusId != 3 && tms.StatusId != 4) 
            {
                MessageBox.Show("Προσοχή! Δεν υπάρχει Aπόφαση για Ανακοπή.\r\nΠαρακαλώ καταχωρήστε πρώτα την απόφαση.");
                return;
            }

            Termination frmTermination = new Termination(tm, tms);
            frmTermination.ShowDialog();
        }

        private void finalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trademark tm = new Trademark() { Id = 9, TMNo = "777", TMName = "test", DepositDt = new DateTime(2018, 09, 19, 16, 3, 15), ResponsibleLawyerId = 2 };

            TM_Status tms = new TM_Status();
            tms = TM_Status.getLastStatus(tm.Id);

            //check oti exei apofasi
            if (tms.StatusId != 2 && tms.StatusId != 3 && tms.StatusId != 4)
            {
                MessageBox.Show("Προσοχή! Δεν υπάρχει Aπόφαση για Οριστικοποίηση.\r\nΠαρακαλώ καταχωρήστε πρώτα την απόφαση.");
                return;
            }

            Finalization frmFinalization = new Finalization(tm, tms);
            frmFinalization.ShowDialog();
        }

        private void renewalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trademark tm = new Trademark() { Id = 9, TMNo = "777", TMName = "test", DepositDt = new DateTime(2018, 09, 19, 16, 3, 15), ResponsibleLawyerId = 2 };

            TM_Status tms = new TM_Status();
            tms = TM_Status.getLastStatus(tm.Id);

            //check oti exei oristikopoiisi
            if (tms.StatusId != 7)
            {
                MessageBox.Show("Προσοχή! Δεν μπορεί να γίνει Ανανέωση.\r\nΠαρακαλώ καταχωρήστε πρώτα την οριστικοποίηση.");
                return;
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

            if (CurrentVersion == "" || LatestVersion == "")
            {
                return false;
            }

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
            sqlConn.Close();

            return ret;
        }
    }

    public static class SqlDBInfo
    {
        static SqlDBInfo()
        {
            //default values
            //connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            //read it from app.config
            string str = System.Configuration.ConfigurationManager.AppSettings["connStr"];

            //decrypt it 
            connectionString = myCryptographyFunctions.DecryptStringFromHex_Aes(str);
        }

        public static string connectionString { get; set; }
        //public static string passPhrase = "Use this passPhrase to decrypt!";
    }

    public class myCryptographyFunctions
    {
        public static byte[] EncryptStringToBytes_Aes(string plainText)
        {
            byte[] Key = System.Text.Encoding.Unicode.GetBytes("myKeymyKeymyKey!");
            byte[] IV = System.Text.Encoding.Unicode.GetBytes("myIVmyIV");

            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static string DecryptStringFromHex_Aes(string cipherText)
        {
            //string to byte[]
            byte[] encrypted = StringToByteArray(cipherText);

            //decrypt it 
            return DecryptStringFromBytes_Aes(encrypted);
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText)
        {
            byte[] Key = System.Text.Encoding.Unicode.GetBytes("myKeymyKeymyKey!");
            byte[] IV = System.Text.Encoding.Unicode.GetBytes("myIVmyIV");

            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

    }
}
