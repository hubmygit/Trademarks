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
    public partial class TmUpdLog : Form
    {
        public TmUpdLog()
        {
            InitializeComponent();

        }

        public TmUpdLog(int TmId)
        {
            InitializeComponent();

            TmLogRecList = SelectTmLogRecs(TmId);

            FillDataGridView(dgvTmLogRecs, TmLogRecList);
        }

        public List<TmLog> TmLogRecList = new List<TmLog>();

        public List<TmLog> SelectTmLogRecs(int givenTmId)
        {
            List<TmLog> ret = new List<TmLog>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT T.Id as TmId, TS.Id as TsId, L.[ExecStatement], L.[Dt], U.FullName, T.TMNo, T.TMName, " +
                              "case when TS.StatusId in (2, 3, 4, 5, 7, 8) then L.[Section] + ' (Απόφαση: ' + TS.[DecisionNo] + ')' " +
	                          "when TS.StatusId in (6) then L.[Section] + ' (Απόφαση: ' + TS.[DecisionNo] + ', Ανακ. Εταιρία: ' + TS.TermCompany + ')' " +
	                          "else L.[Section] end as [Status], " +
                              "L.[FieldNameToShow], L.[OldValue], L.[NewValue] " +
                              "FROM [dbo].[TM_Log] L left outer join " +
                              "     [dbo].[AppUsers] U on L.AppUsers_Id = U.Id left outer join " +
                              "     [dbo].[Trademarks] T on L.Trademarks_Id = T.Id left outer join " +
                              "     [dbo].[TM_Status] TS on L.TM_Status_Id = TS.Id " +
                              "WHERE T.Id = @givenTmId " +
                              "ORDER BY L.Dt, L.Id ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@givenTmId", givenTmId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TmLog tmlRec = new TmLog();

                    tmlRec.Trademarks_Id = Convert.ToInt32(reader["TmId"].ToString());
                    tmlRec.TM_Status_Id = Convert.ToInt32(reader["TsId"].ToString());
                    tmlRec.ExecStatement = reader["ExecStatement"].ToString();
                    tmlRec.Dt = Convert.ToDateTime(reader["Dt"].ToString());
                    tmlRec.FullName = reader["FullName"].ToString();
                    tmlRec.TMNo = reader["TMNo"].ToString();
                    tmlRec.TMName = reader["TMName"].ToString();
                    tmlRec.Status = reader["Status"].ToString();
                    tmlRec.FieldNameToShow = reader["FieldNameToShow"].ToString();
                    tmlRec.OldValue = reader["OldValue"].ToString();
                    tmlRec.NewValue = reader["NewValue"].ToString();
                    
                    ret.Add(tmlRec);
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

        public static void FillDataGridView(DataGridView dgv, List<TmLog> TmLogList)
        {
            dgv.Rows.Clear();

            foreach (TmLog thisRecord in TmLogList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Trademarks_Id, dgvColumnHeader = "Log_TmId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TM_Status_Id, dgvColumnHeader = "Log_TsId" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.ExecStatement, dgvColumnHeader = "Log_ExecStatement" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Dt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "Log_Dt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FullName, dgvColumnHeader = "Log_FullName" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMNo, dgvColumnHeader = "Log_TMNo" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMName, dgvColumnHeader = "Log_TMName" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Status, dgvColumnHeader = "Log_Status" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FieldNameToShow, dgvColumnHeader = "Log_FieldNameToShow" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.OldValue, dgvColumnHeader = "Log_OldValue" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.NewValue, dgvColumnHeader = "Log_NewValue" });         

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
