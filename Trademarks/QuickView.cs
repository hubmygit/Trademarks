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

            tempRecList = SelectAudit();

            FillDataGridView(dgvTempRecs, tempRecList);
        }

        public List<TempRecords> tempRecList = new List<TempRecords>();

        public List<TempRecords> SelectAudit()
        {
            List<TempRecords> ret = new List<TempRecords>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [TMNo], [TMName], [DepositDt], [RenewalDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId] " +
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

                    ret.Add(tmpRec);
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

                Bitmap bitmap = new Bitmap(@"C:\Repos\Trademarks\Files\246883.jpg");
                //dgvDictList.Add(new dgvDictionary() { dbfield = thisRecord.FileContents, dgvColumnHeader = "tmp_Pic" }); //???
                dgvDictList.Add(new dgvDictionary() { dbfield = bitmap, dgvColumnHeader = "tmp_Pic" }); //???

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
