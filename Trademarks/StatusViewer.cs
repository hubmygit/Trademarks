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
                              "[DecisionNo], [DecisionPublDt], [TermCompany], [FinalizedDt], [FinalizedUrl], [RenewalDt], [RenewalFees], [RenewalProtocol], [Remarks], [InsDt] " +
                              "FROM [dbo].[TM_Status] TS " +
                              "WHERE TrademarksId = @TmId " +
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


    }
}
