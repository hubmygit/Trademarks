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
    public partial class Appeal : Form
    {
        public Appeal()
        {
            InitializeComponent();

            isInsert = true;
        }

        public Appeal(Trademark TM, TM_Status LastDecision) //insert
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

        public Appeal(Trademark TM, TM_Status LastDecision, TM_Status TMS) //update
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

            if (TMS.AppealDt != null)
            {
                dtpAppealDt.Value = (DateTime)TMS.AppealDt;
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Προσοχή! Οι ειδοποιήσεις Προσφυγής για αυτό το σήμα θα διακοπούν. \r\nΘέλετε να συνεχίσετε στην καταχώρηση;", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //delete previous alerts (only appeal alerts)
                //Task.DisableNotSentTasks(givenTM.Id, 4); //mono sto insert

                NewRecord = new TM_Status();

                //[TrademarksId], [StatusId], [DecisionNo], [Remarks]
                NewRecord.TmId = givenTM.Id;
                NewRecord.StatusId = 5; //prosfygi
                NewRecord.DecisionNo = prevTMStatus.DecisionNo; //txtDecisionNo.Text;
                NewRecord.DecisionPublDt = prevTMStatus.DecisionPublDt; //dtpPublicationDate.Value.Date;
                NewRecord.DecisionRefId = prevTMStatus.Id;
                if (dtpAppealDt.CustomFormat != " ")
                {
                    NewRecord.AppealDt = dtpAppealDt.Value;
                }
                NewRecord.Remarks = txtDescription.Text;

                NewRecord.Id = TempRecUpdId;

                if (isInsert)
                {
                    //delete previous alerts (only appeal alerts)
                    Task.DisableNotSentTasks(givenTM.Id, 4);

                    //Save
                    if (TM_Status.InsertTM_Status_Appeal(NewRecord) == true)
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
                    if (TM_Status.UpdateTM_Status_Appeal(NewRecord) == true)
                    {
                        TmLog.Insert_TMLog(OldRecord, NewRecord, "Προσφυγή", 3);

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


        }

        private void Appeal_Load(object sender, EventArgs e)
        {
            txtTMId.Select();
        }



        private void dtpAppealDt_ValueChanged(object sender, EventArgs e)
        {
            dtpAppealDt.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpAppealDt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtpAppealDt.CustomFormat = " ";
            }
        }
    }
}
