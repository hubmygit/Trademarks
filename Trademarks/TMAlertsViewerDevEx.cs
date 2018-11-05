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
    public partial class TMAlertsViewerDevEx : Form
    {
        public TMAlertsViewerDevEx()
        {
            InitializeComponent();

            tmAlertList = SelectTmAlerts();

            gridControl1.DataSource = tmAlertList;

            //Φίλτρα στο Grid! - Active
            if (gridView1.ActiveFilterString is null || gridView1.ActiveFilterString.Trim() == "")
            {
                gridView1.ActiveFilterString += " [IsActive] = True ";
            }
            else
            {
                gridView1.ActiveFilterString += " AND [IsActive] = True ";
            }
                
        }

        public TMAlertsViewerDevEx(int TmId)
        {
            InitializeComponent();

            tmAlertList = SelectTmAlerts(TmId);

            gridControl1.DataSource = tmAlertList;

            //Φίλτρα στο Grid! - Active
            gridView1.ActiveFilterString += "[IsActive] = True";
        }

        public BindingList<AlertsDGV> tmAlertList = new BindingList<AlertsDGV>();

        public BindingList<AlertsDGV> SelectTmAlerts()
        {
            BindingList<AlertsDGV> ret = new BindingList<AlertsDGV>();

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

        public BindingList<AlertsDGV> SelectTmAlerts(int tm_Id)
        {
            BindingList<AlertsDGV> ret = new BindingList<AlertsDGV>();

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

        private void tsmiViewTM_Click(object sender, EventArgs e)
        {
            //Select
            if (gridView1.SelectedRowsCount > 0)
            {
                //int dgvIndex = dgvAlerts.SelectedRows[0].Index;
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
            if (gridView1.SelectedRowsCount > 0)
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
