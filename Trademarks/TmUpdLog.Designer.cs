namespace Trademarks
{
    partial class TmUpdLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TmUpdLog));
            this.dgvTmLogRecs = new System.Windows.Forms.DataGridView();
            this.Log_TmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_TsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_ExecStatement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_Dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_TMNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_TMName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_FieldNameToShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTmLogRecs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTmLogRecs
            // 
            this.dgvTmLogRecs.AllowUserToAddRows = false;
            this.dgvTmLogRecs.AllowUserToDeleteRows = false;
            this.dgvTmLogRecs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTmLogRecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTmLogRecs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Log_TmId,
            this.Log_TsId,
            this.Log_ExecStatement,
            this.Log_Dt,
            this.Log_FullName,
            this.Log_TMNo,
            this.Log_TMName,
            this.Log_Status,
            this.Log_FieldNameToShow,
            this.Log_OldValue,
            this.Log_NewValue});
            this.dgvTmLogRecs.Location = new System.Drawing.Point(0, 0);
            this.dgvTmLogRecs.MultiSelect = false;
            this.dgvTmLogRecs.Name = "dgvTmLogRecs";
            this.dgvTmLogRecs.RowTemplate.Height = 24;
            this.dgvTmLogRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTmLogRecs.Size = new System.Drawing.Size(984, 442);
            this.dgvTmLogRecs.TabIndex = 4;
            // 
            // Log_TmId
            // 
            this.Log_TmId.HeaderText = "TmId";
            this.Log_TmId.Name = "Log_TmId";
            this.Log_TmId.Visible = false;
            // 
            // Log_TsId
            // 
            this.Log_TsId.HeaderText = "TsId";
            this.Log_TsId.Name = "Log_TsId";
            this.Log_TsId.Visible = false;
            // 
            // Log_ExecStatement
            // 
            this.Log_ExecStatement.HeaderText = "Statement";
            this.Log_ExecStatement.Name = "Log_ExecStatement";
            this.Log_ExecStatement.ReadOnly = true;
            this.Log_ExecStatement.Width = 80;
            // 
            // Log_Dt
            // 
            this.Log_Dt.HeaderText = "Datetime";
            this.Log_Dt.Name = "Log_Dt";
            this.Log_Dt.ReadOnly = true;
            // 
            // Log_FullName
            // 
            this.Log_FullName.HeaderText = "Full Name";
            this.Log_FullName.Name = "Log_FullName";
            this.Log_FullName.ReadOnly = true;
            // 
            // Log_TMNo
            // 
            this.Log_TMNo.HeaderText = "Tm";
            this.Log_TMNo.Name = "Log_TMNo";
            this.Log_TMNo.ReadOnly = true;
            this.Log_TMNo.Width = 90;
            // 
            // Log_TMName
            // 
            this.Log_TMName.HeaderText = "Tm Name";
            this.Log_TMName.Name = "Log_TMName";
            this.Log_TMName.ReadOnly = true;
            this.Log_TMName.Width = 110;
            // 
            // Log_Status
            // 
            this.Log_Status.HeaderText = "Status";
            this.Log_Status.Name = "Log_Status";
            this.Log_Status.ReadOnly = true;
            this.Log_Status.Width = 120;
            // 
            // Log_FieldNameToShow
            // 
            this.Log_FieldNameToShow.HeaderText = "Field Name";
            this.Log_FieldNameToShow.Name = "Log_FieldNameToShow";
            this.Log_FieldNameToShow.ReadOnly = true;
            this.Log_FieldNameToShow.Width = 90;
            // 
            // Log_OldValue
            // 
            this.Log_OldValue.HeaderText = "Old Value";
            this.Log_OldValue.Name = "Log_OldValue";
            this.Log_OldValue.ReadOnly = true;
            // 
            // Log_NewValue
            // 
            this.Log_NewValue.HeaderText = "New Value";
            this.Log_NewValue.Name = "Log_NewValue";
            this.Log_NewValue.ReadOnly = true;
            // 
            // TmUpdLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 442);
            this.Controls.Add(this.dgvTmLogRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TmUpdLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTmLogRecs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTmLogRecs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_TmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_TsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_ExecStatement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_Dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_TMNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_TMName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_FieldNameToShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_OldValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log_NewValue;
    }
}