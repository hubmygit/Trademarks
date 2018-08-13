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
    public partial class QuickInsert : Form
    {
        public QuickInsert()
        {
            InitializeComponent();

            txtTMId.Text = "246883";
            dtpDepositDt.Value = new DateTime(2017, 12, 21);
            dtpDepositTime.Value = new DateTime(1900, 1, 1, 12, 33, 0);
            txtCompany.Text = "PEAK CHARM HOLDINGS LIMITED";
            txtLawyerFullname.Text = "ΤΖΑΝΕΡΡΙΚΟΥ ΙΩΑΝΝΑ";
            chlbTMType.SetItemChecked(0, true);
            chlbTMType.SetItemChecked(1, true);
            chlbTMType.SetItemChecked(5, true);
            txtTMName.Text = "XIOSBANK";
            txtDecisionNo.Text = "ΕΞ 1627 /30-03-2018";
            dtpPublicationDate.Value = new DateTime(2018, 3, 30);
            dtpFinalization.Value = new DateTime(2018, 6, 30);
            chlbClasses.SetItemChecked(34, true);
            chlbClasses.SetItemChecked(35, true);
            txtFees.Text = "181122029958 0220 0052, 181132490958 0220 0073.";
            txtDescription.Text = "Όλα εντάξει!";
            pbTMPic.Image = Image.FromFile(@"C:\Repos\Trademarks\Files\246883.jpg");
        }

        ToolTip classTooltip = new ToolTip();

        private void QuickInsert_Load(object sender, EventArgs e)
        {

        }

        public string getClassHeaders(int ClassNo)
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Headers FROM [dbo].[Class] WHERE No = " + ClassNo.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["Headers"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        private void chlbClasses_MouseHover(object sender, EventArgs e)
        {
            Point point = chlbClasses.PointToClient(Cursor.Position);
            int index = chlbClasses.IndexFromPoint(point);
            if (index < 0) return;

            int classId = Convert.ToInt32(chlbClasses.Items[index].ToString());
            
            string tip = getClassHeaders(classId);
            classTooltip.SetToolTip(chlbClasses, "Κλάση " + classId.ToString() + ": " + tip);
        }

        private bool InsertTrademark()
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[xxxxx] ([Name],[IsAuditor],[IsAuditee] ,[IsAdmin], [PasswordPeriod], [InsDt]) VALUES " +
                           "(@Name, @IsAuditor, @IsAuditee, @IsAdmin, @PassPeriod, getdate() ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                //cmd.Parameters.AddWithValue("@Name", role.Name);
                //cmd.Parameters.AddWithValue("@IsAuditor", role.IsAuditor);
                //cmd.Parameters.AddWithValue("@IsAuditee", role.IsAuditee);
                //cmd.Parameters.AddWithValue("@IsAdmin", role.IsAdmin);
                //cmd.Parameters.AddWithValue("@PassPeriod", role.PasswordPeriod);

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

        private void CreateAlarms(DateTime Deposit_Datetime)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ToDo...

            //Save
            InsertTrademark();

            //Alarm
            CreateAlarms(new DateTime(2017, 12, 21, 12, 33, 0));
        }

        private void btnAddTMPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Files";
            ofd.Multiselect = false;
            ofd.ShowDialog();
            
            pbTMPic.Image = Image.FromFile(ofd.FileName);
        }


    }
}
