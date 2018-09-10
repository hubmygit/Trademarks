namespace Trademarks
{
    partial class QuickView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickView));
            this.dgvTempRecs = new System.Windows.Forms.DataGridView();
            this.tmp_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Pic = new System.Windows.Forms.DataGridViewImageColumn();
            this.tmp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_DepositDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_RenewalDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_NatPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_GrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_Com = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmp_RespLawyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cbLawyerFullname = new System.Windows.Forms.ComboBox();
            this.lblLawyerFullname = new System.Windows.Forms.Label();
            this.cbNatPower = new System.Windows.Forms.ComboBox();
            this.lblNatPower = new System.Windows.Forms.Label();
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
            this.tmp_RenewalDt,
            this.tmp_NatPower,
            this.tmp_GrNo,
            this.tmp_Com,
            this.tmp_RespLawyer});
            this.dgvTempRecs.ContextMenuStrip = this.cmsOnGrid;
            this.dgvTempRecs.Location = new System.Drawing.Point(0, 79);
            this.dgvTempRecs.MultiSelect = false;
            this.dgvTempRecs.Name = "dgvTempRecs";
            this.dgvTempRecs.RowTemplate.Height = 50;
            this.dgvTempRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTempRecs.Size = new System.Drawing.Size(1234, 523);
            this.dgvTempRecs.TabIndex = 1;
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
            // tmp_RenewalDt
            // 
            this.tmp_RenewalDt.HeaderText = "Ανανέωση";
            this.tmp_RenewalDt.Name = "tmp_RenewalDt";
            this.tmp_RenewalDt.ReadOnly = true;
            // 
            // tmp_NatPower
            // 
            this.tmp_NatPower.HeaderText = "Εθν. Ισχύς";
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
            // tmp_RespLawyer
            // 
            this.tmp_RespLawyer.HeaderText = "Υπεύθ. Δικηγόρος";
            this.tmp_RespLawyer.Name = "tmp_RespLawyer";
            this.tmp_RespLawyer.ReadOnly = true;
            this.tmp_RespLawyer.Width = 180;
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiOpenUrl});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(209, 92);
            // 
            // tsmiView
            // 
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(208, 22);
            this.tsmiView.Text = "Εμφάνιση Σήματος";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdate.Text = "Ενημέρωση Σήματος";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelete.Text = "Διαγραφή Σήματος";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiOpenUrl
            // 
            this.tsmiOpenUrl.Name = "tsmiOpenUrl";
            this.tsmiOpenUrl.Size = new System.Drawing.Size(208, 22);
            this.tsmiOpenUrl.Text = "Άνοιγμα Υπερσυνδέσμου";
            this.tsmiOpenUrl.Click += new System.EventHandler(this.tsmiOpenUrl_Click);
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(19, 48);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 3;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(128, 45);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.Size = new System.Drawing.Size(200, 22);
            this.txtTMName.TabIndex = 6;
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(10, 15);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 4;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(128, 12);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.Size = new System.Drawing.Size(200, 22);
            this.txtTMId.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Trademarks.Properties.Resources.find_40x;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1132, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 45);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Εύρεση";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbCompany
            // 
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.ItemHeight = 16;
            this.cbCompany.Items.AddRange(new object[] {
            "Όλα"});
            this.cbCompany.Location = new System.Drawing.Point(473, 45);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(500, 24);
            this.cbCompany.TabIndex = 18;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(414, 48);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(52, 16);
            this.lblCompany.TabIndex = 17;
            this.lblCompany.Text = "Εταιρία";
            // 
            // cbLawyerFullname
            // 
            this.cbLawyerFullname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLawyerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbLawyerFullname.FormattingEnabled = true;
            this.cbLawyerFullname.ItemHeight = 16;
            this.cbLawyerFullname.Items.AddRange(new object[] {
            "Όλα"});
            this.cbLawyerFullname.Location = new System.Drawing.Point(473, 12);
            this.cbLawyerFullname.Name = "cbLawyerFullname";
            this.cbLawyerFullname.Size = new System.Drawing.Size(250, 24);
            this.cbLawyerFullname.TabIndex = 20;
            // 
            // lblLawyerFullname
            // 
            this.lblLawyerFullname.AutoSize = true;
            this.lblLawyerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLawyerFullname.Location = new System.Drawing.Point(340, 15);
            this.lblLawyerFullname.Name = "lblLawyerFullname";
            this.lblLawyerFullname.Size = new System.Drawing.Size(126, 16);
            this.lblLawyerFullname.TabIndex = 19;
            this.lblLawyerFullname.Text = "Ονομ/μο Δικηγόρου";
            // 
            // cbNatPower
            // 
            this.cbNatPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNatPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbNatPower.FormattingEnabled = true;
            this.cbNatPower.ItemHeight = 16;
            this.cbNatPower.Items.AddRange(new object[] {
            "Όλα"});
            this.cbNatPower.Location = new System.Drawing.Point(823, 12);
            this.cbNatPower.Name = "cbNatPower";
            this.cbNatPower.Size = new System.Drawing.Size(150, 24);
            this.cbNatPower.TabIndex = 22;
            // 
            // lblNatPower
            // 
            this.lblNatPower.AutoSize = true;
            this.lblNatPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblNatPower.Location = new System.Drawing.Point(735, 15);
            this.lblNatPower.Name = "lblNatPower";
            this.lblNatPower.Size = new System.Drawing.Size(82, 16);
            this.lblNatPower.TabIndex = 21;
            this.lblNatPower.Text = "Εθνική Ισχύς";
            // 
            // QuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 602);
            this.Controls.Add(this.cbNatPower);
            this.Controls.Add(this.lblNatPower);
            this.Controls.Add(this.cbLawyerFullname);
            this.Controls.Add(this.lblLawyerFullname);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.dgvTempRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 640);
            this.Name = "QuickView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick View";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTempRecs;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenUrl;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_No;
        private System.Windows.Forms.DataGridViewImageColumn tmp_Pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_DepositDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_RenewalDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_NatPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_GrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_Com;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmp_RespLawyer;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cbLawyerFullname;
        private System.Windows.Forms.Label lblLawyerFullname;
        private System.Windows.Forms.ComboBox cbNatPower;
        private System.Windows.Forms.Label lblNatPower;
    }
}