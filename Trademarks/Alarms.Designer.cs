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
            this.Alarm_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alarm_NotificationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpExpDt = new System.Windows.Forms.DateTimePicker();
            this.lblExpDt = new System.Windows.Forms.Label();
            this.dtpExpTime = new System.Windows.Forms.DateTimePicker();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).BeginInit();
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
            this.dgvAlarms.Location = new System.Drawing.Point(44, 115);
            this.dgvAlarms.MultiSelect = false;
            this.dgvAlarms.Name = "dgvAlarms";
            this.dgvAlarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarms.Size = new System.Drawing.Size(497, 268);
            this.dgvAlarms.TabIndex = 0;
            // 
            // Alarm_Id
            // 
            this.Alarm_Id.HeaderText = "Id";
            this.Alarm_Id.Name = "Alarm_Id";
            this.Alarm_Id.Visible = false;
            // 
            // Alarm_Active
            // 
            this.Alarm_Active.HeaderText = "Active";
            this.Alarm_Active.Name = "Alarm_Active";
            this.Alarm_Active.ReadOnly = true;
            this.Alarm_Active.Width = 50;
            // 
            // Alarm_NotificationDate
            // 
            this.Alarm_NotificationDate.HeaderText = "Notification Date";
            this.Alarm_NotificationDate.Name = "Alarm_NotificationDate";
            this.Alarm_NotificationDate.ReadOnly = true;
            this.Alarm_NotificationDate.Width = 120;
            // 
            // Alarm_Event
            // 
            this.Alarm_Event.HeaderText = "Event Type";
            this.Alarm_Event.Name = "Alarm_Event";
            this.Alarm_Event.ReadOnly = true;
            this.Alarm_Event.Width = 160;
            // 
            // Alarm_Period
            // 
            this.Alarm_Period.HeaderText = "Period";
            this.Alarm_Period.Name = "Alarm_Period";
            this.Alarm_Period.ReadOnly = true;
            this.Alarm_Period.Width = 90;
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
            this.btnOk.Location = new System.Drawing.Point(255, 400);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Alarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 442);
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
            this.MaximumSize = new System.Drawing.Size(600, 480);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "Alarms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alarms";
            this.Load += new System.EventHandler(this.Alarms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alarm_Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_NotificationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Period;
        private System.Windows.Forms.Button btnOk;
    }
}