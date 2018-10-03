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
    public partial class TMAlertsViewer : Form
    {
        public TMAlertsViewer()
        {
            InitializeComponent();
        }

        public TMAlertsViewer(int TmId)
        {
            InitializeComponent();

            tmAlertList = SelectTmAlerts(TmId);

            FillDataGridView(dgvAlerts, tmAlertList);
        }

        public List<AlertsDGV> tmAlertList = new List<AlertsDGV>();

        public List<AlertsDGV> SelectTmAlerts(int tm_Id)
        {
            List<AlertsDGV> ret = new List<AlertsDGV>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT A.Id, A.IsActive, A.ExpDate, A.NotificationDate, A.NotificationSent, E.Name as EventType, " +
                                   "DATEDIFF(DAY, getdate(), A.ExpDate) as ExpCountDown, DATEDIFF(DAY, getdate(), A.NotificationDate) as AlertCountdown, " +
                              "A.TrademarksId, T.TMNo, T.TMName, T.DepositDt, '1900-01-01' as RenewalDt, N.Name as NationalPower, C.Name as Company, L.FullName as ResponsibleLawyer, " +
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

    }
}
