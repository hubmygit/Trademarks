namespace Trademarks
{
    partial class NatTmSelectorDevEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NatTmSelectorDevEx));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.trademarkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileContents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepositDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalPowerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibleLawyerName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.trademarkBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(884, 462);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // trademarkBindingSource
            // 
            this.trademarkBindingSource.DataSource = typeof(Trademarks.Trademark_Full);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTMNo,
            this.colFileContents,
            this.colTMName,
            this.colDepositDt,
            this.colValidTo,
            this.colCompanyName,
            this.colNationalPowerName,
            this.colResponsibleLawyerName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colTMNo
            // 
            this.colTMNo.Caption = "Σήμα";
            this.colTMNo.FieldName = "TMNo";
            this.colTMNo.Name = "colTMNo";
            this.colTMNo.Visible = true;
            this.colTMNo.VisibleIndex = 0;
            // 
            // colFileContents
            // 
            this.colFileContents.Caption = "Αρχείο";
            this.colFileContents.FieldName = "FileContents";
            this.colFileContents.Name = "colFileContents";
            this.colFileContents.Visible = true;
            this.colFileContents.VisibleIndex = 1;
            // 
            // colTMName
            // 
            this.colTMName.Caption = "Όνομα";
            this.colTMName.FieldName = "TMName";
            this.colTMName.Name = "colTMName";
            this.colTMName.Visible = true;
            this.colTMName.VisibleIndex = 2;
            // 
            // colDepositDt
            // 
            this.colDepositDt.Caption = "Κατάθεση";
            this.colDepositDt.FieldName = "DepositDt";
            this.colDepositDt.Name = "colDepositDt";
            this.colDepositDt.Visible = true;
            this.colDepositDt.VisibleIndex = 3;
            // 
            // colValidTo
            // 
            this.colValidTo.Caption = "Ισχύς έως";
            this.colValidTo.FieldName = "ValidTo";
            this.colValidTo.Name = "colValidTo";
            this.colValidTo.Visible = true;
            this.colValidTo.VisibleIndex = 4;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Εταιρία";
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 5;
            // 
            // colNationalPowerName
            // 
            this.colNationalPowerName.FieldName = "NationalPowerName";
            this.colNationalPowerName.Name = "colNationalPowerName";
            // 
            // colResponsibleLawyerName
            // 
            this.colResponsibleLawyerName.FieldName = "ResponsibleLawyerName";
            this.colResponsibleLawyerName.Name = "colResponsibleLawyerName";
            // 
            // NatTmSelectorDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "NatTmSelectorDevEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Επιλογή Σήματος";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource trademarkBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTMNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFileContents;
        private DevExpress.XtraGrid.Columns.GridColumn colTMName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepositDt;
        private DevExpress.XtraGrid.Columns.GridColumn colValidTo;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalPowerName;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibleLawyerName;
    }
}