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

            tempRecList = SelectTempRecs_Trademark();
            tempRecList_Full = SelectTempRecs(tempRecList);

            gridControl1.DataSource = tempRecList_Full;
        }

        public List<Trademark> tempRecList = new List<Trademark>();
        public BindingList<Trademark_Full> tempRecList_Full = new BindingList<Trademark_Full>();

        public BindingList<Trademark_Full> SelectTempRecs(List<Trademark> tmList)
        {
            BindingList<Trademark_Full> ret = new BindingList<Trademark_Full>();

            foreach (Trademark tm in tmList)
            {
                ret.Add(new Trademark_Full(tm));
            }

            return ret;
        }
        public List<Trademark> SelectTempRecs_Trademark()
        {
            List<Trademark> ret = new List<Trademark>();

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

                    //Trademark_Full TMFull = new Trademark_Full(tmpRec);
                    //ret.Add(TMFull);

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

        private void tsmiDecision_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForDecision(thisTmpRec);

                tempRecList = SelectTempRecs_Trademark(); //List
                tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                gridControl1.DataSource = tempRecList_Full; //DataSource
            }
        }

        private void tsmiAppeal_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForAppeal(thisTmpRec);

                tempRecList = SelectTempRecs_Trademark(); //List
                tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                gridControl1.DataSource = tempRecList_Full; //DataSource
            }
        }

        private void tsmiTermination_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForTermination(thisTmpRec);

                tempRecList = SelectTempRecs_Trademark(); //List
                tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                gridControl1.DataSource = tempRecList_Full; //DataSource
            }
        }

        private void tsmiFinalization_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                tempRecList = SelectTempRecs_Trademark(); //List
                tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                gridControl1.DataSource = tempRecList_Full; //DataSource
            }
        }

        private void tsmiRenewal_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                new MainMenu().GoForRenewal(thisTmpRec);

                tempRecList = SelectTempRecs_Trademark(); //List
                tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                gridControl1.DataSource = tempRecList_Full; //DataSource
            }
        }






        private void tsmiViewTM_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                InsertTM frmViewTm = new InsertTM(thisTmpRec);
                frmViewTm.MakeAllControlsReadOnly(frmViewTm);
                frmViewTm.GetFromGridOnlyChecked();

                frmViewTm.btnSave.Enabled = false;
                frmViewTm.ShowDialog();
            }

            

        }

        private void tsmiUpdTM_Click(object sender, EventArgs e)
        {
            // Update
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να ενημερώσετε την εγγραφή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                if (TM_Status.FinalizedOrRejected(tm.Id) != 0) //Πρέπει να μην έχει ορ./απορ.
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να ενημερώσετε την εγγραφή. \r\nΤο Σήμα έχει ήδη οριστικοποιηθεί!");
                    return;
                }

                InsertTM frmUpdTm = new InsertTM(tm);
                frmUpdTm.ShowDialog();

                if (frmUpdTm.success)
                {
                    tempRecList = SelectTempRecs_Trademark(); //List
                    tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                    gridControl1.DataSource = tempRecList_Full; //DataSource
                }
            }
        }

        
    }
}
