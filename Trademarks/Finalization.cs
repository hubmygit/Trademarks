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
    public partial class Finalization : Form
    {
        public Finalization()
        {
            InitializeComponent();

            isInsert = true;
        }

        public Finalization(Trademark TM, TM_Status LastDecision) //insert
        {
            InitializeComponent();

            givenTM = TM;
            prevTMStatus = LastDecision;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            if (LastDecision.StatusId == 2)
            {
                rbApproved.Checked = true;

                rbFinalization.Checked = true;
                gbFinalizationStatus.Enabled = false;
            }
            else if (LastDecision.StatusId == 3)
            {
                rbPartiallyRejected.Checked = true;

                rbFinalization.Checked = true;
                gbFinalizationStatus.Enabled = false;
            }
            else if (LastDecision.StatusId == 4)
            {
                //rbPartiallyRejected.Checked = true;
                rbTotallyRejected.Checked = true;
            }
            txtDecisionNo.Text = LastDecision.DecisionNo;
            dtpPublicationDate.Value = LastDecision.DecisionPublDt;

            isInsert = true;
        }

        public Finalization(Trademark TM, TM_Status LastDecision, TM_Status TMS) //update
        {
            InitializeComponent();

            givenTM = TM;
            prevTMStatus = LastDecision;
            givenTMS = TMS;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            if (LastDecision.StatusId == 2)
            {
                rbApproved.Checked = true;

                rbFinalization.Checked = true;
                gbFinalizationStatus.Enabled = false;
            }
            else if (LastDecision.StatusId == 3)
            {
                rbPartiallyRejected.Checked = true;

                rbFinalization.Checked = true;
                gbFinalizationStatus.Enabled = false;
            }
            else if (LastDecision.StatusId == 4)
            {
                //rbPartiallyRejected.Checked = true;
                rbTotallyRejected.Checked = true;
            }
            txtDecisionNo.Text = LastDecision.DecisionNo;
            dtpPublicationDate.Value = LastDecision.DecisionPublDt;

            isInsert = false;

            OldRecord = TMS;
            TempRecUpdId = TMS.Id;

            if (TMS.StatusId == 7) //oristikopoiisi
            {
                rbFinalization.Checked = true;
            }
            else if (TMS.StatusId == 8) //oliki aporripsi
            {
                rbRejected.Checked = true;
            }
            dtpFinalizationDate.Value = TMS.FinalizedDt;
            txtUrl.Text = TMS.FinalizedUrl;
            txtDescription.Text = TMS.Remarks;
        }

        public TM_Status NewRecord = new TM_Status();
        public TM_Status OldRecord = new TM_Status();
        private Trademark givenTM = new Trademark();
        private TM_Status givenTMS = new TM_Status();
        private TM_Status prevTMStatus = new TM_Status();
        public bool isInsert = false;
        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Responsible> secretariesList = Responsible.getSecretariesList();
        public int TempRecUpdId = 0;
        public bool success = false;


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
        
        

        public bool CreateRenewalAlarms(Trademark TMRec, DateTime? RenewalDt, int TMS_Id)
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 1; //Ανανεώσεις
            TaskToInsert.TM_StatusId = TMS_Id;

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId, TMRec.NationalPowerId);

            DateTime ExpDate = TMRec.DepositDt.AddYears(task_EventType.ExpYears); //10 years

            if (RenewalDt != null)
            {
                ExpDate = ((DateTime)RenewalDt).AddYears(task_EventType.ExpYears); //10 years
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
            rec.TM_StatusId = TaskToInsert.TM_StatusId;
            rec.EventTypesId = TaskToInsert.EventTypesId;
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

                StRec.Id = TM_Status.InsertTM_Status_Finalization(StRec);
                if (StRec.Id <= 0)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (StRec.StatusId == 7) //oristikopoiisi
                    {
                        if (CreateRenewalAlarms(TmRec, null, StRec.Id) == false)
                        {
                            MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                            return;
                        }
                    }

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
                bool successful = true;

                if (TM_Status.UpdateTM_Status_Finalization(StRec) == false)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    TmLog.Insert_TMLog(OldRecord, NewRecord, "Οριστικοποίηση", 5);

                    if (OldRecord.StatusId != NewRecord.StatusId)
                    {
                        //disable old Alarms first...
                        Task.DisableNotSentTasks(StRec.TmId);

                        //delete recipients
                        Recipient.DeleteRecipients(StRec.TmId, StRec.Id, 1);//ananewsi

                        if (StRec.StatusId == 7) //oristikopoiisi
                        {
                            if (CreateRenewalAlarms(TmRec, null, StRec.Id) == false)
                            {
                                MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                                return;
                            }
                        }                        

                    }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (!rbFinalization.Checked && !rbRejected.Checked)
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

                NewRecord.Id = TempRecUpdId;

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
