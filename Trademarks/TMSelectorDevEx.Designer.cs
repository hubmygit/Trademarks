namespace Trademarks
{
    partial class TMSelectorDevEx
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMSelectorDevEx));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
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
            this.trademark_FullBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepositDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalPowerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMGrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleLawyerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileContents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFees = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.gbPrint = new System.Windows.Forms.GroupBox();
            this.rbPrintAll = new System.Windows.Forms.RadioButton();
            this.rbPrintChoosen = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trademark_FullBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.gbPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsOnGrid;
            this.gridControl1.DataSource = this.trademark_FullBindingSource;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "TMTypes";
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "TMClasses";
            gridLevelNode3.LevelTemplate = this.gridView4;
            gridLevelNode3.RelationName = "TMCountries";
            gridLevelNode4.RelationName = "TM_Statuses";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3,
            gridLevelNode4});
            this.gridControl1.Location = new System.Drawing.Point(221, 107);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(717, 364);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView4,
            this.gridView1,
            this.gridView2});
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
            // trademark_FullBindingSource
            // 
            this.trademark_FullBindingSource.DataSource = typeof(Trademarks.Trademark_Full);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTMNo,
            this.colDepositDt,
            this.colNationalPowerName,
            this.colTMGrNo,
            this.colCompanyName,
            this.colResponsibleLawyerName,
            this.colTMName,
            this.colFileName,
            this.colFileContents,
            this.colDescription,
            this.colFees,
            this.colValidTo,
            this.colIsDeleted});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colTMNo
            // 
            this.colTMNo.FieldName = "TMNo";
            this.colTMNo.Name = "colTMNo";
            this.colTMNo.Visible = true;
            this.colTMNo.VisibleIndex = 1;
            // 
            // colDepositDt
            // 
            this.colDepositDt.FieldName = "DepositDt";
            this.colDepositDt.Name = "colDepositDt";
            this.colDepositDt.Visible = true;
            this.colDepositDt.VisibleIndex = 2;
            // 
            // colNationalPowerName
            // 
            this.colNationalPowerName.FieldName = "NationalPowerName";
            this.colNationalPowerName.Name = "colNationalPowerName";
            this.colNationalPowerName.Visible = true;
            this.colNationalPowerName.VisibleIndex = 3;
            // 
            // colTMGrNo
            // 
            this.colTMGrNo.FieldName = "TMGrNo";
            this.colTMGrNo.Name = "colTMGrNo";
            this.colTMGrNo.Visible = true;
            this.colTMGrNo.VisibleIndex = 4;
            // 
            // colCompanyName
            // 
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 5;
            // 
            // colResponsibleLawyerName
            // 
            this.colResponsibleLawyerName.FieldName = "ResponsibleLawyerName";
            this.colResponsibleLawyerName.Name = "colResponsibleLawyerName";
            this.colResponsibleLawyerName.Visible = true;
            this.colResponsibleLawyerName.VisibleIndex = 6;
            // 
            // colTMName
            // 
            this.colTMName.FieldName = "TMName";
            this.colTMName.Name = "colTMName";
            this.colTMName.Visible = true;
            this.colTMName.VisibleIndex = 7;
            // 
            // colFileName
            // 
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 8;
            // 
            // colFileContents
            // 
            this.colFileContents.FieldName = "FileContents";
            this.colFileContents.Name = "colFileContents";
            this.colFileContents.Visible = true;
            this.colFileContents.VisibleIndex = 9;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 10;
            // 
            // colFees
            // 
            this.colFees.FieldName = "Fees";
            this.colFees.Name = "colFees";
            this.colFees.Visible = true;
            this.colFees.VisibleIndex = 11;
            // 
            // colValidTo
            // 
            this.colValidTo.FieldName = "ValidTo";
            this.colValidTo.Name = "colValidTo";
            this.colValidTo.Visible = true;
            this.colValidTo.VisibleIndex = 12;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 13;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Image = global::Trademarks.Properties.Resources.Create_32x;
            this.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNew.Location = new System.Drawing.Point(12, 12);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(100, 45);
            this.btnCreateNew.TabIndex = 35;
            this.btnCreateNew.Text = "Νέο Σήμα";
            this.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // gbPrint
            // 
            this.gbPrint.Controls.Add(this.rbPrintAll);
            this.gbPrint.Controls.Add(this.rbPrintChoosen);
            this.gbPrint.Location = new System.Drawing.Point(311, 6);
            this.gbPrint.Name = "gbPrint";
            this.gbPrint.Size = new System.Drawing.Size(89, 51);
            this.gbPrint.TabIndex = 39;
            this.gbPrint.TabStop = false;
            // 
            // rbPrintAll
            // 
            this.rbPrintAll.AutoSize = true;
            this.rbPrintAll.Location = new System.Drawing.Point(6, 29);
            this.rbPrintAll.Name = "rbPrintAll";
            this.rbPrintAll.Size = new System.Drawing.Size(46, 17);
            this.rbPrintAll.TabIndex = 6;
            this.rbPrintAll.Text = "Όλα";
            this.rbPrintAll.UseVisualStyleBackColor = true;
            // 
            // rbPrintChoosen
            // 
            this.rbPrintChoosen.AutoSize = true;
            this.rbPrintChoosen.Checked = true;
            this.rbPrintChoosen.Location = new System.Drawing.Point(6, 10);
            this.rbPrintChoosen.Name = "rbPrintChoosen";
            this.rbPrintChoosen.Size = new System.Drawing.Size(81, 17);
            this.rbPrintChoosen.TabIndex = 5;
            this.rbPrintChoosen.TabStop = true;
            this.rbPrintChoosen.Text = "Επιλεγμένο";
            this.rbPrintChoosen.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Trademarks.Properties.Resources.SwitchToPreview_32x;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(205, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 45);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = "Εκτύπωση";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // TMSelectorDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 762);
            this.Controls.Add(this.gbPrint);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 800);
            this.Name = "TMSelectorDevEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εμπορικά Σήματα";
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trademark_FullBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.gbPrint.ResumeLayout(false);
            this.gbPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource trademark_FullBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTMNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDepositDt;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalPowerName;
        private DevExpress.XtraGrid.Columns.GridColumn colTMGrNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleLawyerName;
        private DevExpress.XtraGrid.Columns.GridColumn colTMName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileContents;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colFees;
        private DevExpress.XtraGrid.Columns.GridColumn colValidTo;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewTM;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdTM;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelTM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiDecision;
        private System.Windows.Forms.ToolStripMenuItem tsmiAppeal;
        private System.Windows.Forms.ToolStripMenuItem tsmiTermination;
        private System.Windows.Forms.ToolStripMenuItem tsmiFinalization;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenewal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatusViewer;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlertsViewer;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenUrl;
        private System.Windows.Forms.ToolStripMenuItem tsmiTmLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.GroupBox gbPrint;
        private System.Windows.Forms.RadioButton rbPrintAll;
        private System.Windows.Forms.RadioButton rbPrintChoosen;
        private System.Windows.Forms.Button btnPrint;
    }
}