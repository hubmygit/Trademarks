namespace Trademarks
{
    partial class StatusViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusViewer));
            this.dgvStatusViewer = new System.Windows.Forms.DataGridView();
            this.st_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_TmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_DepositDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_DecisionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_DecisionDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_TermCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_FinalizedDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_FinalizedUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalApplicationDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_InsDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdDecision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdAppeal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdTermination = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdFinalization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdRenewal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelDecision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelAppeal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelTermination = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelFinalization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelRenewal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusViewer)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStatusViewer
            // 
            this.dgvStatusViewer.AllowUserToAddRows = false;
            this.dgvStatusViewer.AllowUserToDeleteRows = false;
            this.dgvStatusViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatusViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.st_Id,
            this.st_TmId,
            this.st_Name,
            this.st_DepositDt,
            this.st_DecisionNo,
            this.st_DecisionDt,
            this.st_TermCom,
            this.st_FinalizedDt,
            this.st_FinalizedUrl,
            this.st_RenewalApplicationDt,
            this.st_RenewalDt,
            this.st_RenewalFees,
            this.st_RenewalProtocol,
            this.st_Remarks,
            this.st_InsDt});
            this.dgvStatusViewer.ContextMenuStrip = this.cmsOnGrid;
            this.dgvStatusViewer.Location = new System.Drawing.Point(0, 79);
            this.dgvStatusViewer.MultiSelect = false;
            this.dgvStatusViewer.Name = "dgvStatusViewer";
            this.dgvStatusViewer.RowTemplate.Height = 24;
            this.dgvStatusViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatusViewer.Size = new System.Drawing.Size(1298, 483);
            this.dgvStatusViewer.TabIndex = 4;
            this.dgvStatusViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStatusViewer_MouseDown);
            // 
            // st_Id
            // 
            this.st_Id.HeaderText = "Id";
            this.st_Id.Name = "st_Id";
            this.st_Id.Visible = false;
            // 
            // st_TmId
            // 
            this.st_TmId.HeaderText = "TmId";
            this.st_TmId.Name = "st_TmId";
            this.st_TmId.Visible = false;
            // 
            // st_Name
            // 
            this.st_Name.HeaderText = "Κατάσταση";
            this.st_Name.Name = "st_Name";
            this.st_Name.ReadOnly = true;
            this.st_Name.Width = 140;
            // 
            // st_DepositDt
            // 
            this.st_DepositDt.HeaderText = "Ημ/νία Κατάθεσης";
            this.st_DepositDt.Name = "st_DepositDt";
            this.st_DepositDt.ReadOnly = true;
            // 
            // st_DecisionNo
            // 
            this.st_DecisionNo.HeaderText = "Αρ. Απόφασης";
            this.st_DecisionNo.Name = "st_DecisionNo";
            this.st_DecisionNo.ReadOnly = true;
            // 
            // st_DecisionDt
            // 
            this.st_DecisionDt.HeaderText = "Ημ/νία Δημ. Απόφασης";
            this.st_DecisionDt.Name = "st_DecisionDt";
            this.st_DecisionDt.ReadOnly = true;
            // 
            // st_TermCom
            // 
            this.st_TermCom.HeaderText = "Εταιρία Ανακοπής";
            this.st_TermCom.Name = "st_TermCom";
            this.st_TermCom.ReadOnly = true;
            // 
            // st_FinalizedDt
            // 
            this.st_FinalizedDt.HeaderText = "Ημ/νία Οριστικοπ.";
            this.st_FinalizedDt.Name = "st_FinalizedDt";
            this.st_FinalizedDt.ReadOnly = true;
            // 
            // st_FinalizedUrl
            // 
            this.st_FinalizedUrl.HeaderText = "Url Οριστικοπ.";
            this.st_FinalizedUrl.Name = "st_FinalizedUrl";
            this.st_FinalizedUrl.ReadOnly = true;
            // 
            // st_RenewalApplicationDt
            // 
            this.st_RenewalApplicationDt.HeaderText = "Ημ/νία Αίτ. Ανανέωσης";
            this.st_RenewalApplicationDt.Name = "st_RenewalApplicationDt";
            this.st_RenewalApplicationDt.ReadOnly = true;
            // 
            // st_RenewalDt
            // 
            this.st_RenewalDt.HeaderText = "Ημ/νία Ανανέωσης";
            this.st_RenewalDt.Name = "st_RenewalDt";
            this.st_RenewalDt.ReadOnly = true;
            // 
            // st_RenewalFees
            // 
            this.st_RenewalFees.HeaderText = "Παράβολα Ανανέωσης";
            this.st_RenewalFees.Name = "st_RenewalFees";
            this.st_RenewalFees.ReadOnly = true;
            // 
            // st_RenewalProtocol
            // 
            this.st_RenewalProtocol.HeaderText = "Πρωτόκολλο Ανανέωσης";
            this.st_RenewalProtocol.Name = "st_RenewalProtocol";
            this.st_RenewalProtocol.ReadOnly = true;
            // 
            // st_Remarks
            // 
            this.st_Remarks.HeaderText = "Παρατηρήσεις";
            this.st_Remarks.Name = "st_Remarks";
            this.st_Remarks.ReadOnly = true;
            // 
            // st_InsDt
            // 
            this.st_InsDt.HeaderText = "Ημ/νία Καταχώρησης";
            this.st_InsDt.Name = "st_InsDt";
            this.st_InsDt.ReadOnly = true;
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdDecision,
            this.tsmiUpdAppeal,
            this.tsmiUpdTermination,
            this.tsmiUpdFinalization,
            this.tsmiUpdRenewal,
            this.tsmiDelDecision,
            this.tsmiDelAppeal,
            this.tsmiDelTermination,
            this.tsmiDelFinalization,
            this.tsmiDelRenewal});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(209, 224);
            // 
            // tsmiUpdDecision
            // 
            this.tsmiUpdDecision.Name = "tsmiUpdDecision";
            this.tsmiUpdDecision.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdDecision.Text = "Update Απόφασης";
            this.tsmiUpdDecision.Click += new System.EventHandler(this.tsmiUpdDecision_Click);
            // 
            // tsmiUpdAppeal
            // 
            this.tsmiUpdAppeal.Name = "tsmiUpdAppeal";
            this.tsmiUpdAppeal.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdAppeal.Text = "Update Προσφυγής";
            this.tsmiUpdAppeal.Click += new System.EventHandler(this.tsmiUpdAppeal_Click);
            // 
            // tsmiUpdTermination
            // 
            this.tsmiUpdTermination.Name = "tsmiUpdTermination";
            this.tsmiUpdTermination.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdTermination.Text = "Update Ανακοπής";
            this.tsmiUpdTermination.Click += new System.EventHandler(this.tsmiUpdTermination_Click);
            // 
            // tsmiUpdFinalization
            // 
            this.tsmiUpdFinalization.Name = "tsmiUpdFinalization";
            this.tsmiUpdFinalization.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdFinalization.Text = "Update Οριστικοποίησης";
            this.tsmiUpdFinalization.Click += new System.EventHandler(this.tsmiUpdFinalization_Click);
            // 
            // tsmiUpdRenewal
            // 
            this.tsmiUpdRenewal.Name = "tsmiUpdRenewal";
            this.tsmiUpdRenewal.Size = new System.Drawing.Size(208, 22);
            this.tsmiUpdRenewal.Text = "Update Ανανέωσης";
            this.tsmiUpdRenewal.Click += new System.EventHandler(this.tsmiUpdRenewal_Click);
            // 
            // tsmiDelDecision
            // 
            this.tsmiDelDecision.Name = "tsmiDelDecision";
            this.tsmiDelDecision.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelDecision.Text = "Delete Απόφασης";
            this.tsmiDelDecision.Click += new System.EventHandler(this.tsmiDelDecision_Click);
            // 
            // tsmiDelAppeal
            // 
            this.tsmiDelAppeal.Name = "tsmiDelAppeal";
            this.tsmiDelAppeal.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelAppeal.Text = "Delete Προσφυγής";
            this.tsmiDelAppeal.Click += new System.EventHandler(this.tsmiDelAppeal_Click);
            // 
            // tsmiDelTermination
            // 
            this.tsmiDelTermination.Name = "tsmiDelTermination";
            this.tsmiDelTermination.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelTermination.Text = "Delete Ανακοπής";
            this.tsmiDelTermination.Click += new System.EventHandler(this.tsmiDelTermination_Click);
            // 
            // tsmiDelFinalization
            // 
            this.tsmiDelFinalization.Name = "tsmiDelFinalization";
            this.tsmiDelFinalization.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelFinalization.Text = "Delete Οριστικοποίησης";
            this.tsmiDelFinalization.Click += new System.EventHandler(this.tsmiDelFinalization_Click);
            // 
            // tsmiDelRenewal
            // 
            this.tsmiDelRenewal.Name = "tsmiDelRenewal";
            this.tsmiDelRenewal.Size = new System.Drawing.Size(208, 22);
            this.tsmiDelRenewal.Text = "Delete Ανανέωσης";
            this.tsmiDelRenewal.Click += new System.EventHandler(this.tsmiDelRenewal_Click);
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOpenLink.Image = global::Trademarks.Properties.Resources.OpenLink_16x;
            this.btnOpenLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenLink.Location = new System.Drawing.Point(1186, 22);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(100, 40);
            this.btnOpenLink.TabIndex = 14;
            this.btnOpenLink.Text = "Άνοιγμα Url";
            this.btnOpenLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenLink.UseVisualStyleBackColor = true;
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // StatusViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 562);
            this.Controls.Add(this.btnOpenLink);
            this.Controls.Add(this.dgvStatusViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatusViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Καταστάσεις Σήματος";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusViewer)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvStatusViewer;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdDecision;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdAppeal;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdTermination;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdFinalization;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdRenewal;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelDecision;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelAppeal;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelTermination;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelFinalization;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelRenewal;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_TmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_DepositDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_DecisionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_DecisionDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_TermCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_FinalizedDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_FinalizedUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalApplicationDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_InsDt;
        private System.Windows.Forms.Button btnOpenLink;
    }
}