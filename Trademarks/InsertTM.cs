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
    public partial class InsertTM : Form
    {
        public InsertTM() //insert 
        {
            InitializeComponent();

            Init();

            isInsert = true;

            //cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact(Responsible.getResponsibleName(3));
            //InsUser = Responsible Lawyer
        }

        public InsertTM(Trademark givenRec) //update
        {
            InitializeComponent();

            Init();

            isInsert = false;

            OldRecord = givenRec;
            TempRecUpdId = givenRec.Id;

            txtTMId.Text = givenRec.TMNo;
            txtTMName.Text = givenRec.TMName;
            dtpDepositDt.Value = givenRec.DepositDt;
            dtpDepositTime.Value = givenRec.DepositDt;

            if (givenRec.ValidTo != null)
            {
                dtpValidTo.CustomFormat = "dd/MM/yyyy";
                dtpValidTo.Value = (DateTime)givenRec.ValidTo;
            }            

            if (givenRec.NationalPowerId == 1) //1 Εθνικό
            {
                rbEthniko.Checked = true;
            }
            else if (givenRec.NationalPowerId == 2) //2 Κοινοτικό
            {
                rbKoinotiko.Checked = true;
            }
            else if (givenRec.NationalPowerId == 3) //3 Διεθνές
            {
                rbDiethnes.Checked = true;
            }
            txtTMGrId.Text = givenRec.TMGrNo;
            cbCompany.SelectedIndex = cbCompany.FindStringExact(Company.getCompanyName(givenRec.CompanyId));
            cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact(Responsible.getResponsibleName(givenRec.ResponsibleLawyerId));

            foreach (int typeId in givenRec.TMTypeIds)
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

            string fn = System.IO.Path.GetExtension(givenRec.FileName);
            if (givenRec.FileContents != null)
            {
                //string lvPath = "";
                string ext = "";
                //string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
                //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(tmpRec.FileName) + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                string tempPath = Path.GetTempPath() + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "\\";
                string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(givenRec.FileName));
                try
                {
                    //if (!Directory.Exists(tempPath))
                    //{
                    //    MessageBox.Show("Error. Please check your privileges on " + tempPath);
                    //}

                    Directory.CreateDirectory(tempPath);

                    string fname = givenRec.FileName;
                    ext = fname.Substring(fname.LastIndexOf("."));
                    //lvPath = tempFile + ext;
                    File.WriteAllBytes(tempFile + ext, givenRec.FileContents);

                    if (fn == ".gif" || fn == ".jpg" || fn == ".jpeg" || fn == ".bmp" || fn == ".wmf" || fn == ".png")
                    {
                        pbTMPic.Image = Image.FromFile(tempFile + ext);
                    }
                    else
                    {
                        lblPreview.Visible = true;
                    }

                    txtFilename.Text = tempFile + ext; //tmpRec.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                    //return;
                }
            }

            foreach (int classId in givenRec.ClassIds)
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

            foreach (int countryId in givenRec.CountryIds)
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

            txtFees.Text = givenRec.Fees;
            txtDescription.Text = givenRec.Description;

        }
        
        public bool isInsert = false;
        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Responsible> secretariesList = Responsible.getSecretariesList();
        public List<Company> companyList = Company.getCompanyList();
        ToolTip classTooltip = new ToolTip();
        public bool success = false;
        public Trademark OldRecord = new Trademark();
        public Trademark NewRecord = new Trademark();
        public int TempRecUpdId = 0;

        private void InsertGrTM_Load(object sender, EventArgs e)
        {
            txtTMId.Select();
        }

        private void Init()
        {
            cbLawyerFullname.Items.AddRange(Responsible.GetResponsibleComboboxItemsList(responsibleList).ToArray<ComboboxItem>());
            cbCompany.Items.AddRange(Company.GetCompaniesComboboxItemsList(companyList).ToArray<ComboboxItem>());

            FillDataGridView(dgvTypes, Type.getTypeList());
            FillDataGridView(dgvClasses, Class.getClassList());
            FillDataGridView(dgvCountries, Country.getCountryList());
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
                    lblPreview.Visible = false;
                }
                else
                {
                    pbTMPic.Image = null;
                    lblPreview.Visible = true;
                }

                txtFilename.Text = ofd.FileName;
            }
        }

        private void btnRemoveTMFile_Click(object sender, EventArgs e)
        {
            pbTMPic.Image = null;
            txtFilename.Text = "Αρχείο: -";
            lblPreview.Visible = false;
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

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (txtFilename.Text.Trim() != "" && txtFilename.Text.Trim() != "Αρχείο: -")
            {
                System.Diagnostics.Process.Start(txtFilename.Text);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχει καταχωρημένο Αρχείο!");
            }
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

        private void clearCheckedCountries(DataGridView dgv)
        {
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Country_Checked"].Value) == true)
                {
                    dgvr.Cells["Country_Checked"].Value = false;
                }
            }
        }

        private int InsertTrademark(Trademark TMRec)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Trademarks] ([TMNo], [DepositDt], [NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], " +
                "[TMName], [FileName], [FileContents], [Description], [Fees], [InsUser], [InsDt]) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@TMNo, @DepositDt, @NationalPowerId, @TMGrNo, @CompanyId, @ResponsibleLawyerId, " +
                "@TMName, @FileName, @FileContents, @Description, @Fees, @InsUser, getdate() ) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TMNo", TMRec.TMNo);
                cmd.Parameters.AddWithValue("@DepositDt", TMRec.DepositDt);
                cmd.Parameters.AddWithValue("@NationalPowerId", TMRec.NationalPowerId);
                if (TMRec.TMGrNo == "")
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", TMRec.TMGrNo);
                }
                cmd.Parameters.AddWithValue("@CompanyId", TMRec.CompanyId);
                cmd.Parameters.AddWithValue("@ResponsibleLawyerId", TMRec.ResponsibleLawyerId);
                cmd.Parameters.AddWithValue("@TMName", TMRec.TMName);

                if (txtFilename.Text == "Αρχείο: -")
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@FileContents";
                    param.Value = DBNull.Value;
                    param.SqlDbType = SqlDbType.VarBinary;
                    //param.Size
                    cmd.Parameters.Add(param);
                    //cmd.Parameters.AddWithValue("@FileContents", DBNull.Value);

                    cmd.Parameters.AddWithValue("@FileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FileName", TMRec.FileName);
                    cmd.Parameters.AddWithValue("@FileContents", TMRec.FileContents);
                }

                cmd.Parameters.AddWithValue("@Description", TMRec.Description);
                cmd.Parameters.AddWithValue("@Fees", TMRec.Fees);
                                
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

        private bool UpdateTrademark(Trademark TMRec)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string UpdSt = "UPDATE [dbo].[Trademarks] SET [TMNo] = @TMNo, [DepositDt] = @DepositDt, [NationalPowerId] = @NationalPowerId, [TMGrNo] = @TMGrNo, " +
                "[CompanyId] = @CompanyId, [ResponsibleLawyerId] = @ResponsibleLawyerId, [TMName] = @TMName, [FileName] = @FileName, [FileContents] = @FileContents, " +
                "[Description] = @Description, [Fees] = @Fees, " + //[DecisionNo] = @DecisionNo, [PublicationDate] = @PublicationDate, [FinalizationDate] = @FinalizationDate, " +
                //"[Url] = @Url, [RenewalDt] = @RenewalDt, 
                "[UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", TMRec.Id);

                cmd.Parameters.AddWithValue("@TMNo", TMRec.TMNo);
                cmd.Parameters.AddWithValue("@DepositDt", TMRec.DepositDt);
                cmd.Parameters.AddWithValue("@NationalPowerId", TMRec.NationalPowerId);
                if (TMRec.TMGrNo == "")
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TMGrNo", TMRec.TMGrNo);
                }
                cmd.Parameters.AddWithValue("@CompanyId", TMRec.CompanyId);
                cmd.Parameters.AddWithValue("@ResponsibleLawyerId", TMRec.ResponsibleLawyerId);
                cmd.Parameters.AddWithValue("@TMName", TMRec.TMName);

                if (TMRec.FileName is null)
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@FileContents";
                    param.Value = DBNull.Value;
                    param.SqlDbType = SqlDbType.VarBinary;
                    cmd.Parameters.Add(param);

                    cmd.Parameters.AddWithValue("@FileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FileName", TMRec.FileName);
                    cmd.Parameters.AddWithValue("@FileContents", TMRec.FileContents);
                }

                cmd.Parameters.AddWithValue("@Description", TMRec.Description);
                cmd.Parameters.AddWithValue("@Fees", TMRec.Fees);
                
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

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

        public bool CreateDecisionAlarms(Trademark TMRecord, int TMS_Id)
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 2; //Απόφαση σε εκκρεμότητα
            TaskToInsert.TM_StatusId = TMS_Id;

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId, TMRecord.NationalPowerId);

            DateTime ExpDate = TMRecord.DepositDt.AddMonths(task_EventType.ExpMonths); //1 month

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

            foreach (Responsible recipient in secretariesList)
            {
                frmAlarms.dgvRecipients.Rows.Add(new object[] { recipient.Id, true, recipient.FullName, recipient.Email });
                frmAlarms.dgvRecipients.Rows[frmAlarms.dgvRecipients.Rows.Count - 1].ReadOnly = true;
                frmAlarms.dgvRecipients.Rows[frmAlarms.dgvRecipients.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
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

                frmAlarms.dgvAlarms.Rows.Add(new object[] { TMRecord.Id, true, TaskToInsert.NotificationDate.ToString("dd.MM.yyyy HH:mm"), EventTypeName, days.myStr });

                if (TaskToInsert.NotificationDate < DateTime.Now)
                {
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].Cells["Alarm_Active"].Value = false;
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            frmAlarms.ShowDialog();

            bool foundSomething = false;

            foreach (DataGridViewRow dgvr in frmAlarms.dgvAlarms.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Alarm_Active"].Value))
                {
                    TaskToInsert.NotificationDate = Convert.ToDateTime(dgvr.Cells["Alarm_NotificationDate"].Value);
                    TaskToInsert.AlertDescr = dgvr.Cells["Alarm_Period"].Value.ToString();
                    if (QuickInsert.InsertTask(TaskToInsert) == false)
                    {
                        ret = false;
                    }
                    else
                    {
                        foundSomething = true;
                    }
                }
            }

            if (foundSomething == false)
            {
                return ret;
            }

            Recipient rec = new Recipient();
            rec.TrademarksId = TaskToInsert.TrademarksId;
            rec.TM_StatusId = TaskToInsert.TM_StatusId;
            rec.EventTypesId = TaskToInsert.EventTypesId;
            foreach (DataGridViewRow dgvr in frmAlarms.dgvRecipients.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Rec_Checked"].Value))
                {
                    rec.FullName = dgvr.Cells["Rec_Name"].Value.ToString();
                    rec.Email = dgvr.Cells["Rec_Email"].Value.ToString();
                    if (QuickInsert.InsertRecipients(rec) == false)
                    {
                        ret = false;
                    }
                }
            }

            return ret;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (txtTMId.Text.Trim() == "" || cbLawyerFullname.Text == "" || cbCompany.Text == "" || IsAnyTypeChecked(dgvTypes) == false ||
                txtTMName.Text.Trim() == "" || IsAnyClassChecked(dgvClasses) == false ||
                (!rbEthniko.Checked && !rbKoinotiko.Checked && !rbDiethnes.Checked) ||
                (rbDiethnes.Checked && IsAnyCountryChecked(dgvCountries) == false) )//||
                //((rbKoinotiko.Checked || rbDiethnes.Checked) && txtTMGrId.Text.Trim() == "") )
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!");
                return;
            }

            DateTime depositDatetime = new DateTime(dtpDepositDt.Value.Year, dtpDepositDt.Value.Month, dtpDepositDt.Value.Day,
                                                    dtpDepositTime.Value.Hour, dtpDepositTime.Value.Minute, dtpDepositTime.Value.Second);

            NewRecord = new Trademark();

            NewRecord.TMNo = txtTMId.Text;
            NewRecord.DepositDt = depositDatetime;
            //NewRecord.NationalPowerId = 1; //Εθνικό
            //NewRecord.TMGrNo = ""; //NULL ????

            if (rbEthniko.Checked)//1 Εθνικό
            {
                NewRecord.NationalPowerId = 1; 
            }
            else if (rbKoinotiko.Checked) //2 Κοινοτικό
            {
                NewRecord.NationalPowerId = 2;
            }
            else if (rbDiethnes.Checked) //3 Διεθνές
            {
                NewRecord.NationalPowerId = 3;
            }
            NewRecord.TMGrNo = txtTMGrId.Text;
                        
            NewRecord.CompanyId = ComboboxItem.getComboboxItem<Company>(cbCompany).Id;
            NewRecord.ResponsibleLawyerId = ComboboxItem.getComboboxItem<Responsible>(cbLawyerFullname).Id;
            NewRecord.TMTypeIds = getCheckedTypes(dgvTypes);
            NewRecord.TMName = txtTMName.Text;
            if (txtFilename.Text != "Αρχείο: -")
            {
                NewRecord.FileName = System.IO.Path.GetFileName(txtFilename.Text);
                NewRecord.FileContents = System.IO.File.ReadAllBytes(txtFilename.Text);
            }
            NewRecord.ClassIds = getCheckedClasses(dgvClasses);
            NewRecord.CountryIds = getCheckedCountries(dgvCountries);
            NewRecord.Description = txtDescription.Text;
            NewRecord.Fees = txtFees.Text;

            NewRecord.Id = TempRecUpdId;


            TM_Status tmStatus = new TM_Status();
            tmStatus.TmId = TempRecUpdId;
            tmStatus.StatusId = 1; //katathesi
            tmStatus.DepositDt = depositDatetime;
            tmStatus.Remarks = NewRecord.Description;

            if (isInsert)
            {
                //Save
                bool successful = true;
                int InsertedId = InsertTrademark(NewRecord);
                if (InsertedId > 0)
                {
                    NewRecord.Id = InsertedId;
                    tmStatus.TmId = InsertedId;

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

                    tmStatus.Id = TM_Status.InsertTM_Status_Deposit(tmStatus);
                    //if (TM_Status.InsertTM_Status_Deposit(tmStatus) == false)
                    if(tmStatus.Id <= 0)
                    {
                        //TM_Status ins error
                        successful = false;
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
                    if (NewRecord.NationalPowerId == 1) //1 month to decision, only national tm
                    {
                        if (CreateDecisionAlarms(NewRecord, tmStatus.Id) == false)
                        {
                            MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                            return;
                        }
                    }

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    success = true;
                    Close();
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
                    TmLog.Insert_TMLog(OldRecord, NewRecord, "Κατάθεση");

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

                    //delete old records first... (non mandatory field!)
                    Country.DeleteTM_Countries(NewRecord.Id);

                    foreach (int TM_countryId in NewRecord.CountryIds)
                    {
                        if (Country.InsertTM_Country(NewRecord.Id, TM_countryId) == false)
                        {
                            //TM_Class ins error
                            successful = false;
                        }
                    }

                    tmStatus.Id = TM_Status.UpdateTM_Status_Deposit(tmStatus);
                    if (tmStatus.Id <= 0)
                    {
                        //TM_Status ins error
                        successful = false;
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
                    if (OldRecord.DepositDt != NewRecord.DepositDt || OldRecord.NationalPowerId != NewRecord.NationalPowerId)
                    {
                        //disable Alarms first...(only decision)
                        Task.DisableNotSentTasks(NewRecord.Id, 2); 

                        //delete recipients
                        Recipient.DeleteRecipients(NewRecord.Id, tmStatus.Id, 2); //Απόφαση σε εκκρεμότητα

                        if (NewRecord.NationalPowerId == 1) //1 month to decision, only national tm
                        {
                            if (CreateDecisionAlarms(NewRecord, tmStatus.Id) == false)
                            {
                                MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                                return;
                            }
                        }                        
                    }

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }


            }


        }

        private void rbEthniko_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEthniko.Checked == true)
            {
                lblTMGrId.Enabled = false;
                txtTMGrId.Clear();
                btnTmGrNoSelector.Enabled = false;

                clearCheckedCountries(dgvCountries);
                dgvCountries.Columns["Country_Checked"].ReadOnly = true;
            }
        }

        private void rbKoinotiko_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKoinotiko.Checked == true)
            {
                lblTMGrId.Enabled = true;
                btnTmGrNoSelector.Enabled = true;

                clearCheckedCountries(dgvCountries);
                dgvCountries.Columns["Country_Checked"].ReadOnly = true;
            }
        }

        private void rbDiethnes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDiethnes.Checked == true)
            {
                lblTMGrId.Enabled = true;
                btnTmGrNoSelector.Enabled = true;
                
                dgvCountries.Columns["Country_Checked"].ReadOnly = false;
            }
        }

        private void btnTmGrNoSelector_Click(object sender, EventArgs e)
        {
            NatTmSelector frmNatTmSel = new NatTmSelector();
            frmNatTmSel.ShowDialog();

            if (frmNatTmSel.succeed)
            {
                txtTMGrId.Text = frmNatTmSel.TMGrNo;

                if (MessageBox.Show("Θέλετε να μεταφερθούν από το εθνικό σήμα τα παρακάτω πεδία; \r\n" + 
                    "-> Εταιρία\r\n" +
                    "-> Ονομ/μο Δικηγόρου\r\n" +
                    "-> Τύπος\r\n" +
                    "-> Αρχείο\r\n" +
                    "-> Κλάση\r\n" +
                    "-> Σχόλια\r\n", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cbCompany.SelectedIndex = cbCompany.FindStringExact(Company.getCompanyName(frmNatTmSel.selTempRec.CompanyId));
                    cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact(Responsible.getResponsibleName(frmNatTmSel.selTempRec.ResponsibleLawyerId));
                    foreach (int typeId in frmNatTmSel.selTempRec.TMTypeIds)
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

                    string fn = System.IO.Path.GetExtension(frmNatTmSel.selTempRec.FileName);
                    if (frmNatTmSel.selTempRec.FileContents != null)
                    {
                        string ext = "";
                        string tempPath = Path.GetTempPath() + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "\\";
                        string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(frmNatTmSel.selTempRec.FileName));
                        try
                        {
                            Directory.CreateDirectory(tempPath);

                            string fname = frmNatTmSel.selTempRec.FileName;
                            ext = fname.Substring(fname.LastIndexOf("."));
                            File.WriteAllBytes(tempFile + ext, frmNatTmSel.selTempRec.FileContents);

                            if (fn == ".gif" || fn == ".jpg" || fn == ".jpeg" || fn == ".bmp" || fn == ".wmf" || fn == ".png")
                            {
                                pbTMPic.Image = Image.FromFile(tempFile + ext);
                            }
                            else
                            {
                                lblPreview.Visible = true;
                            }

                            txtFilename.Text = tempFile + ext; //tmpRec.FileName;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The following error occurred: " + ex.Message);
                        }
                    }

                    foreach (int classId in frmNatTmSel.selTempRec.ClassIds)
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

                    txtDescription.Text = frmNatTmSel.selTempRec.Description;

                }
            }
        }

        public void MakeAllControlsReadOnly(Form frm)
        {
            foreach (Control control in frm.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).ReadOnly = true;
                }

                if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Enabled = false;
                }

                if (control is CheckBox)
                {
                    ((CheckBox)control).Enabled = false;
                }

                if (control is GroupBox)
                {
                    ((GroupBox)control).Enabled = false;
                }

                if (control is DataGridView)
                {
                    //((DataGridView)control).Enabled = false;
                    if (control.Name == "dgvCountries")
                    {
                        ((DataGridView)control).Columns["Country_Checked"].ReadOnly = true;
                    }
                    if (control.Name == "dgvTypes")
                    {
                        ((DataGridView)control).Columns["Type_Checked"].ReadOnly = true;
                    }
                    if (control.Name == "dgvClasses")
                    {
                        ((DataGridView)control).Columns["Class_Checked"].ReadOnly = true;
                    }
                }

                if (control is ComboBox)
                {
                    ((ComboBox)control).Enabled = false;
                }

                if (control is Button)
                {
                    ((Button)control).Enabled = false;

                    if (control.Name == "btnOpenLink" || control.Name == "btnOpenFile")
                    {
                        ((Button)control).Enabled = true;
                    }

                }
            }
        }

        public void GetFromGridOnlyChecked()
        {
            foreach (Control control in this.Controls)
            {
                if (control is DataGridView)
                {
                    if (control.Name == "dgvCountries")
                    {
                        foreach (DataGridViewRow dgvr in dgvCountries.Rows)
                        {
                            if (Convert.ToBoolean(dgvr.Cells["Country_Checked"].Value) == false)
                            {
                                //dgvCountries.Rows.Remove(dgvr);
                                dgvr.Visible = false;
                            }
                        }
                    }
                    if (control.Name == "dgvTypes")
                    {
                        foreach (DataGridViewRow dgvr in dgvTypes.Rows)
                        {
                            if (Convert.ToBoolean(dgvr.Cells["Type_Checked"].Value) == false)
                            {
                                //dgvTypes.Rows.Remove(dgvr);
                                dgvr.Visible = false;
                            }
                        }
                    }
                    if (control.Name == "dgvClasses")
                    {
                        foreach (DataGridViewRow dgvr in dgvClasses.Rows)
                        {
                            if (Convert.ToBoolean(dgvr.Cells["Class_Checked"].Value) == false)
                            {
                                //gvClasses.Rows.Remove(dgvr);
                                dgvr.Visible = false;
                            }
                        }
                    }
                }
            }
        }


    }

    public class TmLog
    {
        public int Trademarks_Id { get; set; }
        public int? TM_Status_Id { get; set; }
        public int AppUsers_Id { get; set; }
        public DateTime Dt { get; set; }
        public string ExecStatement { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string FieldNameToShow { get; set; }
        public string Section { get; set; }

        //other fields - refs
        public string FullName { get; set; }
        public string TMNo { get; set; }
        public string TMName { get; set; }
        public string Status { get; set; }




        public static void Ins_TMLog(TmLog givenTmLog)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Log] " +
                           "([Trademarks_Id], [TM_Status_Id], [AppUsers_Id], [Dt], [ExecStatement], [TableName], [FieldName], [FieldNameToShow], [OldValue], [NewValue], [Section]) " +
                           "VALUES " +
                           "(@Trademarks_Id, @TM_Status_Id, @AppUsers_Id, @Dt, @ExecStatement, @TableName, @FieldName, @FieldNameToShow, @OldValue, @NewValue, @Section) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Trademarks_Id", givenTmLog.Trademarks_Id);
                if (givenTmLog.TM_Status_Id is null)
                {
                    cmd.Parameters.AddWithValue("@TM_Status_Id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TM_Status_Id", givenTmLog.TM_Status_Id);
                }
                cmd.Parameters.AddWithValue("@AppUsers_Id", givenTmLog.AppUsers_Id);
                cmd.Parameters.AddWithValue("@Dt", givenTmLog.Dt);
                cmd.Parameters.AddWithValue("@ExecStatement", givenTmLog.ExecStatement);
                cmd.Parameters.AddWithValue("@TableName", givenTmLog.TableName);
                cmd.Parameters.AddWithValue("@FieldName", givenTmLog.FieldName);
                cmd.Parameters.AddWithValue("@FieldNameToShow", givenTmLog.FieldNameToShow);
                cmd.Parameters.AddWithValue("@OldValue", givenTmLog.OldValue);
                cmd.Parameters.AddWithValue("@NewValue", givenTmLog.NewValue);
                cmd.Parameters.AddWithValue("@Section", givenTmLog.Section);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();
        }

        public static void Insert_TMLog(TM_Status oldRec, TM_Status newRec, string section, int mandatoryGroup)
        {
            TmLog tml = new TmLog();
            tml.Section = section;
            tml.Trademarks_Id = oldRec.TmId;
            tml.TM_Status_Id = oldRec.Id;
            tml.AppUsers_Id = UserInfo.DB_AppUser_Id;
            tml.Dt = DateTime.Now;
            tml.ExecStatement = "UPDATE";
            if (newRec.IsDeleted == true)
            {
                tml.ExecStatement = "DELETE";
            }
            tml.TableName = "TM_Status";

            List<TmLogFields> FieldsToCheck = new List<TmLogFields>();

            //[MandatoryGroup]
            //Όλα = 0
            //Κατάθεση = 1
            //Απόφαση = 2
            //Προσφυγή = 3 
            //Ανακοπή = 4
            //Οριστικοποίηση / Ολική Απόρριψη = 5
            //Ανανέωση = 6

            FieldsToCheck.Add(new TmLogFields() { FieldName = "StatusId", FieldNameToShow = "Κατάσταση", MandatoryGroup = 0 });

            FieldsToCheck.Add(new TmLogFields() { FieldName = "DepositDt", FieldNameToShow = "Ημ/νία Κατάθεσης", MandatoryGroup = 1 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "Remarks", FieldNameToShow = "Παρατηρήσεις", MandatoryGroup = 0 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "DecisionNo", FieldNameToShow = "Αρ. Απόφασης", MandatoryGroup = 2 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "DecisionPublDt", FieldNameToShow = "Ημ/νία Δημ. Απόφασης", MandatoryGroup = 2 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "TermCompany", FieldNameToShow = "Ανακόπτουσα Εταιρία", MandatoryGroup = 4 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "FinalizedDt", FieldNameToShow = "Ημ/νία Οριστικοποίησης", MandatoryGroup = 5 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "FinalizedUrl", FieldNameToShow = "Url", MandatoryGroup = 5 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "RenewalApplicationDt", FieldNameToShow = "Ημ/νία Αίτησης Ανανέωσης", MandatoryGroup = 6 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "RenewalDt", FieldNameToShow = "Ημ/νία Ανανέωσης", MandatoryGroup = 6 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "RenewalFees", FieldNameToShow = "Παράβολα Ανανέωσης", MandatoryGroup = 6 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "RenewalProtocol", FieldNameToShow = "Πρωτόκολο Ανανέωσης", MandatoryGroup = 6 });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "IsDeleted", FieldNameToShow = "Flag Διαγραφής", MandatoryGroup = 0 });

            foreach (TmLogFields tmlf in FieldsToCheck)
            {
                object objOld = oldRec.GetType().GetProperty(tmlf.FieldName).GetValue(oldRec, null);
                object objNew = newRec.GetType().GetProperty(tmlf.FieldName).GetValue(newRec, null);
                string strOld = "";
                string strNew = "";
                
                if (objOld != null)
                {
                    strOld = objOld.ToString();
                }
                if (objNew != null)
                {
                    strNew = objNew.ToString();
                }

                if (strOld != strNew && (tmlf.MandatoryGroup == 0 || tmlf.MandatoryGroup == mandatoryGroup))
                {
                    tml.FieldName = tmlf.FieldName;
                    tml.OldValue = strOld;
                    tml.NewValue = strNew;
                    tml.FieldNameToShow = tmlf.FieldNameToShow;

                    Ins_TMLog(tml);
                }
                
            }
        }

        public static void Insert_TMLog(Trademark oldRec, Trademark newRec, string section)
        {
            TmLog tml = new TmLog();
            tml.Section = section;
            tml.Trademarks_Id = oldRec.Id;
            //tml.TM_Status_Id = null;
            tml.AppUsers_Id = UserInfo.DB_AppUser_Id;
            tml.Dt = DateTime.Now;
            tml.ExecStatement = "UPDATE";
            if (newRec.IsDeleted == true)
            {
                tml.ExecStatement = "DELETE";
            }
            tml.TableName = "Trademarks";

            List<TmLogFields> FieldsToCheck = new List<TmLogFields>();

            FieldsToCheck.Add(new TmLogFields() { FieldName = "TMNo", FieldNameToShow = "Αρ. Σήματος" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "DepositDt", FieldNameToShow = "Ημ/νία Κατάθεσης" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "NationalPowerId", FieldNameToShow = "Εθνική Ισχύς" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "TMGrNo", FieldNameToShow = "Αρ. Εθν. Σήματος" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "CompanyId", FieldNameToShow = "Εταιρία" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "ResponsibleLawyerId", FieldNameToShow = "Υπεύθυνος" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "TMName", FieldNameToShow = "Όνομα Σήματος" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "FileName", FieldNameToShow = "Όνομα Αρχείου" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "FileContents", FieldNameToShow = "Αρχείο" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "Description", FieldNameToShow = "Περιγραφή" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "Fees", FieldNameToShow = "Παράβολα" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "ValidTo", FieldNameToShow = "Ισχύς έως" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "TMTypeIds", FieldNameToShow = "Τύποι", FieldType = "List<int>" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "ClassIds", FieldNameToShow = "Κλάσεις", FieldType = "List<int>" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "CountryIds", FieldNameToShow = "Χώρες", FieldType = "List<int>" });
            FieldsToCheck.Add(new TmLogFields() { FieldName = "IsDeleted", FieldNameToShow = "Flag Διαγραφής" });

            foreach (TmLogFields tmlf in FieldsToCheck)
            {
                object objOld = oldRec.GetType().GetProperty(tmlf.FieldName).GetValue(oldRec, null);
                object objNew = newRec.GetType().GetProperty(tmlf.FieldName).GetValue(newRec, null);
                string strOld = "";
                string strNew = "";

                if (tmlf.FieldType == "List<int>")
                {
                    if (objOld != null)
                    {
                        strOld = String.Join(",", ((List<int>)objOld).ToArray());
                    }
                    if (objNew != null)
                    {
                        strNew = String.Join(",", ((List<int>)objNew).ToArray());
                    }

                    if (strOld != strNew)
                    {
                        tml.FieldName = tmlf.FieldName;
                        tml.OldValue = strOld;
                        tml.NewValue = strNew;
                        tml.FieldNameToShow = tmlf.FieldNameToShow;

                        Ins_TMLog(tml);
                    }
                }
                else
                {
                    if (objOld != null)
                    {
                        strOld = objOld.ToString();
                    }
                    if (objNew != null)
                    {
                        strNew = objNew.ToString();
                    }

                    if (strOld != strNew)
                    {
                        tml.FieldName = tmlf.FieldName;
                        tml.OldValue = strOld;
                        tml.NewValue = strNew;
                        tml.FieldNameToShow = tmlf.FieldNameToShow;

                        Ins_TMLog(tml);
                    }
                }

            }
        }
    }

    public class TmLogFields
    {
        public string FieldName { get; set; }
        public string FieldNameToShow { get; set; }
        public string FieldType { get; set; }
        public int MandatoryGroup { get; set; }
    }

    public class Trademark
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
        public DateTime? ValidTo { get; set; }
        public bool IsDeleted { get; set; }

        //public string DecisionNo { get; set; }
        //public DateTime PublicationDate { get; set; }
        //public DateTime FinalizationDate { get; set; }
        //public string Url { get; set; }
        //public bool HasRenewal { get; set; }
        //public DateTime RenewalDt { get; set; }

        public Trademark()
        {
        }

        /*
        public Trademark(int Id)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }
        */

        public Trademark(int givenId)
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], [NationalPowerId], [ResponsibleLawyerId], [CompanyId], [TMGrNo], " +
                              "[FileContents], [FileName], [Description], [Fees], [ValidTo] " +
                              "FROM [dbo].[Trademarks] " +
                              "WHERE Id = @Id " +
                              "ORDER BY Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@Id", givenId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader["Id"].ToString());
                    TMNo = reader["TMNo"].ToString();
                    TMName = reader["TMName"].ToString();
                    DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    NationalPowerId = Convert.ToInt32(reader["NationalPowerId"].ToString());
                    TMGrNo = reader["TMGrNo"].ToString();
                    ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());
                    CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    TMTypeIds = Type.getTM_TypesList(Convert.ToInt32(reader["Id"].ToString()));
                    ClassIds = Class.getTM_ClassList(Convert.ToInt32(reader["Id"].ToString()));
                    CountryIds = Country.getTM_CountriesList(Convert.ToInt32(reader["Id"].ToString()));
                    if (reader["FileContents"] != DBNull.Value)
                    {
                        FileContents = (byte[])reader["FileContents"];
                    }

                    FileName = reader["FileName"].ToString();
                    Description = reader["Description"].ToString();
                    Fees = reader["Fees"].ToString();
                    if (reader["ValidTo"] != DBNull.Value)
                    {
                        ValidTo = Convert.ToDateTime(reader["ValidTo"].ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }

        public string getUrl()
        {
            string ret = "";

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT FinalizedUrl FROM [dbo].[TM_Status] WHERE TrademarksId = @TrademarksId AND StatusId in (7, 8) AND isnull(IsDeleted, 'False') = 'False' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TrademarksId", this.Id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = reader["FinalizedUrl"].ToString();
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

        public static int SelectRefTmRecs(string TMNo)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT count(*) as Cnt " +
                              "FROM [dbo].[Trademarks] " +
                              "WHERE TMGrNo = @TMNo AND isnull(IsDeleted, 'False') = 'False' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TMNo", TMNo);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Cnt"].ToString());
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

        public static bool DisableTM(int TrademarksId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Trademarks] SET IsDeleted = 'True', DelDt = getdate(), DelUser = @DelUser  WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", TrademarksId);

                cmd.Parameters.AddWithValue("@DelUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                //ret = true;
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

        public static bool UpdateTM_ValidTo(int TrademarksId, DateTime ValidTo)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[Trademarks] SET ValidTo = @ValidTo WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", TrademarksId);

                cmd.Parameters.AddWithValue("@ValidTo", ValidTo);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                //ret = true;
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

    public class Status
    {
        public Status()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class TM_Status
    {
        public int Id { get; set; }
        public int TmId { get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }
        public DateTime DepositDt { get; set; }
        public string Remarks { get; set; }
        public string DecisionNo { get; set; }
        public DateTime DecisionPublDt { get; set; }
        public int DecisionRefId { get; set; }
        public DateTime? AppealDt { get; set; }
        public string TermCompany { get; set; }
        public DateTime? TermDt { get; set; }
        public DateTime FinalizedDt { get; set; }
        public string FinalizedUrl { get; set; }
        public DateTime RenewalApplicationDt { get; set; }
        public DateTime RenewalDt { get; set; }
        public string RenewalFees { get; set; }
        public string RenewalProtocol { get; set; }
        public DateTime InsDt { get; set; }
        public bool IsDeleted { get; set; }

        public TM_Status()
        {
            status = new Status();
        }

        public static DateTime? getLastRenewal(int Trademarks_Id)
        {
            DateTime? ret = null;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) TS.RenewalDt " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TS.TrademarksId = @TmId AND TS.StatusId = 9 AND isnull(TS.IsDeleted, 'False') = 'False' " + 
                              "order by TS.RenewalDt desc";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);

                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                    
                   ret = Convert.ToDateTime(reader["RenewalDt"].ToString());
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

        public static TM_Status getLastStatus(int Trademarks_Id)
        {
            TM_Status ret = new TM_Status();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) TS.Id, TS.StatusId, TS.DecisionNo, TS.DecisionPublDt " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TS.TrademarksId = @TmId AND isnull(TS.IsDeleted, 'False') = 'False' " + 
                              "order by TS.Id desc";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);

                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.StatusId = Convert.ToInt32(reader["StatusId"].ToString());
                    ret.DecisionNo = reader["DecisionNo"].ToString();
                    if (reader["DecisionPublDt"] != DBNull.Value)
                    {
                        ret.DecisionPublDt = Convert.ToDateTime(reader["DecisionPublDt"].ToString());
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

        public static TM_Status getLastDecision(int Trademarks_Id)
        {
            TM_Status ret = new TM_Status();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) TS.Id, TS.StatusId, TS.DecisionNo, TS.DecisionPublDt " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TS.TrademarksId = @TmId AND TS.StatusId in (2,3,4) AND isnull(IsDeleted, 'False') = 'False' " + 
                              "ORDER BY TS.Id DESC";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);

                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.StatusId = Convert.ToInt32(reader["StatusId"].ToString());
                    ret.DecisionNo = reader["DecisionNo"].ToString();
                    if (reader["DecisionPublDt"] != DBNull.Value)
                    {
                        ret.DecisionPublDt = Convert.ToDateTime(reader["DecisionPublDt"].ToString());
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

        public static List<int> getAllStatuses(int Trademarks_Id)
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT TS.StatusId " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TS.TrademarksId = @TmId AND isnull(TS.IsDeleted, 'False') = 'False' ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);

                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(Convert.ToInt32(reader["StatusId"].ToString()));                    
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

        public static int SelectRefStatusRecs(int Trademarks_Id, int TMStatus_Id)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT count(*) as Cnt " +
                              "FROM [dbo].[TM_Status] " +
                              "WHERE TrademarksId = @TmId AND DecisionRefId = @TmstatusId AND isnull(IsDeleted, 'False') = 'False' ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);
                cmd.Parameters.AddWithValue("@TmstatusId", TMStatus_Id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Cnt"].ToString());
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

        

        public static bool IsFinalized(int Trademarks_Id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) TS.StatusId, TS.DecisionNo, TS.DecisionPublDt " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TS.TrademarksId = @TmId AND TS.StatusId in (7) AND isnull(IsDeleted, 'False') = 'False' " +
                              "ORDER BY TS.Id DESC";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);

                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = true;
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

        public static int FinalizedOrRejected(int Trademarks_Id)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT top (1) TS.StatusId, TS.DecisionNo, TS.DecisionPublDt " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TS.TrademarksId = @TmId AND TS.StatusId in (7, 8) AND isnull(IsDeleted, 'False') = 'False' " +
                              "ORDER BY TS.Id DESC";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@TmId", Trademarks_Id);

                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["StatusId"].ToString());
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

        public static int InsertTM_Status_Deposit(TM_Status tmstatus)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Status] ([TrademarksId], [StatusId], [DepositDt], [Remarks], [InsUser], [InsDt]) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES " +
                           "(@TrademarksId, @StatusId, @DepositDt, @Remarks, @InsUser, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DepositDt", tmstatus.DepositDt);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                //int rowsAffected = cmd.ExecuteNonQuery();
                //if (rowsAffected > 0)
                //{
                //    ret = true;
                //}

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

        public static int UpdateTM_Status_Deposit(TM_Status tmstatus)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] " +
                           "SET [TrademarksId] = @TrademarksId, [StatusId] = @StatusId, [DepositDt] = @DepositDt, [Remarks] = @Remarks, [UpdUser] = @UpdUser, [UpdDt] = getdate()" +
                           "OUTPUT deleted.Id " + 
                           "WHERE TrademarksId = @TrademarksId AND StatusId = 1 AND isnull(IsDeleted, 'False') = 'False' ";
                           //"WHERE Id = @Id ";
            try
            {
                sqlConn.Open();               
                               
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                //cmd.Parameters.AddWithValue("@Id", tmstatus.Id);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DepositDt", tmstatus.DepositDt);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                //int rowsAffected = cmd.ExecuteNonQuery();
                //if (rowsAffected > 0)
                //{
                //    ret = true;
                //}

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

        public static int InsertTM_Status_Decision(TM_Status tmstatus)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Status] ([TrademarksId], [StatusId], [DecisionNo], [DecisionPublDt], [Remarks], [InsUser], [InsDt]) " +
                           "OUTPUT INSERTED.Id " + 
                           "VALUES " +
                           "(@TrademarksId, @StatusId, @DecisionNo, @DecisionPublDt, @Remarks, @InsUser, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@DecisionPublDt", tmstatus.DecisionPublDt);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                //int rowsAffected = cmd.ExecuteNonQuery();
                //if (rowsAffected > 0)
                //{
                //    ret = true;
                //}

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

        public static bool UpdateTM_Status_Decision(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] " +
                           "SET [TrademarksId] = @TrademarksId, [StatusId] = @StatusId, [DecisionNo] = @DecisionNo, " +
                           "[DecisionPublDt] = @DecisionPublDt, [Remarks] = @Remarks, [UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                           "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", tmstatus.Id);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@DecisionPublDt", tmstatus.DecisionPublDt);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

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

        public static bool DisableTM_Status(int givenId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] SET IsDeleted = 'True', DelDt = getdate(), DelUser = @DelUser WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", givenId);

                cmd.Parameters.AddWithValue("@DelUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                //ret = true;
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

        public static bool InsertTM_Status_Appeal(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Status] ([TrademarksId], [StatusId], [DecisionNo], [DecisionRefId], [AppealDt], [Remarks], [InsUser], [InsDt]) VALUES " +
                           "(@TrademarksId, @StatusId, @DecisionNo, @DecisionRefId, @AppealDt, @Remarks, @InsUser, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@DecisionRefId", tmstatus.DecisionRefId);
                if (tmstatus.AppealDt == null)
                {
                    cmd.Parameters.AddWithValue("@AppealDt", DBNull.Value); 
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AppealDt", tmstatus.AppealDt);
                }                
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
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

        public static bool UpdateTM_Status_Appeal(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] " +
                           "SET [TrademarksId] = @TrademarksId, [StatusId] = @StatusId, [DecisionNo] = @DecisionNo, [DecisionRefId] = @DecisionRefId, " + 
                           "[AppealDt] = @AppealDt, [Remarks] = @Remarks, [UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                           "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", tmstatus.Id);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@DecisionRefId", tmstatus.DecisionRefId);
                if (tmstatus.AppealDt == null)
                {
                    cmd.Parameters.AddWithValue("@AppealDt", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AppealDt", tmstatus.AppealDt);
                }
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

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

        public static bool InsertTM_Status_Termination(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Status] ([TrademarksId], [StatusId], [DecisionNo], [DecisionRefId], [Remarks], [TermCompany], [TermDt], [InsUser], [InsDt]) VALUES " +
                           "(@TrademarksId, @StatusId, @DecisionNo, @DecisionRefId, @Remarks, @TermCompany, @TermDt, @InsUser, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@DecisionRefId", tmstatus.DecisionRefId);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                if (tmstatus.TermDt == null)
                {
                    cmd.Parameters.AddWithValue("@TermDt", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TermDt", tmstatus.TermDt);
                }
                cmd.Parameters.AddWithValue("@TermCompany", tmstatus.TermCompany);
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

        public static bool UpdateTM_Status_Termination(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] " +
                           "SET [TrademarksId] = @TrademarksId, [StatusId] = @StatusId, [DecisionNo] = @DecisionNo, [DecisionRefId] = @DecisionRefId, " +
                           "[Remarks] = @Remarks, [TermCompany] = @TermCompany, [TermDt] = @TermDt, [UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                           "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", tmstatus.Id);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@DecisionRefId", tmstatus.DecisionRefId);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                if (tmstatus.TermDt == null)
                {
                    cmd.Parameters.AddWithValue("@TermDt", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TermDt", tmstatus.TermDt);
                }
                cmd.Parameters.AddWithValue("@TermCompany", tmstatus.TermCompany);
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

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

        public static int InsertTM_Status_Finalization(TM_Status tmstatus)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Status] ([TrademarksId], [StatusId], [DecisionNo], [Remarks], [FinalizedDt], [FinalizedUrl], [InsUser], [InsDt]) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES " +  
                           "(@TrademarksId, @StatusId, @DecisionNo, @Remarks, @FinalizedDt, @FinalizedUrl, @InsUser, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@FinalizedDt", tmstatus.FinalizedDt);
                cmd.Parameters.AddWithValue("@FinalizedUrl", tmstatus.FinalizedUrl);
                cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                //int rowsAffected = cmd.ExecuteNonQuery();
                //if (rowsAffected > 0)
                //{
                //    ret = true;
                //}

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

        public static bool UpdateTM_Status_Finalization(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] " +
                           "SET [TrademarksId] = @TrademarksId, [StatusId] = @StatusId, [DecisionNo] = @DecisionNo, [Remarks] = @Remarks, [FinalizedDt] = @FinalizedDt, " +
                           "[FinalizedUrl] = @FinalizedUrl, [UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                           "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", tmstatus.Id);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@DecisionNo", tmstatus.DecisionNo);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@FinalizedDt", tmstatus.FinalizedDt);
                cmd.Parameters.AddWithValue("@FinalizedUrl", tmstatus.FinalizedUrl);
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

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

        public static int InsertTM_Status_Renewal(TM_Status tmstatus)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[TM_Status] ([TrademarksId], [StatusId], [Remarks], [RenewalApplicationDt], [RenewalDt], [RenewalFees], [RenewalProtocol], [InsUser], [InsDt]) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES " +
                           "(@TrademarksId, @StatusId, @Remarks, @RenewalApplicationDt, @RenewalDt, @RenewalFees, @RenewalProtocol, @InsUser, getdate()) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@RenewalApplicationDt", tmstatus.RenewalApplicationDt);
                cmd.Parameters.AddWithValue("@RenewalDt", tmstatus.RenewalDt);
                cmd.Parameters.AddWithValue("@RenewalFees", tmstatus.RenewalFees);
                cmd.Parameters.AddWithValue("@RenewalProtocol", tmstatus.RenewalProtocol);
                cmd.Parameters.AddWithValue("@InsUser", UserInfo.DB_AppUser_Id);

                cmd.CommandType = CommandType.Text;
                //int rowsAffected = cmd.ExecuteNonQuery();
                //if (rowsAffected > 0)
                //{
                //    ret = true;
                //}

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

        public static bool UpdateTM_Status_Renewal(TM_Status tmstatus)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "UPDATE [dbo].[TM_Status] " +
                           "SET [TrademarksId] = @TrademarksId, [StatusId] = @StatusId, [Remarks] = @Remarks, [RenewalApplicationDt] = @RenewalApplicationDt, " +
                           "[RenewalDt] = @RenewalDt, [RenewalFees] = @RenewalFees, [RenewalProtocol] = @RenewalProtocol, [UpdUser] = @UpdUser, [UpdDt] = getdate() " +
                           "WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", tmstatus.Id);

                cmd.Parameters.AddWithValue("@TrademarksId", tmstatus.TmId);
                cmd.Parameters.AddWithValue("@StatusId", tmstatus.StatusId);
                cmd.Parameters.AddWithValue("@Remarks", tmstatus.Remarks);
                cmd.Parameters.AddWithValue("@RenewalApplicationDt", tmstatus.RenewalApplicationDt);
                cmd.Parameters.AddWithValue("@RenewalDt", tmstatus.RenewalDt);
                cmd.Parameters.AddWithValue("@RenewalFees", tmstatus.RenewalFees);
                cmd.Parameters.AddWithValue("@RenewalProtocol", tmstatus.RenewalProtocol);
                cmd.Parameters.AddWithValue("@UpdUser", UserInfo.DB_AppUser_Id);

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


}
