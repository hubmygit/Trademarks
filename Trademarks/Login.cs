using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trademarks
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
    }

    public static class UserInfo
    {
        static UserInfo()
        {            
            WindowsUser = "unknown";
            EmailAddress = "";
            FullName = "Unknown";

            DB_AppUser_Id = 0;

            //IsAuthorized = false;

            IsAdmin = false;


            try
            {
                WindowsUser = Environment.UserName; //get windows/domain logged in username

                EmailAddress = UserPrincipal.Current.EmailAddress;
                if (EmailAddress == null) //if domain infos not found
                {
                    EmailAddress = "";
                }

                FullName = UserPrincipal.Current.DisplayName;
                if (FullName == null) //if domain infos not found
                {
                    FullName = "Unknown";
                }
                DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);

                if (DB_AppUser_Id != 0) //found
                {
                    IsAdmin = Get_Admin_Rights(Environment.UserName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        public static string EmailAddress { get; set; } //only for init
        public static string WindowsUser { get; set; } //only for init
        //public static bool IsAuthorized { get; set; }
        public static string FullName { get; set; }
        public static string MachineName { get { return Environment.MachineName; } set { } }
        public static int DB_AppUser_Id { get; set; }
        public static bool IsAdmin { get; set; }
        public static void UserLogIn()
        {
            
            //select
            if (DB_AppUser_Id != 0) //found
            {
                //update record with last infos
                Update_AppUser();
            }
            else //not found
            {
                //insert new record infos
                Insert_AppUser();

                //select new id
                DB_AppUser_Id = Get_DB_AppUser_Id(Environment.UserName);
            }
            
            Insert_AppLogIn();

        }

        private static void Update_AppUser()
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string UpdSt = "UPDATE [dbo].[AppUsers] SET FullName = @fullName, EmailAddress = @emailAddr, LastEntrance = getdate() WHERE Id = @id ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                cmd.Parameters.AddWithValue("@id", DB_AppUser_Id);
                cmd.Parameters.AddWithValue("@fullName", FullName);
                cmd.Parameters.AddWithValue("@emailAddr", EmailAddress);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }

        private static void Insert_AppUser()
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[AppUsers] (WinUser, FullName, EmailAddress, LastEntrance, IsAdmin) VALUES (@winUser, @fullName, @emailAddr, getdate(), 'False') ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@winUser", WindowsUser);
                cmd.Parameters.AddWithValue("@fullName", FullName);
                cmd.Parameters.AddWithValue("@emailAddr", EmailAddress);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }

        private static int Get_DB_AppUser_Id(string UserName)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[AppUsers] WHERE WinUser = '" + UserName + "'";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
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

        private static bool Get_Admin_Rights(string UserName)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT IsAdmin FROM [dbo].[AppUsers] WHERE WinUser = '" + UserName + "'";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToBoolean(reader["IsAdmin"].ToString());
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

        public static int Get_DB_AppUser_ResponsibleId(int givenId)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT ResponsibleId FROM [dbo].[AppUsers] WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@Id", givenId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ResponsibleId"].ToString().Trim() != "")
                    {
                        ret = Convert.ToInt32(reader["ResponsibleId"].ToString());
                    }
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

        private static void Insert_AppLogIn()
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[AppLogIn] (AppUserId, InsDate) VALUES (@appUserId, getdate()) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@appUserId", DB_AppUser_Id);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }

    }

}
