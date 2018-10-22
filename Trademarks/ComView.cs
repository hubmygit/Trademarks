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
    public partial class ComView : Form
    {
        public ComView()
        {
            InitializeComponent();

            ComList = SelectComRecs();

            FillDataGridView(dgvComRecs, ComList);
        }

        public List<Company> ComList = new List<Company>();

        public List<Company> SelectComRecs()
        {
            List<Company> ret = new List<Company>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [Name], [Headquarters] FROM [dbo].[Company] ORDER BY Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Company Rec = new Company();

                    Rec.Id = Convert.ToInt32(reader["Id"].ToString());
                    Rec.Name = reader["Name"].ToString();
                    Rec.Headquarters = reader["Headquarters"].ToString();

                    ret.Add(Rec);
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

        public static void FillDataGridView(DataGridView dgv, List<Company> givenComList)
        {
            dgv.Rows.Clear();

            foreach (Company thisRecord in givenComList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "com_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Name, dgvColumnHeader = "com_Name" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Headquarters, dgvColumnHeader = "com_Address" });

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

        private void tsmiUpd_Click(object sender, EventArgs e)
        {
            //Update
            if (dgvComRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvComRecs.SelectedRows[0].Cells["com_Id"].Value.ToString());
                Company com = ComList.Where(i => i.Id == Id).First();

                ComEdit frmUpdCom = new ComEdit(com);
                frmUpdCom.ShowDialog();

                if (frmUpdCom.success)
                {
                    ComList = SelectComRecs();
                    FillDataGridView(dgvComRecs, ComList);
                }
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvComRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvComRecs.SelectedRows[0].Cells["com_Id"].Value.ToString());
                Company com = ComList.Where(i => i.Id == Id).First();

                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε την Εταιρία: '" + com.Name + "'.\r\nΕίστε σίγουροι;",
                              "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                    
                    Company.Delete_Coms(Id);
                    
                    ComList = SelectComRecs();
                    FillDataGridView(dgvComRecs, ComList);
                }
            }
        }

        private void dgvComRecs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvComRecs.HitTest(e.X, e.Y);
                if (hti.RowIndex < 0)
                {
                    return;
                }
                dgvComRecs.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            //Insert
            ComEdit frmInsCom = new ComEdit();
            frmInsCom.ShowDialog();

            if (frmInsCom.success)
            {
                ComList = SelectComRecs();
                FillDataGridView(dgvComRecs, ComList);
            }
        }
    }
}
