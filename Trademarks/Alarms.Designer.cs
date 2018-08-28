namespace Trademarks
{
    partial class Alarms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarms));
            this.dgvAlarms = new System.Windows.Forms.DataGridView();
            this.dtpExpDt = new System.Windows.Forms.DateTimePicker();
            this.lblExpDt = new System.Windows.Forms.Label();
            this.dtpExpTime = new System.Windows.Forms.DateTimePicker();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.dgvRecipients = new System.Windows.Forms.DataGridView();
            this.Rec_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rec_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alarm_NotificationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlarms
            // 
            this.dgvAlarms.AllowUserToAddRows = false;
            this.dgvAlarms.AllowUserToDeleteRows = false;
            this.dgvAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Alarm_Id,
            this.Alarm_Active,
            this.Alarm_NotificationDate,
            this.Alarm_Event,
            this.Alarm_Period});
            this.dgvAlarms.Location = new System.Drawing.Point(42, 237);
            this.dgvAlarms.MultiSelect = false;
            this.dgvAlarms.Name = "dgvAlarms";
            this.dgvAlarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarms.Size = new System.Drawing.Size(500, 200);
            this.dgvAlarms.TabIndex = 0;
            // 
            // dtpExpDt
            // 
            this.dtpExpDt.Enabled = false;
            this.dtpExpDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpExpDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDt.Location = new System.Drawing.Point(250, 77);
            this.dtpExpDt.Name = "dtpExpDt";
            this.dtpExpDt.Size = new System.Drawing.Size(120, 22);
            this.dtpExpDt.TabIndex = 4;
            // 
            // lblExpDt
            // 
            this.lblExpDt.AutoSize = true;
            this.lblExpDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblExpDt.Location = new System.Drawing.Point(108, 82);
            this.lblExpDt.Name = "lblExpDt";
            this.lblExpDt.Size = new System.Drawing.Size(136, 16);
            this.lblExpDt.TabIndex = 3;
            this.lblExpDt.Text = "Ημ/νία και Ώρα Λήξης";
            // 
            // dtpExpTime
            // 
            this.dtpExpTime.Enabled = false;
            this.dtpExpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpExpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpExpTime.Location = new System.Drawing.Point(376, 77);
            this.dtpExpTime.Name = "dtpExpTime";
            this.dtpExpTime.ShowUpDown = true;
            this.dtpExpTime.Size = new System.Drawing.Size(100, 22);
            this.dtpExpTime.TabIndex = 6;
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(183, 17);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 7;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(301, 14);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 8;
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(63, 48);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 12;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(172, 45);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.ReadOnly = true;
            this.txtTMName.Size = new System.Drawing.Size(350, 22);
            this.txtTMName.TabIndex = 13;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOk.Location = new System.Drawing.Point(255, 460);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dgvRecipients
            // 
            this.dgvRecipients.AllowUserToAddRows = false;
            this.dgvRecipients.AllowUserToDeleteRows = false;
            this.dgvRecipients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rec_Id,
            this.Rec_Checked,
            this.Rec_Name,
            this.Rec_Email});
            this.dgvRecipients.Location = new System.Drawing.Point(42, 110);
            this.dgvRecipients.MultiSelect = false;
            this.dgvRecipients.Name = "dgvRecipients";
            this.dgvRecipients.RowHeadersVisible = false;
            this.dgvRecipients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipients.Size = new System.Drawing.Size(500, 110);
            this.dgvRecipients.TabIndex = 18;
            // 
            // Rec_Id
            // 
            this.Rec_Id.HeaderText = "Id";
            this.Rec_Id.Name = "Rec_Id";
            this.Rec_Id.Visible = false;
            this.Rec_Id.Width = 40;
            // 
            // Rec_Checked
            // 
            this.Rec_Checked.HeaderText = "";
            this.Rec_Checked.Name = "Rec_Checked";
            this.Rec_Checked.Width = 20;
            // 
            // Rec_Name
            // 
            this.Rec_Name.HeaderText = "Ονοματεπώνυμο";
            this.Rec_Name.Name = "Rec_Name";
            this.Rec_Name.ReadOnly = true;
            this.Rec_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rec_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rec_Name.Width = 220;
            // 
            // Rec_Email
            // 
            this.Rec_Email.HeaderText = "Email";
            this.Rec_Email.Name = "Rec_Email";
            this.Rec_Email.ReadOnly = true;
            this.Rec_Email.Width = 220;
            // 
            // Alarm_Id
            // 
            this.Alarm_Id.HeaderText = "Id";
            this.Alarm_Id.Name = "Alarm_Id";
            this.Alarm_Id.Visible = false;
            // 
            // Alarm_Active
            // 
            this.Alarm_Active.HeaderText = "Ενεργό";
            this.Alarm_Active.Name = "Alarm_Active";
            this.Alarm_Active.ReadOnly = true;
            this.Alarm_Active.Width = 50;
            // 
            // Alarm_NotificationDate
            // 
            this.Alarm_NotificationDate.HeaderText = "Ημ/νία Ειδοποίησης";
            this.Alarm_NotificationDate.Name = "Alarm_NotificationDate";
            this.Alarm_NotificationDate.ReadOnly = true;
            this.Alarm_NotificationDate.Width = 120;
            // 
            // Alarm_Event
            // 
            this.Alarm_Event.HeaderText = "Γεγονός";
            this.Alarm_Event.Name = "Alarm_Event";
            this.Alarm_Event.ReadOnly = true;
            this.Alarm_Event.Width = 160;
            // 
            // Alarm_Period
            // 
            this.Alarm_Period.HeaderText = "Περίοδος";
            this.Alarm_Period.Name = "Alarm_Period";
            this.Alarm_Period.ReadOnly = true;
            this.Alarm_Period.Width = 90;
            // 
            // Alarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 502);
            this.Controls.Add(this.dgvRecipients);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.dtpExpTime);
            this.Controls.Add(this.dtpExpDt);
            this.Controls.Add(this.lblExpDt);
            this.Controls.Add(this.dgvAlarms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 540);
            this.MinimumSize = new System.Drawing.Size(600, 540);
            this.Name = "Alarms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alarms";
            this.Load += new System.EventHandler(this.Alarms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblExpDt;
        public System.Windows.Forms.DateTimePicker dtpExpDt;
        public System.Windows.Forms.DateTimePicker dtpExpTime;
        public System.Windows.Forms.DataGridView dgvAlarms;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.Label lblTMName;
        public System.Windows.Forms.TextBox txtTMId;
        public System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rec_Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alarm_Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_NotificationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Period;
        public System.Windows.Forms.DataGridView dgvRecipients;
    }
}