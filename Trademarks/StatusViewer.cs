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

            Trademark tm = new Trademark(TmId);
            txtTMId.Text = tm.TMNo;
            txtTMName.Text = tm.TMName;
            if (tm.NationalPowerId == 1) //1 Εθνικό
            {
                rbEthniko.Checked = true;
            }
            else if (tm.NationalPowerId == 2) //2 Κοινοτικό
            {
                rbKoinotiko.Checked = true;
            }
            else if (tm.NationalPowerId == 3) //3 Διεθνές
            {
                rbDiethnes.Checked = true;
            }
        }

        public List<TM_Status> tmStatusList = new List<TM_Status>();

        public List<TM_Status> SelectTmStatusRecs(int tm_Id)
        {
            List<TM_Status> ret = new List<TM_Status>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TrademarksId], [StatusId], (SELECT S.Name FROM Status S WHERE S.Id = TS.StatusId) as Status_Name, [DepositDt], " +
                              "[DecisionNo], [DecisionPublDt], [AppealDt], [TermCompany], [TermDt], [FinalizedDt], [FinalizedUrl], [RenewalApplicationDt], [RenewalDt], [RenewalFees], [RenewalProtocol], [Remarks], [InsDt] " +
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
                    if (reader["AppealDt"] != DBNull.Value)
                    {
                        stat.AppealDt = Convert.ToDateTime(reader["AppealDt"].ToString());
                    }
                    stat.TermCompany = reader["TermCompany"].ToString();
                    if (reader["TermDt"] != DBNull.Value)
                    {
                        stat.TermDt = Convert.ToDateTime(reader["TermDt"].ToString());
                    }
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
                if(thisRecord.AppealDt != null && thisRecord.AppealDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = ((DateTime)thisRecord.AppealDt).ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_AppealDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TermCompany, dgvColumnHeader = "st_TermCom" });
                if (thisRecord.TermDt != null && thisRecord.TermDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = ((DateTime)thisRecord.TermDt).ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "st_TermDt" });
                }
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
        }
        private void UpdDecision()
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                //if (tms.StatusId != 2 && tms.StatusId != 3 && tms.StatusId != 4)
                //{
                //    MessageBox.Show("Δεν είναι Απόφαση...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Απόφαση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                TM_Status lastDec = TM_Status.getLastDecision(tm.Id);
                //if (lastDec != null && lastDec.Id != tms.Id)
                if (lastDec.Id != tms.Id)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Απόφαση. \r\nΈχει καταχωρηθεί νεότερη απόφαση!");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Απόφαση. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
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
        }

        private void UpdAppeal()
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                //if (tms.StatusId != 5)
                //{
                //    MessageBox.Show("Δεν είναι Προσφυγή...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Προσφυγή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                //{
                //    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Προσφυγή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                //    return;
                //}

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
        }

        private void UpdTermination()
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                //if (tms.StatusId != 6)
                //{
                //    MessageBox.Show("Δεν είναι Ανακοπή...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Ανακοπή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                //{
                //    MessageBox.Show("Προσοχή! Δεν μπορείτε να καταχωρήσετε Ανακοπή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                //    return;
                //}

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
        }

        private void UpdFinalization()
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                //if (tms.StatusId != 7 && tms.StatusId != 8)
                //{
                //    MessageBox.Show("Δεν είναι Οριστικοποίηση (ή Απόρριψη)...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Οριστικοποίηση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
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
        }

        private void UpdRenewal()
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

                //if (tms.StatusId != 9)
                //{
                //    MessageBox.Show("Δεν είναι Ανανέωση...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να μεταβάλετε την Ανανέωση. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //check oti paw na kanw update thn teleytaia ananewsi.....................

                DateTime? LastRenewalDt = TM_Status.getLastRenewal(tm.Id);
                if (LastRenewalDt == null || LastRenewalDt != tms.RenewalDt) //never null...
                {
                    MessageBox.Show("Προσοχή! Μπορείτε να μεταβάλετε μόνο την τελευταία Ανανέωση Σήματος.");
                    return;
                }

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
        }

        private void DelDecision()
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true; 

                //if (tms.StatusId != 2 && tms.StatusId != 3 && tms.StatusId != 4)
                //{
                //    MessageBox.Show("Δεν είναι Απόφαση...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
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
                        Recipient.DeleteRecipients(tm.Id, tms.Id, 4);
                        success = false;
                    }

                    //disable decision->finalization Tasks 
                    if (Task.DisableNotSentTasks(tm.Id, 3) == false) //Οριστικοποίησης
                    {
                        Recipient.DeleteRecipients(tm.Id, tms.Id, 3);
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

                        //get back decision alerts
                        Recipient.DeleteRecipients(tm.Id, tms.Id, 2); //Απόφαση σε εκκρεμότητα

                        if (tm.NationalPowerId == 1) //1 month to decision, only national tm
                        {
                            if (new InsertTM().CreateDecisionAlarms(tm, tms.Id) == false)
                            {
                                MessageBox.Show("Σφάλμα κατα την επαναφορά ειδοποιήσεων απόφασης!");
                            }                            
                        }

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
        }

        private void DelAppeal()
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                //if (tms.StatusId != 5)
                //{
                //    MessageBox.Show("Δεν είναι Προσφυγή...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
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

                        //get back appeal alerts
                        Recipient.DeleteRecipients(tm.Id, tms.Id, 4); //prosfygi

                        if (tms.StatusId == 3 || tms.StatusId == 4) //merikws aporriptiki || olikws aporriptiki : oristikopoiisi
                        {
                            if (new Decision().CreateProsfygiAlarms(tm, tms) == false) //prosfygi
                            {
                                MessageBox.Show("Σφάλμα κατα την επαναφορά ειδοποιήσεων προσφυγής!");
                            }
                        }


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
        }

        private void DelTermination()
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                //if (tms.StatusId != 6)
                //{
                //    MessageBox.Show("Δεν είναι Ανακοπή...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
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
        }

        private void DelFinalization()
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                //if (tms.StatusId != 7 && tms.StatusId != 8)
                //{
                //    MessageBox.Show("Δεν είναι Οριστικοποίηση (ή Απόρριψη)...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
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
        }

        private void DelRenewal()
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();
                bool success = true;

                //if (tms.StatusId != 9)
                //{
                //    MessageBox.Show("Δεν είναι Ανανέωση...!");
                //    return;
                //}

                Trademark tm = new Trademark(tms.TmId);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
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

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                //int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                //Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                //string url = thisTmpRec.getUrl();
                string url = dgvStatusViewer.SelectedRows[0].Cells["st_FinalizedUrl"].Value.ToString();

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

        private void UpdDeposit()
        {
            // Update
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int TM_Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_TmId"].Value.ToString());
                int ST_Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                TM_Status tms = tmStatusList.Where(i => i.Id == ST_Id).First();
                Trademark tm = new Trademark(TM_Id);

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

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
                    //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdDecision.NewRecord;

                    //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                    tmStatusList = SelectTmStatusRecs(tms.TmId);
                    FillDataGridView(dgvStatusViewer, tmStatusList);
                }
            }
        }

        private void DelDeposit()
        {
            // Delete
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvStatusViewer.SelectedRows[0].Index;
                int TM_Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_TmId"].Value.ToString());
                int ST_Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
                //TM_Status tms = tmStatusList.Where(i => i.Id == ST_Id).First();
                Trademark tm = new Trademark(TM_Id);

                bool success = true;

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την εγγραφή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //check references
                if (Trademark.SelectRefTmRecs(tm.TMNo) > 0)
                {
                    MessageBox.Show("Προσοχή! Δεν είναι δυνατή η διαγραφή της επιλεγμένης εγγραφής! \r\nΥπάρχουν άλλες εγγραφές (Διεθνή / Κοινοτικά Σήματα) που αναφέρονται σε αυτήν.");
                    return;
                }

                TM_Status tms = TM_Status.getLastDecision(tm.Id);
                if (tms.StatusId == 2 || tms.StatusId == 3 || tms.StatusId == 4) //check oti exei apofasi
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
                        //tmStatusList[tmStatusList.FindIndex(w => w.Id == Id)] = frmUpdDecision.NewRecord;

                        //FillDataGridView(dgvTempRecs, frmUpdTm.NewRecord, dgvIndex);
                        tmStatusList = SelectTmStatusRecs(tms.TmId);
                        FillDataGridView(dgvStatusViewer, tmStatusList);
                    }

                }

            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
            TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

            if (tms.StatusId == 1)
            {
                UpdDeposit();
            }
            else if (tms.StatusId == 2 || tms.StatusId == 3 || tms.StatusId == 4)
            {
                UpdDecision();
            }
            else if (tms.StatusId == 5)
            {
                UpdAppeal();
            }
            else if (tms.StatusId == 6)
            {
                UpdTermination();
            }
            else if (tms.StatusId == 7 || tms.StatusId == 8)
            {
                UpdFinalization();
            }
            else if (tms.StatusId == 9)
            {
                UpdRenewal();
            }

        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
            TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

            if (tms.StatusId == 1)
            {
                DelDeposit();
            }
            else if (tms.StatusId == 2 || tms.StatusId == 3 || tms.StatusId == 4)
            {
                DelDecision();
            }
            else if (tms.StatusId == 5)
            {
                DelAppeal();
            }
            else if (tms.StatusId == 6)
            {
                DelTermination();
            }
            else if (tms.StatusId == 7 || tms.StatusId == 8)
            {
                //DelFinalization();

                MessageBox.Show("Προσοχή! Δεν επιτρέπεται η διαγραφή της Οριστικοποίησης.");
                return;
            }
            else if (tms.StatusId == 9)
            {
                //DelRenewal();

                MessageBox.Show("Προσοχή! Δεν επιτρέπεται η διαγραφή της Ανανέωσης.");
                return;
            }

        }

        private void tsmiOpenFinUrl_Click(object sender, EventArgs e)
        {
            if (dgvStatusViewer.SelectedRows.Count > 0)
            {
                //int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                //Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                //string url = thisTmpRec.getUrl();
                string url = dgvStatusViewer.SelectedRows[0].Cells["st_FinalizedUrl"].Value.ToString();

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

        private void tsmiFiles_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgvStatusViewer.SelectedRows[0].Cells["st_Id"].Value.ToString());
            TM_Status tms = tmStatusList.Where(i => i.Id == Id).First();

            if (tms.StatusId == 2 || tms.StatusId == 3 || tms.StatusId == 4 || tms.StatusId == 5 || tms.StatusId == 6)
            {
                SampleFiles frmFiles = new SampleFiles(tms.Id);
                if (frmFiles.filesCnt > 0)
                {
                    frmFiles.btnAddFiles.Enabled = false;
                    frmFiles.btnRemoveFile.Enabled = false;
                    frmFiles.btnRemoveAll.Enabled = false;
                    frmFiles.btnSave.Enabled = false;

                    frmFiles.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχουν καταχωρημένα αρχεία!");
                }
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν καταχωρημένα αρχεία!");
            }
        }
    }
}
