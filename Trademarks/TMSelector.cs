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
    public partial class TMSelector : Form
    {
        public TMSelector()
        {
            InitializeComponent();

            tempRecList = SelectTempRecs();

            FillDataGridView(dgvTempRecs, tempRecList);
        }

        public List<Trademark> tempRecList = new List<Trademark>();

        public List<Trademark> SelectTempRecs()
        {
            List<Trademark> ret = new List<Trademark>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], [NationalPowerId], [ResponsibleLawyerId] " +
                              "FROM [dbo].[Trademarks] " +
                              "ORDER BY Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Trademark tmpRec = new Trademark();

                    tmpRec.Id = Convert.ToInt32(reader["Id"].ToString());
                    tmpRec.TMNo = reader["TMNo"].ToString();
                    tmpRec.TMName = reader["TMName"].ToString();
                    tmpRec.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    tmpRec.NationalPowerId = Convert.ToInt32(reader["NationalPowerId"].ToString());
                    tmpRec.ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());

                    ret.Add(tmpRec);
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

        public static void FillDataGridView(DataGridView dgv, List<Trademark> TempRecList)
        {
            dgv.Rows.Clear();

            foreach (Trademark thisRecord in TempRecList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "tmp_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMNo, dgvColumnHeader = "tmp_No" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMName, dgvColumnHeader = "tmp_Name" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_DepositDt" });
                dgvDictList.Add(new dgvDictionary() { dbfield = NationalPower.getNationalPowerName(thisRecord.NationalPowerId), dgvColumnHeader = "tmp_NatPower" });
                dgvDictList.Add(new dgvDictionary() { dbfield = Responsible.getResponsibleName(thisRecord.ResponsibleLawyerId), dgvColumnHeader = "tmp_Responsible" });

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

        private void dgvTempRecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvTempRecs.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvTempRecs.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void tsmiDecision_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForDecision(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiAppeal_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForAppeal(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiTermination_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForTermination(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiFinalization_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForFinalization(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiRenewal_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForRenewal(thisTmpRec);
                tempRecList = SelectTempRecs();
                FillDataGridView(dgvTempRecs, tempRecList);
            }
        }

        private void tsmiStatusViewer_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                //Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                StatusViewer frmStatViewer = new StatusViewer(Id);
                frmStatViewer.ShowDialog();
            }
        }

        private void tsmiAlertsViewer_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                //Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                TMAlertsViewer frmAlertViewer = new TMAlertsViewer(Id);
                frmAlertViewer.ShowDialog();

            }
        }
    }
}
