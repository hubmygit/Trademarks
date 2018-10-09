namespace Trademarks
{
    partial class Renewal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Renewal));
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.dtpDepositTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDepositDt = new System.Windows.Forms.DateTimePicker();
            this.lblDepositDt = new System.Windows.Forms.Label();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.lblRenewalTitle = new System.Windows.Forms.Label();
            this.dtpRenewalDate = new System.Windows.Forms.DateTimePicker();
            this.lblRenewalDateFrom = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.lblFees = new System.Windows.Forms.Label();
            this.txtProtocolNo = new System.Windows.Forms.TextBox();
            this.lblProtocolNo = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.dtpApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.lblRenewalDateTo = new System.Windows.Forms.Label();
            this.lblExpDt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(41, 398);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(705, 70);
            this.txtDescription.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescription.Location = new System.Drawing.Point(368, 379);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(49, 16);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Σχόλια";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::Trademarks.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(313, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 50);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.lblDepositDt.Location = new System.Drawing.Point(200, 120);
            this.lblDepositDt.Name = "lblDepositDt";
            this.lblDepositDt.Size = new System.Drawing.Size(66, 16);
            this.lblDepositDt.TabIndex = 0;
            this.lblDepositDt.Text = "Κατάθεση";
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(273, 62);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 0;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(391, 59);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(120, 22);
            this.txtTMId.TabIndex = 1;
            // 
            // lblRenewalTitle
            // 
            this.lblRenewalTitle.AutoSize = true;
            this.lblRenewalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRenewalTitle.Location = new System.Drawing.Point(252, 13);
            this.lblRenewalTitle.Name = "lblRenewalTitle";
            this.lblRenewalTitle.Size = new System.Drawing.Size(281, 24);
            this.lblRenewalTitle.TabIndex = 0;
            this.lblRenewalTitle.Text = "Ανανέωση Εμπορικού Σήματος";
            // 
            // dtpRenewalDate
            // 
            this.dtpRenewalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpRenewalDate.Location = new System.Drawing.Point(162, 251);
            this.dtpRenewalDate.Name = "dtpRenewalDate";
            this.dtpRenewalDate.Size = new System.Drawing.Size(250, 22);
            this.dtpRenewalDate.TabIndex = 5;
            this.dtpRenewalDate.ValueChanged += new System.EventHandler(this.dtpRenewalDate_ValueChanged);
            // 
            // lblRenewalDateFrom
            // 
            this.lblRenewalDateFrom.AutoSize = true;
            this.lblRenewalDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRenewalDateFrom.Location = new System.Drawing.Point(21, 256);
            this.lblRenewalDateFrom.Name = "lblRenewalDateFrom";
            this.lblRenewalDateFrom.Size = new System.Drawing.Size(135, 16);
            this.lblRenewalDateFrom.TabIndex = 0;
            this.lblRenewalDateFrom.Text = "Ισχύς Ανανέωσης από";
            // 
            // txtFees
            // 
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFees.Location = new System.Drawing.Point(162, 328);
            this.txtFees.Multiline = true;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(584, 39);
            this.txtFees.TabIndex = 7;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFees.Location = new System.Drawing.Point(38, 331);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(101, 16);
            this.lblFees.TabIndex = 0;
            this.lblFees.Text = "Αρ. Παραβόλων";
            // 
            // txtProtocolNo
            // 
            this.txtProtocolNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtProtocolNo.Location = new System.Drawing.Point(162, 292);
            this.txtProtocolNo.Name = "txtProtocolNo";
            this.txtProtocolNo.Size = new System.Drawing.Size(584, 22);
            this.txtProtocolNo.TabIndex = 6;
            // 
            // lblProtocolNo
            // 
            this.lblProtocolNo.AutoSize = true;
            this.lblProtocolNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProtocolNo.Location = new System.Drawing.Point(38, 295);
            this.lblProtocolNo.Name = "lblProtocolNo";
            this.lblProtocolNo.Size = new System.Drawing.Size(118, 16);
            this.lblProtocolNo.TabIndex = 0;
            this.lblProtocolNo.Text = "Αρ. Πρωτοκόλλου";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblApplicationDate.Location = new System.Drawing.Point(224, 217);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(97, 16);
            this.lblApplicationDate.TabIndex = 10;
            this.lblApplicationDate.Text = "Ημ/νία Αίτησης";
            // 
            // dtpApplicationDate
            // 
            this.dtpApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpApplicationDate.Location = new System.Drawing.Point(327, 212);
            this.dtpApplicationDate.Name = "dtpApplicationDate";
            this.dtpApplicationDate.Size = new System.Drawing.Size(250, 22);
            this.dtpApplicationDate.TabIndex = 11;
            this.dtpApplicationDate.ValueChanged += new System.EventHandler(this.dtpApplicationDate_ValueChanged);
            // 
            // lblRenewalDateTo
            // 
            this.lblRenewalDateTo.AutoSize = true;
            this.lblRenewalDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRenewalDateTo.Location = new System.Drawing.Point(460, 256);
            this.lblRenewalDateTo.Name = "lblRenewalDateTo";
            this.lblRenewalDateTo.Size = new System.Drawing.Size(30, 16);
            this.lblRenewalDateTo.TabIndex = 12;
            this.lblRenewalDateTo.Text = "έως";
            // 
            // lblExpDt
            // 
            this.lblExpDt.AutoSize = true;
            this.lblExpDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblExpDt.Location = new System.Drawing.Point(496, 256);
            this.lblExpDt.Name = "lblExpDt";
            this.lblExpDt.Size = new System.Drawing.Size(40, 16);
            this.lblExpDt.TabIndex = 13;
            this.lblExpDt.Text = "--/--/--";
            // 
            // Renewal
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lblExpDt);
            this.Controls.Add(this.lblRenewalDateTo);
            this.Controls.Add(this.dtpApplicationDate);
            this.Controls.Add(this.lblApplicationDate);
            this.Controls.Add(this.txtProtocolNo);
            this.Controls.Add(this.lblProtocolNo);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.lblFees);
            this.Controls.Add(this.dtpRenewalDate);
            this.Controls.Add(this.lblRenewalDateFrom);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.dtpDepositTime);
            this.Controls.Add(this.dtpDepositDt);
            this.Controls.Add(this.lblDepositDt);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.lblRenewalTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Renewal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ανανέωση";
            this.Load += new System.EventHandler(this.Renewal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.DateTimePicker dtpDepositTime;
        private System.Windows.Forms.DateTimePicker dtpDepositDt;
        private System.Windows.Forms.Label lblDepositDt;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
        private System.Windows.Forms.Label lblRenewalTitle;
        private System.Windows.Forms.DateTimePicker dtpRenewalDate;
        private System.Windows.Forms.Label lblRenewalDateFrom;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.TextBox txtProtocolNo;
        private System.Windows.Forms.Label lblProtocolNo;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.DateTimePicker dtpApplicationDate;
        private System.Windows.Forms.Label lblRenewalDateTo;
        private System.Windows.Forms.Label lblExpDt;
    }
}