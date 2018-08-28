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
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dgvTempRecs.Size = new System.Drawing.Size(984, 383);
            this.dgvTempRecs.TabIndex = 1;
            this.dgvTempRecs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvTempRecs_MouseDown);
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiOpenUrl});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(122, 92);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(121, 22);
            this.tsmiUpdate.Text = "Update";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(121, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiOpenUrl
            // 
            this.tsmiOpenUrl.Name = "tsmiOpenUrl";
            this.tsmiOpenUrl.Size = new System.Drawing.Size(121, 22);
            this.tsmiOpenUrl.Text = "Open Url";
            this.tsmiOpenUrl.Click += new System.EventHandler(this.tsmiOpenUrl_Click);
            // 
            // tsmiView
            // 
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(121, 22);
            this.tsmiView.Text = "View";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
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
            this.tmp_No.Width = 90;
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
            // 
            // tmp_Com
            // 
            this.tmp_Com.HeaderText = "Εταιρία";
            this.tmp_Com.Name = "tmp_Com";
            this.tmp_Com.ReadOnly = true;
            // 
            // tmp_RespLawyer
            // 
            this.tmp_RespLawyer.HeaderText = "Υπεύθ. Δικηγόρος";
            this.tmp_RespLawyer.Name = "tmp_RespLawyer";
            this.tmp_RespLawyer.ReadOnly = true;
            // 
            // QuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.dgvTempRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "QuickView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick View";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}