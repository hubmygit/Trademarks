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
    public partial class TMSelectorDevEx : Form
    {
        public TMSelectorDevEx()
        {
            InitializeComponent();

            tempRecList = SelectTempRecs();

            gridControl1.DataSource = tempRecList;
            gridControl2.DataSource = tempRecList;
        }

        public BindingList<Trademark_Full> tempRecList = new BindingList<Trademark_Full>();

        public BindingList<Trademark_Full> SelectTempRecs()
        {
            BindingList<Trademark_Full> ret = new BindingList<Trademark_Full>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], [FileContents], " +
                              "[FileName], [Description], [Fees], [ValidTo], isnull([IsDeleted], 'False') as IsDeleted " +
                              "FROM [dbo].[Trademarks] " +
                              //"WHERE isnull(IsDeleted, 'False') = 'False'" +
                              "ORDER BY [TMNo] ";
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
                    tmpRec.TMGrNo = reader["TMGrNo"].ToString();
                    tmpRec.ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());
                    tmpRec.CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    tmpRec.TMTypeIds = Type.getTM_TypesList(Convert.ToInt32(reader["Id"].ToString()));
                    tmpRec.ClassIds = Class.getTM_ClassList(Convert.ToInt32(reader["Id"].ToString()));
                    tmpRec.CountryIds = Country.getTM_CountriesList(Convert.ToInt32(reader["Id"].ToString()));
                    if (reader["FileContents"] != DBNull.Value)
                    {
                        tmpRec.FileContents = (byte[])reader["FileContents"];
                    }

                    tmpRec.FileName = reader["FileName"].ToString();
                    tmpRec.Description = reader["Description"].ToString();
                    tmpRec.Fees = reader["Fees"].ToString();
                    if (reader["ValidTo"] != DBNull.Value)
                    {
                        tmpRec.ValidTo = Convert.ToDateTime(reader["ValidTo"].ToString());
                    }
                    tmpRec.IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString());

                    Trademark_Full TMFull = new Trademark_Full(tmpRec);
                    ret.Add(TMFull);
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


    }
}
