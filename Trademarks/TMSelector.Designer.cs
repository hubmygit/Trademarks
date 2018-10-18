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
            this.tmp_Pic = new System.Windows.Forms.DataGridViewImageColumn();
            this.tmp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_DepositDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_NatPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_GrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Com = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Responsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_IsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiViewTM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdTM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelTM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDecision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAppeal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTermination = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFinalization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenewal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiStatusViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlertsViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTmLog = new System.Windows.Forms.ToolStripMenuItem();
            this.cbNatPower = new System.Windows.Forms.ComboBox();
            this.lblNatPower = new System.Windows.Forms.Label();
            this.cbLawyerFullname = new System.Windows.Forms.ComboBox();
            this.lblLawyerFullname = new System.Windows.Forms.Label();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chbDeleted = new System.Windows.Forms.CheckBox();
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
            this.tmp_Pic,
            this.tmp_Name,
            this.tmp_DepositDt,
            this.tmp_NatPower,
            this.tmp_GrNo,
            this.tmp_Com,
            this.tmp_Responsible,
            this.tmp_IsDeleted});
            this.dgvTempRecs.ContextMenuStrip = this.cmsOnGrid;
            this.dgvTempRecs.Location = new System.Drawing.Point(0, 119);
            this.dgvTempRecs.MultiSelect = false;
            this.dgvTempRecs.Name = "dgvTempRecs";
            this.dgvTempRecs.RowTemplate.Height = 50;
            this.dgvTempRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTempRecs.Size = new System.Drawing.Size(1234, 643);
            this.dgvTempRecs.TabIndex = 3;
            this.dgvTempRecs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTempRecs_CellDoubleClick);
            this.dgvTempRecs.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvTempRecs_SortCompare);
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
            // tmp_Pic
            // 
            this.tmp_Pic.HeaderText = "Αρχείο";
            this.tmp_Pic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.tmp_Pic.Name = "tmp_Pic";
            this.tmp_Pic.ReadOnly = true;
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
            // tmp_GrNo
            // 
            this.tmp_GrNo.HeaderText = "Συνδ. Εθν. Σήμα";
            this.tmp_GrNo.Name = "tmp_GrNo";
            this.tmp_GrNo.ReadOnly = true;
            this.tmp_GrNo.Width = 120;
            // 
            // tmp_Com
            // 
            this.tmp_Com.HeaderText = "Εταιρία";
            this.tmp_Com.Name = "tmp_Com";
            this.tmp_Com.ReadOnly = true;
            this.tmp_Com.Width = 220;
            // 
            // tmp_Responsible
            // 
            this.tmp_Responsible.HeaderText = "Υπεύθυνος";
            this.tmp_Responsible.Name = "tmp_Responsible";
            this.tmp_Responsible.ReadOnly = true;
            this.tmp_Responsible.Width = 180;
            // 
            // tmp_IsDeleted
            // 
            this.tmp_IsDeleted.HeaderText = "Διαγραμμένο";
            this.tmp_IsDeleted.Name = "tmp_IsDeleted";
            this.tmp_IsDeleted.ReadOnly = true;
            this.tmp_IsDeleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmp_IsDeleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewTM,
            this.tsmiUpdTM,
            this.tsmiDelTM,
            this.toolStripSeparator2,
            this.tsmiDecision,
            this.tsmiAppeal,
            this.tsmiTermination,
            this.tsmiFinalization,
            this.tsmiRenewal,
            this.toolStripSeparator1,
            this.tsmiStatusViewer,
            this.tsmiAlertsViewer,
            this.tsmiOpenUrl,
            this.tsmiTmLog});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(233, 280);
            // 
            // tsmiViewTM
            // 
            this.tsmiViewTM.Name = "tsmiViewTM";
            this.tsmiViewTM.Size = new System.Drawing.Size(232, 22);
            this.tsmiViewTM.Text = "Εμφάνιση Σήματος";
            this.tsmiViewTM.Click += new System.EventHandler(this.tsmiViewTM_Click);
            // 
            // tsmiUpdTM
            // 
            this.tsmiUpdTM.Name = "tsmiUpdTM";
            this.tsmiUpdTM.Size = new System.Drawing.Size(232, 22);
            this.tsmiUpdTM.Text = "Μεταβολή Σήματος";
            this.tsmiUpdTM.Click += new System.EventHandler(this.tsmiUpdTM_Click);
            // 
            // tsmiDelTM
            // 
            this.tsmiDelTM.Name = "tsmiDelTM";
            this.tsmiDelTM.Size = new System.Drawing.Size(232, 22);
            this.tsmiDelTM.Text = "Διαγραφή Σήματος";
            this.tsmiDelTM.Click += new System.EventHandler(this.tsmiDelTM_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // tsmiDecision
            // 
            this.tsmiDecision.Name = "tsmiDecision";
            this.tsmiDecision.Size = new System.Drawing.Size(232, 22);
            this.tsmiDecision.Text = "Δημιουργία Απόφασης";
            this.tsmiDecision.Click += new System.EventHandler(this.tsmiDecision_Click);
            // 
            // tsmiAppeal
            // 
            this.tsmiAppeal.Name = "tsmiAppeal";
            this.tsmiAppeal.Size = new System.Drawing.Size(232, 22);
            this.tsmiAppeal.Text = "Δημιουργία Προσφυγής";
            this.tsmiAppeal.Click += new System.EventHandler(this.tsmiAppeal_Click);
            // 
            // tsmiTermination
            // 
            this.tsmiTermination.Name = "tsmiTermination";
            this.tsmiTermination.Size = new System.Drawing.Size(232, 22);
            this.tsmiTermination.Text = "Δημιουργία Ανακοπής";
            this.tsmiTermination.Click += new System.EventHandler(this.tsmiTermination_Click);
            // 
            // tsmiFinalization
            // 
            this.tsmiFinalization.Name = "tsmiFinalization";
            this.tsmiFinalization.Size = new System.Drawing.Size(232, 22);
            this.tsmiFinalization.Text = "Δημιουργία Οριστικοποίησης";
            this.tsmiFinalization.Click += new System.EventHandler(this.tsmiFinalization_Click);
            // 
            // tsmiRenewal
            // 
            this.tsmiRenewal.Name = "tsmiRenewal";
            this.tsmiRenewal.Size = new System.Drawing.Size(232, 22);
            this.tsmiRenewal.Text = "Δημιουργία Ανανέωσης";
            this.tsmiRenewal.Click += new System.EventHandler(this.tsmiRenewal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // tsmiStatusViewer
            // 
            this.tsmiStatusViewer.Name = "tsmiStatusViewer";
            this.tsmiStatusViewer.Size = new System.Drawing.Size(232, 22);
            this.tsmiStatusViewer.Text = "Καταστάσεις";
            this.tsmiStatusViewer.Click += new System.EventHandler(this.tsmiStatusViewer_Click);
            // 
            // tsmiAlertsViewer
            // 
            this.tsmiAlertsViewer.Name = "tsmiAlertsViewer";
            this.tsmiAlertsViewer.Size = new System.Drawing.Size(232, 22);
            this.tsmiAlertsViewer.Text = "Ειδοποιήσεις";
            this.tsmiAlertsViewer.Click += new System.EventHandler(this.tsmiAlertsViewer_Click);
            // 
            // tsmiOpenUrl
            // 
            this.tsmiOpenUrl.Name = "tsmiOpenUrl";
            this.tsmiOpenUrl.Size = new System.Drawing.Size(232, 22);
            this.tsmiOpenUrl.Text = "Άνοιγμα Υπερσυνδέσμου";
            this.tsmiOpenUrl.Click += new System.EventHandler(this.tsmiOpenUrl_Click);
            // 
            // tsmiTmLog
            // 
            this.tsmiTmLog.Name = "tsmiTmLog";
            this.tsmiTmLog.Size = new System.Drawing.Size(232, 22);
            this.tsmiTmLog.Text = "Log Μεταβολών";
            this.tsmiTmLog.Click += new System.EventHandler(this.tsmiTmLog_Click);
            // 
            // cbNatPower
            // 
            this.cbNatPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNatPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbNatPower.FormattingEnabled = true;
            this.cbNatPower.ItemHeight = 16;
            this.cbNatPower.Items.AddRange(new object[] {
            "Όλα"});
            this.cbNatPower.Location = new System.Drawing.Point(958, 12);
            this.cbNatPower.Name = "cbNatPower";
            this.cbNatPower.Size = new System.Drawing.Size(150, 24);
            this.cbNatPower.TabIndex = 32;
            // 
            // lblNatPower
            // 
            this.lblNatPower.AutoSize = true;
            this.lblNatPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblNatPower.Location = new System.Drawing.Point(870, 15);
            this.lblNatPower.Name = "lblNatPower";
            this.lblNatPower.Size = new System.Drawing.Size(82, 16);
            this.lblNatPower.TabIndex = 31;
            this.lblNatPower.Text = "Εθνική Ισχύς";
            // 
            // cbLawyerFullname
            // 
            this.cbLawyerFullname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLawyerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbLawyerFullname.FormattingEnabled = true;
            this.cbLawyerFullname.ItemHeight = 16;
            this.cbLawyerFullname.Items.AddRange(new object[] {
            "Όλα"});
            this.cbLawyerFullname.Location = new System.Drawing.Point(608, 12);
            this.cbLawyerFullname.Name = "cbLawyerFullname";
            this.cbLawyerFullname.Size = new System.Drawing.Size(250, 24);
            this.cbLawyerFullname.TabIndex = 30;
            // 
            // lblLawyerFullname
            // 
            this.lblLawyerFullname.AutoSize = true;
            this.lblLawyerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLawyerFullname.Location = new System.Drawing.Point(475, 15);
            this.lblLawyerFullname.Name = "lblLawyerFullname";
            this.lblLawyerFullname.Size = new System.Drawing.Size(126, 16);
            this.lblLawyerFullname.TabIndex = 29;
            this.lblLawyerFullname.Text = "Ονομ/μο Δικηγόρου";
            // 
            // cbCompany
            // 
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.ItemHeight = 16;
            this.cbCompany.Items.AddRange(new object[] {
            "Όλα"});
            this.cbCompany.Location = new System.Drawing.Point(608, 45);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(500, 24);
            this.cbCompany.TabIndex = 28;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(549, 48);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(52, 16);
            this.lblCompany.TabIndex = 27;
            this.lblCompany.Text = "Εταιρία";
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(154, 48);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 23;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(263, 45);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.Size = new System.Drawing.Size(200, 22);
            this.txtTMName.TabIndex = 26;
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(145, 15);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 24;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(263, 12);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.Size = new System.Drawing.Size(200, 22);
            this.txtTMId.TabIndex = 25;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Image = global::Trademarks.Properties.Resources.Create_32x;
            this.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNew.Location = new System.Drawing.Point(12, 16);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(100, 45);
            this.btnCreateNew.TabIndex = 34;
            this.btnCreateNew.Text = "Νέο Σήμα";
            this.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Trademarks.Properties.Resources.find_40x;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1132, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 45);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "Εύρεση";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chbDeleted
            // 
            this.chbDeleted.AutoSize = true;
            this.chbDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbDeleted.Location = new System.Drawing.Point(898, 84);
            this.chbDeleted.Name = "chbDeleted";
            this.chbDeleted.Size = new System.Drawing.Size(210, 20);
            this.chbDeleted.TabIndex = 35;
            this.chbDeleted.Text = "Διαγραμμένα Εμπορικά Σήματα";
            this.chbDeleted.ThreeState = true;
            this.chbDeleted.UseVisualStyleBackColor = true;
            // 
            // TMSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 762);
            this.Controls.Add(this.chbDeleted);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbNatPower);
            this.Controls.Add(this.lblNatPower);
            this.Controls.Add(this.cbLawyerFullname);
            this.Controls.Add(this.lblLawyerFullname);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.dgvTempRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 800);
            this.Name = "TMSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εμπορικά Σήματα";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTempRecs;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiDelTM;
        private System.Windows.Forms.ComboBox cbNatPower;
        private System.Windows.Forms.Label lblNatPower;
        private System.Windows.Forms.ComboBox cbLawyerFullname;
        private System.Windows.Forms.Label lblLawyerFullname;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenUrl;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewTM;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiTmLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_No;
        private System.Windows.Forms.DataGridViewImageColumn tmp_Pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_DepositDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_NatPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_GrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Com;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Responsible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tmp_IsDeleted;
        private System.Windows.Forms.CheckBox chbDeleted;
    }
}