﻿namespace Trademarks
{
    partial class Finalization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finalization));
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
            this.lblFinalizationTitle = new System.Windows.Forms.Label();
            this.dtpFinalizationDate = new System.Windows.Forms.DateTimePicker();
            this.lblFinalizationDate = new System.Windows.Forms.Label();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.gbFinalizationStatus = new System.Windows.Forms.GroupBox();
            this.rbRejected = new System.Windows.Forms.RadioButton();
            this.rbFinalization = new System.Windows.Forms.RadioButton();
            this.gbDecisionType.SuspendLayout();
            this.gbFinalizationStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(41, 414);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(705, 70);
            this.txtDescription.TabIndex = 14;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescription.Location = new System.Drawing.Point(331, 395);
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
            this.btnSave.Location = new System.Drawing.Point(313, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 50);
            this.btnSave.TabIndex = 15;
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
            this.gbDecisionType.Location = new System.Drawing.Point(167, 139);
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
            this.dtpPublicationDate.Location = new System.Drawing.Point(353, 235);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new System.Drawing.Size(270, 22);
            this.dtpPublicationDate.TabIndex = 9;
            // 
            // lblPublicationDate
            // 
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPublicationDate.Location = new System.Drawing.Point(164, 241);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new System.Drawing.Size(160, 16);
            this.lblPublicationDate.TabIndex = 0;
            this.lblPublicationDate.Text = "Ημερομηνία Δημοσίευσης";
            // 
            // lblDecisionNo
            // 
            this.lblDecisionNo.AutoSize = true;
            this.lblDecisionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDecisionNo.Location = new System.Drawing.Point(201, 213);
            this.lblDecisionNo.Name = "lblDecisionNo";
            this.lblDecisionNo.Size = new System.Drawing.Size(123, 16);
            this.lblDecisionNo.TabIndex = 0;
            this.lblDecisionNo.Text = "Αριθμός Απόφασης";
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDecisionNo.Location = new System.Drawing.Point(353, 207);
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.ReadOnly = true;
            this.txtDecisionNo.Size = new System.Drawing.Size(270, 22);
            this.txtDecisionNo.TabIndex = 8;
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(164, 90);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 0;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(273, 87);
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
            this.dtpDepositTime.Location = new System.Drawing.Point(402, 115);
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
            this.dtpDepositDt.Location = new System.Drawing.Point(273, 115);
            this.dtpDepositDt.Name = "dtpDepositDt";
            this.dtpDepositDt.Size = new System.Drawing.Size(120, 22);
            this.dtpDepositDt.TabIndex = 3;
            // 
            // lblDepositDt
            // 
            this.lblDepositDt.AutoSize = true;
            this.lblDepositDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDepositDt.Location = new System.Drawing.Point(201, 118);
            this.lblDepositDt.Name = "lblDepositDt";
            this.lblDepositDt.Size = new System.Drawing.Size(66, 16);
            this.lblDepositDt.TabIndex = 0;
            this.lblDepositDt.Text = "Κατάθεση";
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(284, 62);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 0;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(402, 59);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 1;
            // 
            // lblFinalizationTitle
            // 
            this.lblFinalizationTitle.AutoSize = true;
            this.lblFinalizationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFinalizationTitle.Location = new System.Drawing.Point(270, 13);
            this.lblFinalizationTitle.Name = "lblFinalizationTitle";
            this.lblFinalizationTitle.Size = new System.Drawing.Size(244, 24);
            this.lblFinalizationTitle.TabIndex = 0;
            this.lblFinalizationTitle.Text = "Οριστικοποίηση Απόφασης";
            // 
            // dtpFinalizationDate
            // 
            this.dtpFinalizationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpFinalizationDate.Location = new System.Drawing.Point(496, 315);
            this.dtpFinalizationDate.Name = "dtpFinalizationDate";
            this.dtpFinalizationDate.Size = new System.Drawing.Size(250, 22);
            this.dtpFinalizationDate.TabIndex = 11;
            // 
            // lblFinalizationDate
            // 
            this.lblFinalizationDate.AutoSize = true;
            this.lblFinalizationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFinalizationDate.Location = new System.Drawing.Point(343, 318);
            this.lblFinalizationDate.Name = "lblFinalizationDate";
            this.lblFinalizationDate.Size = new System.Drawing.Size(151, 16);
            this.lblFinalizationDate.TabIndex = 0;
            this.lblFinalizationDate.Text = "Ημ/νία Οριστικοποίησης";
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.Image = global::Trademarks.Properties.Resources.OpenLink_16x;
            this.btnOpenLink.Location = new System.Drawing.Point(724, 358);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(22, 22);
            this.btnOpenLink.TabIndex = 13;
            this.btnOpenLink.UseVisualStyleBackColor = true;
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtUrl.Location = new System.Drawing.Point(69, 358);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(649, 22);
            this.txtUrl.TabIndex = 12;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblUrl.Location = new System.Drawing.Point(38, 361);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(25, 16);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Url";
            // 
            // gbFinalizationStatus
            // 
            this.gbFinalizationStatus.Controls.Add(this.rbRejected);
            this.gbFinalizationStatus.Controls.Add(this.rbFinalization);
            this.gbFinalizationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.gbFinalizationStatus.Location = new System.Drawing.Point(40, 297);
            this.gbFinalizationStatus.Name = "gbFinalizationStatus";
            this.gbFinalizationStatus.Size = new System.Drawing.Size(262, 49);
            this.gbFinalizationStatus.TabIndex = 16;
            this.gbFinalizationStatus.TabStop = false;
            // 
            // rbRejected
            // 
            this.rbRejected.AutoSize = true;
            this.rbRejected.Location = new System.Drawing.Point(135, 18);
            this.rbRejected.Name = "rbRejected";
            this.rbRejected.Size = new System.Drawing.Size(124, 20);
            this.rbRejected.TabIndex = 6;
            this.rbRejected.TabStop = true;
            this.rbRejected.Text = "Ολική Απόρριψη";
            this.rbRejected.UseVisualStyleBackColor = true;
            // 
            // rbFinalization
            // 
            this.rbFinalization.AutoSize = true;
            this.rbFinalization.Location = new System.Drawing.Point(8, 18);
            this.rbFinalization.Name = "rbFinalization";
            this.rbFinalization.Size = new System.Drawing.Size(121, 20);
            this.rbFinalization.TabIndex = 5;
            this.rbFinalization.TabStop = true;
            this.rbFinalization.Text = "Οριστικοποίηση";
            this.rbFinalization.UseVisualStyleBackColor = true;
            // 
            // Finalization
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.gbFinalizationStatus);
            this.Controls.Add(this.btnOpenLink);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.dtpFinalizationDate);
            this.Controls.Add(this.lblFinalizationDate);
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
            this.Controls.Add(this.lblFinalizationTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Finalization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Οριστικοποίηση";
            this.Load += new System.EventHandler(this.Finalization_Load);
            this.gbDecisionType.ResumeLayout(false);
            this.gbDecisionType.PerformLayout();
            this.gbFinalizationStatus.ResumeLayout(false);
            this.gbFinalizationStatus.PerformLayout();
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
        private System.Windows.Forms.Label lblFinalizationTitle;
        private System.Windows.Forms.DateTimePicker dtpFinalizationDate;
        private System.Windows.Forms.Label lblFinalizationDate;
        private System.Windows.Forms.Button btnOpenLink;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.GroupBox gbFinalizationStatus;
        private System.Windows.Forms.RadioButton rbRejected;
        private System.Windows.Forms.RadioButton rbFinalization;
    }
}