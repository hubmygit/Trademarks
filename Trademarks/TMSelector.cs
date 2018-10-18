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
    public partial class TMSelector : Form
    {
        public TMSelector()
        {
            InitializeComponent();

            tempRecList = SelectTempRecs();

            FillDataGridView(dgvTempRecs, tempRecList);

            cbCompany.SelectedIndex = 0;
            cbCompany.Items.AddRange(Company.GetCompaniesComboboxItemsList(companyList).ToArray<ComboboxItem>());

            cbLawyerFullname.SelectedIndex = 0;
            cbLawyerFullname.Items.AddRange(Responsible.GetResponsibleComboboxItemsList(responsibleList).ToArray<ComboboxItem>());

            cbNatPower.SelectedIndex = 0;
            cbNatPower.Items.AddRange(NationalPower.GetNationalPowerComboboxItemsList(nationalPowerList).ToArray<ComboboxItem>());
        }

        public List<Trademark> tempRecList = new List<Trademark>();
        public List<Company> companyList = Company.getCompanyList();
        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<NationalPower> nationalPowerList = NationalPower.getNationalPowerListList();

        public List<Trademark> SelectTempRecs()
        {
            List<Trademark> ret = new List<Trademark>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], [FileContents], " +
                              "[FileName], [Description], [Fees], isnull([IsDeleted], 'False') as IsDeleted " +
                              "FROM [dbo].[Trademarks] " +
                              //"WHERE isnull(IsDeleted, 'False') = 'False'" +
                              "ORDER BY [TMNo] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Trademark tmpRec = new Trademark();

                    tmpRec.Id = Convert.ToInt32(reader["Id"].ToString());
                    tmpRec.TMNo = reader["TMNo"].ToString();
                    tmpRec.TMName = reader["TMName"].ToString();
                    tmpRec.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    tmpRec.NationalPowerId = Convert.ToInt32(reader["NationalPowerId"].ToString());
                    tmpRec.TMGrNo = reader["TMGrNo"].ToString();
                    tmpRec.ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());
                    tmpRec.CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    tmpRec.TMTypeIds = Type.getTM_TypesList(Convert.ToInt32(reader["Id"].ToString()));
                    tmpRec.ClassIds = Class.getTM_ClassList(Convert.ToInt32(reader["Id"].ToString()));
                    tmpRec.CountryIds = Country.getTM_CountriesList(Convert.ToInt32(reader["Id"].ToString()));
                    if (reader["FileContents"] != DBNull.Value)
                    {
                        tmpRec.FileContents = (byte[])reader["FileContents"];
                    }

                    tmpRec.FileName = reader["FileName"].ToString();
                    tmpRec.Description = reader["Description"].ToString();
                    tmpRec.Fees = reader["Fees"].ToString();
                    tmpRec.IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString());

                    ret.Add(tmpRec);
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

        

        public static void FillDataGridView(DataGridView dgv, List<Trademark> TempRecList)
        {
            dgv.Rows.Clear();

            foreach (Trademark thisRecord in TempRecList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "tmp_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMNo, dgvColumnHeader = "tmp_No" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMName, dgvColumnHeader = "tmp_Name" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_DepositDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = NationalPower.getNationalPowerName(thisRecord.NationalPowerId), dgvColumnHeader = "tmp_NatPower" });
                dgvDictList.Add(new dgvDictionary() { dbfield = Responsible.getResponsibleName(thisRecord.ResponsibleLawyerId), dgvColumnHeader = "tmp_Responsible" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMGrNo, dgvColumnHeader = "tmp_GrNo" });
                dgvDictList.Add(new dgvDictionary() { dbfield = Company.getCompanyName(thisRecord.CompanyId), dgvColumnHeader = "tmp_Com" });
                dgv.Columns["tmp_Pic"].DefaultCellStyle.NullValue = null;
                string fn = System.IO.Path.GetExtension(thisRecord.FileName);
                if ((thisRecord.FileContents != null) && (fn == ".gif" || fn == ".jpg" || fn == ".jpeg" || fn == ".bmp" || fn == ".wmf" || fn == ".png"))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FileContents, dgvColumnHeader = "tmp_Pic" }); //???
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsDeleted, dgvColumnHeader = "tmp_IsDeleted" });

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

        private void dgvTempRecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvTempRecs.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvTempRecs.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void tsmiDecision_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForDecision(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiAppeal_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForAppeal(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiTermination_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForTermination(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiFinalization_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForFinalization(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiRenewal_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForRenewal(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiStatusViewer_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                //Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                StatusViewer frmStatViewer = new StatusViewer(Id);
                frmStatViewer.ShowDialog();

                //refresh...deposit updates or deletions
                //tempRecList[tempRecList.FindIndex(w => w.Id == Id)] = frmUpdTm.NewRecord;

                //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiAlertsViewer_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                //Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                TMAlertsViewer frmAlertViewer = new TMAlertsViewer(Id);
                frmAlertViewer.ShowDialog();

            }
        }

        private void tsmiUpdTM_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvTempRecs.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να ενημερώσετε την εγγραφή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να ενημερώσετε την εγγραφή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                InsertTM frmUpdTm = new InsertTM(tm);
                frmUpdTm.ShowDialog();

                if (frmUpdTm.success)
                {
                    //refresh
                    //tempRecList[tempRecList.FindIndex(w => w.Id == Id)] = frmUpdTm.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tempRecList = SelectTempRecs();
                    FillDataGridView(dgvTempRecs, tempRecList);
                }
            }
        }

        private void tsmiDelTM_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvTempRecs.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();
                bool success = true;

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την εγγραφή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //check references
                if (Trademark.SelectRefTmRecs(tm.TMNo)  > 0)
                {
                    MessageBox.Show("Προσοχή! Δεν είναι δυνατή η διαγραφή της επιλεγμένης εγγραφής! \r\nΥπάρχουν άλλες εγγραφές (Διεθνή / Κοινοτικά Σήματα) που αναφέρονται σε αυτήν.");
                    return;
                }

                TM_Status tms = TM_Status.getLastDecision(tm.Id);
                if (tms.StatusId == 2 && tms.StatusId == 3 && tms.StatusId == 4) //check oti exei apofasi
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την εγγραφή. \r\nΥπάρχει καταχωρημένη Aπόφαση.");
                    return;
                }
                
                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε το Σήμα: \r\n" +
                              tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;", 
                              "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                      
                    //disable Tasks
                    if (Task.DisableNotSentTasks(tm.Id) == false)
                    {
                        success = false;
                    }
                    
                    //delete from Trademarks (make inactive, mark as deleted)
                    if (Trademark.DisableTM(tm.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new Trademark() { Id = tm.Id, IsDeleted = false }, new Trademark() { Id = tm.Id, IsDeleted = true }, "Κατάθεση");
                        
                        //refresh
                        //tempRecList[tempRecList.FindIndex(w => w.Id == Id)] = frmUpdTm.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tempRecList = SelectTempRecs();
                        FillDataGridView(dgvTempRecs, tempRecList);
                    }

                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Trademark> filteredRecs = tempRecList;
            if (txtTMId.Text.Trim() != "")
            {
                filteredRecs = filteredRecs.Where(i => i.TMNo.IndexOf(txtTMId.Text, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            if (txtTMName.Text.Trim() != "")
            {
                filteredRecs = filteredRecs.Where(i => i.TMName.IndexOf(txtTMName.Text, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            if (cbCompany.SelectedIndex > 0)
            {
                filteredRecs = filteredRecs.Where(i => i.CompanyId == ComboboxItem.getComboboxItem<Company>(cbCompany).Id).ToList();
            }

            if (cbLawyerFullname.SelectedIndex > 0)
            {
                filteredRecs = filteredRecs.Where(i => i.ResponsibleLawyerId == ComboboxItem.getComboboxItem<Responsible>(cbLawyerFullname).Id).ToList();
            }

            if (cbNatPower.SelectedIndex > 0)
            {
                filteredRecs = filteredRecs.Where(i => i.NationalPowerId == ComboboxItem.getComboboxItem<NationalPower>(cbNatPower).Id).ToList();
            }

            if (chbDeleted.CheckState != CheckState.Indeterminate)
            {
                filteredRecs = filteredRecs.Where(i => i.IsDeleted == chbDeleted.Checked).ToList();
            }

            FillDataGridView(dgvTempRecs, filteredRecs);
        }

        private void dgvTempRecs_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "tmp_DepositDt")// || e.Column.Name == "tmp_RenewalDt")
            {
                string dtA = "";
                string dtB = "";

                if (e.CellValue1 != null && e.CellValue1.ToString().Trim() != "")
                {
                    dtA = Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss");
                }

                if (e.CellValue2 != null && e.CellValue2.ToString().Trim() != "")
                {
                    dtB = Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss");
                }

                //e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss"),
                //                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss"));

                e.SortResult = System.String.Compare(dtA, dtB);

                e.Handled = true;
            }
        }

        private void dgvTempRecs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                string url = thisTmpRec.getUrl();

                if (url.Trim() != "")
                {
                    System.Diagnostics.Process.Start(url);
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχει καταχωρημένο Url για τη συγκεκριμένη εγγραφή!");
                }
            }
        }

        private void tsmiOpenUrl_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                string url = thisTmpRec.getUrl();

                if (url.Trim() != "")
                {
                    System.Diagnostics.Process.Start(url);
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχει καταχωρημένο Url για τη συγκεκριμένη εγγραφή!");
                }
            }
        }
        
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            InsertTM frmInsTm = new InsertTM();
            frmInsTm.ShowDialog();

            if (frmInsTm.success)
            {
                //refresh
                //tempRecList[tempRecList.FindIndex(w => w.Id == Id)] = frmUpdTm.NewRecord;

                //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }



        private void tsmiViewTM_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                InsertTM frmViewTm = new InsertTM(thisTmpRec);
                frmViewTm.MakeAllControlsReadOnly(frmViewTm);
                frmViewTm.GetFromGridOnlyChecked();

                frmViewTm.btnSave.Enabled = false;
                frmViewTm.ShowDialog();
            }
        }

        private void tsmiTmLog_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε δείτε το Log μεταβολών της εγγραφής. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                TmUpdLog frmViewLog = new TmUpdLog(tm.Id);
                frmViewLog.ShowDialog();
            }
        }

    }
}
