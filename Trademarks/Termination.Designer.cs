﻿namespace Trademarks
{
    partial class Termination
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Termination));
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbDecisionType = new System.Windows.Forms.GroupBox();
            this.rbTotallyRejected = new System.Windows.Forms.RadioButton();
            this.rbPartiallyRejected = new System.Windows.Forms.RadioButton();
            this.rbApproved = new System.Windows.Forms.RadioButton();
            this.dtpPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.lblPublicationDate = new System.Windows.Forms.Label();
            this.lblDecisionNo = new System.Windows.Forms.Label();
            this.txtDecisionNo = new System.Windows.Forms.TextBox();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.dtpDepositTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDepositDt = new System.Windows.Forms.DateTimePicker();
            this.lblDepositDt = new System.Windows.Forms.Label();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.lblAppealTitle = new System.Windows.Forms.Label();
            this.btnTermCompany = new System.Windows.Forms.Label();
            this.txtTermCompany = new System.Windows.Forms.TextBox();
            this.lblTerminationDt = new System.Windows.Forms.Label();
            this.dtpTerminationDt = new System.Windows.Forms.DateTimePicker();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.gbDecisionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(40, 412);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(705, 70);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescription.Location = new System.Drawing.Point(330, 393);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(125, 16);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Περιγραφή / Σχόλια";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::Trademarks.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(312, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 50);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbDecisionType
            // 
            this.gbDecisionType.Controls.Add(this.rbTotallyRejected);
            this.gbDecisionType.Controls.Add(this.rbPartiallyRejected);
            this.gbDecisionType.Controls.Add(this.rbApproved);
            this.gbDecisionType.Enabled = false;
            this.gbDecisionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.gbDecisionType.Location = new System.Drawing.Point(166, 139);
            this.gbDecisionType.Name = "gbDecisionType";
            this.gbDecisionType.Size = new System.Drawing.Size(456, 62);
            this.gbDecisionType.TabIndex = 0;
            this.gbDecisionType.TabStop = false;
            this.gbDecisionType.Text = "Απόφαση";
            // 
            // rbTotallyRejected
            // 
            this.rbTotallyRejected.AutoSize = true;
            this.rbTotallyRejected.Location = new System.Drawing.Point(291, 27);
            this.rbTotallyRejected.Name = "rbTotallyRejected";
            this.rbTotallyRejected.Size = new System.Drawing.Size(148, 20);
            this.rbTotallyRejected.TabIndex = 7;
            this.rbTotallyRejected.TabStop = true;
            this.rbTotallyRejected.Text = "Ολικώς Απορριπτική";
            this.rbTotallyRejected.UseVisualStyleBackColor = true;
            // 
            // rbPartiallyRejected
            // 
            this.rbPartiallyRejected.AutoSize = true;
            this.rbPartiallyRejected.Location = new System.Drawing.Point(117, 27);
            this.rbPartiallyRejected.Name = "rbPartiallyRejected";
            this.rbPartiallyRejected.Size = new System.Drawing.Size(156, 20);
            this.rbPartiallyRejected.TabIndex = 6;
            this.rbPartiallyRejected.TabStop = true;
            this.rbPartiallyRejected.Text = "Μερικώς Απορριπτική";
            this.rbPartiallyRejected.UseVisualStyleBackColor = true;
            // 
            // rbApproved
            // 
            this.rbApproved.AutoSize = true;
            this.rbApproved.Location = new System.Drawing.Point(15, 27);
            this.rbApproved.Name = "rbApproved";
            this.rbApproved.Size = new System.Drawing.Size(84, 20);
            this.rbApproved.TabIndex = 5;
            this.rbApproved.TabStop = true;
            this.rbApproved.Text = "Εγκριτική";
            this.rbApproved.UseVisualStyleBackColor = true;
            // 
            // dtpPublicationDate
            // 
            this.dtpPublicationDate.Enabled = false;
            this.dtpPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpPublicationDate.Location = new System.Drawing.Point(352, 235);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new System.Drawing.Size(270, 22);
            this.dtpPublicationDate.TabIndex = 9;
            // 
            // lblPublicationDate
            // 
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPublicationDate.Location = new System.Drawing.Point(163, 241);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new System.Drawing.Size(160, 16);
            this.lblPublicationDate.TabIndex = 0;
            this.lblPublicationDate.Text = "Ημερομηνία Δημοσίευσης";
            // 
            // lblDecisionNo
            // 
            this.lblDecisionNo.AutoSize = true;
            this.lblDecisionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDecisionNo.Location = new System.Drawing.Point(200, 213);
            this.lblDecisionNo.Name = "lblDecisionNo";
            this.lblDecisionNo.Size = new System.Drawing.Size(123, 16);
            this.lblDecisionNo.TabIndex = 0;
            this.lblDecisionNo.Text = "Αριθμός Απόφασης";
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDecisionNo.Location = new System.Drawing.Point(352, 207);
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.ReadOnly = true;
            this.txtDecisionNo.Size = new System.Drawing.Size(270, 22);
            this.txtDecisionNo.TabIndex = 8;
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(163, 90);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 0;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(272, 87);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.ReadOnly = true;
            this.txtTMName.Size = new System.Drawing.Size(350, 22);
            this.txtTMName.TabIndex = 2;
            // 
            // dtpDepositTime
            // 
            this.dtpDepositTime.Enabled = false;
            this.dtpDepositTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpDepositTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDepositTime.Location = new System.Drawing.Point(401, 115);
            this.dtpDepositTime.Name = "dtpDepositTime";
            this.dtpDepositTime.ShowUpDown = true;
            this.dtpDepositTime.Size = new System.Drawing.Size(100, 22);
            this.dtpDepositTime.TabIndex = 4;
            // 
            // dtpDepositDt
            // 
            this.dtpDepositDt.Enabled = false;
            this.dtpDepositDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpDepositDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepositDt.Location = new System.Drawing.Point(272, 115);
            this.dtpDepositDt.Name = "dtpDepositDt";
            this.dtpDepositDt.Size = new System.Drawing.Size(120, 22);
            this.dtpDepositDt.TabIndex = 3;
            // 
            // lblDepositDt
            // 
            this.lblDepositDt.AutoSize = true;
            this.lblDepositDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDepositDt.Location = new System.Drawing.Point(200, 118);
            this.lblDepositDt.Name = "lblDepositDt";
            this.lblDepositDt.Size = new System.Drawing.Size(66, 16);
            this.lblDepositDt.TabIndex = 0;
            this.lblDepositDt.Text = "Κατάθεση";
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(283, 62);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 0;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(401, 59);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 1;
            // 
            // lblAppealTitle
            // 
            this.lblAppealTitle.AutoSize = true;
            this.lblAppealTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAppealTitle.Location = new System.Drawing.Point(266, 13);
            this.lblAppealTitle.Name = "lblAppealTitle";
            this.lblAppealTitle.Size = new System.Drawing.Size(252, 24);
            this.lblAppealTitle.TabIndex = 0;
            this.lblAppealTitle.Text = "Ανακοπή από Τρίτη Εταιρία";
            // 
            // btnTermCompany
            // 
            this.btnTermCompany.AutoSize = true;
            this.btnTermCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnTermCompany.Location = new System.Drawing.Point(37, 356);
            this.btnTermCompany.Name = "btnTermCompany";
            this.btnTermCompany.Size = new System.Drawing.Size(138, 16);
            this.btnTermCompany.TabIndex = 0;
            this.btnTermCompany.Text = "Ανακόπτουσα Εταιρία";
            // 
            // txtTermCompany
            // 
            this.txtTermCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTermCompany.Location = new System.Drawing.Point(181, 353);
            this.txtTermCompany.Name = "txtTermCompany";
            this.txtTermCompany.Size = new System.Drawing.Size(564, 22);
            this.txtTermCompany.TabIndex = 10;
            // 
            // lblTerminationDt
            // 
            this.lblTerminationDt.AutoSize = true;
            this.lblTerminationDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTerminationDt.Location = new System.Drawing.Point(218, 312);
            this.lblTerminationDt.Name = "lblTerminationDt";
            this.lblTerminationDt.Size = new System.Drawing.Size(109, 16);
            this.lblTerminationDt.TabIndex = 18;
            this.lblTerminationDt.Text = "Ημ/νία Ανακοπής";
            // 
            // dtpTerminationDt
            // 
            this.dtpTerminationDt.CustomFormat = " ";
            this.dtpTerminationDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpTerminationDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTerminationDt.Location = new System.Drawing.Point(333, 310);
            this.dtpTerminationDt.Name = "dtpTerminationDt";
            this.dtpTerminationDt.Size = new System.Drawing.Size(250, 22);
            this.dtpTerminationDt.TabIndex = 17;
            this.dtpTerminationDt.ValueChanged += new System.EventHandler(this.dtpTerminationDt_ValueChanged);
            this.dtpTerminationDt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpTerminationDt_KeyDown);
            // 
            // btnAttachments
            // 
            this.btnAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAttachments.Image = global::Trademarks.Properties.Resources.OpenAttachment_16x;
            this.btnAttachments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttachments.Location = new System.Drawing.Point(670, 307);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(75, 25);
            this.btnAttachments.TabIndex = 28;
            this.btnAttachments.Text = "Αρχεία";
            this.btnAttachments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // Termination
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.lblTerminationDt);
            this.Controls.Add(this.dtpTerminationDt);
            this.Controls.Add(this.txtTermCompany);
            this.Controls.Add(this.btnTermCompany);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbDecisionType);
            this.Controls.Add(this.dtpPublicationDate);
            this.Controls.Add(this.lblPublicationDate);
            this.Controls.Add(this.lblDecisionNo);
            this.Controls.Add(this.txtDecisionNo);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.dtpDepositTime);
            this.Controls.Add(this.dtpDepositDt);
            this.Controls.Add(this.lblDepositDt);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.lblAppealTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Termination";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ανακοπή";
            this.Load += new System.EventHandler(this.Termination_Load);
            this.gbDecisionType.ResumeLayout(false);
            this.gbDecisionType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbDecisionType;
        private System.Windows.Forms.RadioButton rbTotallyRejected;
        private System.Windows.Forms.RadioButton rbPartiallyRejected;
        private System.Windows.Forms.RadioButton rbApproved;
        private System.Windows.Forms.DateTimePicker dtpPublicationDate;
        private System.Windows.Forms.Label lblPublicationDate;
        private System.Windows.Forms.Label lblDecisionNo;
        private System.Windows.Forms.TextBox txtDecisionNo;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.DateTimePicker dtpDepositTime;
        private System.Windows.Forms.DateTimePicker dtpDepositDt;
        private System.Windows.Forms.Label lblDepositDt;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
        private System.Windows.Forms.Label lblAppealTitle;
        private System.Windows.Forms.Label btnTermCompany;
        private System.Windows.Forms.TextBox txtTermCompany;
        private System.Windows.Forms.Label lblTerminationDt;
        private System.Windows.Forms.DateTimePicker dtpTerminationDt;
        private System.Windows.Forms.Button btnAttachments;
    }
}