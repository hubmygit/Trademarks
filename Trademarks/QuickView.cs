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
    public partial class QuickView : Form
    {
        public QuickView()
        {
            InitializeComponent();

            tempRecList = SelectTempRecs();

            FillDataGridView(dgvTempRecs, tempRecList);
        }

        public List<TempRecords> tempRecList = new List<TempRecords>();

        public List<TempRecords> SelectTempRecs()
        {
            List<TempRecords> ret = new List<TempRecords>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], [RenewalDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], [FileContents], " +
                              "[FileName], [Description], [Fees], [DecisionNo], [PublicationDate], [FinalizationDate], [Url] " +
                              "FROM [dbo].[TempRecords] " +
                              "ORDER BY Id "; //??
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dtRenewal = new DateTime();
                    bool HasRenewalDt = false;
                    if (reader["RenewalDt"] != DBNull.Value)
                    {
                        HasRenewalDt = true;
                        dtRenewal = Convert.ToDateTime(reader["RenewalDt"].ToString());
                    }

                    TempRecords tmpRec = new TempRecords();

                    tmpRec.Id = Convert.ToInt32(reader["Id"].ToString());
                    tmpRec.TMNo = reader["TMNo"].ToString();
                    tmpRec.TMName = reader["TMName"].ToString();
                    tmpRec.DepositDt = Convert.ToDateTime(reader["DepositDt"].ToString());
                    tmpRec.HasRenewal = HasRenewalDt;
                    if (HasRenewalDt)
                    {
                        tmpRec.RenewalDt = dtRenewal;
                    }
                    tmpRec.NationalPowerId = Convert.ToInt32(reader["NationalPowerId"].ToString());
                    tmpRec.TMGrNo = reader["TMGrNo"].ToString();
                    tmpRec.CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    tmpRec.ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());
                    if (reader["FileContents"] != DBNull.Value)
                    {
                        tmpRec.FileContents = (byte[])reader["FileContents"];
                    }

                    tmpRec.FileName = reader["FileName"].ToString();
                    tmpRec.Description = reader["Description"].ToString();
                    tmpRec.Fees = reader["Fees"].ToString();
                    tmpRec.DecisionNo = reader["DecisionNo"].ToString();
                    tmpRec.PublicationDate = Convert.ToDateTime(reader["PublicationDate"].ToString());
                    tmpRec.FinalizationDate = Convert.ToDateTime(reader["FinalizationDate"].ToString());
                    tmpRec.Url = reader["Url"].ToString();

                    tmpRec.TMTypeIds = Type.getTM_TypesList(Convert.ToInt32(reader["Id"].ToString()));
                    tmpRec.ClassIds = Class.getTM_ClassList(Convert.ToInt32(reader["Id"].ToString()));
                    tmpRec.CountryIds = Country.getTM_CountriesList(Convert.ToInt32(reader["Id"].ToString()));

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

        public static void FillDataGridView(DataGridView dgv, List<TempRecords> TempRecList)
        {
            dgv.Rows.Clear();

            foreach (TempRecords thisRecord in TempRecList)
            {
                List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.Id, dgvColumnHeader = "tmp_Id" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMNo, dgvColumnHeader = "tmp_No" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMName, dgvColumnHeader = "tmp_Name" });
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_DepositDt" });
                if (thisRecord.HasRenewal)
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.RenewalDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_RenewalDt" }); 
                }
                else
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = "", dgvColumnHeader = "tmp_RenewalDt" }); 
                }
                dgvDictList.Add(new dgvDictionary() { dbfield = NationalPower.getNationalPowerName(thisRecord.NationalPowerId), dgvColumnHeader = "tmp_NatPower" }); 
                dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.TMGrNo, dgvColumnHeader = "tmp_GrNo" });
                dgvDictList.Add(new dgvDictionary() { dbfield = Company.getCompanyName(thisRecord.CompanyId), dgvColumnHeader = "tmp_Com" }); 
                dgvDictList.Add(new dgvDictionary() { dbfield = Responsible.getResponsibleName(thisRecord.ResponsibleLawyerId), dgvColumnHeader = "tmp_RespLawyer" });

                //Bitmap bitmap = new Bitmap(@"C:\Repos\Trademarks\Files\246883.jpg");

                //Bitmap bitmap;
                //if (thisRecord.FileContents != null)
                //{
                //    using (var ms = new System.IO.MemoryStream(thisRecord.FileContents))
                //    {
                //        bitmap = new Bitmap(ms);
                //    }
                //}
                //else
                //{
                //    bitmap = null; //new Bitmap(@"C:\Repos\Trademarks\Files\246883.jpg");
                //}
                //dgvDictList.Add(new dgvDictionary() { dbfield = bitmap, dgvColumnHeader = "tmp_Pic" }); //???

                dgv.Columns["tmp_Pic"].DefaultCellStyle.NullValue = null;
                string fn = System.IO.Path.GetExtension(thisRecord.FileName);
                if ((thisRecord.FileContents != null) && (fn == ".gif" || fn == ".jpg" || fn == ".jpeg" || fn == ".bmp" || fn == ".wmf" || fn == ".png"))
                {
                    dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FileContents, dgvColumnHeader = "tmp_Pic" }); //???
                }
                
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

        public void FillDataGridView(DataGridView dgv, TempRecords tmpRec, int dgvIndex)
        {
            List<dgvDictionary> dgvDictList = new List<dgvDictionary>();

            dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.Id, dgvColumnHeader = "tmp_Id" });
            dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.TMNo, dgvColumnHeader = "tmp_No" });
            dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.TMName, dgvColumnHeader = "tmp_Name" });
            dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.DepositDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_DepositDt" });
            if (tmpRec.HasRenewal)
            {
                dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.RenewalDt.ToString("dd.MM.yyyy HH:mm"), dgvColumnHeader = "tmp_RenewalDt" });
            }
            else
            {
                dgvDictList.Add(new dgvDictionary() { dbfield = "", dgvColumnHeader = "tmp_RenewalDt" });
            }
            dgvDictList.Add(new dgvDictionary() { dbfield = NationalPower.getNationalPowerName(tmpRec.NationalPowerId), dgvColumnHeader = "tmp_NatPower" });
            dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.TMGrNo, dgvColumnHeader = "tmp_GrNo" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Company.getCompanyName(tmpRec.CompanyId), dgvColumnHeader = "tmp_Com" });
            dgvDictList.Add(new dgvDictionary() { dbfield = Responsible.getResponsibleName(tmpRec.ResponsibleLawyerId), dgvColumnHeader = "tmp_RespLawyer" });

            dgv.Columns["tmp_Pic"].DefaultCellStyle.NullValue = null;
            string fn = System.IO.Path.GetExtension(tmpRec.FileName);
            if ((tmpRec.FileContents != null) && (fn == ".gif" || fn == ".jpg" || fn == ".jpeg" || fn == ".bmp" || fn == ".wmf" || fn == ".png"))
            {
                dgvDictList.Add(new dgvDictionary() { dbfield = tmpRec.FileContents, dgvColumnHeader = "tmp_Pic" }); //???
            }

            object[] obj = new object[dgv.Columns.Count];

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgvDictList.Exists(z => z.dgvColumnHeader == dgv.Columns[i].Name))
                {
                    obj[i] = dgvDictList.Where(z => z.dgvColumnHeader == dgv.Columns[i].Name).First().dbfield;
                }
                dgv.Rows[dgvIndex].Cells[i].Value = obj[i];
            }
            
            dgv.Rows[dgvIndex].Selected = true;
        }

        private bool DeleteTrademark(int TM_id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string UpdSt = "DELETE FROM [dbo].[TempRecords] WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", TM_id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
        }

        private bool MakeTrademarkInactive(int TM_id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            //string UpdSt = "UPDATE [dbo].[TempRecords] SET DelUser = @DelUser, DelDt = getdate()  WHERE Id = @Id ";
            string UpdSt = "UPDATE [dbo].[TempRecords] SET Deleted = 'True'  WHERE Id = @Id ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", TM_id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);

            }
            sqlConn.Close();

            return ret;
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

        private void tsmiOpenUrl_Click(object sender, EventArgs e)
        {
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                TempRecords thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                if (thisTmpRec.Url.Trim() != "")
                {
                    System.Diagnostics.Process.Start(thisTmpRec.Url);
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχει καταχωρημένο Url για τη συγκεκριμένη εγγραφή!");
                }
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvTempRecs.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                TempRecords thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                QuickInsert frmUpdateTmpRec = new QuickInsert(thisTmpRec);
                frmUpdateTmpRec.ShowDialog();

                if (frmUpdateTmpRec.success)
                {                    
                    //refresh
                    tempRecList[tempRecList.FindIndex(w => w.Id == Id)] = frmUpdateTmpRec.NewRecord;

                    FillDataGridView(dgvTempRecs, frmUpdateTmpRec.NewRecord, dgvIndex);                    
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            // Delete
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                //delete data from all tables....
                int dgvIndex = dgvTempRecs.SelectedRows[0].Index;
                string Sima = dgvTempRecs["tmp_No", dgvIndex].Value.ToString();
                int tmpId = Convert.ToInt32(dgvTempRecs["tmp_Id", dgvIndex].Value.ToString());
                TempRecords thisTmpRec = tempRecList.Where(i => i.Id == tmpId).First(); //new
                bool success = true;

                DialogResult dialogResult = MessageBox.Show("Θέλετε οπωσδήποτε να διαγράψετε την εγγραφή του Σήματος: [" + Sima + "];\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις.", "Διαγραφή Σήματος", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //delete from TM_Types
                    if (Type.DeleteTM_Types(tmpId) == false)
                    {
                        success = false;
                    }

                    //delete from TM_Classes
                    if (Class.DeleteTM_Classes(tmpId) == false)
                    {
                        success = false;
                    }

                    //delete from TM_Countries (non mandatory field!)
                    //if (Country.DeleteTM_Countries(tmpId) == false) 
                    if (Country.DeleteTM_Countries(tmpId) == false && thisTmpRec.CountryIds.Count > 0)
                    {
                        success = false;
                    }

                    //delete from Trademarks
                    if (DeleteTrademark(tmpId) == false)
                    {
                        success = false;
                    }

                    //delete from Tasks
                    if (Task.DeleteTasks(tmpId) == false)
                    {
                        success = false;
                    }

                    //delete from Recipients
                    if (Recipient.DeleteRecipients(tmpId) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        //refresh
                        tempRecList.RemoveAt(tempRecList.FindIndex(w => w.Id == tmpId));

                        dgvTempRecs.Rows.RemoveAt(dgvIndex);

                        //dgvTempRecs.Refresh();
                    }

                }
            }
        }

        private void tsmiView_Click(object sender, EventArgs e)
        {
            //Select
            if (dgvTempRecs.SelectedRows.Count > 0)
            {
                int dgvIndex = dgvTempRecs.SelectedRows[0].Index;
                int Id = Convert.ToInt32(dgvTempRecs.SelectedRows[0].Cells["tmp_Id"].Value.ToString());
                TempRecords thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                QuickInsert frmUpdateTmpRec = new QuickInsert(thisTmpRec);

                frmUpdateTmpRec.MakeAllControlsReadOnly(frmUpdateTmpRec);

                frmUpdateTmpRec.btnSave.Enabled = false;
                frmUpdateTmpRec.ShowDialog();                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<TempRecords> filteredRecs = tempRecList;
            if (txtTMId.Text.Trim() != "")
            {
                filteredRecs = filteredRecs.Where(i => i.TMNo.IndexOf(txtTMId.Text, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            if (txtTMName.Text.Trim() != "")
            {
                filteredRecs = filteredRecs.Where(i => i.TMName.IndexOf(txtTMName.Text, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            }

            FillDataGridView(dgvTempRecs, filteredRecs);
        }

        private void dgvTempRecs_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "tmp_DepositDt" || e.Column.Name == "tmp_RenewalDt")
            {
                string dtA = "";
                string dtB = "";

                if (e.CellValue1 != null && e.CellValue1.ToString().Trim() != "")
                {
                    dtA = Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss");
                }

                if (e.CellValue2 != null && e.CellValue2.ToString().Trim() != "")
                {
                    dtB = Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss");
                }

                //e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd HHmmss"),
                //                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd HHmmss"));

                e.SortResult = System.String.Compare(dtA, dtB);

                e.Handled = true;
            }
        }
    }
}
