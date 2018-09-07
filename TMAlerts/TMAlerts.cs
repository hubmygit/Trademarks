using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;
using Microsoft.Exchange.WebServices.Data;

using System.Configuration;
using System.Security.Cryptography;

namespace TMAlerts
{
    public partial class TMAlerts : Form
    {
        public TMAlerts()
        {
            InitializeComponent();
        }

        private void TMAlerts_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "AUTO") > 0)
            {
                AutomaticProcedure();

                Application.Exit();
            }
        }

        private void AutomaticProcedure()
        {
            Output.WriteToFile("STARTING...");

            //bool isConfigProtected_AppSet = ConfigFunctions.IsEncrypted_AppConfig_AppSettings(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //Output.WriteToFile("Config AppSettings section Encrypted: " + isConfigProtected_AppSet.ToString());
            //bool isConfigProtected_ConnStr = ConfigFunctions.IsEncrypted_AppConfig_ConnStrings(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);            
            //Output.WriteToFile("Config ConnectionString section Encrypted: " + isConfigProtected_ConnStr.ToString());

            List<Task> taskToSend = Check_Tasks();

            Output.WriteToFile("Tasks to send: " + taskToSend.Count.ToString());

            if (taskToSend.Count > 0)
            {
                bool FullySuccessful = SendEmailAlertsPerTask(taskToSend);
            }

            Output.WriteToFile("COMPLETED...");
        }

        private void btnRunProcedure_Click(object sender, EventArgs e)
        {
            AutomaticProcedure();
        }

        //-----------------------------------------------

        public List<Task> Check_Tasks()
        {
            Output.WriteToFile("Check Tasks");
            List<Task> ret = new List<Task>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, TrademarksId, EventTypesId, ExpDate, AlertDescr " +
                              "FROM [dbo].[Tasks] " +
                              "WHERE IsActive = 'True' AND NotificationSent IS NULL AND getdate() > NotificationDate ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Task newTask = new Task();
                    newTask.Id = Convert.ToInt32(reader["Id"].ToString());
                    newTask.TrademarksId = Convert.ToInt32(reader["TrademarksId"].ToString());
                    newTask.ExpDate = Convert.ToDateTime(reader["ExpDate"].ToString());
                    newTask.EventTypesId = Convert.ToInt32(reader["EventTypesId"].ToString());
                    newTask.EventTypes = new EventType(newTask.EventTypesId);
                    newTask.AlertDescr = reader["AlertDescr"].ToString();

                    ret.Add(newTask);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }
            sqlConn.Close();

            return ret;
        }

        public List<Recipient> getTaskRecipients(int givenTrademarksId)
        {
            List<Recipient> ret = new List<Recipient>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TrademarksId], [FullName], [Email] " +
                              "FROM [dbo].[Recipients] " +
                              "WHERE IsActive = 'True' AND TrademarksId = " + givenTrademarksId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Recipient rec = new Recipient();
                    rec.Id = Convert.ToInt32(reader["Id"].ToString());
                    rec.TrademarksId = Convert.ToInt32(reader["TrademarksId"].ToString());
                    rec.FullName = reader["FullName"].ToString();
                    rec.Email = reader["Email"].ToString();

                    ret.Add(rec);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }
            sqlConn.Close();

            return ret;
        }

        public bool SendMail(List<Recipient> Recipients, string EmailBody)
        {
            bool ret = true;

            EmailParams emailParams = new EmailParams();
            ExchangeService service = new ExchangeService();

            try
            {
                service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            }
            catch (Exception ex)
            {
                ret = false;
                //MessageBox.Show("ERROR:" + ex.Message);
                Output.WriteToFile(ex.Message, true);
            }

            service.Credentials = new WebCredentials(emailParams.UserName, emailParams.Password, emailParams.Domain);
            service.AutodiscoverUrl(emailParams.EmailAddress);

            EmailMessage email = new EmailMessage(service);
            email.Importance = Importance.High;
            email.Subject = "Trademark Alert"; //"mySubjectText";
            email.Body = new MessageBody(BodyType.Text, EmailBody); //"myBodyText");
            //email.ToRecipients.Add("hkylidis@moh.gr");
            foreach (Recipient rec in Recipients)
            {
                email.ToRecipients.Add(rec.Email);
            }

            //mailto:example@email.com?subject=Email%20Subject&body=Email%20Body%20Text

            try
            {
                email.SendAndSaveCopy();
            }
            catch (Exception ex)
            {
                ret = false;
                //MessageBox.Show("Exception occured: " + ex.Message + " \r\n {0}", ex.ToString());
                Output.WriteToFile("Exception occurred: " + ex.Message + " \r\n " + ex.ToString(), true);
            }

            return ret;
        }

        private bool UpdateCompletedTask(int givenId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Tasks] SET [NotificationSent] = getDate(), IsActive = 'False' " +
                "WHERE id = @id";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@id", givenId);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }
            sqlConn.Close();

            return ret;
        }

        private bool SaveTaskReceivers(int givenTaskId, List<Recipient> recipients)
        {
            bool ret = true;

            foreach (Recipient rec in recipients)
            {
                if (SaveTaskReceivers(givenTaskId, rec.FullName, rec.Email) == false)
                {
                    ret = false;
                }
            }

            return ret;
        }

        private bool SaveTaskReceivers(int givenTaskId, string FullName, string Email)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TaskReceivers] (TasksId, FullName, Email) VALUES (@TasksId, @FullName, @Email) ";
            try
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TasksId", givenTaskId);
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Email", Email);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }
            sqlConn.Close();

            return ret;
        }

        public bool SendEmailAlertsPerTask(List<Task> tasks)
        {
            Output.WriteToFile("Send Email Alerts Per Task");
            bool ret = true;

            foreach (Task thisTask in tasks)
            {
                List<Recipient> recipients = getTaskRecipients(thisTask.TrademarksId);

                if (recipients.Count <= 0)
                {
                    Output.WriteToFile("No recipients found!", true);
                    ret = false;
                    continue;
                }

                //get other data from trademark ... getOtherUsefulTrademarkData(thisTask.TrademarksId);
                TempRecords tmpRec = new TempRecords(thisTask.TrademarksId);

                string emailBody = "Trademark " + tmpRec.TMNo + ": " + tmpRec.TMName + "\r\n" +
                                   thisTask.EventTypes.Name + ".\r\n" +
                                   "Καταληκτική Ημερομηνία: " + thisTask.ExpDate.ToString("dd.MM.yyyy HH:mm") + " [" + thisTask.AlertDescr + "]";//".\r\n" +
                                   //"\r\n" +
                                   //"mailto:hkylidis@moh.gr?subject=Trademark_" + thisTask.TrademarksId.ToString() + "&body=Trademark%20Email%20Alert";

                //This message has been generated by the Trademark Alert Server. Do not reply.

                Output.WriteToFile("Email for TaskId: " + thisTask.Id);
                if (SendMail(recipients, emailBody) == true)
                {
                    Output.WriteToFile("Update Flags for TaskId: " + thisTask.Id);
                    if (UpdateCompletedTask(thisTask.Id) == true)
                    {
                        Output.WriteToFile("Save Task Receivers for TaskId: " + thisTask.Id);
                        if (SaveTaskReceivers(thisTask.Id, recipients) == false)
                        {
                            ret = false;
                        }
                    }
                    else
                    {
                        ret = false;
                    }
                }
                else
                {
                    ret = false;
                }
            }

            return ret;
        }

        private void btnEncryptConfig_Click(object sender, EventArgs e)
        {
            // EncryptAppConfig_ConnStrings();
            // EncryptAppConfig_AppSettings();

            // ConfigFunctions.EncryptAppConfig_ConnStrings(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            // ConfigFunctions.EncryptAppConfig_AppSettings(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        }

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

                MessageBox.Show(sectionName  + ": Protected -> " + section.SectionInformation.IsProtected);

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
        void EncryptAppConfig_AppSettings() //"appSettings"
        {
            string sectionName = "appSettings";
            // Takes the executable file name without the .config extension.
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                AppSettingsSection section = config.GetSection("appSettings") as AppSettingsSection;
                //ConnectionStringsSection section = config.GetSection(sectionName) as ConnectionStringsSection;
                
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

    }


    public class Task
    {
        public int Id { get; set; }
        public int TrademarksId { get; set; }
        public DateTime ExpDate { get; set; }
        public int EventTypesId { get; set; }
        public EventType EventTypes { get; set; }
        public string AlertDescr { get; set; }

        public Task()
        { }

    }

    public class Recipient
    {
        public int Id { get; set; }
        public int TrademarksId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public Recipient()
        { }


    }

    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EventType()
        { }
        public EventType(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name] " +
                              "FROM [dbo].[EventTypes] " +
                              "WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    Name = reader["Name"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }
            sqlConn.Close();

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
        //public static string passPhrase = "";
    }


    public class EmailParams
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string EmailAddress { get; set; }
        public string SmtpClientHost { get; set; }

        public EmailParams()
        {
            //decryption
            UserName = myCryptographyFunctions.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_UserName"]);
            Password = myCryptographyFunctions.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_Password"]);
            Domain = myCryptographyFunctions.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_Domain"]);
            EmailAddress = myCryptographyFunctions.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_Address"]);
            SmtpClientHost = myCryptographyFunctions.DecryptStringFromHex_Aes(ConfigurationManager.AppSettings["Mailbox_SmtpClientHost"]);
        }
    }

    public static class Output
    {
        public static void WriteToFile(string text, bool error = false)
        {
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Logs\\Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true))
            {
                if (text.IndexOf("STARTING...") >= 0)
                {
                    sw.WriteLine("");
                }

                if (error)
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd_HHmmss") + " ERROR! " + text);
                }
                else
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd_HHmmss") + " " + text);
                }

            }
        }
    }

    public class TempRecords
    {
        public int Id { get; set; }
        public string TMNo { get; set; }
        public DateTime DepositDt { get; set; }
        public int NationalPowerId { get; set; } //class ???
        public string TMGrNo { get; set; }
        public int CompanyId { get; set; }
        public int ResponsibleLawyerId { get; set; }
        //public List<int> TMTypeIds { get; set; } //?? other table??
        public string TMName { get; set; }

        public string FileName { get; set; }
        public byte[] FileContents { get; set; }

        //public List<int> ClassIds { get; set; } //?? other table??
        public string Description { get; set; }
        public string Fees { get; set; } //paravola
        public string DecisionNo { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime FinalizationDate { get; set; }
        public string Url { get; set; }

        public bool HasRenewal { get; set; }
        public DateTime RenewalDt { get; set; }

        public TempRecords()
        {
        }

        public TempRecords(int Id)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], [RenewalDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], [FileContents], " +
                              "[FileName], [Description], [Fees], [DecisionNo], [PublicationDate], [FinalizationDate], [Url] " +
                              "FROM [dbo].[TempRecords] " +
                              "WHERE Id = @Id ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            cmd.Parameters.AddWithValue("@Id", Id);

            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dtRenewal = new DateTime();
                    bool HasRenewalDt = false;
                    if (reader["RenewalDt"] != DBNull.Value)
                    {
                        HasRenewalDt = true;
                        dtRenewal = Convert.ToDateTime(reader["RenewalDt"].ToString());
                    }

                    Id = Convert.ToInt32(reader["Id"].ToString());
                    TMNo = reader["TMNo"].ToString();
                    TMName = reader["TMName"].ToString();
                    DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    HasRenewal = HasRenewalDt;
                    if (HasRenewalDt)
                    {
                        RenewalDt = dtRenewal;
                    }
                    NationalPowerId = Convert.ToInt32(reader["NationalPowerId"].ToString());
                    TMGrNo = reader["TMGrNo"].ToString();
                    CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());
                    if (reader["FileContents"] != DBNull.Value)
                    {
                        FileContents = (byte[])reader["FileContents"];
                    }

                    FileName = reader["FileName"].ToString();
                    Description = reader["Description"].ToString();
                    Fees = reader["Fees"].ToString();
                    DecisionNo = reader["DecisionNo"].ToString();
                    PublicationDate = Convert.ToDateTime(reader["PublicationDate"].ToString());
                    FinalizationDate = Convert.ToDateTime(reader["FinalizationDate"].ToString());
                    Url = reader["Url"].ToString();

                    //TMTypeIds = Type.getTM_TypesList(Convert.ToInt32(reader["Id"].ToString()));
                    //ClassIds = Class.getTM_ClassList(Convert.ToInt32(reader["Id"].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();

        }
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
