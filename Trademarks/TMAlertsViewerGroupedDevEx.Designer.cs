namespace Trademarks
{
    partial class TMAlertsViewerGroupedDevEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMAlertsViewerGroupedDevEx));
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiViewTM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecipients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnalyticalView = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.alertsDGVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpCountdownDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotificationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlertCountdownDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlertDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotificationSent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrademarksId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepositDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRenewalDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalPower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleLawyer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.cmsOnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDGVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewTM,
            this.tsmiRecipients,
            this.tsmiAnalyticalView});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(184, 70);
            // 
            // tsmiViewTM
            // 
            this.tsmiViewTM.Name = "tsmiViewTM";
            this.tsmiViewTM.Size = new System.Drawing.Size(183, 22);
            this.tsmiViewTM.Text = "Εμφάνιση Σήματος";
            this.tsmiViewTM.Click += new System.EventHandler(this.tsmiViewTM_Click);
            // 
            // tsmiRecipients
            // 
            this.tsmiRecipients.Name = "tsmiRecipients";
            this.tsmiRecipients.Size = new System.Drawing.Size(183, 22);
            this.tsmiRecipients.Text = "Παραλήπτες";
            this.tsmiRecipients.Click += new System.EventHandler(this.tsmiRecipients_Click);
            // 
            // tsmiAnalyticalView
            // 
            this.tsmiAnalyticalView.Name = "tsmiAnalyticalView";
            this.tsmiAnalyticalView.Size = new System.Drawing.Size(183, 22);
            this.tsmiAnalyticalView.Text = "Αναλυτική Προβολή";
            this.tsmiAnalyticalView.Click += new System.EventHandler(this.tsmiAnalyticalView_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsOnGrid;
            this.gridControl1.DataSource = this.alertsDGVBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1184, 539);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // alertsDGVBindingSource
            // 
            this.alertsDGVBindingSource.DataSource = typeof(Trademarks.AlertsDGV);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colIsActive,
            this.colExpDate,
            this.colExpCountdownDays,
            this.colNotificationDate,
            this.colAlertCountdownDays,
            this.colAlertDescr,
            this.colNotificationSent,
            this.colEventType,
            this.colTrademarksId,
            this.colTMNo,
            this.colTMName,
            this.colDepositDt,
            this.colRenewalDt,
            this.colNationalPower,
            this.colCompany,
            this.colResponsibleLawyer});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Ενεργό";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 0;
            // 
            // colExpDate
            // 
            this.colExpDate.Caption = "Καταληκτική Ημ/νία";
            this.colExpDate.FieldName = "ExpDate";
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.Visible = true;
            this.colExpDate.VisibleIndex = 1;
            // 
            // colExpCountdownDays
            // 
            this.colExpCountdownDays.Caption = "Λήξη (Ημέρες)";
            this.colExpCountdownDays.FieldName = "ExpCountdownDays";
            this.colExpCountdownDays.FieldNameSortGroup = "Λήξη (Ημέρες)";
            this.colExpCountdownDays.Name = "colExpCountdownDays";
            this.colExpCountdownDays.Visible = true;
            this.colExpCountdownDays.VisibleIndex = 2;
            // 
            // colNotificationDate
            // 
            this.colNotificationDate.Caption = "Ημ/νία Ειδοποίησης";
            this.colNotificationDate.FieldName = "NotificationDate";
            this.colNotificationDate.FieldNameSortGroup = "Ημ/νία Ειδοποίησης";
            this.colNotificationDate.Name = "colNotificationDate";
            this.colNotificationDate.Visible = true;
            this.colNotificationDate.VisibleIndex = 3;
            // 
            // colAlertCountdownDays
            // 
            this.colAlertCountdownDays.Caption = "Ειδοπ. (Ημέρες)";
            this.colAlertCountdownDays.FieldName = "AlertCountdownDays";
            this.colAlertCountdownDays.FieldNameSortGroup = "Ειδοπ. (Ημέρες)";
            this.colAlertCountdownDays.Name = "colAlertCountdownDays";
            this.colAlertCountdownDays.Visible = true;
            this.colAlertCountdownDays.VisibleIndex = 4;
            // 
            // colAlertDescr
            // 
            this.colAlertDescr.Caption = "Περίοδος Ειδοπ.";
            this.colAlertDescr.FieldName = "AlertDescr";
            this.colAlertDescr.Name = "colAlertDescr";
            this.colAlertDescr.Visible = true;
            this.colAlertDescr.VisibleIndex = 5;
            // 
            // colNotificationSent
            // 
            this.colNotificationSent.Caption = "Αποστολή Ειδοπ.";
            this.colNotificationSent.FieldName = "NotificationSent";
            this.colNotificationSent.Name = "colNotificationSent";
            // 
            // colEventType
            // 
            this.colEventType.Caption = "Γεγονός";
            this.colEventType.FieldName = "EventType";
            this.colEventType.Name = "colEventType";
            this.colEventType.Visible = true;
            this.colEventType.VisibleIndex = 6;
            // 
            // colTrademarksId
            // 
            this.colTrademarksId.FieldName = "TrademarksId";
            this.colTrademarksId.Name = "colTrademarksId";
            // 
            // colTMNo
            // 
            this.colTMNo.Caption = "Σήμα";
            this.colTMNo.FieldName = "TMNo";
            this.colTMNo.Name = "colTMNo";
            this.colTMNo.Visible = true;
            this.colTMNo.VisibleIndex = 7;
            // 
            // colTMName
            // 
            this.colTMName.Caption = "Όνομα";
            this.colTMName.FieldName = "TMName";
            this.colTMName.Name = "colTMName";
            this.colTMName.Visible = true;
            this.colTMName.VisibleIndex = 8;
            // 
            // colDepositDt
            // 
            this.colDepositDt.Caption = "Κατάθεση";
            this.colDepositDt.FieldName = "DepositDt";
            this.colDepositDt.Name = "colDepositDt";
            this.colDepositDt.Visible = true;
            this.colDepositDt.VisibleIndex = 9;
            // 
            // colRenewalDt
            // 
            this.colRenewalDt.Caption = "Ανανέωση";
            this.colRenewalDt.FieldName = "RenewalDt";
            this.colRenewalDt.Name = "colRenewalDt";
            this.colRenewalDt.Visible = true;
            this.colRenewalDt.VisibleIndex = 10;
            // 
            // colNationalPower
            // 
            this.colNationalPower.Caption = "Εθν. Ισχύς";
            this.colNationalPower.FieldName = "NationalPower";
            this.colNationalPower.Name = "colNationalPower";
            this.colNationalPower.Visible = true;
            this.colNationalPower.VisibleIndex = 11;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Εταιρία";
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 12;
            // 
            // colResponsibleLawyer
            // 
            this.colResponsibleLawyer.Caption = "Υπεύθ. Δικηγόρος";
            this.colResponsibleLawyer.FieldName = "ResponsibleLawyer";
            this.colResponsibleLawyer.Name = "colResponsibleLawyer";
            this.colResponsibleLawyer.Visible = true;
            this.colResponsibleLawyer.VisibleIndex = 13;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.Image = global::Trademarks.Properties.Resources.ExportToExcel_32x;
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(1072, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(100, 45);
            this.btnExcelExport.TabIndex = 41;
            this.btnExcelExport.Text = "Export (xls)";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // TMAlertsViewerGroupedDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 602);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 640);
            this.Name = "TMAlertsViewerGroupedDevEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ειδοποιήσεις (Συγκεντρωτικά)";
            this.cmsOnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertsDGVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewTM;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecipients;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalyticalView;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource alertsDGVBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colExpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNotificationSent;
        private DevExpress.XtraGrid.Columns.GridColumn colEventType;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertCountdownDays;
        private DevExpress.XtraGrid.Columns.GridColumn colExpCountdownDays;
        private DevExpress.XtraGrid.Columns.GridColumn colTrademarksId;
        private DevExpress.XtraGrid.Columns.GridColumn colTMNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTMName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepositDt;
        private DevExpress.XtraGrid.Columns.GridColumn colRenewalDt;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalPower;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleLawyer;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertDescr;
        private System.Windows.Forms.Button btnExcelExport;
    }
}