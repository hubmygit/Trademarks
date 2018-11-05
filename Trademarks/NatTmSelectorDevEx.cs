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
    public partial class NatTmSelectorDevEx : Form
    {
        public NatTmSelectorDevEx()
        {
            InitializeComponent();

            tempRecList = SelectTempRecs();
            gridControl1.DataSource = Tm_To_TmFull(tempRecList);
        }

        public BindingList<Trademark> tempRecList = new BindingList<Trademark>();

        public string TMGrNo = "";
        public bool succeed = false;

        public Trademark selTempRec;

        public BindingList<Trademark_Full> Tm_To_TmFull(BindingList<Trademark> givenTM_BL)
        {
            BindingList<Trademark_Full> ret = new BindingList<Trademark_Full>();

            foreach (Trademark tm in givenTM_BL)
            {
                ret.Add(new Trademark_Full(tm));
            }

            return ret;
        }

        public BindingList<Trademark> SelectTempRecs()
        {
            BindingList<Trademark> ret = new BindingList<Trademark>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Id], [TMNo], [TMName], [DepositDt], " +
                              "[NationalPowerId], [TMGrNo], [CompanyId], [ResponsibleLawyerId], [FileContents], " +
                              "[FileName], [Description], [Fees], [ValidTo] " +
                              "FROM [dbo].[Trademarks] " +
                              "WHERE NationalPowerId = 1 AND isnull(IsDeleted, 'False') = 'False' " +
                              "ORDER BY TMNo "; //??
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
                    tmpRec.CompanyId = Convert.ToInt32(reader["CompanyId"].ToString());
                    tmpRec.ResponsibleLawyerId = Convert.ToInt32(reader["ResponsibleLawyerId"].ToString());
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                TMGrNo = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["TMNo"]).ToString();
                int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());

                selTempRec = tempRecList.Where(i => i.Id == id).First();

                succeed = true;
                Close();
            }
        }
    }
}
