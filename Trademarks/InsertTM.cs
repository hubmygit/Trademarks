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

        public InsertTM(int xxxxxx) //update
        {
            InitializeComponent();

            Init();

            isInsert = false;
        }
        
        public bool isInsert = false;
        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Responsible> secretariesList = Responsible.getSecretariesList();
        public List<Company> companyList = Company.getCompanyList();
        ToolTip classTooltip = new ToolTip();
        public bool success = false;
        //public Trademark OldRecord = new Trademark();
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

        private bool CreateDecisionAlarms(Trademark TMRecord)
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 2; //Απόφαση σε εκκρεμότητα

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId);

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
                ((rbKoinotiko.Checked || rbDiethnes.Checked) && txtTMGrId.Text.Trim() == "") || (rbDiethnes.Checked && IsAnyCountryChecked(dgvCountries) == false))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!");
                return;
            }

            DateTime depositDatetime = new DateTime(dtpDepositDt.Value.Year, dtpDepositDt.Value.Month, dtpDepositDt.Value.Day,
                                                    dtpDepositTime.Value.Hour, dtpDepositTime.Value.Minute, dtpDepositTime.Value.Second);

            NewRecord = new Trademark();

            NewRecord.TMNo = txtTMId.Text;
            NewRecord.DepositDt = depositDatetime;
            NewRecord.NationalPowerId = 1; //Εθνικό
            NewRecord.TMGrNo = ""; //NULL ????
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
                    //if (CreateAlarms(NewRecord) == false)
                    if(CreateDecisionAlarms(NewRecord) == false)
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

    }


}
