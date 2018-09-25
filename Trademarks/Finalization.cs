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
        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Responsible> secretariesList = Responsible.getSecretariesList();

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

        private bool CreateRenewalAlarms(Trademark TMRec, bool HasRenewal)
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 1; //Ανανεώσεις

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId);

            DateTime ExpDate = TMRec.DepositDt.AddYears(task_EventType.ExpYears); //10 years

            if (HasRenewal)
            {
                //ExpDate = TMRecord.RenewalDt.AddYears(task_EventType.ExpYears);
            }

            TaskToInsert.TrademarksId = TMRec.Id;
            TaskToInsert.ExpDate = ExpDate;
            TaskToInsert.IsActive = true;

            string EventTypeName = EventType.getEventTypeName(TaskToInsert.EventTypesId);

            //new form to show alarms before insert!
            //move to contructor??
            Alarms frmAlarms = new Alarms();
            frmAlarms.txtTMId.Text = TMRec.TMNo;
            frmAlarms.txtTMName.Text = TMRec.TMName;

            foreach (Responsible recipient in responsibleList)
            {
                bool IsChecked = false;
                if (recipient.Id == TMRec.ResponsibleLawyerId)
                {
                    IsChecked = true;
                }
                frmAlarms.dgvRecipients.Rows.Add(new object[] { recipient.Id, IsChecked, recipient.FullName, recipient.Email });
            }

            foreach (Responsible recipient in secretariesList)
            {
                frmAlarms.dgvRecipients.Rows.Add(new object[] { recipient.Id, true, recipient.FullName, recipient.Email });
                frmAlarms.dgvRecipients.Rows[frmAlarms.dgvRecipients.Rows.Count - 1].ReadOnly = true;
                frmAlarms.dgvRecipients.Rows[frmAlarms.dgvRecipients.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
            }

            frmAlarms.dtpExpDt.Value = ExpDate;
            frmAlarms.dtpExpTime.Value = ExpDate;

            foreach (myIntAndStr months in task_EventType.AlertMonths)
            {
                TaskToInsert.NotificationDate = ExpDate.AddMonths(-months.myInt);

                frmAlarms.dgvAlarms.Rows.Add(new object[] { TMRec.Id, true, TaskToInsert.NotificationDate.ToString("dd.MM.yyyy HH:mm"), EventTypeName, months.myStr });

                if (TaskToInsert.NotificationDate < DateTime.Now)
                {
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].Cells["Alarm_Active"].Value = false;
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            foreach (myIntAndStr days in task_EventType.AlertDays)
            {
                TaskToInsert.NotificationDate = ExpDate.AddDays(-days.myInt);

                frmAlarms.dgvAlarms.Rows.Add(new object[] { TMRec.Id, true, TaskToInsert.NotificationDate.ToString("dd.MM.yyyy HH:mm"), EventTypeName, days.myStr });

                if (TaskToInsert.NotificationDate < DateTime.Now)
                {
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].Cells["Alarm_Active"].Value = false;
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            
            frmAlarms.ShowDialog();

            foreach (DataGridViewRow dgvr in frmAlarms.dgvAlarms.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Alarm_Active"].Value))
                {
                    TaskToInsert.NotificationDate = Convert.ToDateTime(dgvr.Cells["Alarm_NotificationDate"].Value);
                    TaskToInsert.AlertDescr = dgvr.Cells["Alarm_Period"].Value.ToString();
                    if (QuickInsert.InsertTask(TaskToInsert) == false)
                    {
                        ret = false;
                    }
                }
            }

            Recipient rec = new Recipient();
            rec.TrademarksId = TaskToInsert.TrademarksId;
            foreach (DataGridViewRow dgvr in frmAlarms.dgvRecipients.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["Rec_Checked"].Value))
                {
                    rec.FullName = dgvr.Cells["Rec_Name"].Value.ToString();
                    rec.Email = dgvr.Cells["Rec_Email"].Value.ToString();
                    if (QuickInsert.InsertRecipients(rec) == false)
                    {
                        ret = false;
                    }
                }
            }

            return ret;
        }

        private void Finalized(TM_Status StRec, Trademark TmRec)
        {            
            if (isInsert)
            {
                //Save
                bool successful = true;

                if (TM_Status.InsertTM_Status_Finalization(StRec) == false)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (StRec.StatusId == 7) //oristikopoiisi
                    {
                        if (CreateRenewalAlarms(TmRec, false) == false)
                        {
                            MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                            return;
                        }
                    }

                    MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if ((!rbFinalization.Checked && !rbRejected.Checked))
            {
                MessageBox.Show("Παρακαλώ επιλέξτε αν πρόκειται για Οριστικοποίηση ή Απόρριψη!");
                return;
            }

            if (MessageBox.Show("Προσοχή! Πριν προχωρήσετε θα πρέπει να έχετε ολοκληρώσει τις αλλαγές στο εμπορικό σήμα \r\nκαθώς δεν θα επιτρέπονται αλλαγές μετά την οριστικοποίηση. \r\nΑν υπάρχουν προηγούμενες ειδοποιήσεις για αυτό το σήμα θα διακοπούν. \r\nΘέλετε να συνεχίσετε στην καταχώρηση;", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //delete previous alerts 
                Task.DisableNotSentTasks(givenTM.Id);

                NewRecord = new TM_Status();

                NewRecord.TmId = givenTM.Id;                
                NewRecord.DecisionNo = prevTMStatus.DecisionNo; //txtDecisionNo.Text;
                NewRecord.DecisionPublDt = prevTMStatus.DecisionPublDt; //dtpPublicationDate.Value.Date;
                NewRecord.FinalizedDt = dtpFinalizationDate.Value;
                NewRecord.FinalizedUrl = txtUrl.Text;
                NewRecord.Remarks = txtDescription.Text;

                if (rbFinalization.Checked)
                {
                    NewRecord.StatusId = 7; //oristikopoiisi
                }
                else if (rbRejected.Checked)
                {
                    NewRecord.StatusId = 8; //oliki aporripsi

                }

                Finalized(NewRecord, givenTM);
            }
        }
    }
}
