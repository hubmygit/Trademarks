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
    public partial class Decision : Form
    {
        public Decision()
        {
            InitializeComponent();

            isInsert = true;
        }

        public Decision(Trademark TM) //insert 
        {
            InitializeComponent();

            givenTM = TM;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            isInsert = true;
        }

        public Decision(Trademark TM, TM_Status TMS) //update
        {
            InitializeComponent();

            givenTM = TM;
            givenTMS = TMS;

            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            isInsert = false;

            OldRecord = TMS;
            TempRecUpdId = TMS.Id;

            if (TMS.StatusId == 2) //2 Εγκριτική
            {
                rbApproved.Checked = true;
            }
            else if (TMS.StatusId == 3) //3 Μερικώς Απορ.
            {
                rbPartiallyRejected.Checked = true;
            }
            else if (TMS.StatusId == 4) //4 Ολικώς Απορ.
            {
                rbTotallyRejected.Checked = true;
            }

            txtDecisionNo.Text = TMS.DecisionNo;
            dtpPublicationDate.Value = TMS.DecisionPublDt;
            txtDescription.Text = TMS.Remarks;
        }

        public TM_Status NewRecord = new TM_Status();
        public TM_Status OldRecord = new TM_Status();
        private Trademark givenTM = new Trademark();
        private TM_Status givenTMS = new TM_Status();
        public bool isInsert = false;
        public List<Responsible> responsibleList = Responsible.getResponsibleList();
        public List<Responsible> secretariesList = Responsible.getSecretariesList();
        public int TempRecUpdId = 0;
        public bool success = false;

        private void Decision_Load(object sender, EventArgs e)
        {
            txtTMId.Select();
        }

        private bool CreateFinalizationAlarms(Trademark TMRec, TM_Status TMStatus)
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 3; //Οριστικοποίηση σε εκκρεμότητα
            TaskToInsert.TM_StatusId = TMStatus.Id;

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId, TMRec.NationalPowerId);

            DateTime ExpDate = TMStatus.DecisionPublDt.AddMonths(task_EventType.ExpMonths); //3 months

            TaskToInsert.TrademarksId = TMStatus.TmId;
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

        private void decision_Approval_or_Rejected(TM_Status StRec, Trademark TmRec, int Status_Id)
        {
            //delete previous alerts (not only old decisions)
            //Task.DisableNotSentTasks(givenTM.Id); 
            //first decision / ins: decision Task 
            //other(new) decision (ins) or upd: prosf & orist Tasks


            StRec = new TM_Status();

            StRec.TmId = TmRec.Id;
            StRec.StatusId = Status_Id; //apofasi: (2) egkritiki, (3) merikws aporriptiki, (4) olikws aporriptiki
            StRec.DecisionNo = txtDecisionNo.Text;
            StRec.DecisionPublDt = dtpPublicationDate.Value.Date;
            StRec.Remarks = txtDescription.Text;

            StRec.Id = TempRecUpdId;

            if (isInsert)
            {
                //delete previous alerts (not only old decisions)
                Task.DisableNotSentTasks(givenTM.Id); 

                //Save
                bool successful = true;

                StRec.Id = TM_Status.InsertTM_Status_Decision(StRec);
                if (StRec.Id <= 0)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (StRec.StatusId == 2 || StRec.StatusId == 3) //egkritiki || merikws aporriptiki : oristikopoiisi
                    {
                        if (CreateFinalizationAlarms(TmRec, StRec) == false)
                        {
                            MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων οριστικοποίησης!");
                            return;
                        }
                    }

                    if (StRec.StatusId == 3 || StRec.StatusId == 4) //merikws aporriptiki || olikws aporriptiki : oristikopoiisi
                    {
                        if (CreateProsfygiAlarms(TmRec, StRec) == false) //prosfygi
                        {
                            MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων προσφυγής!");
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

                if (TM_Status.UpdateTM_Status_Decision(StRec) == false)
                {
                    //TM ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    TmLog.Insert_TMLog(OldRecord, StRec, "Απόφαση", 2);

                    if (OldRecord.DecisionPublDt != StRec.DecisionPublDt || OldRecord.StatusId != StRec.StatusId)
                    {
                        //disable old Alarms first...
                        Task.DisableNotSentTasks(StRec.TmId);

                        //delete recipients
                        Recipient.DeleteRecipients(StRec.TmId, OldRecord.Id, 3);//oristikop
                        Recipient.DeleteRecipients(StRec.TmId, OldRecord.Id, 4);//prosf

                        if (StRec.StatusId == 2 || StRec.StatusId == 3) //egkritiki || merikws aporriptiki : oristikopoiisi
                        {
                            if (CreateFinalizationAlarms(TmRec, StRec) == false)
                            {
                                MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων οριστικοποίησης!");
                                return;
                            }
                        }

                        if (StRec.StatusId == 3 || StRec.StatusId == 4) //merikws aporriptiki || olikws aporriptiki : oristikopoiisi
                        {
                            if (CreateProsfygiAlarms(TmRec, StRec) == false) //prosfygi
                            {
                                MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων προσφυγής!");
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

        public bool CreateProsfygiAlarms(Trademark TMRec, TM_Status TMStatus)
        {
            bool ret = true;

            Task TaskToInsert = new Task();
            TaskToInsert.EventTypesId = 4; //Προσφυγή σε εκκρεμότητα
            TaskToInsert.TM_StatusId = TMStatus.Id;

            Tasks_EventType task_EventType = new Tasks_EventType(TaskToInsert.EventTypesId, TMRec.NationalPowerId);

            DateTime ExpDate = TMStatus.DecisionPublDt.AddMonths(task_EventType.ExpMonths); //2 months

            TaskToInsert.TrademarksId = TMStatus.TmId;
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
                    //frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].Cells["Alarm_Active"].Value = false;
                    //send email next time scheduler will run
                    frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            foreach (myIntAndStr days in task_EventType.AlertDays)
            {
                TaskToInsert.NotificationDate = ExpDate.AddDays(-days.myInt);

                frmAlarms.dgvAlarms.Rows.Add(new object[] { TMRec.Id, true, TaskToInsert.NotificationDate.ToString("dd.MM.yyyy HH:mm"), EventTypeName, days.myStr });

                if (TaskToInsert.NotificationDate < DateTime.Now)
                {
                    //frmAlarms.dgvAlarms.Rows[frmAlarms.dgvAlarms.Rows.Count - 1].Cells["Alarm_Active"].Value = false;
                    //send email next time scheduler will run
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

        //private void decision_Rejected(TM_Status StRec, Trademark TmRec, int Status_Id)
        //{
        //    StRec = new TM_Status();

        //    StRec.TmId = TmRec.Id;
        //    StRec.StatusId = Status_Id; //apofasi: (3) merikws aporriptiki, (4) olikws aporriptiki, 
        //    StRec.DecisionNo = txtDecisionNo.Text;
        //    StRec.DecisionPublDt = dtpPublicationDate.Value.Date;
        //    StRec.Remarks = txtDescription.Text;

        //    if (isInsert)
        //    {
        //        //Save
        //        bool successful = true;

        //        if (TM_Status.InsertTM_Status_Decision(StRec) == false)
        //        {
        //            //TM_Status ins error
        //            successful = false;
        //        }

        //        //Alarms
        //        if (successful)
        //        {                    
        //            if (StRec.StatusId == 3) //merikws aporriptiki
        //            {
        //                if (CreateFinalizationAlarms(TmRec, StRec) == false) //merikws aporriptiki: oristikopoiisi
        //                {
        //                    MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων οριστικοποίησης!");
        //                    return;
        //                }
        //            }

        //            if (CreateProsfygiAlarms(TmRec, StRec) == false) //prosfygi
        //            {
        //                MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων προσφυγής!");
        //                return;
        //            }

        //            MessageBox.Show("Η εγγραφή καταχωρήθηκε επιτυχώς!");
        //            success = true;
        //            Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Σφάλμα κατα την καταχώρηση της εγγραφής!");
        //        }

        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check that all fields has been filled correctly
            if (txtDecisionNo.Text.Trim() == "" ||
                (!rbApproved.Checked && !rbPartiallyRejected.Checked && !rbTotallyRejected.Checked))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία!");
                return;
            }

            DateTime depositDatetime = new DateTime(dtpDepositDt.Value.Year, dtpDepositDt.Value.Month, dtpDepositDt.Value.Day);

            DateTime publicationDatetime = new DateTime(dtpPublicationDate.Value.Year, dtpPublicationDate.Value.Month, dtpPublicationDate.Value.Day);

            if (depositDatetime > publicationDatetime)
            {
                MessageBox.Show("Προσοχή! Η ημερομηνία Δημοσίευσης είναι μικρότερη από την ημερομηνία Κατάθεσης!");
                return;
            }
            
            if (rbApproved.Checked)
            {
                decision_Approval_or_Rejected(NewRecord, givenTM, 2);
            }
            else if (rbPartiallyRejected.Checked)
            {
                decision_Approval_or_Rejected(NewRecord, givenTM, 3);
            }
            else if (rbTotallyRejected.Checked)
            {
                decision_Approval_or_Rejected(NewRecord, givenTM, 4);
            }

        }
    }
}
