﻿using System;
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
    public partial class NatTmNoSelector : Form
    {
        public NatTmNoSelector()
        {
            InitializeComponent();

            tempRecList = SelectTempRecs();

            FillDataGridView(dgvTempRecs, tempRecList);
        }

        public List<TempRecords> tempRecList = new List<TempRecords>();

        public string TMGrNo = "";
        public bool succeed = false;

        public List<TempRecords> SelectTempRecs()
        {
            List<TempRecords> ret = new List<TempRecords>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], [RenewalDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], [FileContents], " +
                              "[FileName], [Description], [Fees], [DecisionNo], [PublicationDate], [FinalizationDate], [Url] " +
                              "FROM [dbo].[TempRecords] " +
                              "WHERE NationalPowerId = 1 " +
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

        private void dgvTempRecs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                TMGrNo = dgvTempRecs["tmp_No", e.RowIndex].Value.ToString();
                succeed = true;
                Close();
            }
        }
    }
}
