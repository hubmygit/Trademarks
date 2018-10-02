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
    public partial class Renewal : Form
    {
        public Renewal()
        {
            InitializeComponent();

            isInsert = true;
        }

        public Renewal(Trademark TM) //insert
        {
            InitializeComponent();

            givenTM = TM;
           
            txtTMId.Text = TM.TMNo;
            txtTMName.Text = TM.TMName;
            dtpDepositDt.Value = TM.DepositDt;
            dtpDepositTime.Value = TM.DepositDt;

            isInsert = true;
        }

        public Renewal(Trademark TM, TM_Status TMS) //update
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

            dtpRenewalDate.Value = TMS.RenewalDt;
            txtProtocolNo.Text = TMS.RenewalProtocol;
            txtFees.Text = TMS.RenewalFees;
            txtDescription.Text = TMS.Remarks;
        }


        public TM_Status NewRecord = new TM_Status();
        public TM_Status OldRecord = new TM_Status();
        private Trademark givenTM = new Trademark();
        private TM_Status givenTMS = new TM_Status();
        public bool isInsert = false;
        //private TM_Status prevTMStatus = new TM_Status();
        //public List<Responsible> responsibleList = Responsible.getResponsibleList();
        //public List<Responsible> secretariesList = Responsible.getSecretariesList();
        public int TempRecUpdId = 0;
        public bool success = false;


        private void Renewal_Load(object sender, EventArgs e)
        {
            txtTMId.Select();
        }

        private void RenewalProcedure(TM_Status StRec, Trademark TmRec)
        {
            if (isInsert)
            {
                //Save
                bool successful = true;

                if (TM_Status.InsertTM_Status_Renewal(StRec) == false)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (new Finalization().CreateRenewalAlarms(TmRec, StRec.RenewalDt) == false)
                    {
                        MessageBox.Show("Σφάλμα κατα την καταχώρηση ειδοποιήσεων!");
                        return;
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

                if (TM_Status.UpdateTM_Status_Renewal(StRec) == false)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (OldRecord.RenewalDt != NewRecord.RenewalDt)
                    {
                        //disable old Alarms first...
                        Task.DisableNotSentTasks(StRec.TmId);

                        //delete recipients
                        Recipient.DeleteRecipients(NewRecord.Id);

                        if (new Finalization().CreateRenewalAlarms(TmRec, StRec.RenewalDt) == false)
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

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime depositDatetime = new DateTime(dtpDepositDt.Value.Year, dtpDepositDt.Value.Month, dtpDepositDt.Value.Day);

            DateTime renewalDatetime = new DateTime(dtpRenewalDate.Value.Year, dtpRenewalDate.Value.Month, dtpRenewalDate.Value.Day);

            if (depositDatetime > renewalDatetime)
            {
                MessageBox.Show("Προσοχή! Η ημερομηνία Ανανέωσης είναι μικρότερη από την ημερομηνία Κατάθεσης!");
                return;
            }

            //delete previous alerts 
            Task.DisableNotSentTasks(givenTM.Id);

            NewRecord = new TM_Status();
            NewRecord.TmId = givenTM.Id;
            NewRecord.StatusId = 9; //ananewsi

            NewRecord.RenewalDt = dtpRenewalDate.Value;
            NewRecord.RenewalProtocol = txtProtocolNo.Text;
            NewRecord.RenewalFees = txtFees.Text;
            NewRecord.Remarks = txtDescription.Text;

            NewRecord.Id = TempRecUpdId;

            RenewalProcedure(NewRecord, givenTM);

        }
    }
}
