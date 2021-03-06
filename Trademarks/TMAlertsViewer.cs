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
    public partial class TMAlertsViewer : Form
    {
        public TMAlertsViewer()
        {
            InitializeComponent();

            tmAlertList = SelectTmAlerts();

            applyFilters();
        }

        public TMAlertsViewer(int TmId)
        {
            InitializeComponent();

            tmAlertList = SelectTmAlerts(TmId);

            //FillDataGridView(dgvAlerts, tmAlertList);
            applyFilters();
        }

        public List<AlertsDGV> tmAlertList = new List<AlertsDGV>();

        public List<AlertsDGV> SelectTmAlerts()
        {
            List<AlertsDGV> ret = new List<AlertsDGV>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A.Id, A.IsActive, A.ExpDate, A.NotificationDate, A.NotificationSent, E.Name as EventType, " +
                                   "DATEDIFF(DAY, getdate(), A.ExpDate) as ExpCountDown, DATEDIFF(DAY, getdate(), A.NotificationDate) as AlertCountdown, " +
                              "A.TrademarksId, A.TM_StatusId, A.EventTypesId, T.TMNo, T.TMName, T.DepositDt, " +
                              //"'1900-01-01' as RenewalDt, " +
                              "(select max(TMS.RenewalDt) from TM_Status TMS where TMS.TrademarksId = T.Id and TMS.StatusId = 9 and isnull(TMS.IsDeleted, 'False') = 'False') as RenewalDt, " +
                              "N.Name as NationalPower, C.Name as Company, L.FullName as ResponsibleLawyer, " +
                              "A.AlertDescr " +
                              "FROM [dbo].[Tasks] A left outer join " +
                              "[dbo].[Trademarks] T on A.TrademarksId = T.Id left outer join " +
                              "[dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join " +
                              "[dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join " +
                              "[dbo].[Company] C on T.CompanyId = C.Id left outer join " +
                              "[dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id " +
                              "WHERE isnull(T.IsDeleted, 'False') = 'False' " +
                              "ORDER BY T.TMNo, A.NotificationDate "; //A.TrademarksId
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AlertsDGV alertRec = new AlertsDGV();
                    alertRec.Id = Convert.ToInt32(reader["Id"].ToString());
                    alertRec.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    alertRec.ExpDate = Convert.ToDateTime(reader["ExpDate"].ToString());
                    alertRec.NotificationDate = Convert.ToDateTime(reader["NotificationDate"].ToString());
                    if (reader["NotificationSent"] != DBNull.Value)
                    {
                        alertRec.NotificationSent = Convert.ToDateTime(reader["NotificationSent"].ToString());
                    }
                    alertRec.EventType = reader["EventType"].ToString();
                    alertRec.AlertCountdownDays = Convert.ToInt32(reader["AlertCountdown"].ToString());
                    if (alertRec.AlertCountdownDays < 0)
                    {
                        alertRec.AlertCountdownDays = 0;
                    }

                    alertRec.ExpCountdownDays = Convert.ToInt32(reader["ExpCountDown"].ToString());
                    if (alertRec.ExpCountdownDays < 0)
                    {
                        alertRec.ExpCountdownDays = 0;
                    }

                    alertRec.TrademarksId = Convert.ToInt32(reader["TrademarksId"].ToString());
                    if (reader["TM_StatusId"] != DBNull.Value)
                    {
                        alertRec.TM_StatusId = Convert.ToInt32(reader["TM_StatusId"].ToString());
                    }
                    if (reader["EventTypesId"] != DBNull.Value)
                    {
                        alertRec.EventTypesId = Convert.ToInt32(reader["EventTypesId"].ToString());
                    }
                    alertRec.TMNo = reader["TMNo"].ToString();
                    alertRec.TMName = reader["TMName"].ToString();

                    if (reader["DepositDt"] != DBNull.Value)
                    {
                        alertRec.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    }

                    if (reader["RenewalDt"] != DBNull.Value)
                    {
                        alertRec.RenewalDt = Convert.ToDateTime(reader["RenewalDt"].ToString());
                    }
                    alertRec.NationalPower = reader["NationalPower"].ToString();
                    alertRec.Company = reader["Company"].ToString();
                    alertRec.ResponsibleLawyer = reader["ResponsibleLawyer"].ToString();
                    alertRec.AlertDescr = reader["AlertDescr"].ToString();

                    ret.Add(alertRec);
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

        public List<AlertsDGV> SelectTmAlerts(int tm_Id)
        {
            List<AlertsDGV> ret = new List<AlertsDGV>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A.Id, A.IsActive, A.ExpDate, A.NotificationDate, A.NotificationSent, E.Name as EventType, " +
                                   "DATEDIFF(DAY, getdate(), A.ExpDate) as ExpCountDown, DATEDIFF(DAY, getdate(), A.NotificationDate) as AlertCountdown, " +
                              "A.TrademarksId, A.TM_StatusId, A.EventTypesId, T.TMNo, T.TMName, T.DepositDt, " + 
                              //"'1900-01-01' as RenewalDt, " +
                              "(select max(TMS.RenewalDt) from TM_Status TMS where TMS.TrademarksId = T.Id and TMS.StatusId = 9 and isnull(TMS.IsDeleted, 'False') = 'False') as RenewalDt, " +
                              "N.Name as NationalPower, C.Name as Company, L.FullName as ResponsibleLawyer, " +
                              "A.AlertDescr " +
                              "FROM [dbo].[Tasks] A left outer join " +
                              "[dbo].[Trademarks] T on A.TrademarksId = T.Id left outer join " +
                              "[dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join " +
                              "[dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join " +
                              "[dbo].[Company] C on T.CompanyId = C.Id left outer join " +
                              "[dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id " +
                              "WHERE A.TrademarksId = @TmId AND isnull(T.IsDeleted, 'False') = 'False' " +
                              "ORDER BY A.Id "; //A.TrademarksId
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@TmId", tm_Id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AlertsDGV alertRec = new AlertsDGV();
                    alertRec.Id = Convert.ToInt32(reader["Id"].ToString());
                    alertRec.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    alertRec.ExpDate = Convert.ToDateTime(reader["ExpDate"].ToString());
                    alertRec.NotificationDate = Convert.ToDateTime(reader["NotificationDate"].ToString());
                    if (reader["NotificationSent"] != DBNull.Value)
                    {
                        alertRec.NotificationSent = Convert.ToDateTime(reader["NotificationSent"].ToString());
                    }
                    alertRec.EventType = reader["EventType"].ToString();
                    alertRec.AlertCountdownDays = Convert.ToInt32(reader["AlertCountdown"].ToString());
                    if (alertRec.AlertCountdownDays < 0)
                    {
                        alertRec.AlertCountdownDays = 0;
                    }

                    alertRec.ExpCountdownDays = Convert.ToInt32(reader["ExpCountDown"].ToString());
                    if (alertRec.ExpCountdownDays < 0)
                    {
                        alertRec.ExpCountdownDays = 0;
                    }

                    alertRec.TrademarksId = Convert.ToInt32(reader["TrademarksId"].ToString());
                    if (reader["TM_StatusId"] != DBNull.Value)
                    {
                        alertRec.TM_StatusId = Convert.ToInt32(reader["TM_StatusId"].ToString());
                    }
                    if (reader["EventTypesId"] != DBNull.Value)
                    {
                        alertRec.EventTypesId = Convert.ToInt32(reader["EventTypesId"].ToString());
                    }
                    alertRec.TMNo = reader["TMNo"].ToString();
                    alertRec.TMName = reader["TMName"].ToString();

                    if (reader["DepositDt"] != DBNull.Value)
                    {
                        alertRec.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    }

                    if (reader["RenewalDt"] != DBNull.Value)
                    {
                        alertRec.RenewalDt = Convert.ToDateTime(reader["RenewalDt"].ToString());
                    }
                    alertRec.NationalPower = reader["NationalPower"].ToString();
                    alertRec.Company = reader["Company"].ToString();
                    alertRec.ResponsibleLawyer = reader["ResponsibleLawyer"].ToString();
                    alertRec.AlertDescr = reader["AlertDescr"].ToString();

                    ret.Add(alertRec);
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

        public static void FillDataGridView(DataGridView dgv, List<AlertsDGV> AlertList)
        {
            dgv.Rows.Clear();

            foreach (AlertsDGV thisRecord in AlertList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "alarm_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.IsActive, dgvColumnHeader = "alarm_Active" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ExpDate.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "alarm_ExpDate" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.NotificationDate.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "alarm_NotificationDate" });
                if (thisRecord.NotificationSent != null && thisRecord.NotificationSent > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = ((DateTime)thisRecord.NotificationSent).ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "alarm_NotifSentDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.EventType, dgvColumnHeader = "alarm_Event" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AlertCountdownDays, dgvColumnHeader = "alarm_AlertCountdown" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ExpCountdownDays, dgvColumnHeader = "alarm_ExpCountdown" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TrademarksId, dgvColumnHeader = "tmp_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMNo, dgvColumnHeader = "tmp_No" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMName, dgvColumnHeader = "tmp_Name" });
                if (thisRecord.DepositDt != null && thisRecord.DepositDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_DepositDt" });
                }
                if (thisRecord.RenewalDt != null && thisRecord.RenewalDt > new DateTime(1800, 1, 1))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = ((DateTime)thisRecord.RenewalDt).ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_RenewalDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.NationalPower, dgvColumnHeader = "tmp_NatPower" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Company, dgvColumnHeader = "tmp_Com" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ResponsibleLawyer, dgvColumnHeader = "tmp_RespLawyer" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AlertDescr, dgvColumnHeader = "alarm_Period" });

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

        private void tsmiViewTM_Click(object sender, EventArgs e)
        {
            //Select
            if (dgvAlerts.SelectedRows.Count > 0)
            {
                //int dgvIndex = dgvAlerts.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvAlerts.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmRec = new Trademark(Id);

                InsertTM frmViewTm = new InsertTM(thisTmRec);
                frmViewTm.MakeAllControlsReadOnly(frmViewTm);
                frmViewTm.GetFromGridOnlyChecked();

                frmViewTm.btnSave.Enabled = false;
                frmViewTm.ShowDialog();                
            }
        }

        private void dgvAlerts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvAlerts.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvAlerts.Rows[hti.RowIndex].Selected = true;
            }
        }

        public void applyFilters()
        {
            List<AlertsDGV> filteredRecs = tmAlertList;

            if (chbActive.CheckState != CheckState.Indeterminate)
            {
                filteredRecs = filteredRecs.Where(i => i.IsActive == chbActive.Checked).ToList();
            }

            if (txtTMId.Text.Trim() != "")
            {
                filteredRecs = filteredRecs.Where(i => i.TMNo.IndexOf(txtTMId.Text, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            if (txtTMName.Text.Trim() != "")
            {
                filteredRecs = filteredRecs.Where(i => i.TMName.IndexOf(txtTMName.Text, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            FillDataGridView(dgvAlerts, filteredRecs);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void chbActive_CheckStateChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void dgvAlerts_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "alarm_ExpDate" || e.Column.Name == "alarm_NotificationDate" || e.Column.Name == "tmp_DepositDt" || e.Column.Name == "tmp_RenewalDt")
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

        private void tsmiRecipients_Click(object sender, EventArgs e)
        {
            if (dgvAlerts.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvAlerts.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                int alarm_Id = Convert.ToInt32(dgvAlerts.SelectedRows[0].Cells["alarm_Id"].Value.ToString());
                AlertsDGV alDgcRec = tmAlertList.Where(i => i.Id == alarm_Id).First();
                List<Recipient> recipientList = Task.getTaskRecipients(Id, alDgcRec.TM_StatusId, alDgcRec.EventTypesId);

                Recipients frmRecipients = new Recipients();
                frmRecipients.txtTMId.Text = dgvAlerts.SelectedRows[0].Cells["tmp_No"].Value.ToString();
                frmRecipients.txtTMName.Text = dgvAlerts.SelectedRows[0].Cells["tmp_Name"].Value.ToString();
                frmRecipients.dtpExpDt.Value = Convert.ToDateTime(dgvAlerts.SelectedRows[0].Cells["alarm_ExpDate"].Value.ToString());
                frmRecipients.dtpExpTime.Value = Convert.ToDateTime(dgvAlerts.SelectedRows[0].Cells["alarm_ExpDate"].Value.ToString());

                foreach (Recipient recipient in recipientList)
                {
                    frmRecipients.dgvRecipients.Rows.Add(new object[] { recipient.Id, recipient.FullName, recipient.Email });
                }

                frmRecipients.ShowDialog();
            }
        }
    }
}
