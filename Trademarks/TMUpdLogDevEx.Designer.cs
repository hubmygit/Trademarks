namespace Trademarks
{
    partial class TMUpdLogDevEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMUpdLogDevEx));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tmLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTrademarks_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTM_Status_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExecStatement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldNameToShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcelExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.tmLogBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(884, 399);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tmLogBindingSource
            // 
            this.tmLogBindingSource.DataSource = typeof(Trademarks.TmLog);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTrademarks_Id,
            this.colTM_Status_Id,
            this.colExecStatement,
            this.colDt,
            this.colFullName,
            this.colTMNo,
            this.colTMName,
            this.colStatus,
            this.colFieldNameToShow,
            this.colOldValue,
            this.colNewValue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colTrademarks_Id
            // 
            this.colTrademarks_Id.Caption = "TMId";
            this.colTrademarks_Id.FieldName = "Trademarks_Id";
            this.colTrademarks_Id.Name = "colTrademarks_Id";
            // 
            // colTM_Status_Id
            // 
            this.colTM_Status_Id.Caption = "TSId";
            this.colTM_Status_Id.FieldName = "TM_Status_Id";
            this.colTM_Status_Id.Name = "colTM_Status_Id";
            // 
            // colExecStatement
            // 
            this.colExecStatement.Caption = "Statement";
            this.colExecStatement.FieldName = "ExecStatement";
            this.colExecStatement.Name = "colExecStatement";
            this.colExecStatement.Visible = true;
            this.colExecStatement.VisibleIndex = 0;
            // 
            // colDt
            // 
            this.colDt.Caption = "Datetime";
            this.colDt.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss.fff";
            this.colDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDt.FieldName = "Dt";
            this.colDt.Name = "colDt";
            this.colDt.Visible = true;
            this.colDt.VisibleIndex = 1;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Full Name";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
            // 
            // colTMNo
            // 
            this.colTMNo.Caption = "Tm";
            this.colTMNo.FieldName = "TMNo";
            this.colTMNo.Name = "colTMNo";
            this.colTMNo.Visible = true;
            this.colTMNo.VisibleIndex = 3;
            // 
            // colTMName
            // 
            this.colTMName.Caption = "Tm Name";
            this.colTMName.FieldName = "TMName";
            this.colTMName.Name = "colTMName";
            this.colTMName.Visible = true;
            this.colTMName.VisibleIndex = 4;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            // 
            // colFieldNameToShow
            // 
            this.colFieldNameToShow.Caption = "Field Name";
            this.colFieldNameToShow.FieldName = "FieldNameToShow";
            this.colFieldNameToShow.Name = "colFieldNameToShow";
            this.colFieldNameToShow.Visible = true;
            this.colFieldNameToShow.VisibleIndex = 6;
            // 
            // colOldValue
            // 
            this.colOldValue.Caption = "Old Value";
            this.colOldValue.FieldName = "OldValue";
            this.colOldValue.Name = "colOldValue";
            this.colOldValue.Visible = true;
            this.colOldValue.VisibleIndex = 7;
            // 
            // colNewValue
            // 
            this.colNewValue.Caption = "New Value";
            this.colNewValue.FieldName = "NewValue";
            this.colNewValue.Name = "colNewValue";
            this.colNewValue.Visible = true;
            this.colNewValue.VisibleIndex = 8;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.Image = global::Trademarks.Properties.Resources.ExportToExcel_32x;
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(772, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(100, 45);
            this.btnExcelExport.TabIndex = 42;
            this.btnExcelExport.Text = "Export (xls)";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // TMUpdLogDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "TMUpdLogDevEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Log";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tmLogBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTrademarks_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colTM_Status_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colDt;
        private DevExpress.XtraGrid.Columns.GridColumn colExecStatement;
        private DevExpress.XtraGrid.Columns.GridColumn colOldValue;
        private DevExpress.XtraGrid.Columns.GridColumn colNewValue;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldNameToShow;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colTMNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTMName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private System.Windows.Forms.Button btnExcelExport;
    }
}