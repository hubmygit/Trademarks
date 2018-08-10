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
            string SelectSt = "SELECT Id, TrademarksId, EventTypesId, ExpDate " +
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

                    ret.Add(newTask);
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }

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
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }

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

                string emailBody = "Trademark xxxxxxxxxx... \r\n" +
                                   thisTask.EventTypes.Name + ".\r\n" +
                                   "Ημερομηνία Ενέργειας: " + thisTask.ExpDate.ToString("dd.MM.yyyy HH:mm") + ".\r\n" +
                                   "\r\n" +
                                   "mailto:hkylidis@moh.gr?subject=Trademark_" + thisTask.TrademarksId.ToString() + "&body=Trademark%20Email%20Alert";

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
        
    }


    public class Task
    {
        public int Id { get; set; }
        public int TrademarksId { get; set; }
        public DateTime ExpDate { get; set; }
        public int EventTypesId { get; set; }
        public EventType EventTypes { get; set; }

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
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                Output.WriteToFile("The following error occurred: " + ex.Message, true);
            }
        }

    }


    public static class SqlDBInfo
    {
        static SqlDBInfo()
        {
            //default values
            string server = "DELIGEEL\\SQLEXPRESS";
            string database = "Trademarks";
            string username = "sa";
            string password = "motoroil";
            connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;
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
            UserName = "hkylidis";
            Password = "xxxxxxxxxxxxxxxx";
            Domain = "moh";
            EmailAddress = "hkylidis@moh.gr";
            SmtpClientHost = "wmath.moh.gr";
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


}
