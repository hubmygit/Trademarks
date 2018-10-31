using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Trademarks
{
    public partial class Report_TmBasic : DevExpress.XtraReports.UI.XtraReport
    {
        public Report_TmBasic()
        {
            InitializeComponent();
        }

        public Report_TmBasic(BindingList<Trademark_Full> TmFull_BList)
        {
            InitializeComponent();

            DataSource = TmFull_BList;
        }

        private void DetailKatathesi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            TM_Status tmStatus = (TM_Status)DetailReportKatathesi.GetCurrentRow();
            if (tmStatus.StatusId == 1) //katathesi
            {
                xrLabelDummy1.Text = "Ημ/νία Κατάθεσης:";
                xrLabelDummy1Value.Text = tmStatus.DepositDt.ToString("dd.MM.yyyy HH:mm");

                xrLabelDummy1.Visible = true;
                xrLabelDummy1Value.Visible = true;
                xrLabelDummy2.Visible = false;
                xrLabelDummy2Value.Visible = false;
            }
            else if (tmStatus.StatusId == 2 || tmStatus.StatusId == 3 || tmStatus.StatusId == 4) //apofasi
            {
                xrLabelDummy1.Text = "Αρ. Απόφασης:";
                xrLabelDummy1Value.Text = tmStatus.DecisionNo;

                xrLabelDummy1.Visible = true;
                xrLabelDummy1Value.Visible = true;
                xrLabelDummy2.Visible = false;
                xrLabelDummy2Value.Visible = false;
            }
            else if (tmStatus.StatusId == 5) //prosfygi
            {
                xrLabelDummy1.Text = "Αρ. Απόφασης:";
                xrLabelDummy1Value.Text = tmStatus.DecisionNo;

                xrLabelDummy1.Visible = true;
                xrLabelDummy1Value.Visible = true;
                xrLabelDummy2.Visible = false;
                xrLabelDummy2Value.Visible = false;
            }
            else if (tmStatus.StatusId == 6) //anakopi
            {
                xrLabelDummy1.Text = "Αρ. Απόφασης:";
                xrLabelDummy1Value.Text = tmStatus.DecisionNo;
                xrLabelDummy2.Text = "Ανακ. Εταιρία:";
                xrLabelDummy2Value.Text = tmStatus.TermCompany;

                xrLabelDummy1.Visible = true;
                xrLabelDummy1Value.Visible = true;
                xrLabelDummy2.Visible = true;
                xrLabelDummy2Value.Visible = true;
            }
            else if (tmStatus.StatusId == 7 || tmStatus.StatusId == 8) //oristikopoiisi
            {
                xrLabelDummy1.Text = "Αρ. Απόφασης:";
                xrLabelDummy1Value.Text = tmStatus.DecisionNo;

                xrLabelDummy1.Visible = true;
                xrLabelDummy1Value.Visible = true;
                xrLabelDummy2.Visible = false;
                xrLabelDummy2Value.Visible = false;
            }
            else if (tmStatus.StatusId == 9) //ananewsi
            {
                xrLabelDummy1.Text = "Ημ/νία Ανανέωσης:";
                xrLabelDummy1Value.Text = tmStatus.RenewalDt.ToString("dd.MM.yyyy HH:mm");

                xrLabelDummy1.Visible = true;
                xrLabelDummy1Value.Visible = true;
                xrLabelDummy2.Visible = false;
                xrLabelDummy2Value.Visible = false;
            }            
        }

        private void DetailReportKatathesi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
