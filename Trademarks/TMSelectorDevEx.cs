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

        private void tsmiStatusViewer_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());

                StatusViewerDevEx frmStatViewer = new StatusViewerDevEx(Id);
                frmStatViewer.ShowDialog();

                //refresh...deposit updates or deletions
                //tempRecList[tempRecList.FindIndex(w => w.Id == Id)] = frmUpdTm.NewRecord;

                tempRecList = SelectTempRecs_Trademark(); //List
                tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                gridControl1.DataSource = tempRecList_Full; //DataSource
            }
        }

        private void tsmiAlertsViewer_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());

                //TMAlertsViewer frmAlertViewer = new TMAlertsViewer(Id);

                TMAlertsViewerDevEx frmAlertViewer = new TMAlertsViewerDevEx(Id);
                frmAlertViewer.ShowDialog();
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

        private void tsmiDelTM_Click(object sender, EventArgs e)
        {
            // Delete
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();
                bool success = true;

                if (tm.IsDeleted)
                {
                    MessageBox.Show("Προσοχή! Το Σήμα είναι διαγραμμένο!");
                    return;
                }

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την εγγραφή. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                //check references
                if (Trademark.SelectRefTmRecs(tm.TMNo) > 0)
                {
                    MessageBox.Show("Προσοχή! Δεν είναι δυνατή η διαγραφή της επιλεγμένης εγγραφής! \r\nΥπάρχουν άλλες εγγραφές (Διεθνή / Κοινοτικά Σήματα) που αναφέρονται σε αυτήν.");
                    return;
                }

                TM_Status tms = TM_Status.getLastDecision(tm.Id);
                if (tms.StatusId == 2 || tms.StatusId == 3 || tms.StatusId == 4) //check oti exei apofasi
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε να διαγράψετε την εγγραφή. \r\nΥπάρχει καταχωρημένη Aπόφαση.");
                    return;
                }

                if (MessageBox.Show("Προσοχή! Πρόκειται να διαγράψετε το Σήμα: \r\n" +
                              tm.TMNo + " - " + tm.TMName + ".\r\n\r\nΘα διαγραφούν επίσης και οι αντίστοιχες ειδοποιήσεις. \r\nΕίστε σίγουροι;",
                              "Διαγραφή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //disable Tasks
                    if (Task.DisableNotSentTasks(tm.Id) == false)
                    {
                        success = false;
                    }

                    //delete from Trademarks (make inactive, mark as deleted)
                    if (Trademark.DisableTM(tm.Id) == false)
                    {
                        success = false;
                    }

                    if (success)
                    {
                        TmLog.Insert_TMLog(new Trademark() { Id = tm.Id, IsDeleted = false }, new Trademark() { Id = tm.Id, IsDeleted = true }, "Κατάθεση");

                        //refresh
                        tempRecList = SelectTempRecs_Trademark(); //List
                        tempRecList_Full = SelectTempRecs(tempRecList); //BindingList
                        gridControl1.DataSource = tempRecList_Full; //DataSource
                    }

                }

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();

                string url = tm.getUrl();

                if (url.Trim() != "")
                {
                    System.Diagnostics.Process.Start(url);
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχει καταχωρημένο Url για τη συγκεκριμένη εγγραφή!");
                }
            }

        }

        private void tsmiOpenUrl_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark thisTmpRec = tempRecList.Where(i => i.Id == Id).First();

                string url = thisTmpRec.getUrl();

                if (url.Trim() != "")
                {
                    System.Diagnostics.Process.Start(url);
                }
                else
                {
                    MessageBox.Show("Δεν υπάρχει καταχωρημένο Url για τη συγκεκριμένη εγγραφή!");
                }
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            InsertTM frmInsTm = new InsertTM();
            frmInsTm.ShowDialog();

            if (frmInsTm.success)
            {
                //refresh
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

        private void tsmiTmLog_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                Trademark tm = tempRecList.Where(i => i.Id == Id).First();

                if (UserInfo.Get_DB_AppUser_ResponsibleId(UserInfo.DB_AppUser_Id) != tm.ResponsibleLawyerId && UserInfo.IsAdmin == false)
                {
                    MessageBox.Show("Προσοχή! Δεν μπορείτε δείτε το Log μεταβολών της εγγραφής. \r\nΟ Χρήστης πρέπει να έχει οριστεί Υπεύθυνος για το Σήμα.");
                    return;
                }

                TmUpdLog frmViewLog = new TmUpdLog(tm.Id);
                frmViewLog.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<Trademark> tm_list = new List<Trademark>();
            if (rbPrintChoosen.Checked)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    int Id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], gridView1.Columns["Id"]).ToString());
                    tm_list = tempRecList.Where(i => i.Id == Id).ToList(); //.First()
                }
            }
            else if (rbPrintAll.Checked)
            {
                //tm_list = filteredRecs;
                for (int m = 0; m< gridView1.RowCount; m++)
                {
                    int Id = Convert.ToInt32(gridView1.GetRowCellValue(m, "Id").ToString());
                    tm_list.Add(tempRecList.Where(i => i.Id == Id).First());
                }
            }

            
            List<Trademark_Full> TM_Full_List = new List<Trademark_Full>();

            foreach (Trademark tm in tm_list)
            {
                TM_Full_List.Add(new Trademark_Full(tm));
            }

            if (TM_Full_List.Count > 0)
            {
                BindingList<Trademark_Full> tmBList = new BindingList<Trademark_Full>(TM_Full_List);

                //send tm_list to report
                Report_TmBasic rep_tmBasic = new Report_TmBasic(tmBList);

                DevExpress.XtraReports.UI.ReportPrintTool RepPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rep_tmBasic);

                //rep_tmBasic.ShowPreviewMarginLines = false;
                RepPrintTool.PreviewForm.AllowFormSkin = false;

                RepPrintTool.ShowPreview();
            }
            
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    gridControl1.ExportToHtml("C://Tests//a.html");
            
        //}
    }
}
