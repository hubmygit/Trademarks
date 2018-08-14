﻿using System;
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

            cbLawyerFullname.Items.AddRange(Responsible.GetResponsibleComboboxItemsList(responsibleList).ToArray<ComboboxItem>());
            cbCompany.Items.AddRange(Company.GetCompaniesComboboxItemsList(companyList).ToArray<ComboboxItem>());

            
            txtTMId.Text = "246883";
            dtpDepositDt.Value = new DateTime(2017, 12, 21);
            dtpDepositTime.Value = new DateTime(1900, 1, 1, 12, 33, 0);
            cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact("Ιωάννα Τζανερρίκου");
            cbCompany.SelectedIndex = cbCompany.FindStringExact("PEAK CHARM HOLDINGS LIMITED");
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
            txtDescription.Text = "Δεν ασκήθηκε ανακοπή. \r\nΚαταχωρήθηκε 3/7/2018.";
            pbTMPic.Image = Image.FromFile(@"C:\Repos\Trademarks\Files\246883.jpg");
            txtFilename.Text = @"C:\Repos\Trademarks\Files\246883.jpg";
            rbEthniko.Checked = true;
            txtUrl.Text = "https://www.tmdn.org/tmview/get-detail?st13=GR50201700N246883";
            
        }

        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Company> companyList = Company.getCompanyList();
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

        private bool InsertTrademark(TempRecords tempRec)
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

        private bool InsertTask(Task task)
        {
            //return int - output of Id
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Tasks] ([TrademarksId],[ExpDate],[NotificationDate] ,[IsActive], [EventTypesId]) VALUES " +
                           "(@TrademarksId, @ExpDate, @NotificationDate, @IsActive, @EventTypesId ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", task.TrademarksId);
                cmd.Parameters.AddWithValue("@ExpDate", task.ExpDate);
                cmd.Parameters.AddWithValue("@NotificationDate", task.NotificationDate);
                cmd.Parameters.AddWithValue("@IsActive", task.IsActive);
                cmd.Parameters.AddWithValue("@EventTypesId", task.EventTypesId);

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

        private void CreateAlarms(int TrademarksId, DateTime Deposit_Datetime)
        {         
            DateTime ExpDate = Deposit_Datetime.AddYears(10);

            Task TaskToInsert = new Task();
            TaskToInsert.TrademarksId = TrademarksId;
            TaskToInsert.ExpDate = ExpDate;
            TaskToInsert.IsActive = true;
            TaskToInsert.EventTypesId = 1;
            TaskToInsert.NotificationDate = ExpDate.AddMonths(-6);
            InsertTask(TaskToInsert);
            TaskToInsert.NotificationDate = ExpDate.AddMonths(-4);
            InsertTask(TaskToInsert);
            TaskToInsert.NotificationDate = ExpDate.AddMonths(-2);
            InsertTask(TaskToInsert);
            TaskToInsert.NotificationDate = ExpDate.AddMonths(-1);
            InsertTask(TaskToInsert);
            TaskToInsert.NotificationDate = ExpDate.AddDays(-15);
            InsertTask(TaskToInsert);
            TaskToInsert.NotificationDate = ExpDate.AddDays(-3);
            InsertTask(TaskToInsert);
            TaskToInsert.NotificationDate = ExpDate;
            InsertTask(TaskToInsert);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (txtTMId.Text.Trim() == "" || cbLawyerFullname.Text == "" || cbCompany.Text == "" || chlbTMType.CheckedItems.Count <= 0 || 
                txtTMName.Text.Trim() == "" || txtDecisionNo.Text.Trim() == "" || chlbClasses.CheckedItems.Count <= 0 || txtFees.Text.Trim() == "" ||
                txtFilename.Text == "Αρχείο: -" || (!rbEthniko.Checked && !rbKoinotiko.Checked && !rbDiethnes.Checked) || 
                ((rbKoinotiko.Checked || rbDiethnes.Checked) && txtTMGrId.Text.Trim() == ""))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία");
                return;
            }

            DateTime depositDatetime = new DateTime(dtpDepositDt.Value.Year, dtpDepositDt.Value.Month, dtpDepositDt.Value.Day,
                                                    dtpDepositTime.Value.Hour, dtpDepositTime.Value.Minute, dtpDepositTime.Value.Second);

            TempRecords NewRecord = new TempRecords();
            NewRecord.TMNo = txtTMId.Text;
            NewRecord.Deposit = depositDatetime;
            //NewRecord.NationalPowerId = 0; //rbEthniko
            NewRecord.TMGrNo = txtTMGrId.Text;
            NewRecord.CompanyId = ComboboxItem.getComboboxItem<Company>(cbCompany).Id;
            NewRecord.ResponsibleLawyerId = ComboboxItem.getComboboxItem<Responsible>(cbLawyerFullname).Id;
            //NewRecord.TMTypeIds   //chlbTMType
            NewRecord.TMName = txtTMName.Text;
            //NewRecord.   //FileName..
            //NewRecord.ClassIds   //chlbClasses
            NewRecord.Description = txtDescription.Text;
            NewRecord.Fees = txtFees.Text;
            NewRecord.DecisionNo = txtDecisionNo.Text;
            NewRecord.PublicationDate = dtpPublicationDate.Value;
            NewRecord.FinalizationDate = dtpFinalization.Value;
            NewRecord.Url = txtUrl.Text;


            //Save
            //InsertTrademark(NewRecord); //To Do..
            int outputId = 124; 

            //Alarms                                                   
            CreateAlarms(outputId, depositDatetime);
        }

        private void btnAddTMPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Files";
            ofd.Multiselect = false;
            DialogResult dlgRes = ofd.ShowDialog();

            if (dlgRes == DialogResult.OK)
            {
                string fn = System.IO.Path.GetExtension(ofd.FileName);
                if (fn == ".gif" || fn == ".jpg" || fn == ".jpeg" || fn == ".bmp" || fn == ".wmf" || fn == ".png")
                {
                    pbTMPic.Image = Image.FromFile(ofd.FileName);
                }
                else
                {
                    pbTMPic.Image = null;
                    lblPreview.Visible = true;
                }

                txtFilename.Text = ofd.FileName;
            }
        }

        private void rbEthniko_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEthniko.Checked == true)
            {
                lblTMGrId.Enabled = false;
                txtTMGrId.Clear();
                txtTMGrId.Enabled = false;
            }
        }
        private void rbKoinotiko_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKoinotiko.Checked == true)
            {
                lblTMGrId.Enabled = true;
                txtTMGrId.Enabled = true;
            }
        }

        private void rbDiethnes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDiethnes.Checked == true)
            {
                lblTMGrId.Enabled = true;
                txtTMGrId.Enabled = true;
            }
        }

        private void btnRemoveTMFile_Click(object sender, EventArgs e)
        {
            pbTMPic.Image = null;
            txtFilename.Text = "Αρχείο: -";
            lblPreview.Visible = false;
        }
    }

    public class Responsible
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Responsible()
        {
        }

        public static List<Responsible> getResponsibleList()
        {
            List<Responsible> ret = new List<Responsible>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, FullName, Email FROM [dbo].[Responsible] ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Responsible resp = new Responsible();
                    resp.Id = Convert.ToInt32(reader["Id"].ToString());
                    resp.FullName = reader["FullName"].ToString();
                    resp.Email = reader["Email"].ToString();
                    ret.Add(resp); 
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetResponsibleComboboxItemsList(List<Responsible> ResponsibleList)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Responsible r in ResponsibleList)
            {
                ret.Add(new ComboboxItem() { Value = r, Text = r.FullName });
            }

            return ret;
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Headquarters { get; set; }
        public Company()
        {
        }

        public static List<Company> getCompanyList()
        {
            List<Company> ret = new List<Company>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, Name, Headquarters FROM [dbo].[Company] ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company comp = new Company();
                    comp.Id = Convert.ToInt32(reader["Id"].ToString());
                    comp.Name = reader["Name"].ToString();
                    comp.Headquarters = reader["Headquarters"].ToString();
                    ret.Add(comp);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetCompaniesComboboxItemsList(List<Company> CompanyList)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Company c in CompanyList)
            {
                ret.Add(new ComboboxItem() { Value = c, Text = c.Name });
            }

            return ret;
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public static T getComboboxItem<T>(ComboBox cb)
        {
            T ret = ((T)((ComboboxItem)cb.SelectedItem).Value);

            return ret;
        }
    }

    public class Task
    {
        public int TrademarksId { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsActive { get; set; }
        public int EventTypesId { get; set; }

        public Task()
        {
        }

    }
        

    public class TempRecords
    {
        public string TMNo { get; set; }
        public DateTime Deposit { get; set; }
        public int NationalPowerId { get; set; } //class ???
        public string TMGrNo { get; set; }
        public int CompanyId { get; set; }
        public int ResponsibleLawyerId { get; set; }
        public List<int> TMTypeIds { get; set; } //?? other table??
        public string TMName { get; set; }
        //FileName //?????????? other table??
        public List<int> ClassIds { get; set; } //?? other table??
        public string Description { get; set; }
        public string Fees { get; set; } //paravola
        public string DecisionNo { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime FinalizationDate { get; set; }
        public string Url { get; set; }
                    
    }

}
