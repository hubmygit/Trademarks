namespace Trademarks
{
    partial class Recipients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recipients));
            this.dgvRecipients = new System.Windows.Forms.DataGridView();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.dtpExpTime = new System.Windows.Forms.DateTimePicker();
            this.dtpExpDt = new System.Windows.Forms.DateTimePicker();
            this.lblExpDt = new System.Windows.Forms.Label();
            this.Rec_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecipients
            // 
            this.dgvRecipients.AllowUserToAddRows = false;
            this.dgvRecipients.AllowUserToDeleteRows = false;
            this.dgvRecipients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rec_Id,
            this.Rec_Name,
            this.Rec_Email});
            this.dgvRecipients.Location = new System.Drawing.Point(12, 127);
            this.dgvRecipients.MultiSelect = false;
            this.dgvRecipients.Name = "dgvRecipients";
            this.dgvRecipients.RowHeadersVisible = false;
            this.dgvRecipients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipients.Size = new System.Drawing.Size(500, 183);
            this.dgvRecipients.TabIndex = 26;
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(33, 54);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 24;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(142, 51);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.ReadOnly = true;
            this.txtTMName.Size = new System.Drawing.Size(350, 22);
            this.txtTMName.TabIndex = 25;
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(153, 23);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 22;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(271, 20);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 23;
            // 
            // dtpExpTime
            // 
            this.dtpExpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpExpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpExpTime.Location = new System.Drawing.Point(365, 83);
            this.dtpExpTime.Name = "dtpExpTime";
            this.dtpExpTime.ShowUpDown = true;
            this.dtpExpTime.Size = new System.Drawing.Size(100, 22);
            this.dtpExpTime.TabIndex = 21;
            // 
            // dtpExpDt
            // 
            this.dtpExpDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpExpDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDt.Location = new System.Drawing.Point(239, 83);
            this.dtpExpDt.Name = "dtpExpDt";
            this.dtpExpDt.Size = new System.Drawing.Size(120, 22);
            this.dtpExpDt.TabIndex = 20;
            // 
            // lblExpDt
            // 
            this.lblExpDt.AutoSize = true;
            this.lblExpDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblExpDt.Location = new System.Drawing.Point(60, 88);
            this.lblExpDt.Name = "lblExpDt";
            this.lblExpDt.Size = new System.Drawing.Size(173, 16);
            this.lblExpDt.TabIndex = 19;
            this.lblExpDt.Text = "Καταληκτική Ημ/νία και Ώρα";
            // 
            // Rec_Id
            // 
            this.Rec_Id.HeaderText = "Id";
            this.Rec_Id.Name = "Rec_Id";
            this.Rec_Id.Visible = false;
            this.Rec_Id.Width = 40;
            // 
            // Rec_Name
            // 
            this.Rec_Name.HeaderText = "Ονοματεπώνυμο";
            this.Rec_Name.Name = "Rec_Name";
            this.Rec_Name.ReadOnly = true;
            this.Rec_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rec_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rec_Name.Width = 230;
            // 
            // Rec_Email
            // 
            this.Rec_Email.HeaderText = "Email";
            this.Rec_Email.Name = "Rec_Email";
            this.Rec_Email.ReadOnly = true;
            this.Rec_Email.Width = 230;
            // 
            // Recipients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 322);
            this.Controls.Add(this.dgvRecipients);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.dtpExpTime);
            this.Controls.Add(this.dtpExpDt);
            this.Controls.Add(this.lblExpDt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Recipients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recipients";
            this.Load += new System.EventHandler(this.Recipients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvRecipients;
        private System.Windows.Forms.Label lblTMName;
        public System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label lblTMId;
        public System.Windows.Forms.TextBox txtTMId;
        public System.Windows.Forms.DateTimePicker dtpExpTime;
        public System.Windows.Forms.DateTimePicker dtpExpDt;
        private System.Windows.Forms.Label lblExpDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Email;
    }
}