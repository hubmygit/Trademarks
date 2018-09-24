﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trademarks
{
    public partial class Finalization : Form
    {
        public Finalization()
        {
            InitializeComponent();

            isInsert = true;
        }

        public Finalization(Trademark TM, TM_Status TMStat)
        {
            InitializeComponent();

            givenTM = TM;
            prevTMStatus = TMStat;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            if (TMStat.StatusId == 3)
            {
                rbPartiallyRejected.Checked = true;
            }
            else if (TMStat.StatusId == 4)
            {
                rbPartiallyRejected.Checked = true;
            }
            txtDecisionNo.Text = TMStat.DecisionNo;
            dtpPublicationDate.Value = TMStat.DecisionPublDt;

            isInsert = true;
        }

        public TM_Status NewRecord = new TM_Status();
        private Trademark givenTM = new Trademark();
        private TM_Status prevTMStatus = new TM_Status();
        public bool isInsert = false;

        private void Finalization_Load(object sender, EventArgs e)
        {
            txtTMId.Select();
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.Trim() != "")
            {
                System.Diagnostics.Process.Start(txtUrl.Text);
            }
            else
            {
                MessageBox.Show("Δεν υπάρχει καταχωρημένο Url!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Προσοχή! Αν υπάρχουν ειδοποιήσεις για αυτό το σήμα θα διακοπούν. \r\nΘέλετε να συνεχίσετε στην καταχώρηση;", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //delete previous alerts 
                Task.DisableNotSentTasks(givenTM.Id);

                NewRecord = new TM_Status();

                //[TrademarksId], [StatusId], [DecisionNo], [Remarks]
                NewRecord.TmId = givenTM.Id;
                if (chbHasFinalization.Checked)
                {
                    NewRecord.StatusId = 7; //oristikopoiisi
                }
                else
                {
                    NewRecord.StatusId = 8; //mi oristikopoiisi
                }
                NewRecord.DecisionNo = prevTMStatus.DecisionNo; //txtDecisionNo.Text;
                NewRecord.DecisionPublDt = prevTMStatus.DecisionPublDt; //dtpPublicationDate.Value.Date;

                //dtpFinalizationDate
                //txtUrl

                NewRecord.Remarks = txtDescription.Text;

                //if (isInsert)
                //{
                //    if (TM_Status.InsertTM_Status_Appeal(NewRecord) == true)
                //    {
                //        MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                //        Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                //    }
                //}

            }
        }
    }
}
