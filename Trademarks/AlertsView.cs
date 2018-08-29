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
                                   "DATEDIFF(DAY, getdate(), A.ExpDate) as AlertCountdown, DATEDIFF(DAY, getdate(), A.NotificationDate) as ExpCountDown, " +
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
    }

    public class AlertsDGV
    {
        public int Id;
        public bool IsActive;
        public DateTime ExpDate;
        public DateTime NotificationDate;
        public DateTime? NotificationSent;
        public string EventType;
        public int AlertCountdownDays;
        public int ExpCountdownDays;
        public int TrademarksId;
        public string TMNo;
        public string TMName;
        public DateTime DepositDt;
        public DateTime? RenewalDt;
        public string NationalPower;
        public string Company;
        public string ResponsibleLawyer;
    }
}
