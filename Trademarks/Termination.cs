using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trademarks
{
    public partial class Termination : Form
    {
        public Termination()
        {
            InitializeComponent();

            isInsert = true;
        }

        public Termination(Trademark TM, TM_Status LastDecision) //insert
        {
            InitializeComponent();

            givenTM = TM;
            prevTMStatus = LastDecision;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            if (LastDecision.StatusId == 3)
            {
                rbPartiallyRejected.Checked = true;
            }
            else if (LastDecision.StatusId == 4)
            {
                rbPartiallyRejected.Checked = true;
            }
            txtDecisionNo.Text = LastDecision.DecisionNo;
            dtpPublicationDate.Value = LastDecision.DecisionPublDt;

            isInsert = true;
        }

        public Termination(Trademark TM, TM_Status LastDecision, TM_Status TMS) //update
        {
            InitializeComponent();

            givenTM = TM;
            prevTMStatus = LastDecision;
            givenTMS = TMS;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            if (LastDecision.StatusId == 3)
            {
                rbPartiallyRejected.Checked = true;
            }
            else if (LastDecision.StatusId == 4)
            {
                rbPartiallyRejected.Checked = true;
            }
            txtDecisionNo.Text = LastDecision.DecisionNo;
            dtpPublicationDate.Value = LastDecision.DecisionPublDt;

            isInsert = false;

            OldRecord = TMS;
            TempRecUpdId = TMS.Id;

            txtTermCompany.Text = TMS.TermCompany;
            txtDescription.Text = TMS.Remarks;
        }

        public TM_Status NewRecord = new TM_Status();
        public TM_Status OldRecord = new TM_Status();
        private Trademark givenTM = new Trademark();
        private TM_Status givenTMS = new TM_Status();
        private TM_Status prevTMStatus = new TM_Status();
        public bool isInsert = false;
        public int TempRecUpdId = 0;
        public bool success = false;

        private void Termination_Load(object sender, EventArgs e)
        {
            txtTMId.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (txtTermCompany.Text.Trim() == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο 'Ανακόπτουσα Εταιρία'!");
                return;
            }

            //delete previous alerts 
            Task.DisableNotSentTasks(givenTM.Id);

            NewRecord = new TM_Status();

            //[TrademarksId], [StatusId], [DecisionNo], [Remarks]
            NewRecord.TmId = givenTM.Id;
            NewRecord.StatusId = 6; //anakopi
            NewRecord.DecisionNo = prevTMStatus.DecisionNo; //txtDecisionNo.Text;
            NewRecord.DecisionPublDt = prevTMStatus.DecisionPublDt; //dtpPublicationDate.Value.Date;
            NewRecord.Remarks = txtDescription.Text;
            NewRecord.TermCompany = txtTermCompany.Text;

            NewRecord.Id = TempRecUpdId;

            if (isInsert)
            {
                //Save
                if (TM_Status.InsertTM_Status_Termination(NewRecord) == true)
                {
                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }
            }
            else
            {
                //Save
                if (TM_Status.UpdateTM_Status_Termination(NewRecord) == true)
                {
                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }
            }
        }
    }
}
