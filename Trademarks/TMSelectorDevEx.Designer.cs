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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMSelectorDevEx));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ObJ_Type_Name = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.Obj_Class_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Class_Headers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Obj_Countries_NameShort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Countries_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Obj_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Pic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_DepositDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_ValidTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_NatPower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_GrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Com = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Responsible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_IsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.gbPrint = new System.Windows.Forms.GroupBox();
            this.rbPrintAll = new System.Windows.Forms.RadioButton();
            this.rbPrintChoosen = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcelExport = new System.Windows.Forms.Button();
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
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ObJ_Type_Name});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.ViewCaption = "Τύποι";
            // 
            // ObJ_Type_Name
            // 
            this.ObJ_Type_Name.Caption = "Όνομα";
            this.ObJ_Type_Name.FieldName = "Name";
            this.ObJ_Type_Name.Name = "ObJ_Type_Name";
            this.ObJ_Type_Name.Visible = true;
            this.ObJ_Type_Name.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsOnGrid;
            this.gridControl1.DataSource = this.trademark_FullBindingSource;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "TMTypes";
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "TMClasses";
            gridLevelNode3.LevelTemplate = this.gridView4;
            gridLevelNode3.RelationName = "TMCountries";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.gridControl1.Location = new System.Drawing.Point(0, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(1184, 499);
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
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Obj_Class_No,
            this.Obj_Class_Headers});
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.ViewCaption = "Κλάσεις";
            // 
            // Obj_Class_No
            // 
            this.Obj_Class_No.Caption = "Νο";
            this.Obj_Class_No.FieldName = "No";
            this.Obj_Class_No.Name = "Obj_Class_No";
            this.Obj_Class_No.Visible = true;
            this.Obj_Class_No.VisibleIndex = 0;
            // 
            // Obj_Class_Headers
            // 
            this.Obj_Class_Headers.Caption = "Επικεφαλίδες";
            this.Obj_Class_Headers.FieldName = "Headers";
            this.Obj_Class_Headers.Name = "Obj_Class_Headers";
            this.Obj_Class_Headers.Visible = true;
            this.Obj_Class_Headers.VisibleIndex = 1;
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Obj_Countries_NameShort,
            this.Obj_Countries_Name});
            this.gridView4.GridControl = this.gridControl1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.ReadOnly = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.ViewCaption = "Χώρες";
            // 
            // Obj_Countries_NameShort
            // 
            this.Obj_Countries_NameShort.Caption = "Συντομογραφία";
            this.Obj_Countries_NameShort.FieldName = "NameShort";
            this.Obj_Countries_NameShort.Name = "Obj_Countries_NameShort";
            this.Obj_Countries_NameShort.Visible = true;
            this.Obj_Countries_NameShort.VisibleIndex = 0;
            // 
            // Obj_Countries_Name
            // 
            this.Obj_Countries_Name.Caption = "Όνομα";
            this.Obj_Countries_Name.FieldName = "Name";
            this.Obj_Countries_Name.Name = "Obj_Countries_Name";
            this.Obj_Countries_Name.Visible = true;
            this.Obj_Countries_Name.VisibleIndex = 1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Obj_Id,
            this.Obj_No,
            this.Obj_Pic,
            this.Obj_Name,
            this.Obj_DepositDt,
            this.Obj_ValidTo,
            this.Obj_NatPower,
            this.Obj_GrNo,
            this.Obj_Com,
            this.Obj_Responsible,
            this.Obj_IsDeleted});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // Obj_Id
            // 
            this.Obj_Id.Caption = "Id";
            this.Obj_Id.FieldName = "Id";
            this.Obj_Id.Name = "Obj_Id";
            // 
            // Obj_No
            // 
            this.Obj_No.Caption = "Σήμα";
            this.Obj_No.FieldName = "TMNo";
            this.Obj_No.Name = "Obj_No";
            this.Obj_No.Visible = true;
            this.Obj_No.VisibleIndex = 0;
            // 
            // Obj_Pic
            // 
            this.Obj_Pic.Caption = "Αρχείο";
            this.Obj_Pic.FieldName = "FileContents";
            this.Obj_Pic.Name = "Obj_Pic";
            this.Obj_Pic.Visible = true;
            this.Obj_Pic.VisibleIndex = 1;
            // 
            // Obj_Name
            // 
            this.Obj_Name.Caption = "Όνομα";
            this.Obj_Name.FieldName = "TMName";
            this.Obj_Name.Name = "Obj_Name";
            this.Obj_Name.Visible = true;
            this.Obj_Name.VisibleIndex = 2;
            // 
            // Obj_DepositDt
            // 
            this.Obj_DepositDt.Caption = "Κατάθεση";
            this.Obj_DepositDt.FieldName = "DepositDt";
            this.Obj_DepositDt.Name = "Obj_DepositDt";
            this.Obj_DepositDt.Visible = true;
            this.Obj_DepositDt.VisibleIndex = 3;
            // 
            // Obj_ValidTo
            // 
            this.Obj_ValidTo.Caption = "Ισχύς έως";
            this.Obj_ValidTo.FieldName = "ValidTo";
            this.Obj_ValidTo.Name = "Obj_ValidTo";
            this.Obj_ValidTo.Visible = true;
            this.Obj_ValidTo.VisibleIndex = 4;
            // 
            // Obj_NatPower
            // 
            this.Obj_NatPower.Caption = "Εθνική Ισχύς";
            this.Obj_NatPower.FieldName = "NationalPowerName";
            this.Obj_NatPower.Name = "Obj_NatPower";
            this.Obj_NatPower.Visible = true;
            this.Obj_NatPower.VisibleIndex = 5;
            // 
            // Obj_GrNo
            // 
            this.Obj_GrNo.Caption = "Συνδ. Εθν. Σήμα";
            this.Obj_GrNo.FieldName = "TMGrNo";
            this.Obj_GrNo.Name = "Obj_GrNo";
            this.Obj_GrNo.Visible = true;
            this.Obj_GrNo.VisibleIndex = 6;
            // 
            // Obj_Com
            // 
            this.Obj_Com.Caption = "Εταιρία";
            this.Obj_Com.FieldName = "CompanyName";
            this.Obj_Com.Name = "Obj_Com";
            this.Obj_Com.Visible = true;
            this.Obj_Com.VisibleIndex = 7;
            // 
            // Obj_Responsible
            // 
            this.Obj_Responsible.Caption = "Υπεύθυνος";
            this.Obj_Responsible.FieldName = "ResponsibleLawyerName";
            this.Obj_Responsible.Name = "Obj_Responsible";
            this.Obj_Responsible.Visible = true;
            this.Obj_Responsible.VisibleIndex = 8;
            // 
            // Obj_IsDeleted
            // 
            this.Obj_IsDeleted.Caption = "Διαγραμμένο";
            this.Obj_IsDeleted.FieldName = "IsDeleted";
            this.Obj_IsDeleted.Name = "Obj_IsDeleted";
            this.Obj_IsDeleted.Visible = true;
            this.Obj_IsDeleted.VisibleIndex = 9;
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
            this.gbPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrint.Controls.Add(this.rbPrintAll);
            this.gbPrint.Controls.Add(this.rbPrintChoosen);
            this.gbPrint.Location = new System.Drawing.Point(1083, 6);
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
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Trademarks.Properties.Resources.SwitchToPreview_32x;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(977, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 45);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = "Εκτύπωση";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.Image = global::Trademarks.Properties.Resources.ExportToExcel_32x;
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(871, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(100, 45);
            this.btnExcelExport.TabIndex = 40;
            this.btnExcelExport.Text = "Export (xls)";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // TMSelectorDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.gbPrint);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 600);
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
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Id;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_No;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_DepositDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_NatPower;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_GrNo;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Com;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Responsible;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Name;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Pic;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_ValidTo;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_IsDeleted;
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
        private DevExpress.XtraGrid.Columns.GridColumn ObJ_Type_Name;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Class_No;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Class_Headers;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Countries_NameShort;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Countries_Name;
        private System.Windows.Forms.Button btnExcelExport;
    }
}