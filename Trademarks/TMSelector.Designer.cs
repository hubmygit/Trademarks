namespace Trademarks
{
    partial class TMSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMSelector));
            this.dgvTempRecs = new System.Windows.Forms.DataGridView();
            this.tmp_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_DepositDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_NatPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Responsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDecision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAppeal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTermination = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFinalization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenewal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiStatusViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlertsViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUpdTM = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTempRecs
            // 
            this.dgvTempRecs.AllowUserToAddRows = false;
            this.dgvTempRecs.AllowUserToDeleteRows = false;
            this.dgvTempRecs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTempRecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempRecs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmp_Id,
            this.tmp_No,
            this.tmp_Name,
            this.tmp_DepositDt,
            this.tmp_NatPower,
            this.tmp_Responsible});
            this.dgvTempRecs.ContextMenuStrip = this.cmsOnGrid;
            this.dgvTempRecs.Location = new System.Drawing.Point(0, 79);
            this.dgvTempRecs.MultiSelect = false;
            this.dgvTempRecs.Name = "dgvTempRecs";
            this.dgvTempRecs.RowTemplate.Height = 24;
            this.dgvTempRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTempRecs.Size = new System.Drawing.Size(784, 483);
            this.dgvTempRecs.TabIndex = 3;
            this.dgvTempRecs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvTempRecs_MouseDown);
            // 
            // tmp_Id
            // 
            this.tmp_Id.HeaderText = "Id";
            this.tmp_Id.Name = "tmp_Id";
            this.tmp_Id.Visible = false;
            // 
            // tmp_No
            // 
            this.tmp_No.HeaderText = "Σήμα";
            this.tmp_No.Name = "tmp_No";
            this.tmp_No.ReadOnly = true;
            // 
            // tmp_Name
            // 
            this.tmp_Name.HeaderText = "Όνομα";
            this.tmp_Name.Name = "tmp_Name";
            this.tmp_Name.ReadOnly = true;
            this.tmp_Name.Width = 220;
            // 
            // tmp_DepositDt
            // 
            this.tmp_DepositDt.HeaderText = "Κατάθεση";
            this.tmp_DepositDt.Name = "tmp_DepositDt";
            this.tmp_DepositDt.ReadOnly = true;
            // 
            // tmp_NatPower
            // 
            this.tmp_NatPower.HeaderText = "Εθνική Ισχύς";
            this.tmp_NatPower.Name = "tmp_NatPower";
            this.tmp_NatPower.ReadOnly = true;
            // 
            // tmp_Responsible
            // 
            this.tmp_Responsible.HeaderText = "Υπεύθυνος";
            this.tmp_Responsible.Name = "tmp_Responsible";
            this.tmp_Responsible.ReadOnly = true;
            this.tmp_Responsible.Width = 180;
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDecision,
            this.tsmiAppeal,
            this.tsmiTermination,
            this.tsmiFinalization,
            this.tsmiRenewal,
            this.toolStripSeparator1,
            this.tsmiStatusViewer,
            this.tsmiAlertsViewer,
            this.toolStripSeparator2,
            this.tsmiUpdTM});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(181, 214);
            // 
            // tsmiDecision
            // 
            this.tsmiDecision.Name = "tsmiDecision";
            this.tsmiDecision.Size = new System.Drawing.Size(180, 22);
            this.tsmiDecision.Text = "Απόφαση";
            this.tsmiDecision.Click += new System.EventHandler(this.tsmiDecision_Click);
            // 
            // tsmiAppeal
            // 
            this.tsmiAppeal.Name = "tsmiAppeal";
            this.tsmiAppeal.Size = new System.Drawing.Size(180, 22);
            this.tsmiAppeal.Text = "Προσφυγή";
            this.tsmiAppeal.Click += new System.EventHandler(this.tsmiAppeal_Click);
            // 
            // tsmiTermination
            // 
            this.tsmiTermination.Name = "tsmiTermination";
            this.tsmiTermination.Size = new System.Drawing.Size(180, 22);
            this.tsmiTermination.Text = "Ανακοπή";
            this.tsmiTermination.Click += new System.EventHandler(this.tsmiTermination_Click);
            // 
            // tsmiFinalization
            // 
            this.tsmiFinalization.Name = "tsmiFinalization";
            this.tsmiFinalization.Size = new System.Drawing.Size(180, 22);
            this.tsmiFinalization.Text = "Οριστικοποίηση";
            this.tsmiFinalization.Click += new System.EventHandler(this.tsmiFinalization_Click);
            // 
            // tsmiRenewal
            // 
            this.tsmiRenewal.Name = "tsmiRenewal";
            this.tsmiRenewal.Size = new System.Drawing.Size(180, 22);
            this.tsmiRenewal.Text = "Ανανέωση";
            this.tsmiRenewal.Click += new System.EventHandler(this.tsmiRenewal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiStatusViewer
            // 
            this.tsmiStatusViewer.Name = "tsmiStatusViewer";
            this.tsmiStatusViewer.Size = new System.Drawing.Size(180, 22);
            this.tsmiStatusViewer.Text = "Καταστάσεις";
            this.tsmiStatusViewer.Click += new System.EventHandler(this.tsmiStatusViewer_Click);
            // 
            // tsmiAlertsViewer
            // 
            this.tsmiAlertsViewer.Name = "tsmiAlertsViewer";
            this.tsmiAlertsViewer.Size = new System.Drawing.Size(180, 22);
            this.tsmiAlertsViewer.Text = "Ειδοποιήσεις";
            this.tsmiAlertsViewer.Click += new System.EventHandler(this.tsmiAlertsViewer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiUpdTM
            // 
            this.tsmiUpdTM.Name = "tsmiUpdTM";
            this.tsmiUpdTM.Size = new System.Drawing.Size(180, 22);
            this.tsmiUpdTM.Text = "UpdateTM";
            this.tsmiUpdTM.Click += new System.EventHandler(this.tsmiUpdTM_Click);
            // 
            // TMSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dgvTempRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TMSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εμπορικά Σήματα";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTempRecs;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_DepositDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_NatPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Responsible;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiDecision;
        private System.Windows.Forms.ToolStripMenuItem tsmiAppeal;
        private System.Windows.Forms.ToolStripMenuItem tsmiTermination;
        private System.Windows.Forms.ToolStripMenuItem tsmiFinalization;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenewal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatusViewer;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlertsViewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdTM;
    }
}