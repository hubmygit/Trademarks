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
    public partial class InsertGrTM : Form
    {
        public InsertGrTM() //insert 
        {
            InitializeComponent();

            Init();

            isInsert = true;

            //cbLawyerFullname.SelectedIndex = cbLawyerFullname.FindStringExact(Responsible.getResponsibleName(3));
            //InsUser = Responsible Lawyer
        }

        public InsertGrTM(int xxxxxx) //update
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (txtTMId.Text.Trim() == "" || cbLawyerFullname.Text == "" || cbCompany.Text == "" || IsAnyTypeChecked(dgvTypes) == false ||
                txtTMName.Text.Trim() == "" || IsAnyClassChecked(dgvClasses) == false)
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
            //NewRecord.CountryIds = getCheckedCountries(dgvCountries);
            NewRecord.Description = txtDescription.Text;
            NewRecord.Fees = txtFees.Text;
            //NewRecord.DecisionNo = txtDecisionNo.Text;
            //NewRecord.PublicationDate = dtpPublicationDate.Value;
            //NewRecord.FinalizationDate = dtpFinalization.Value;
            //NewRecord.Url = txtUrl.Text;
            //NewRecord.HasRenewal = chbHasRenewal.Checked;
            //NewRecord.RenewalDt = renewalDatetime;

            NewRecord.Id = TempRecUpdId;

            if (isInsert)
            {
                //Save
                bool successful = true;
                //int InsertedId = InsertTrademark(NewRecord);
                //if (InsertedId > 0)
                //{
                //    NewRecord.Id = InsertedId;

                //    foreach (int TM_typeId in NewRecord.TMTypeIds)
                //    {
                //        if (Type.InsertTM_Type(InsertedId, TM_typeId) == false)
                //        {
                //            //TM_Type ins error
                //            successful = false;
                //        }
                //    }

                //    foreach (int TM_classId in NewRecord.ClassIds)
                //    {
                //        if (Class.InsertTM_Class(InsertedId, TM_classId) == false)
                //        {
                //            //TM_Class ins error
                //            successful = false;
                //        }
                //    }

                //    foreach (int TM_countryId in NewRecord.CountryIds)
                //    {
                //        if (Country.InsertTM_Country(InsertedId, TM_countryId) == false)
                //        {
                //            //TM_Country ins error
                //            successful = false;
                //        }
                //    }
                //}
                //else
                //{
                //    //TM ins error
                //    successful = false;
                //}

                ////Alarms
                //if (successful)
                //{
                //    if (CreateAlarms(NewRecord) == false)
                //    {
                //        MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");

                //        Close();
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                //}
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
