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
    public partial class AlertsViewGrouped : Form
    {
        public AlertsViewGrouped()
        {
            InitializeComponent();

            tempAlertList = SelectAlerts();

            //FillDataGridView(dgvAlerts, tempAlertList);

            applyFilters();
        }

        public List<AlertsDGV> tempAlertList = new List<AlertsDGV>();

        public List<AlertsDGV> SelectAlerts()
        {
            List<AlertsDGV> ret = new List<AlertsDGV>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A2.Id, w.ExpDate, w.NotificationDate, w.EventType, w.ExpCountDown, w.AlertCountdown, w.TrademarksId, " +
                "w.TMNo, w.TMName, w.DepositDt, w.RenewalDt, w.NationalPower, w.Company, w.ResponsibleLawyer, A2.AlertDescr " +
                "FROM " +
                "( " +
                "SELECT A.ExpDate, min(A.NotificationDate) as NotificationDate, E.Name as EventType, " +
                "DATEDIFF(DAY, getdate(), min(A.ExpDate)) as ExpCountDown, DATEDIFF(DAY, getdate(), min(A.NotificationDate)) as AlertCountdown, " +
                "A.TrademarksId, T.TMNo, T.TMName, T.DepositDt, T.RenewalDt, N.Name as NationalPower, C.Name as Company, " +
                "L.FullName as ResponsibleLawyer " +
                "FROM [dbo].[Tasks] A left outer join " +
                "[dbo].[TempRecords] T on A.TrademarksId = T.Id left outer join " +
                "[dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join " +
                "[dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join " +
                "[dbo].[Company] C on T.CompanyId = C.Id left outer join " +
                "[dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id " +
                "WHERE A.IsActive = 'True' " +
                "GROUP BY A.ExpDate, E.Name, A.TrademarksId, T.TMNo, T.TMName, T.DepositDt, T.RenewalDt, N.Name, C.Name, L.FullName " +
                ")w left outer join [dbo].[Tasks] A2 on A2.IsActive = 'True' and w.TrademarksId = A2.TrademarksId and w.NotificationDate = A2.NotificationDate " +
                //"ORDER BY w.TMNo " +
                "ORDER BY w.ExpCountDown, w.TMNo";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AlertsDGV alertRec = new AlertsDGV();
                    alertRec.Id = Convert.ToInt32(reader["Id"].ToString());
                    alertRec.IsActive = true;
                    alertRec.ExpDate = Convert.ToDateTime(reader["ExpDate"].ToString());
                    alertRec.NotificationDate = Convert.ToDateTime(reader["NotificationDate"].ToString());
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
                if (thisRecord.NotificationSent != null)
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = ((DateTime)thisRecord.NotificationSent).ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "alarm_NotifSentDt" });
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.EventType, dgvColumnHeader = "alarm_Event" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.AlertCountdownDays, dgvColumnHeader = "alarm_AlertCountdown" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ExpCountdownDays, dgvColumnHeader = "alarm_ExpCountdown" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TrademarksId, dgvColumnHeader = "tmp_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMNo, dgvColumnHeader = "tmp_No" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMName, dgvColumnHeader = "tmp_Name" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_DepositDt" });
                if (thisRecord.RenewalDt != null)
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
                int dgvIndex = dgvAlerts.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvAlerts.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                TempRecords thisTmpRec = new TempRecords(Id);

                QuickInsert frmViewTmpRec = new QuickInsert(thisTmpRec);

                frmViewTmpRec.MakeAllControlsReadOnly(frmViewTmpRec);
                frmViewTmpRec.GetFromGridOnlyChecked();

                frmViewTmpRec.btnSave.Enabled = false;
                frmViewTmpRec.ShowDialog();
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

        private void applyFilters()
        {
            List<AlertsDGV> filteredRecs = tempAlertList;
                        
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

        private void tsmiRecipients_Click(object sender, EventArgs e)
        {
            if (dgvAlerts.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvAlerts.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                List<Recipient> recipientList = Task.getTaskRecipients(Id);

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void tsmiAnalyticalView_Click(object sender, EventArgs e)
        {
            if (dgvAlerts.SelectedRows.Count > 0)
            {
                string TMNo = dgvAlerts.SelectedRows[0].Cells["tmp_No"].Value.ToString();
                string TMName = dgvAlerts.SelectedRows[0].Cells["tmp_Name"].Value.ToString();

                AlertsView frmAlertsView = new AlertsView();

                frmAlertsView.txtTMId.Text = TMNo;
                frmAlertsView.txtTMName.Text = TMName;

                frmAlertsView.applyFilters();

                frmAlertsView.ShowDialog();
            }
        }
    }
}
