namespace Trademarks
{
    partial class AlertsViewGrouped
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertsViewGrouped));
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.alarm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alarm_ExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_ExpCountdown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_NotificationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_AlertCountdown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_NotifSentDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm_Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_DepositDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_RenewalDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_NatPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Com = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_RespLawyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiViewTM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecipients = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.AllowUserToAddRows = false;
            this.dgvAlerts.AllowUserToDeleteRows = false;
            this.dgvAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alarm_Id,
            this.alarm_Active,
            this.alarm_ExpDate,
            this.alarm_ExpCountdown,
            this.alarm_NotificationDate,
            this.alarm_AlertCountdown,
            this.alarm_Period,
            this.alarm_NotifSentDt,
            this.alarm_Event,
            this.tmp_Id,
            this.tmp_No,
            this.tmp_Name,
            this.tmp_DepositDt,
            this.tmp_RenewalDt,
            this.tmp_NatPower,
            this.tmp_Com,
            this.tmp_RespLawyer});
            this.dgvAlerts.ContextMenuStrip = this.cmsOnGrid;
            this.dgvAlerts.Location = new System.Drawing.Point(0, 79);
            this.dgvAlerts.MultiSelect = false;
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.RowHeadersVisible = false;
            this.dgvAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlerts.Size = new System.Drawing.Size(1284, 523);
            this.dgvAlerts.TabIndex = 3;
            this.dgvAlerts.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvAlerts_SortCompare);
            this.dgvAlerts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAlerts_MouseDown);
            // 
            // alarm_Id
            // 
            this.alarm_Id.HeaderText = "AlarmId";
            this.alarm_Id.Name = "alarm_Id";
            this.alarm_Id.Visible = false;
            // 
            // alarm_Active
            // 
            this.alarm_Active.HeaderText = "Ενεργό";
            this.alarm_Active.Name = "alarm_Active";
            this.alarm_Active.ReadOnly = true;
            this.alarm_Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.alarm_Active.Width = 50;
            // 
            // alarm_ExpDate
            // 
            this.alarm_ExpDate.HeaderText = "Καταληκτική Ημ/νία";
            this.alarm_ExpDate.Name = "alarm_ExpDate";
            this.alarm_ExpDate.ReadOnly = true;
            this.alarm_ExpDate.Width = 95;
            // 
            // alarm_ExpCountdown
            // 
            this.alarm_ExpCountdown.HeaderText = "Λήξη (ημέρες)";
            this.alarm_ExpCountdown.Name = "alarm_ExpCountdown";
            this.alarm_ExpCountdown.ReadOnly = true;
            this.alarm_ExpCountdown.Width = 60;
            // 
            // alarm_NotificationDate
            // 
            this.alarm_NotificationDate.HeaderText = "Ημ/νία Ειδοποίησης";
            this.alarm_NotificationDate.Name = "alarm_NotificationDate";
            this.alarm_NotificationDate.ReadOnly = true;
            this.alarm_NotificationDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alarm_NotificationDate.Width = 95;
            // 
            // alarm_AlertCountdown
            // 
            this.alarm_AlertCountdown.HeaderText = "Ειδοπ. (ημέρες)";
            this.alarm_AlertCountdown.Name = "alarm_AlertCountdown";
            this.alarm_AlertCountdown.ReadOnly = true;
            this.alarm_AlertCountdown.Width = 60;
            // 
            // alarm_Period
            // 
            this.alarm_Period.HeaderText = "Περίοδος Ειδοπ.";
            this.alarm_Period.Name = "alarm_Period";
            this.alarm_Period.ReadOnly = true;
            this.alarm_Period.Width = 68;
            // 
            // alarm_NotifSentDt
            // 
            this.alarm_NotifSentDt.HeaderText = "Αποστολή Ειδοπ.";
            this.alarm_NotifSentDt.Name = "alarm_NotifSentDt";
            this.alarm_NotifSentDt.ReadOnly = true;
            this.alarm_NotifSentDt.Width = 95;
            // 
            // alarm_Event
            // 
            this.alarm_Event.HeaderText = "Γεγονός";
            this.alarm_Event.Name = "alarm_Event";
            this.alarm_Event.ReadOnly = true;
            // 
            // tmp_Id
            // 
            this.tmp_Id.HeaderText = "TmpId";
            this.tmp_Id.Name = "tmp_Id";
            this.tmp_Id.Visible = false;
            // 
            // tmp_No
            // 
            this.tmp_No.HeaderText = "Σήμα";
            this.tmp_No.Name = "tmp_No";
            this.tmp_No.ReadOnly = true;
            this.tmp_No.Width = 70;
            // 
            // tmp_Name
            // 
            this.tmp_Name.HeaderText = "Όνομα";
            this.tmp_Name.Name = "tmp_Name";
            this.tmp_Name.ReadOnly = true;
            // 
            // tmp_DepositDt
            // 
            this.tmp_DepositDt.HeaderText = "Κατάθεση";
            this.tmp_DepositDt.Name = "tmp_DepositDt";
            this.tmp_DepositDt.ReadOnly = true;
            this.tmp_DepositDt.Width = 95;
            // 
            // tmp_RenewalDt
            // 
            this.tmp_RenewalDt.HeaderText = "Ανανέωση";
            this.tmp_RenewalDt.Name = "tmp_RenewalDt";
            this.tmp_RenewalDt.ReadOnly = true;
            this.tmp_RenewalDt.Width = 95;
            // 
            // tmp_NatPower
            // 
            this.tmp_NatPower.HeaderText = "Εθν. Ισχύς";
            this.tmp_NatPower.Name = "tmp_NatPower";
            this.tmp_NatPower.ReadOnly = true;
            this.tmp_NatPower.Width = 68;
            // 
            // tmp_Com
            // 
            this.tmp_Com.HeaderText = "Εταιρία";
            this.tmp_Com.Name = "tmp_Com";
            this.tmp_Com.ReadOnly = true;
            // 
            // tmp_RespLawyer
            // 
            this.tmp_RespLawyer.HeaderText = "Υπεύθ. Δικηγόρος";
            this.tmp_RespLawyer.Name = "tmp_RespLawyer";
            this.tmp_RespLawyer.ReadOnly = true;
            this.tmp_RespLawyer.Width = 110;
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewTM,
            this.tsmiRecipients});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(176, 48);
            // 
            // tsmiViewTM
            // 
            this.tsmiViewTM.Name = "tsmiViewTM";
            this.tsmiViewTM.Size = new System.Drawing.Size(175, 22);
            this.tsmiViewTM.Text = "Εμφάνιση Σήματος";
            this.tsmiViewTM.Click += new System.EventHandler(this.tsmiViewTM_Click);
            // 
            // tsmiRecipients
            // 
            this.tsmiRecipients.Name = "tsmiRecipients";
            this.tsmiRecipients.Size = new System.Drawing.Size(175, 22);
            this.tsmiRecipients.Text = "Παραλήπτες";
            this.tsmiRecipients.Click += new System.EventHandler(this.tsmiRecipients_Click);
            // 
            // AlertsViewGrouped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 602);
            this.Controls.Add(this.dgvAlerts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlertsViewGrouped";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alerts View Grouped";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alarm_Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_ExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_ExpCountdown;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_NotificationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_AlertCountdown;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_NotifSentDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarm_Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_DepositDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_RenewalDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_NatPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Com;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_RespLawyer;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewTM;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecipients;
    }
}