using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trademarks
{
    public partial class QuickInsert : Form
    {
        public QuickInsert() //insert
        {
            InitializeComponent();

            Init();

            isInsert = true;
        }

        public QuickInsert(TempRecords tmpRec) //update
        {
            InitializeComponent();

            Init();

            isInsert = false;
            btnSaveAndNext.Enabled = false;

            oldTempRecord = tmpRec;
            TempRecUpdId = tmpRec.Id;


            txtTMId.Text = tmpRec.TMNo;
            txtTMName.Text = tmpRec.TMName;
            dtpDepositDt.Value = tmpRec.DepositDt;
            dtpDepositTime.Value = tmpRec.DepositDt;
            chbHasRenewal.Checked = tmpRec.HasRenewal;
            if(chbHasRenewal.Checked)
            {
                dtpLastRenwalDt.Value = tmpRec.RenewalDt;
                dtpLastRenwalTime.Value = tmpRec.RenewalDt;
            }

            if (tmpRec.NationalPowerId == 1) //1 Εθνικό
            {
                rbEthniko.Checked = true;
            }
            else if (tmpRec.NationalPowerId == 2) //2 Κοινοτικό
            {
                rbKoinotiko.Checked = true;
            }
            else if (tmpRec.NationalPowerId == 3) //3 Διεθνές
            {
                rbDiethnes.Checked = true;
            }
            txtTMGrId.Text = tmpRec.TMGrNo;

            cbCompany.SelectedIndex = cbCompany.FindStringExact(Company.getCompanyName(tmpRec.CompanyId));
            cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact(Responsible.getResponsibleName(tmpRec.ResponsibleLawyerId));

            foreach (int typeId in tmpRec.TMTypeIds)
            {
                DataGridViewRow row = dgvTypes.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(r => Convert.ToInt32(r.Cells["Type_Id"].Value.ToString()) == typeId)
                                      .First();

                if (row.Index >= 0)
                {
                    dgvTypes["Type_Checked", row.Index].Value = "True";
                }
            }

            if (tmpRec.FileContents != null)
            {
                //string lvPath = "";
                string ext = "";
                //string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
                //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(tmpRec.FileName) + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                string tempPath = Path.GetTempPath() + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "\\";
                string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(tmpRec.FileName));
                try
                {
                    //if (!Directory.Exists(tempPath))
                    //{
                    //    MessageBox.Show("Error. Please check your privileges on " + tempPath);
                    //}

                    Directory.CreateDirectory(tempPath);

                    string fname = tmpRec.FileName;
                    ext = fname.Substring(fname.LastIndexOf("."));
                    //lvPath = tempFile + ext;
                    File.WriteAllBytes(tempFile + ext, tmpRec.FileContents);
                    
                    pbTMPic.Image = Image.FromFile(tempFile + ext);
                    txtFilename.Text = tempFile + ext; //tmpRec.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                    //return;
                }

                //pbTMPic.Image = Image.FromFile(@"C:\Repos\Trademarks\Files\246883.jpg"); //????????????????????????
                //txtFilename.Text = tmpRec.FileName;
            }



            foreach (int classId in tmpRec.ClassIds)
            {
                DataGridViewRow row = dgvClasses.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(r => Convert.ToInt32(r.Cells["Class_Id"].Value.ToString()) == classId)
                                      .First();

                if (row.Index >= 0)
                {
                    dgvClasses["Class_Checked", row.Index].Value = "True";
                }
            }

            foreach (int countryId in tmpRec.CountryIds)
            {
                DataGridViewRow row = dgvCountries.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(r => Convert.ToInt32(r.Cells["Country_Id"].Value.ToString()) == countryId)
                                      .First();

                if (row.Index >= 0)
                {
                    dgvCountries["Country_Checked", row.Index].Value = "True";
                }
            }

            txtFees.Text = tmpRec.Fees;
            txtDescription.Text = tmpRec.Description;
            txtDecisionNo.Text = tmpRec.DecisionNo;
            dtpPublicationDate.Value = tmpRec.PublicationDate;
            dtpFinalization.Value = tmpRec.FinalizationDate;

            txtUrl.Text = tmpRec.Url;            
        }

        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Company> companyList = Company.getCompanyList();
        ToolTip classTooltip = new ToolTip();
        public bool GoToNext = false;

        public bool isInsert = false;
        public bool success = false;

        public TempRecords oldTempRecord = new TempRecords();
        public TempRecords NewRecord = new TempRecords();
        public int TempRecUpdId = 0;

        private void Init()
        {
            cbLawyerFullname.Items.AddRange(Responsible.GetResponsibleComboboxItemsList(responsibleList).ToArray<ComboboxItem>());
            cbCompany.Items.AddRange(Company.GetCompaniesComboboxItemsList(companyList).ToArray<ComboboxItem>());

            FillDataGridView(dgvTypes, Type.getTypeList());
            FillDataGridView(dgvClasses, Class.getClassList());
            FillDataGridView(dgvCountries, Country.getCountryList());
        }

        private void QuickInsert_Load(object sender, EventArgs e)
        {         
            txtTMId.Select();
        }

        public static void FillDataGridView(DataGridView dgv, List<Type> TypeList)
        {
            dgv.Rows.Clear();

            foreach (Type thisRecord in TypeList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Type_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Name, dgvColumnHeader = "Type_Name" });
                
                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgvDictList.Exists(z => z.dgvColumnHeader == dgv.Columns[i].Name))
                    {
                        obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                    }
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
        }

        public static void FillDataGridView(DataGridView dgv, List<Class> ClassList)
        {
            dgv.Rows.Clear();

            foreach (Class thisRecord in ClassList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Class_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.No, dgvColumnHeader = "Class_No" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Headers, dgvColumnHeader = "Class_Headers" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Link, dgvColumnHeader = "Class_Link" });

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgvDictList.Exists(z => z.dgvColumnHeader == dgv.Columns[i].Name))
                    {
                        obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                    }
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
        }

        public static void FillDataGridView(DataGridView dgv, List<Country> CountryList)
        {
            dgv.Rows.Clear();

            foreach (Country thisRecord in CountryList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "Country_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Name, dgvColumnHeader = "Country_Name" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.NameShort, dgvColumnHeader = "Country_ShortName" });

                object[] obj = new object[dgv.Columns.Count];

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgvDictList.Exists(z => z.dgvColumnHeader == dgv.Columns[i].Name))
                    {
                        obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                    }
                }

                dgv.Rows.Add(obj);
            }

            dgv.ClearSelection();
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

        //private void chlbClasses_MouseHover(object sender, EventArgs e)
        //{
        //    Point point = chlbClasses.PointToClient(Cursor.Position);
        //    int index = chlbClasses.IndexFromPoint(point);
        //    if (index < 0) return;

        //    int classId = Convert.ToInt32(chlbClasses.Items[index].ToString());

        //    string tip = getClassHeaders(classId);
        //    classTooltip.SetToolTip(chlbClasses, "Κλάση " + classId.ToString() + ": " + tip);
        //}

        

        

        private int InsertTrademark(TempRecords tempRec)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TempRecords] ([TMNo], [DepositDt], [NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], " + 
                "[TMName], [FileName], [FileContents], [Description], [Fees], [DecisionNo], [PublicationDate], [FinalizationDate],[Url], [RenewalDt], [InsUser], [InsDt]) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@TMNo, @DepositDt, @NationalPowerId, @TMGrNo, @CompanyId, @ResponsibleLawyerId, " + 
                "@TMName, @FileName, @FileContents, @Description, @Fees, @DecisionNo, @PublicationDate, @FinalizationDate, @Url, @RenewalDt, @InsUser, getdate() ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TMNo", tempRec.TMNo);
                cmd.Parameters.AddWithValue("@DepositDt", tempRec.DepositDt);
                cmd.Parameters.AddWithValue("@NationalPowerId", tempRec.NationalPowerId);
                if (tempRec.TMGrNo == "")
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", tempRec.TMGrNo);
                }
                cmd.Parameters.AddWithValue("@CompanyId", tempRec.CompanyId);
                cmd.Parameters.AddWithValue("@ResponsibleLawyerId", tempRec.ResponsibleLawyerId);
                cmd.Parameters.AddWithValue("@TMName", tempRec.TMName);
                cmd.Parameters.AddWithValue("@FileName", tempRec.FileName);
                cmd.Parameters.AddWithValue("@FileContents", tempRec.FileContents);
                cmd.Parameters.AddWithValue("@Description", tempRec.Description);
                cmd.Parameters.AddWithValue("@Fees", tempRec.Fees);
                cmd.Parameters.AddWithValue("@DecisionNo", tempRec.DecisionNo);
                cmd.Parameters.AddWithValue("@PublicationDate", tempRec.PublicationDate);
                cmd.Parameters.AddWithValue("@FinalizationDate", tempRec.FinalizationDate);
                cmd.Parameters.AddWithValue("@Url", tempRec.Url);
                if (tempRec.HasRenewal)
                {
                    cmd.Parameters.AddWithValue("@RenewalDt", tempRec.RenewalDt);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RenewalDt", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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

        private bool UpdateTrademark(TempRecords tempRec)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string UpdSt = "UPDATE [dbo].[TempRecords] SET [TMNo] = @TMNo, [DepositDt] = @DepositDt, [NationalPowerId] = @NationalPowerId, [TMGrNo] = @TMGrNo, " +
                "[CompanyId] = @CompanyId, [ResponsibleLawyerId] = @ResponsibleLawyerId, [TMName] = @TMName, [FileName] = @FileName, [FileContents] = @FileContents, " +
                "[Description] = @Description, [Fees] = @Fees, [DecisionNo] = @DecisionNo, [PublicationDate] = @PublicationDate, [FinalizationDate] = @FinalizationDate, " +
                "[Url] = @Url, [RenewalDt] = @RenewalDt, [InsUser] = @InsUser, [InsDt] = getdate() " + 
                "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", tempRec.Id);

                cmd.Parameters.AddWithValue("@TMNo", tempRec.TMNo);
                cmd.Parameters.AddWithValue("@DepositDt", tempRec.DepositDt);
                cmd.Parameters.AddWithValue("@NationalPowerId", tempRec.NationalPowerId);
                if (tempRec.TMGrNo == "")
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", tempRec.TMGrNo);
                }
                cmd.Parameters.AddWithValue("@CompanyId", tempRec.CompanyId);
                cmd.Parameters.AddWithValue("@ResponsibleLawyerId", tempRec.ResponsibleLawyerId);
                cmd.Parameters.AddWithValue("@TMName", tempRec.TMName);
                cmd.Parameters.AddWithValue("@FileName", tempRec.FileName);
                cmd.Parameters.AddWithValue("@FileContents", tempRec.FileContents);
                cmd.Parameters.AddWithValue("@Description", tempRec.Description);
                cmd.Parameters.AddWithValue("@Fees", tempRec.Fees);
                cmd.Parameters.AddWithValue("@DecisionNo", tempRec.DecisionNo);
                cmd.Parameters.AddWithValue("@PublicationDate", tempRec.PublicationDate);
                cmd.Parameters.AddWithValue("@FinalizationDate", tempRec.FinalizationDate);
                cmd.Parameters.AddWithValue("@Url", tempRec.Url);
                if (tempRec.HasRenewal)
                {
                    cmd.Parameters.AddWithValue("@RenewalDt", tempRec.RenewalDt);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RenewalDt", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

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

        private bool InsertRecipients(Recipient rec)
        {
            //return int - output of Id
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Recipients] ([TrademarksId],[FullName],[Email] ,[IsActive]) VALUES " +
                           "(@TrademarksId, @FullName, @Email, 'True') ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", rec.TrademarksId);
                cmd.Parameters.AddWithValue("@FullName", rec.FullName);
                cmd.Parameters.AddWithValue("@Email", rec.Email);

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

        private bool CreateAlarms(TempRecords TMRecord)//DateTime Deposit_Datetime) 
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 1; //Ανανεώσεις

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId); 
 
            DateTime ExpDate = TMRecord.DepositDt.AddYears(task_EventType.ExpYears); //10 years

            if (TMRecord.HasRenewal)
            {
                ExpDate = TMRecord.RenewalDt.AddYears(task_EventType.ExpYears);
            }
                        
            TaskToInsert.TrademarksId = TMRecord.Id;
            TaskToInsert.ExpDate = ExpDate;
            TaskToInsert.IsActive = true;
            
            string EventTypeName = EventType.getEventTypeName(TaskToInsert.EventTypesId);

            //new form to show alarms before insert!
            //move to contructor??
            Alarms frmAlarms = new Alarms();
            frmAlarms.txtTMId.Text = TMRecord.TMNo;
            frmAlarms.txtTMName.Text = TMRecord.TMName;

            foreach (Responsible recipient in responsibleList)
            {
                bool IsChecked = false;
                if (recipient.Id == TMRecord.ResponsibleLawyerId)
                {
                    IsChecked = true;
                }
                frmAlarms.dgvRecipients.Rows.Add(new object[] { recipient.Id, IsChecked, recipient.FullName, recipient.Email });
            }

            frmAlarms.dtpExpDt.Value = ExpDate;
            frmAlarms.dtpExpTime.Value = ExpDate;

            foreach (myIntAndStr months in task_EventType.AlertMonths)
            {
                TaskToInsert.NotificationDate = ExpDate.AddMonths(-months.myInt);

                frmAlarms.dgvAlarms.Rows.Add(new object[] { TMRecord.Id, true, TaskToInsert.NotificationDate.ToString("dd.MM.yyyy HH:mm"), EventTypeName, months.myStr });

                if (TaskToInsert.NotificationDate < DateTime.Now)
                {
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].Cells["Alarm_Active"].Value = false;
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }
                
            }

            foreach (myIntAndStr days in task_EventType.AlertDays)
            {
                TaskToInsert.NotificationDate = ExpDate.AddDays(-days.myInt);
                bool IsActive = true;
                if (TaskToInsert.NotificationDate < DateTime.Now)
                {
                    IsActive = false;
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }
                frmAlarms.dgvAlarms.Rows.Add(new object[] { TMRecord.Id, IsActive, TaskToInsert.NotificationDate.ToString("dd.MM.yyyy HH:mm"), EventTypeName, days.myStr });
            }
            
            frmAlarms.ShowDialog();

            foreach (DataGridViewRow dgvr in frmAlarms.dgvAlarms.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Alarm_Active"].Value))
                {
                    TaskToInsert.NotificationDate = Convert.ToDateTime(dgvr.Cells["Alarm_NotificationDate"].Value);
                    if (InsertTask(TaskToInsert) == false)
                    {
                        ret = false;
                    }
                }
            }

            Recipient rec = new Recipient();
            rec.TrademarksId = TaskToInsert.TrademarksId;
            foreach (DataGridViewRow dgvr in frmAlarms.dgvRecipients.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Rec_Checked"].Value))
                {
                    rec.FullName = dgvr.Cells["Rec_Name"].Value.ToString();
                    rec.Email = dgvr.Cells["Rec_Email"].Value.ToString();
                    if (InsertRecipients(rec) == false)
                    {
                        ret = false;
                    }
                }
            }

            return ret;
        }

        
        private bool IsAnyTypeChecked(DataGridView dgv)
        {
            bool ret = false;

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Type_Checked"].Value) == true)
                {
                    ret = true;
                }
            }

            return ret;
        }

        private List<int> getCheckedTypes(DataGridView dgv)
        {
            List<int> ret = new List<int>();

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Type_Checked"].Value) == true)
                {
                    ret.Add(Convert.ToInt32(dgvr.Cells["Type_Id"].Value));
                }
            }

            return ret;
        }

        private bool IsAnyClassChecked(DataGridView dgv)
        {
            bool ret = false;

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Class_Checked"].Value) == true)
                {
                    ret = true;
                }
            }

            return ret;
        }

        private List<int> getCheckedClasses(DataGridView dgv)
        {
            List<int> ret = new List<int>();

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Class_Checked"].Value) == true)
                {
                    ret.Add(Convert.ToInt32(dgvr.Cells["Class_Id"].Value));
                }
            }

            return ret;
        }
        private bool IsAnyCountryChecked(DataGridView dgv)
        {
            bool ret = false;

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Country_Checked"].Value) == true)
                {
                    ret = true;
                }
            }

            return ret;
        }

        private List<int> getCheckedCountries(DataGridView dgv)
        {
            List<int> ret = new List<int>();

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Country_Checked"].Value) == true)
                {
                    ret.Add(Convert.ToInt32(dgvr.Cells["Country_Id"].Value));
                }
            }

            return ret;
        }

        public int getNatPowerId(GroupBox gb)
        {            
            string NatPowerName = "";
            foreach (RadioButton rb in gb.Controls)
            {
                if (rb.Checked == true)
                {
                    NatPowerName = rb.Text;
                }
            }
            
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[NationalPower] WHERE Name = @Name";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@Name", NatPowerName);

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

            return ret;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (txtTMId.Text.Trim() == "" || cbLawyerFullname.Text == "" || cbCompany.Text == "" || IsAnyTypeChecked(dgvTypes) == false || 
                txtTMName.Text.Trim() == "" || txtDecisionNo.Text.Trim() == "" || IsAnyClassChecked(dgvClasses) == false || txtFees.Text.Trim() == "" ||
                txtFilename.Text == "Αρχείο: -" || (!rbEthniko.Checked && !rbKoinotiko.Checked && !rbDiethnes.Checked) || 
                ((rbKoinotiko.Checked || rbDiethnes.Checked) && txtTMGrId.Text.Trim() == "") || (rbDiethnes.Checked && IsAnyCountryChecked(dgvCountries) == false))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!");
                return;
            }

            DateTime depositDatetime = new DateTime(dtpDepositDt.Value.Year, dtpDepositDt.Value.Month, dtpDepositDt.Value.Day,
                                                    dtpDepositTime.Value.Hour, dtpDepositTime.Value.Minute, dtpDepositTime.Value.Second);

            DateTime renewalDatetime = new DateTime(dtpLastRenwalDt.Value.Year, dtpLastRenwalDt.Value.Month, dtpLastRenwalDt.Value.Day,
                                                    dtpLastRenwalTime.Value.Hour, dtpLastRenwalTime.Value.Minute, dtpLastRenwalTime.Value.Second);

            if (chbHasRenewal.Checked && depositDatetime > renewalDatetime)
            {
                MessageBox.Show("Προσοχή! Η ημερομηνία Ανανέωσης είναι μικρότερη από την ημερομηνία Κατάθεσης!");
                return;
            }

            NewRecord = new TempRecords();

            NewRecord.TMNo = txtTMId.Text;
            NewRecord.DepositDt = depositDatetime;
            NewRecord.NationalPowerId = getNatPowerId(gbNatPower);
            NewRecord.TMGrNo = txtTMGrId.Text;
            NewRecord.CompanyId = ComboboxItem.getComboboxItem<Company>(cbCompany).Id;
            NewRecord.ResponsibleLawyerId = ComboboxItem.getComboboxItem<Responsible>(cbLawyerFullname).Id;
            NewRecord.TMTypeIds = getCheckedTypes(dgvTypes); 
            NewRecord.TMName = txtTMName.Text;
            NewRecord.FileName = System.IO.Path.GetFileName(txtFilename.Text);
            NewRecord.FileContents = System.IO.File.ReadAllBytes(txtFilename.Text);
            NewRecord.ClassIds = getCheckedClasses(dgvClasses);
            NewRecord.CountryIds = getCheckedCountries(dgvCountries);
            NewRecord.Description = txtDescription.Text;
            NewRecord.Fees = txtFees.Text;
            NewRecord.DecisionNo = txtDecisionNo.Text;
            NewRecord.PublicationDate = dtpPublicationDate.Value;
            NewRecord.FinalizationDate = dtpFinalization.Value;
            NewRecord.Url = txtUrl.Text;
            NewRecord.HasRenewal = chbHasRenewal.Checked;
            NewRecord.RenewalDt = renewalDatetime;

            NewRecord.Id = TempRecUpdId;

            if (isInsert)
            {
                //Save
                bool successful = true;
                int InsertedId = InsertTrademark(NewRecord);
                if (InsertedId > 0)
                {
                    NewRecord.Id = InsertedId;

                    foreach (int TM_typeId in NewRecord.TMTypeIds)
                    {
                        if (Type.InsertTM_Type(InsertedId, TM_typeId) == false)
                        {
                            //TM_Type ins error
                            successful = false;
                        }
                    }

                    foreach (int TM_classId in NewRecord.ClassIds)
                    {
                        if (Class.InsertTM_Class(InsertedId, TM_classId) == false)
                        {
                            //TM_Class ins error
                            successful = false;
                        }
                    }

                    foreach (int TM_countryId in NewRecord.CountryIds)
                    {
                        if (Country.InsertTM_Country(InsertedId, TM_countryId) == false)
                        {
                            //TM_Country ins error
                            successful = false;
                        }
                    }
                }
                else
                {
                    //TM ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (CreateAlarms(NewRecord) == false)
                    {
                        MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                    }
                    else
                    {
                        MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");

                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }
            }
            else
            {
                //Save
                bool successful = true;
                if (UpdateTrademark(NewRecord))
                {
                    //delete old records first...
                    Type.DeleteTM_Types(NewRecord.Id);

                    foreach (int TM_typeId in NewRecord.TMTypeIds)
                    {
                        if (Type.InsertTM_Type(NewRecord.Id, TM_typeId) == false)
                        {
                            //TM_Type ins error
                            successful = false;
                        }
                    }

                    //delete old records first...
                    Class.DeleteTM_Classes(NewRecord.Id);

                    foreach (int TM_classId in NewRecord.ClassIds)
                    {
                        if (Class.InsertTM_Class(NewRecord.Id, TM_classId) == false)
                        {
                            //TM_Class ins error
                            successful = false;
                        }
                    }

                    //delete old records first...
                    Country.DeleteTM_Countries(NewRecord.Id);

                    foreach (int TM_countryId in NewRecord.CountryIds)
                    {
                        if (Country.InsertTM_Country(NewRecord.Id, TM_countryId) == false)
                        {
                            //TM_Class ins error
                            successful = false;
                        }
                    }
                }
                else
                {
                    //TM ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    //delete old Alarms first...
                    Task.DeleteTasks(NewRecord.Id);

                    //delete recipients
                    Recipient.DeleteRecipients(NewRecord.Id);

                    if (CreateAlarms(NewRecord) == false)
                    {
                        MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
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
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }


            }
        }

        private void ToDelete()
        {
            txtTMId.Text = "246883";
            dtpDepositDt.Value = new DateTime(2017, 12, 21);
            dtpDepositTime.Value = new DateTime(1900, 1, 1, 12, 33, 0);

            cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact("Ιωάννα Τζανερρίκου");
            cbCompany.SelectedIndex = cbCompany.FindStringExact("PEAK CHARM HOLDINGS LIMITED");

            dgvTypes["Type_Checked", 0].Value = "True";
            dgvTypes["Type_Checked", 1].Value = "True";
            dgvTypes["Type_Checked", 5].Value = "True";

            txtTMName.Text = "XIOSBANK";
            txtDecisionNo.Text = "ΕΞ 1627 /30-03-2018";
            dtpPublicationDate.Value = new DateTime(2018, 3, 30);
            dtpFinalization.Value = new DateTime(2018, 6, 30);

            dgvClasses["Class_Checked", 34].Value = "True";
            dgvClasses["Class_Checked", 35].Value = "True";

            txtFees.Text = "181122029958 0220 0052, 181132490958 0220 0073.";
            txtDescription.Text = "Δεν ασκήθηκε ανακοπή. \r\nΚαταχωρήθηκε 3/7/2018.";
            pbTMPic.Image = Image.FromFile(@"C:\Repos\Trademarks\Files\246883.jpg");
            txtFilename.Text = @"C:\Repos\Trademarks\Files\246883.jpg";
            rbEthniko.Checked = true;
            txtUrl.Text = "https://www.tmdn.org/tmview/get-detail?st13=GR50201700N246883";
        }

        private void btnAddTMPic_Click(object sender, EventArgs e)
        {
            //To Delete
            if (txtTMId.Text == "")
            {
                ToDelete();
                return;
            }

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

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            GoToNext = true;
            btnSave_Click(null, null);
        }

        private void chbHasRenewal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHasRenewal.Checked)
            {
                dtpLastRenwalDt.Enabled = true;
                dtpLastRenwalTime.Enabled = true;
            }
            else
            {
                dtpLastRenwalDt.Enabled = false;
                dtpLastRenwalTime.Enabled = false;
            }
        }

        private void dgvClasses_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvClasses.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvClasses.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void tsmiOpenUrl_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvClasses.SelectedRows[0].Cells["class_Id"].Value.ToString());
                string classLink = dgvClasses.SelectedRows[0].Cells["class_Link"].Value.ToString();

                if (classLink.Trim() != "")
                {
                    System.Diagnostics.Process.Start(classLink);
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχει καταχωρημένο Url για τη συγκεκριμένη εγγραφή!");
                }
            }
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.Trim() != "")
            {
                System.Diagnostics.Process.Start(txtUrl.Text);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχει καταχωρημένο Url!");
            }
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

        public static string getResponsibleName(int givenId)
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT FullName FROM [dbo].[Responsible] WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["FullName"].ToString();
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

        public static string getCompanyName(int givenId)
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Name FROM [dbo].[Company] WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["Name"].ToString();
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

    public class NationalPower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public NationalPower()
        {
        }

        public static string getNationalPowerName(int givenId)
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Name FROM [dbo].[NationalPower] WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["Name"].ToString();
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

        public static bool DeleteTasks(int TrademarksId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[Tasks] WHERE TrademarksId = @TrademarksId ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", TrademarksId);

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

    }
        
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Type()
        {
        }

        public static List<Type> getTypeList()
        {
            List<Type> ret = new List<Type>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Type] ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Type type = new Type();
                    type.Id = Convert.ToInt32(reader["Id"].ToString());
                    type.Name = reader["Name"].ToString();
                    
                    ret.Add(type);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<int> getTM_TypesList(int TrademarkId)
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Type_Id FROM [dbo].[TM_Types] WHERE Trademarks_Id = @TM_Id ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TM_Id", TrademarkId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(Convert.ToInt32(reader["Type_Id"].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static bool InsertTM_Type(int TM_id, int TM_typeId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Types] ([Trademarks_Id], [Type_Id]) VALUES (@Trademarks_Id, @Type_Id) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", TM_id);
                cmd.Parameters.AddWithValue("@Type_Id", TM_typeId);

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

        public static bool DeleteTM_Types(int TM_id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[TM_Types] WHERE Trademarks_Id = @Trademarks_Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", TM_id);

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
    }

    public class Class
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Headers { get; set; }
        public string Link { get; set; }

        public Class()
        {
        }

        public static List<Class> getClassList()
        {
            List<Class> ret = new List<Class>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, No, Headers, Link FROM [dbo].[Class] ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class newclass = new Class();
                    newclass.Id = Convert.ToInt32(reader["Id"].ToString());
                    newclass.No = Convert.ToInt32(reader["No"].ToString());
                    newclass.Headers = reader["Headers"].ToString();
                    newclass.Link = reader["Link"].ToString();

                    ret.Add(newclass);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<int> getTM_ClassList(int TrademarkId)
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Class_Id FROM [dbo].[TM_Classes] WHERE Trademarks_Id = @TM_Id ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TM_Id", TrademarkId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(Convert.ToInt32(reader["Class_Id"].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static bool InsertTM_Class(int TM_id, int TM_classId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Classes] ([Trademarks_Id], [Class_Id]) VALUES (@Trademarks_Id, @Class_Id) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", TM_id);
                cmd.Parameters.AddWithValue("@Class_Id", TM_classId);

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

        public static bool DeleteTM_Classes(int TM_id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[TM_Classes] WHERE Trademarks_Id = @Trademarks_Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", TM_id);

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
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }

        public Country()
        {
        }

        public static List<Country> getCountryList()
        {
            List<Country> ret = new List<Country>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, Name, NameShort FROM [dbo].[Country] ORDER BY Name";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new Country();
                    country.Id = Convert.ToInt32(reader["Id"].ToString());
                    country.Name = reader["Name"].ToString();
                    country.NameShort = reader["NameShort"].ToString();

                    ret.Add(country);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<int> getTM_CountriesList(int TrademarkId)
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Country_Id FROM [dbo].[TM_Countries] WHERE Trademarks_Id = @TM_Id ORDER BY Id";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TM_Id", TrademarkId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(Convert.ToInt32(reader["Country_Id"].ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static bool InsertTM_Country(int TM_id, int TM_countryId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Countries] ([Trademarks_Id], [Country_Id]) VALUES (@Trademarks_Id, @Country_Id) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", TM_id);
                cmd.Parameters.AddWithValue("@Country_Id", TM_countryId);

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

        public static bool DeleteTM_Countries(int TM_id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[TM_Countries] WHERE Trademarks_Id = @Trademarks_Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", TM_id);

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
        public List<int> TMTypeIds { get; set; } //?? other table??
        public string TMName { get; set; }

        public string FileName { get; set; }
        public byte[] FileContents { get; set; }

        public List<int> ClassIds { get; set; } //?? other table??

        public List<int> CountryIds { get; set; }
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

        public TempRecords (int Id)
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

                    TMTypeIds = Type.getTM_TypesList(Convert.ToInt32(reader["Id"].ToString()));
                    ClassIds = Class.getTM_ClassList(Convert.ToInt32(reader["Id"].ToString()));
                    CountryIds = Country.getTM_CountriesList(Convert.ToInt32(reader["Id"].ToString()));
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
    }

    public class dgvDictionary
    {
        public object dbfield { get; set; }
        public string dgvColumnHeader { get; set; }
    }

    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EventType()
        {
        }

        public static string getEventTypeName(int givenId)
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Name FROM [dbo].[EventTypes] WHERE Id = " + givenId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["Name"].ToString();
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

    public class Recipient
    {
        public int Id { get; set; }
        public int TrademarksId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public Recipient()
        { }

        public static bool DeleteRecipients(int TrademarksId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "DELETE FROM [dbo].[Recipients] WHERE TrademarksId = @TrademarksId ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", TrademarksId);

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
    }

    public class myIntAndStr
    {
        public int myInt { get; set; }
        public string myStr { get; set; }
    }

    public class Tasks_EventType
    {
        //public int Id { get; set; }
        public int EventTypeId { get; set; }
        public int ExpYears { get; set; }
        public List<myIntAndStr> AlertMonths { get; set; }
        public List<myIntAndStr> AlertDays { get; set; }


        public Tasks_EventType()
        {
            AlertMonths = new List<myIntAndStr>();
            AlertDays = new List<myIntAndStr>();
        }

        public Tasks_EventType(int EventTypeId)
        {
            AlertMonths = new List<myIntAndStr>();
            AlertDays = new List<myIntAndStr>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [EventTypeId], [ExpYears], [AlertMonths], [AlertDays], [AlertDescr] " + 
                              "FROM [dbo].[Tasks_EventType] " + 
                              "WHERE EventTypeId = @EventTypeId " + 
                              "ORDER BY AlertMonths desc, AlertDays desc";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@EventTypeId", EventTypeId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EventTypeId = Convert.ToInt32(reader["EventTypeId"].ToString());
                    ExpYears = Convert.ToInt32(reader["ExpYears"].ToString());
                    

                    if (reader["AlertMonths"] != DBNull.Value)
                    {
                        AlertMonths.Add(new myIntAndStr() { myInt = Convert.ToInt32(reader["AlertMonths"].ToString()), myStr = reader["AlertDescr"].ToString() }); 
                    }

                    if (reader["AlertDays"] != DBNull.Value)
                    {
                        AlertDays.Add(new myIntAndStr() { myInt = Convert.ToInt32(reader["AlertDays"].ToString()), myStr = reader["AlertDescr"].ToString() }); 
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

    }

}
