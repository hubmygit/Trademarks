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
    public partial class StatusViewer : Form
    {
        public StatusViewer()
        {
            InitializeComponent();
        }

        public StatusViewer(int TmId)
        {
            InitializeComponent();

            tmStatusList = SelectTmStatusRecs(TmId);
            FillDataGridView(dgvStatusViewer, tmStatusList);
        }

        public List<TM_Status> tmStatusList = new List<TM_Status>();

        public List<TM_Status> SelectTmStatusRecs(int tm_Id)
        {
            List<TM_Status> ret = new List<TM_Status>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TrademarksId], [StatusId], (SELECT S.Name FROM Status S WHERE S.Id = TS.StatusId) as Status_Name, [DepositDt], " +
                              "[DecisionNo], [DecisionPublDt], [TermCompany], [FinalizedDt], [FinalizedUrl], [RenewalApplicationDt], [RenewalDt], [RenewalFees], [RenewalProtocol], [Remarks], [InsDt] " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TrademarksId = @TmId AND isnull(IsDeleted, 'False') = 'False' " +
                              "ORDER BY Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TmId", tm_Id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TM_Status stat = new TM_Status();

                    stat.Id = Convert.ToInt32(reader["Id"].ToString());
                    stat.TmId = Convert.ToInt32(reader["TrademarksId"].ToString());
                    stat.StatusId = Convert.ToInt32(reader["StatusId"].ToString());
                    stat.status.Id = Convert.ToInt32(reader["StatusId"].ToString());
                    stat.status.Name = reader["Status_Name"].ToString();
                    if (reader["DepositDt"] != DBNull.Value)
                    {
                        stat.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    }
                    stat.DecisionNo = reader["DecisionNo"].ToString();
                    if (reader["DecisionPublDt"] != DBNull.Value)
                    {
                        stat.DecisionPublDt = Convert.ToDateTime(reader["DecisionPublDt"].ToString());
                    }
                    stat.TermCompany = reader["TermCompany"].ToString();
                    if (reader["FinalizedDt"] != DBNull.Value)
                    {
                        stat.FinalizedDt = Convert.ToDateTime(reader["FinalizedDt"].ToString());
                    }
                    stat.FinalizedUrl = reader["FinalizedUrl"].ToString();
                    if (reader["RenewalApplicationDt"] != DBNull.Value)
                    {
                        stat.RenewalApplicationDt = Convert.ToDateTime(reader["RenewalApplicationDt"].ToString());
                    }
                    if (reader["RenewalDt"] != DBNull.Value)
                    {
                        stat.RenewalDt = Convert.ToDateTime(reader["RenewalDt"].ToString());
                    }
                    stat.RenewalFees = reader["RenewalFees"].ToString();
                    stat.RenewalProtocol = reader["RenewalProtocol"].ToString();
                    stat.Remarks = reader["Remarks"].ToString();
                    stat.InsDt = Convert.ToDateTime(reader["InsDt"].ToString());

                    ret.Add(stat);
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

        public static void FillDataGridView(DataGridView dgv, List<TM_Status> TempRecList)
        {
            dgv.Rows.Clear();

            foreach (TM_Status thisRecord in TempRecList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "st_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TmId, dgvColumnHeader = "st_TmId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.status.Name, dgvColumnHeader = "st_Name" });
                if (thisRecord.DepositDt != null && thisRecord.DepositDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_DepositDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DecisionNo, dgvColumnHeader = "st_DecisionNo" });
                if (thisRecord.DecisionPublDt != null && thisRecord.DecisionPublDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DecisionPublDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_DecisionDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TermCompany, dgvColumnHeader = "st_TermCom" });
                if (thisRecord.FinalizedDt != null && thisRecord.FinalizedDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FinalizedDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_FinalizedDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FinalizedUrl, dgvColumnHeader = "st_FinalizedUrl" });
                if (thisRecord.RenewalApplicationDt != null && thisRecord.RenewalApplicationDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RenewalApplicationDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_RenewalApplicationDt" });
                }
                if (thisRecord.RenewalDt != null && thisRecord.RenewalDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RenewalDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_RenewalDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RenewalFees, dgvColumnHeader = "st_RenewalFees" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RenewalProtocol, dgvColumnHeader = "st_RenewalProtocol" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Remarks, dgvColumnHeader = "st_Remarks" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.InsDt, dgvColumnHeader = "st_InsDt" });


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
        
        private void dgvStatusViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvStatusViewer.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvStatusViewer.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void tsmiUpdDecision_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                if (tms.StatusId != 2 && tms.StatusId != 3 && tms.StatusId != 4)
                {
                    MessageBox.Show("Δεν είναι Απόφαση...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId); 

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Απόφαση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Απόφαση. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                Decision frmUpdDecision = new Decision(tm, tms);
                frmUpdDecision.ShowDialog();

                if (frmUpdDecision.success)
                {
                    //refresh
                    //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdDecision.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tmStatusList = SelectTmStatusRecs(tms.TmId);
                    FillDataGridView(dgvStatusViewer, tmStatusList);
                }

            }
        }

        private void tsmiUpdAppeal_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                if (tms.StatusId != 5)
                {
                    MessageBox.Show("Δεν είναι Προσφυγή...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Προσφυγή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Προσφυγή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                TM_Status prevTms = TM_Status.getLastDecision(tm.Id);

                Appeal frmUpdAppeal = new Appeal(tm, prevTms, tms);
                frmUpdAppeal.ShowDialog();

                if (frmUpdAppeal.success)
                {
                    //refresh
                    //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdAppeal.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tmStatusList = SelectTmStatusRecs(tms.TmId);
                    FillDataGridView(dgvStatusViewer, tmStatusList);
                }

            }
        }

        private void tsmiUpdTermination_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                if (tms.StatusId != 6)
                {
                    MessageBox.Show("Δεν είναι Ανακοπή...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Ανακοπή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Ανακοπή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                TM_Status prevTms = TM_Status.getLastDecision(tm.Id);

                Termination frmUpdTermination = new Termination(tm, prevTms, tms);
                frmUpdTermination.ShowDialog();

                if (frmUpdTermination.success)
                {
                    //refresh
                    //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdTermination.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tmStatusList = SelectTmStatusRecs(tms.TmId);
                    FillDataGridView(dgvStatusViewer, tmStatusList);
                }

            }
        }

        private void tsmiUpdFinalization_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                if (tms.StatusId != 7 && tms.StatusId != 8)
                {
                    MessageBox.Show("Δεν είναι Οριστικοποίηση (ή Απόρριψη)...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Οριστικοποίηση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                TM_Status prevTms = TM_Status.getLastDecision(tm.Id);

                Finalization frmUpdFinalization = new Finalization(tm, prevTms, tms);
                frmUpdFinalization.ShowDialog();

                if (frmUpdFinalization.success)
                {
                    //refresh
                    //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdFinalization.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tmStatusList = SelectTmStatusRecs(tms.TmId);
                    FillDataGridView(dgvStatusViewer, tmStatusList);
                }

            }
        }

        private void tsmiUpdRenewal_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                if (tms.StatusId != 9)
                {
                    MessageBox.Show("Δεν είναι Ανανέωση...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Οριστικοποίηση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //TM_Status prevTms = TM_Status.getLastDecision(tm.Id);

                Renewal frmUpdRenewal = new Renewal(tm, tms);
                frmUpdRenewal.ShowDialog();

                if (frmUpdRenewal.success)
                {
                    //refresh
                    //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdRenewal.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tmStatusList = SelectTmStatusRecs(tms.TmId);
                    FillDataGridView(dgvStatusViewer, tmStatusList);
                }

            }
        }

        private void tsmiDelDecision_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true; 

                if (tms.StatusId != 2 && tms.StatusId != 3 && tms.StatusId != 4)
                {
                    MessageBox.Show("Δεν είναι Απόφαση...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Απόφαση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //check references
                if (TM_Status.SelectRefStatusRecs(tm.Id, tms.Id) > 0)
                {
                    MessageBox.Show("Προσοχή! Δεν είναι δυνατή η διαγραφή της επιλεγμένης εγγραφής! \r\nΥπάρχουν άλλες εγγραφές (Προσφυγές ή Ανακοπές) που αναφέρονται σε αυτήν.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Απόφαση. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε την Απόφαση: " + tms.DecisionNo + " / " + tms.DecisionPublDt.ToString("dd.MM.yyyy") +
                                    "\r\nΤου Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;",
                                    "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //disable decision->appeal Tasks 
                    if (Task.DisableNotSentTasks(tm.Id, 4) == false) //Προσφυγής
                    {
                        success = false;
                    }

                    //disable decision->finalization Tasks 
                    if (Task.DisableNotSentTasks(tm.Id, 3) == false) //Οριστικοποίησης
                    {
                        success = false;
                    }

                    //delete from TM_Status (make inactive, mark as deleted)
                    if (TM_Status.DisableTM_Status(tms.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = false }, new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = true }, "Απόφαση", 2);
                        
                        //refresh
                        //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdRenewal.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tmStatusList = SelectTmStatusRecs(tms.TmId);
                        FillDataGridView(dgvStatusViewer, tmStatusList);
                    }
                    
                }

            }
        }

        private void tsmiDelAppeal_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                if (tms.StatusId != 5)
                {
                    MessageBox.Show("Δεν είναι Προσφυγή...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Προσφυγή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Προσφυγή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε την Προσφυγή της απόφασης: " + tms.DecisionNo + " / " + tms.DecisionPublDt.ToString("dd.MM.yyyy") +
                                    //"\r\nΤου Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;",
                                    "\r\nΤου Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΕίστε σίγουροι;",
                                    "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //delete from TM_Status (make inactive, mark as deleted)
                    if (TM_Status.DisableTM_Status(tms.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = false }, new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = true }, "Προσφυγή", 3);

                        //refresh
                        //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdRenewal.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tmStatusList = SelectTmStatusRecs(tms.TmId);
                        FillDataGridView(dgvStatusViewer, tmStatusList);
                    }


                }


            }
        }

        private void tsmiDelTermination_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                if (tms.StatusId != 6)
                {
                    MessageBox.Show("Δεν είναι Ανακοπή...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Ανακοπή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Ανακοπή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε την Ανακοπή της απόφασης: " + tms.DecisionNo + " / " + tms.DecisionPublDt.ToString("dd.MM.yyyy") +
                                    //"\r\nΤου Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;",
                                    "\r\nΤου Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΕίστε σίγουροι;",
                                    "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //delete from TM_Status (make inactive, mark as deleted)
                    if (TM_Status.DisableTM_Status(tms.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = false }, new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = true }, "Ανακοπή", 4);

                        //refresh
                        //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdRenewal.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tmStatusList = SelectTmStatusRecs(tms.TmId);
                        FillDataGridView(dgvStatusViewer, tmStatusList);
                    }

                }
                                          
            }
        }

        private void tsmiDelFinalization_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                if (tms.StatusId != 7 && tms.StatusId != 8)
                {
                    MessageBox.Show("Δεν είναι Οριστικοποίηση (ή Απόρριψη)...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Οριστικοποίηση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.getLastRenewal(tm.Id) != null) //Πρέπει να μην έχει Ανανέωση
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Οριστικοποίηση. \r\nΥπάρχει ήδη Ανανέωση!");
                    return;
                }


                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε την Οριστικοποίηση του Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;",
                                    "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //disable finalization->Renewal Tasks 
                    if (Task.DisableNotSentTasks(tm.Id, 1) == false) //Ανανέωσης
                    {
                        success = false;
                    }

                    //delete from TM_Status (make inactive, mark as deleted)
                    if (TM_Status.DisableTM_Status(tms.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = false }, new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = true }, "Οριστικοποίηση", 5);

                        //refresh
                        //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdRenewal.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tmStatusList = SelectTmStatusRecs(tms.TmId);
                        FillDataGridView(dgvStatusViewer, tmStatusList);

                    }

                }


            }
        }

        private void tsmiDelRenewal_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                if (tms.StatusId != 9)
                {
                    MessageBox.Show("Δεν είναι Ανανέωση...!");
                    return;
                }

                Trademark tm = new Trademark(tms.TmId);

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την Ανανέωση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε την Ανανέωση του Σήματος: " + tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;",
                                    "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //disable renewal->Renewal Tasks 
                    if (Task.DisableNotSentTasks(tm.Id, 1) == false) //Ανανέωσης
                    {
                        success = false;
                    }

                    //delete from TM_Status (make inactive, mark as deleted)
                    if (TM_Status.DisableTM_Status(tms.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = false }, new TM_Status() { Id = tms.Id, TmId = tms.TmId, IsDeleted = true }, "Ανανέωση", 6);

                        //refresh
                        //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdRenewal.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tmStatusList = SelectTmStatusRecs(tms.TmId);
                        FillDataGridView(dgvStatusViewer, tmStatusList);

                    }



                }
            }
        }
    }
}
