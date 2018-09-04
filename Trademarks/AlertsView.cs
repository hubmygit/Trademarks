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
    public partial class AlertsView : Form
    {
        public AlertsView()
        {
            InitializeComponent();

            //SELECT A.Id, A.IsActive, A.ExpDate, A.NotificationDate, A.NotificationSent, E.Name as EventType, DATEDIFF(DAY, A.NotificationDate, A.ExpDate) as AlertCountdown, A.TrademarksId,
            //       T.TMNo, T.TMName, T.DepositDt, T.RenewalDt, N.Name as NationalPower, C.Name as Company, L.FullName as ResponsibleLawyer
            //FROM [dbo].[Tasks] A left outer join 
            //     [dbo].[TempRecords] T on A.TrademarksId = T.Id left outer join 
            //	   [dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join 
            //	   [dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join 
            //	   [dbo].[Company] C on T.CompanyId = C.Id left outer join 
            //	   [dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id

            tempAlertList = SelectAlerts();

            FillDataGridView(dgvAlerts, tempAlertList);
        }

        public List<AlertsDGV> tempAlertList = new List<AlertsDGV>();

        public List<AlertsDGV> SelectAlerts()
        {
            List<AlertsDGV> ret = new List<AlertsDGV>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A.Id, A.IsActive, A.ExpDate, A.NotificationDate, A.NotificationSent, E.Name as EventType, " +
                                   "DATEDIFF(DAY, getdate(), A.ExpDate) as ExpCountDown, DATEDIFF(DAY, getdate(), A.NotificationDate) as AlertCountdown, " +
                              "A.TrademarksId, T.TMNo, T.TMName, T.DepositDt, T.RenewalDt, N.Name as NationalPower, C.Name as Company, L.FullName as ResponsibleLawyer " +
                              "FROM [dbo].[Tasks] A left outer join " +
                              "[dbo].[TempRecords] T on A.TrademarksId = T.Id left outer join " +
                              "[dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join " +
                              "[dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join " +
                              "[dbo].[Company] C on T.CompanyId = C.Id left outer join " +
                              "[dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id " +
                              "ORDER BY A.TrademarksId "; 
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
                    alertRec.ExpCountdownDays = Convert.ToInt32(reader["ExpCountDown"].ToString());
                    alertRec.TrademarksId = Convert.ToInt32(reader["TrademarksId"].ToString());
                    alertRec.TMNo = reader["TMNo"].ToString();
                    alertRec.TMName = reader["TMName"].ToString();
                    alertRec.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    if (reader["RenewalDt"] != DBNull.Value)
                    {
                        alertRec.RenewalDt = Convert.ToDateTime(reader["RenewalDt"].ToString());
                    }
                    alertRec.NationalPower = reader["NationalPower"].ToString();
                    alertRec.Company = reader["Company"].ToString();
                    alertRec.ResponsibleLawyer = reader["ResponsibleLawyer"].ToString();
                    
                    ret.Add(alertRec);
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

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
    }

    public class AlertsDGV
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime? NotificationSent { get; set; }
        public string EventType { get; set; }
        public int AlertCountdownDays { get; set; }
        public int ExpCountdownDays { get; set; }
        public int TrademarksId { get; set; }
        public string TMNo { get; set; }
        public string TMName { get; set; }
        public DateTime DepositDt { get; set; }
        public DateTime? RenewalDt { get; set; }
        public string NationalPower { get; set; }
        public string Company { get; set; }
        public string ResponsibleLawyer { get; set; }
    }
}
