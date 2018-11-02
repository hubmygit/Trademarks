namespace Trademarks
{
    partial class StatusViewerDevEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusViewerDevEx));
            this.gbNatPower = new System.Windows.Forms.GroupBox();
            this.rbDiethnes = new System.Windows.Forms.RadioButton();
            this.rbKoinotiko = new System.Windows.Forms.RadioButton();
            this.rbEthniko = new System.Windows.Forms.RadioButton();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFinUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Obj_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_TmId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_DepositDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_DecisionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_DecisionPublDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_AppealDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_TermCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_TermDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_FinalizedDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_FinalizedUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_RenewalApplicationDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_RenewalDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_RenewalFees = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_RenewalProtocol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_Remarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obj_InsDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbNatPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbNatPower
            // 
            this.gbNatPower.Controls.Add(this.rbDiethnes);
            this.gbNatPower.Controls.Add(this.rbKoinotiko);
            this.gbNatPower.Controls.Add(this.rbEthniko);
            this.gbNatPower.Location = new System.Drawing.Point(236, 7);
            this.gbNatPower.Name = "gbNatPower";
            this.gbNatPower.Size = new System.Drawing.Size(278, 36);
            this.gbNatPower.TabIndex = 25;
            this.gbNatPower.TabStop = false;
            // 
            // rbDiethnes
            // 
            this.rbDiethnes.AutoCheck = false;
            this.rbDiethnes.AutoSize = true;
            this.rbDiethnes.Location = new System.Drawing.Point(202, 12);
            this.rbDiethnes.Name = "rbDiethnes";
            this.rbDiethnes.Size = new System.Drawing.Size(65, 17);
            this.rbDiethnes.TabIndex = 7;
            this.rbDiethnes.TabStop = true;
            this.rbDiethnes.Text = "Διεθνές";
            this.rbDiethnes.UseVisualStyleBackColor = true;
            // 
            // rbKoinotiko
            // 
            this.rbKoinotiko.AutoCheck = false;
            this.rbKoinotiko.AutoSize = true;
            this.rbKoinotiko.Location = new System.Drawing.Point(103, 12);
            this.rbKoinotiko.Name = "rbKoinotiko";
            this.rbKoinotiko.Size = new System.Drawing.Size(72, 17);
            this.rbKoinotiko.TabIndex = 6;
            this.rbKoinotiko.TabStop = true;
            this.rbKoinotiko.Text = "Κοινοτικό";
            this.rbKoinotiko.UseVisualStyleBackColor = true;
            // 
            // rbEthniko
            // 
            this.rbEthniko.AutoCheck = false;
            this.rbEthniko.AutoSize = true;
            this.rbEthniko.Location = new System.Drawing.Point(15, 12);
            this.rbEthniko.Name = "rbEthniko";
            this.rbEthniko.Size = new System.Drawing.Size(57, 17);
            this.rbEthniko.TabIndex = 5;
            this.rbEthniko.TabStop = true;
            this.rbEthniko.Text = "Εθνικό";
            this.rbEthniko.UseVisualStyleBackColor = true;
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(21, 52);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 21;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(130, 49);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.ReadOnly = true;
            this.txtTMName.Size = new System.Drawing.Size(384, 22);
            this.txtTMName.TabIndex = 24;
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(12, 24);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 22;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(130, 21);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 23;
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOpenLink.Image = global::Trademarks.Properties.Resources.OpenLink_16x;
            this.btnOpenLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenLink.Location = new System.Drawing.Point(1072, 24);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(100, 40);
            this.btnOpenLink.TabIndex = 20;
            this.btnOpenLink.Text = "Άνοιγμα Url";
            this.btnOpenLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenLink.UseVisualStyleBackColor = true;
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsOnGrid;
            this.gridControl1.DataSource = typeof(Trademarks.TM_Status);
            this.gridControl1.Location = new System.Drawing.Point(0, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1184, 474);
            this.gridControl1.TabIndex = 26;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiDelete,
            this.toolStripSeparator1,
            this.tsmiOpenFinUrl,
            this.toolStripSeparator2,
            this.tsmiFiles});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(209, 104);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdate.Text = "Μεταβολή";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelete.Text = "Διαγραφή";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // tsmiOpenFinUrl
            // 
            this.tsmiOpenFinUrl.Name = "tsmiOpenFinUrl";
            this.tsmiOpenFinUrl.Size = new System.Drawing.Size(208, 22);
            this.tsmiOpenFinUrl.Text = "Άνοιγμα Υπερσυνδέσμου";
            this.tsmiOpenFinUrl.Click += new System.EventHandler(this.tsmiOpenFinUrl_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // tsmiFiles
            // 
            this.tsmiFiles.Name = "tsmiFiles";
            this.tsmiFiles.Size = new System.Drawing.Size(208, 22);
            this.tsmiFiles.Text = "Αρχεία";
            this.tsmiFiles.Click += new System.EventHandler(this.tsmiFiles_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Obj_Id,
            this.Obj_TmId,
            this.Obj_Name,
            this.Obj_DepositDt,
            this.Obj_DecisionNo,
            this.Obj_DecisionPublDt,
            this.Obj_AppealDt,
            this.Obj_TermCompany,
            this.Obj_TermDt,
            this.Obj_FinalizedDt,
            this.Obj_FinalizedUrl,
            this.Obj_RenewalApplicationDt,
            this.Obj_RenewalDt,
            this.Obj_RenewalFees,
            this.Obj_RenewalProtocol,
            this.Obj_Remarks,
            this.Obj_InsDt});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // Obj_Id
            // 
            this.Obj_Id.Caption = "Id";
            this.Obj_Id.FieldName = "Id";
            this.Obj_Id.Name = "Obj_Id";
            // 
            // Obj_TmId
            // 
            this.Obj_TmId.Caption = "TmId";
            this.Obj_TmId.FieldName = "TmId";
            this.Obj_TmId.Name = "Obj_TmId";
            // 
            // Obj_Name
            // 
            this.Obj_Name.Caption = "Κατάσταση";
            this.Obj_Name.FieldName = "status.Name";
            this.Obj_Name.Name = "Obj_Name";
            this.Obj_Name.Visible = true;
            this.Obj_Name.VisibleIndex = 0;
            // 
            // Obj_DepositDt
            // 
            this.Obj_DepositDt.Caption = "Ημ/νία Κατάθεσης";
            this.Obj_DepositDt.FieldName = "DepositDt";
            this.Obj_DepositDt.Name = "Obj_DepositDt";
            this.Obj_DepositDt.Visible = true;
            this.Obj_DepositDt.VisibleIndex = 1;
            // 
            // Obj_DecisionNo
            // 
            this.Obj_DecisionNo.Caption = "Αρ. Απόφασης";
            this.Obj_DecisionNo.FieldName = "DecisionNo";
            this.Obj_DecisionNo.Name = "Obj_DecisionNo";
            this.Obj_DecisionNo.Visible = true;
            this.Obj_DecisionNo.VisibleIndex = 2;
            // 
            // Obj_DecisionPublDt
            // 
            this.Obj_DecisionPublDt.Caption = "Ημ/νία Δημοσίευσης Απόφασης";
            this.Obj_DecisionPublDt.FieldName = "DecisionPublDt";
            this.Obj_DecisionPublDt.Name = "Obj_DecisionPublDt";
            this.Obj_DecisionPublDt.Visible = true;
            this.Obj_DecisionPublDt.VisibleIndex = 3;
            // 
            // Obj_AppealDt
            // 
            this.Obj_AppealDt.Caption = "Ημ/νία Προσφυγής";
            this.Obj_AppealDt.FieldName = "AppealDt";
            this.Obj_AppealDt.Name = "Obj_AppealDt";
            this.Obj_AppealDt.Visible = true;
            this.Obj_AppealDt.VisibleIndex = 4;
            // 
            // Obj_TermCompany
            // 
            this.Obj_TermCompany.Caption = "Εταιρία Ανακοπής";
            this.Obj_TermCompany.FieldName = "TermCompany";
            this.Obj_TermCompany.Name = "Obj_TermCompany";
            this.Obj_TermCompany.Visible = true;
            this.Obj_TermCompany.VisibleIndex = 5;
            // 
            // Obj_TermDt
            // 
            this.Obj_TermDt.Caption = "Ημ/νία Ανακοπής";
            this.Obj_TermDt.FieldName = "TermDt";
            this.Obj_TermDt.Name = "Obj_TermDt";
            this.Obj_TermDt.Visible = true;
            this.Obj_TermDt.VisibleIndex = 6;
            // 
            // Obj_FinalizedDt
            // 
            this.Obj_FinalizedDt.Caption = "Ημ/νία Οριστικοπ.";
            this.Obj_FinalizedDt.FieldName = "FinalizedDt";
            this.Obj_FinalizedDt.Name = "Obj_FinalizedDt";
            this.Obj_FinalizedDt.Visible = true;
            this.Obj_FinalizedDt.VisibleIndex = 7;
            // 
            // Obj_FinalizedUrl
            // 
            this.Obj_FinalizedUrl.Caption = "Url Οριστικοπ.";
            this.Obj_FinalizedUrl.FieldName = "FinalizedUrl";
            this.Obj_FinalizedUrl.Name = "Obj_FinalizedUrl";
            this.Obj_FinalizedUrl.Visible = true;
            this.Obj_FinalizedUrl.VisibleIndex = 8;
            // 
            // Obj_RenewalApplicationDt
            // 
            this.Obj_RenewalApplicationDt.Caption = "Ημ/νία Αίτ. Ανανέωσης";
            this.Obj_RenewalApplicationDt.FieldName = "RenewalApplicationDt";
            this.Obj_RenewalApplicationDt.Name = "Obj_RenewalApplicationDt";
            this.Obj_RenewalApplicationDt.Visible = true;
            this.Obj_RenewalApplicationDt.VisibleIndex = 9;
            // 
            // Obj_RenewalDt
            // 
            this.Obj_RenewalDt.Caption = "Ημ/νία Ανανέωσης";
            this.Obj_RenewalDt.FieldName = "RenewalDt";
            this.Obj_RenewalDt.Name = "Obj_RenewalDt";
            this.Obj_RenewalDt.Visible = true;
            this.Obj_RenewalDt.VisibleIndex = 10;
            // 
            // Obj_RenewalFees
            // 
            this.Obj_RenewalFees.Caption = "Παράβολα Ανανέωσης";
            this.Obj_RenewalFees.FieldName = "RenewalFees";
            this.Obj_RenewalFees.Name = "Obj_RenewalFees";
            this.Obj_RenewalFees.Visible = true;
            this.Obj_RenewalFees.VisibleIndex = 11;
            // 
            // Obj_RenewalProtocol
            // 
            this.Obj_RenewalProtocol.Caption = "Πρωτόκολλο Ανανέωσης";
            this.Obj_RenewalProtocol.FieldName = "RenewalProtocol";
            this.Obj_RenewalProtocol.Name = "Obj_RenewalProtocol";
            this.Obj_RenewalProtocol.Visible = true;
            this.Obj_RenewalProtocol.VisibleIndex = 12;
            // 
            // Obj_Remarks
            // 
            this.Obj_Remarks.Caption = "Παρατηρήσεις";
            this.Obj_Remarks.FieldName = "Remarks";
            this.Obj_Remarks.Name = "Obj_Remarks";
            this.Obj_Remarks.Visible = true;
            this.Obj_Remarks.VisibleIndex = 13;
            // 
            // Obj_InsDt
            // 
            this.Obj_InsDt.Caption = "Ημ/νία Καταχώρησης";
            this.Obj_InsDt.FieldName = "InsDt";
            this.Obj_InsDt.Name = "Obj_InsDt";
            this.Obj_InsDt.Visible = true;
            this.Obj_InsDt.VisibleIndex = 14;
            // 
            // StatusViewerDevEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gbNatPower);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.btnOpenLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "StatusViewerDevEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Καταστάσεις Σήματος";
            this.gbNatPower.ResumeLayout(false);
            this.gbNatPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNatPower;
        private System.Windows.Forms.RadioButton rbDiethnes;
        private System.Windows.Forms.RadioButton rbKoinotiko;
        private System.Windows.Forms.RadioButton rbEthniko;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
        private System.Windows.Forms.Button btnOpenLink;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Name;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_DepositDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_DecisionNo;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_DecisionPublDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_AppealDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_TermCompany;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_TermDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_FinalizedDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_FinalizedUrl;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_RenewalApplicationDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_RenewalDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_RenewalFees;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_RenewalProtocol;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Remarks;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_InsDt;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_Id;
        private DevExpress.XtraGrid.Columns.GridColumn Obj_TmId;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFinUrl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFiles;
    }
}