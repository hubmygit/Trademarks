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

            if (TMS.TermDt != null)
            {
                dtpTerminationDt.Value = (DateTime)TMS.TermDt;
            }
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
            //Task.DisableNotSentTasks(givenTM.Id);

            NewRecord = new TM_Status();

            //[TrademarksId], [StatusId], [DecisionNo], [Remarks]
            NewRecord.TmId = givenTM.Id;
            NewRecord.StatusId = 6; //anakopi
            NewRecord.DecisionNo = prevTMStatus.DecisionNo; //txtDecisionNo.Text;
            NewRecord.DecisionPublDt = prevTMStatus.DecisionPublDt; //dtpPublicationDate.Value.Date;
            NewRecord.DecisionRefId = prevTMStatus.Id;
            NewRecord.Remarks = txtDescription.Text;
            if (dtpTerminationDt.CustomFormat != " ")
            {
                NewRecord.TermDt = dtpTerminationDt.Value;
            }
            NewRecord.TermCompany = txtTermCompany.Text;

            NewRecord.Id = TempRecUpdId;

            if (isInsert)
            {
                //Save
                if (TM_Status.InsertTM_Status_Termination(NewRecord) == true)
                {
                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    success = true;
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
                    TmLog.Insert_TMLog(OldRecord, NewRecord, "Ανακοπή", 4);

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    success = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }
            }
        }

        private void dtpTerminationDt_ValueChanged(object sender, EventArgs e)
        {
            dtpTerminationDt.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpTerminationDt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtpTerminationDt.CustomFormat = " ";
            }
        }
    }
}
