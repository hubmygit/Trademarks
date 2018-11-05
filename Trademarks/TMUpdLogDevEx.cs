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
    public partial class TMUpdLogDevEx : Form
    {
        public TMUpdLogDevEx()
        {
            InitializeComponent();
        }

        public TMUpdLogDevEx(int TmId)
        {
            InitializeComponent();

            TmLogRecList = SelectTmLogRecs(TmId);

            gridControl1.DataSource = TmLogRecList;
        }

        public BindingList<TmLog> TmLogRecList = new BindingList<TmLog>();

        public BindingList<TmLog> SelectTmLogRecs(int givenTmId)
        {
            BindingList<TmLog> ret = new BindingList<TmLog>();

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
                    if (reader["TsId"] != DBNull.Value)
                    {
                        tmlRec.TM_Status_Id = Convert.ToInt32(reader["TsId"].ToString());
                    }
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
