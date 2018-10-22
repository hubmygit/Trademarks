using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trademarks
{
    public partial class ComEdit : Form
    {
        public ComEdit() //ins
        {
            InitializeComponent();

            isInsert = true;
        }

        public ComEdit(Company givenCom) //upd
        {
            InitializeComponent();

            isInsert = false;

            OldRecord = givenCom;
            TempRecUpdId = givenCom.Id;

            txtComName.Text = givenCom.Name;
            txtComAddr.Text = givenCom.Headquarters;
        }
        
        public bool isInsert = false;
        public bool success = false;
        public Company OldRecord = new Company();
        public Company NewRecord = new Company();
        public int TempRecUpdId = 0;


        private bool InsertCompany(Company ComRec)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Company] ([Name], [Headquarters]) " + //, [InsUser], [InsDt]) " +
                "VALUES (@Name, @Headquarters) "; //, @InsUser, getdate() ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Name", ComRec.Name);
                cmd.Parameters.AddWithValue("@Headquarters", ComRec.Headquarters);
                //cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();

            return ret;
        }

        private bool UpdateCompany(Company ComRec)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string UpdSt = "UPDATE [dbo].[Company] SET [Name] = @Name, [Headquarters] = @Headquarters " +
                //"[UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", ComRec.Id);
                cmd.Parameters.AddWithValue("@Name", ComRec.Name);
                cmd.Parameters.AddWithValue("@Headquarters", ComRec.Headquarters);
                //cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtComName.Text.Trim() == "" || txtComAddr.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!");
                return;
            }

            NewRecord = new Company();

            NewRecord.Name = txtComName.Text;
            NewRecord.Headquarters = txtComAddr.Text;

            NewRecord.Id = TempRecUpdId;

            if (isInsert)
            {
                if (InsertCompany(NewRecord) == false)
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατα την καταχώρηση της εταιρίας!");
                }
                else
                {
                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    success = true;
                    Close();
                }
            }
            else
            {
                if (UpdateCompany(NewRecord) == false)
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατα την καταχώρηση της εταιρίας!");
                }
                else
                {
                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    success = true;
                    Close();
                }
            }


        }
    }
}
