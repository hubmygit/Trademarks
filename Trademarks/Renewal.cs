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
            dtpValidTo.Value = (DateTime)TM.ValidTo;

            isInsert = true;

            dtpRenewalDate.Value = dtpValidTo.Value;
            dtpRenewalDateTo.Value = dtpValidTo.Value.AddYears(10);

            //DateTime? renDt = CalcRenewalDt(dtpDepositDt.Value);
            //if (renDt != null)
            //{
            //    dtpRenewalDate.Value = (DateTime)renDt;
            //    lblExpDt.Text = ((DateTime)renDt).AddYears(10).ToString("dd/MM/yyyy");
            //}
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
            dtpValidTo.Value = (DateTime)TM.ValidTo;

            isInsert = false;

            OldRecord = TMS;
            TempRecUpdId = TMS.Id;

            dtpApplicationDate.Value = TMS.RenewalApplicationDt;
            dtpRenewalDate.Value = TMS.RenewalDt;
            dtpRenewalDateTo.Value = (DateTime)TM.ValidTo; //TMS.RenewalDt.AddYears(10);
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

        public DateTime? CalcRenewalDt(DateTime depositDt, DateTime applicationDt)
        {
            DateTime ret = depositDt;
            bool goOn = true;

            while (goOn)
            {
                ret = ret.AddYears(10); 

                if (applicationDt >= ret.AddMonths(-6) && applicationDt <= ret.AddMonths(6)) 
                {
                    goOn = false;
                }

                if (applicationDt < ret.AddMonths(-6))
                {
                    return null;
                }
            }

            return ret;
        }

        //public DateTime? CalcRenewalDt(DateTime depositDt)
        //{
        //    DateTime ret = depositDt;
        //    DateTime NowDt = DateTime.Now;
        //    bool goOn = true;

        //    while (goOn)
        //    {
        //        ret = ret.AddYears(10);

        //        if (NowDt >= ret && NowDt <= ret.AddYears(10))
        //        {
        //            goOn = false;
        //        }
        //    }

        //    return ret;
        //}

        private void RenewalProcedure(TM_Status StRec, Trademark TmRec)
        {           
            if (isInsert)
            {
                //delete previous alerts 
                Task.DisableNotSentTasks(givenTM.Id);

                //Save
                bool successful = true;

                StRec.Id = TM_Status.InsertTM_Status_Renewal(StRec);
                if (StRec.Id <= 0)
                {
                    //TM_Status ins error
                    successful = false;
                }

                //Alarms
                if (successful)
                {
                    if (Trademark.UpdateTM_ValidTo(TmRec.Id, StRec.RenewalDt.AddYears(10)) == false)
                    {
                        MessageBox.Show("Προσοχή! \r\nΣφάλμα κατα την καταχώρηση της Καταληκτικής Ημερομηνίας του Σήματος!");
                    }
                    else
                    {
                        TmLog.Insert_TMLog(new Trademark() { Id = TmRec.Id, ValidTo = TmRec.ValidTo }, new Trademark() { Id = TmRec.Id, ValidTo = StRec.RenewalDt.AddYears(10) }, "Κατάθεση");
                    }

                    if (new Finalization().CreateRenewalAlarms(TmRec, StRec.RenewalDt, StRec.Id) == false)
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
                    TmLog.Insert_TMLog(OldRecord, NewRecord, "Ανανέωση", 6);

                    if (Trademark.UpdateTM_ValidTo(TmRec.Id, StRec.RenewalDt.AddYears(10)) == false)
                    {
                        MessageBox.Show("Προσοχή! \r\nΣφάλμα κατα την καταχώρηση της Καταληκτικής Ημερομηνίας του Σήματος!");
                    }
                    else
                    {
                        TmLog.Insert_TMLog(new Trademark() { Id = TmRec.Id, ValidTo = TmRec.ValidTo }, new Trademark() { Id = TmRec.Id, ValidTo = StRec.RenewalDt.AddYears(10) }, "Κατάθεση");
                    }

                    if (OldRecord.RenewalDt != NewRecord.RenewalDt)
                    {
                        //disable old Alarms first...
                        Task.DisableNotSentTasks(StRec.TmId);

                        //delete recipients
                        Recipient.DeleteRecipients(StRec.TmId, StRec.Id, 1); //ananewsi

                        if (new Finalization().CreateRenewalAlarms(TmRec, StRec.RenewalDt, StRec.Id) == false)
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
            //Task.DisableNotSentTasks(givenTM.Id);

            NewRecord = new TM_Status();
            NewRecord.TmId = givenTM.Id;
            NewRecord.StatusId = 9; //ananewsi

            NewRecord.RenewalApplicationDt = dtpApplicationDate.Value;
            NewRecord.RenewalDt = dtpRenewalDate.Value;
            NewRecord.RenewalProtocol = txtProtocolNo.Text;
            NewRecord.RenewalFees = txtFees.Text;
            NewRecord.Remarks = txtDescription.Text;

            NewRecord.Id = TempRecUpdId;

            RenewalProcedure(NewRecord, givenTM);

        }

        private void dtpApplicationDate_ValueChanged(object sender, EventArgs e)
        {
            //DateTime? renDt = CalcRenewalDt(dtpDepositDt.Value, dtpApplicationDate.Value);

            //if (renDt != null)
            //{
            //    dtpRenewalDate.Value = (DateTime)renDt;

                //dtpExpDt.Value = ((DateTime)renDt).AddYears(10);
            //}
        }

    }
}
