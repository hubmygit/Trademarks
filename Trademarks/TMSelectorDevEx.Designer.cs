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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tmp_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tmp_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.trademark_FullBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Obj_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Pic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_DepositDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_ValidTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_NatPower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_GrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Com = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trademarkFullBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Obj_Responsible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_IsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademark_FullBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkFullBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 523);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1234, 239);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tmp_Id,
            this.tmp_No});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // tmp_Id
            // 
            this.tmp_Id.Caption = "Id";
            this.tmp_Id.FieldName = "Id";
            this.tmp_Id.Name = "tmp_Id";
            this.tmp_Id.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.tmp_Id.Visible = true;
            this.tmp_Id.VisibleIndex = 0;
            // 
            // tmp_No
            // 
            this.tmp_No.Caption = "Σήμα";
            this.tmp_No.FieldName = "TMNo";
            this.tmp_No.Name = "tmp_No";
            this.tmp_No.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.tmp_No.Visible = true;
            this.tmp_No.VisibleIndex = 1;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.trademark_FullBindingSource;
            gridLevelNode1.RelationName = "TMTypes";
            gridLevelNode2.RelationName = "TMClasses";
            gridLevelNode3.RelationName = "TMCountries";
            gridLevelNode4.RelationName = "TM_Statuses";
            this.gridControl2.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3,
            gridLevelNode4});
            this.gridControl2.Location = new System.Drawing.Point(0, 108);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1234, 370);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // trademark_FullBindingSource
            // 
            this.trademark_FullBindingSource.DataSource = typeof(Trademarks.Trademark_Full);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
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
            this.Obj_Pic.ImageOptions.SvgImageSize = new System.Drawing.Size(100, 100);
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
            this.Obj_DepositDt.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.Obj_DepositDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Obj_DepositDt.FieldName = "DepositDt";
            this.Obj_DepositDt.Name = "Obj_DepositDt";
            this.Obj_DepositDt.Visible = true;
            this.Obj_DepositDt.VisibleIndex = 3;
            // 
            // Obj_ValidTo
            // 
            this.Obj_ValidTo.Caption = "Ισχύς έως";
            this.Obj_ValidTo.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.Obj_ValidTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
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
            // trademarkFullBindingSource
            // 
            this.trademarkFullBindingSource.DataSource = typeof(Trademarks.Trademark_Full);
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
            // TMSelectorDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 762);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 800);
            this.Name = "TMSelectorDevEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εμπορικά Σήματα";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademark_FullBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkFullBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn tmp_Id;
        private DevExpress.XtraGrid.Columns.GridColumn tmp_No;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private System.Windows.Forms.BindingSource trademarkFullBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Id;
        private System.Windows.Forms.BindingSource trademark_FullBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_No;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_NatPower;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Pic;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Name;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_DepositDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_ValidTo;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_GrNo;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Com;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Responsible;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_IsDeleted;
    }
}