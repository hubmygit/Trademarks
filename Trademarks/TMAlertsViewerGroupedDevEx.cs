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
    public partial class TMAlertsViewerGroupedDevEx : Form
    {
        public TMAlertsViewerGroupedDevEx()
        {
            InitializeComponent();

            tmAlertList = SelectAlerts();

            gridControl1.DataSource = tmAlertList;
        }

        public BindingList<AlertsDGV> tmAlertList = new BindingList<AlertsDGV>();

        public BindingList<AlertsDGV> SelectAlerts()
        {
            BindingList<AlertsDGV> ret = new BindingList<AlertsDGV>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A2.Id, w.ExpDate, w.NotificationDate, w.EventType, w.ExpCountDown, w.AlertCountdown, w.TrademarksId, w.TM_StatusId, w.EventTypesId, " +
                "w.TMNo, w.TMName, w.DepositDt, w.RenewalDt, w.NationalPower, w.Company, w.ResponsibleLawyer, A2.AlertDescr " +
                "FROM " +
                "( " +
                "SELECT A.ExpDate, min(A.NotificationDate) as NotificationDate, E.Name as EventType, " +
                "DATEDIFF(DAY, getdate(), min(A.ExpDate)) as ExpCountDown, DATEDIFF(DAY, getdate(), min(A.NotificationDate)) as AlertCountdown, " +
                "A.TrademarksId, A.TM_StatusId, A.EventTypesId, T.TMNo, T.TMName, T.DepositDt, " +
                //"'1900-01-01' as RenewalDt, " +
                "(select max(tms.RenewalDt) from TM_Status tms where T.Id = tms.TrademarksId and tms.StatusId = 9 and isnull(tms.IsDeleted, 'False') = 'False' ) as RenewalDt, " +
                "N.Name as NationalPower, C.Name as Company, " +
                "L.FullName as ResponsibleLawyer " +
                "FROM [dbo].[Tasks] A left outer join " +
                "[dbo].[Trademarks] T on A.TrademarksId = T.Id left outer join " +
                "[dbo].[EventTypes] E on A.EventTypesId = E.Id left outer join " +
                "[dbo].[NationalPower] N on T.NationalPowerId = N.Id left outer join " +
                "[dbo].[Company] C on T.CompanyId = C.Id left outer join " +
                "[dbo].[Responsible] L on T.ResponsibleLawyerId = L.Id " +
                "WHERE A.IsActive = 'True' " +
                //"GROUP BY A.ExpDate, E.Name, A.TrademarksId, T.TMNo, T.TMName, T.DepositDt, T.RenewalDt, N.Name, C.Name, L.FullName " +
                "GROUP BY A.ExpDate, E.Name, A.TrademarksId, A.TM_StatusId, A.EventTypesId, T.TMNo, T.TMName, T.DepositDt, T.Id, N.Name, C.Name, L.FullName " +
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

        private void tsmiViewTM_Click(object sender, EventArgs e)
        {
            //Select
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TrademarksId"]).ToString());
                Trademark thisTmRec = new Trademark(Id);

                InsertTM frmViewTm = new InsertTM(thisTmRec);

                frmViewTm.MakeAllControlsReadOnly(frmViewTm);
                frmViewTm.GetFromGridOnlyChecked();

                frmViewTm.btnSave.Enabled = false;
                frmViewTm.ShowDialog();
            }
        }

        private void tsmiRecipients_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TrademarksId"]).ToString());
                int alarm_Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                AlertsDGV alDgcRec = tmAlertList.Where(i => i.Id == alarm_Id).First();
                List<Recipient> recipientList = Task.getTaskRecipients(Id, alDgcRec.TM_StatusId, alDgcRec.EventTypesId);

                Recipients frmRecipients = new Recipients();
                frmRecipients.txtTMId.Text = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TMNo"]).ToString();
                frmRecipients.txtTMName.Text = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TMName"]).ToString();
                frmRecipients.dtpExpDt.Value = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["ExpDate"]).ToString());
                frmRecipients.dtpExpTime.Value = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["ExpDate"]).ToString());

                foreach (Recipient recipient in recipientList)
                {
                    frmRecipients.dgvRecipients.Rows.Add(new object[] { recipient.Id, recipient.FullName, recipient.Email });
                }

                frmRecipients.ShowDialog();
            }
        }

        private void tsmiAnalyticalView_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && gridView1.GetSelectedRows()[0] >= 0)
            {
                string TMNo = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TMNo"]).ToString();
                string TMName = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TMName"]).ToString();

                //TMAlertsViewer frmAlertsView = new TMAlertsViewer();
                TMAlertsViewerDevEx frmAlertsView = new TMAlertsViewerDevEx();

                //frmAlertsView.txtTMId.Text = TMNo;
                //frmAlertsView.txtTMName.Text = TMName;

                //Φίλτρα στο Grid!

                if (frmAlertsView.gridView1.ActiveFilterString is null || frmAlertsView.gridView1.ActiveFilterString.Trim() == "")
                {
                    frmAlertsView.gridView1.ActiveFilterString += " [TMNo] = '" + TMNo + "' AND [TMName] = '" + TMName + "' ";
                }
                else
                {
                    frmAlertsView.gridView1.ActiveFilterString += " AND [TMNo] = '" + TMNo + "' AND [TMName] = '" + TMName + "' ";
                }

                frmAlertsView.ShowDialog();
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xls)|*.xls";
            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                gridControl1.ExportToXls(sfd.FileName);
            }
        }
    }
}
