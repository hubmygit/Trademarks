﻿namespace Trademarks
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
            this.st_AppealDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_TermCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_TermDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_FinalizedDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_FinalizedUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalApplicationDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_RenewalProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_InsDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFinUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.gbNatPower = new System.Windows.Forms.GroupBox();
            this.rbDiethnes = new System.Windows.Forms.RadioButton();
            this.rbKoinotiko = new System.Windows.Forms.RadioButton();
            this.rbEthniko = new System.Windows.Forms.RadioButton();
            this.tsmiFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusViewer)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.gbNatPower.SuspendLayout();
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
            this.st_AppealDt,
            this.st_TermCom,
            this.st_TermDt,
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
            this.st_DecisionDt.HeaderText = "Ημ/νία Δημοσίευσης Απόφασης";
            this.st_DecisionDt.Name = "st_DecisionDt";
            this.st_DecisionDt.ReadOnly = true;
            // 
            // st_AppealDt
            // 
            this.st_AppealDt.HeaderText = "Ημ/νία Προσφυγής";
            this.st_AppealDt.Name = "st_AppealDt";
            this.st_AppealDt.ReadOnly = true;
            // 
            // st_TermCom
            // 
            this.st_TermCom.HeaderText = "Εταιρία Ανακοπής";
            this.st_TermCom.Name = "st_TermCom";
            this.st_TermCom.ReadOnly = true;
            // 
            // st_TermDt
            // 
            this.st_TermDt.HeaderText = "Ημ/νία Ανακοπής";
            this.st_TermDt.Name = "st_TermDt";
            this.st_TermDt.ReadOnly = true;
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
            this.tsmiUpdate,
            this.tsmiDelete,
            this.toolStripSeparator1,
            this.tsmiOpenFinUrl,
            this.toolStripSeparator2,
            this.tsmiFiles});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(209, 126);
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
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(21, 46);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 15;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(130, 43);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.ReadOnly = true;
            this.txtTMName.Size = new System.Drawing.Size(384, 22);
            this.txtTMName.TabIndex = 18;
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(12, 18);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 16;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(130, 15);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.ReadOnly = true;
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 17;
            // 
            // gbNatPower
            // 
            this.gbNatPower.Controls.Add(this.rbDiethnes);
            this.gbNatPower.Controls.Add(this.rbKoinotiko);
            this.gbNatPower.Controls.Add(this.rbEthniko);
            this.gbNatPower.Location = new System.Drawing.Point(236, 1);
            this.gbNatPower.Name = "gbNatPower";
            this.gbNatPower.Size = new System.Drawing.Size(278, 36);
            this.gbNatPower.TabIndex = 19;
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
            // tsmiFiles
            // 
            this.tsmiFiles.Name = "tsmiFiles";
            this.tsmiFiles.Size = new System.Drawing.Size(208, 22);
            this.tsmiFiles.Text = "Αρχεία";
            this.tsmiFiles.Click += new System.EventHandler(this.tsmiFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // StatusViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 562);
            this.Controls.Add(this.gbNatPower);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Controls.Add(this.btnOpenLink);
            this.Controls.Add(this.dgvStatusViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatusViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Καταστάσεις Σήματος";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusViewer)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.gbNatPower.ResumeLayout(false);
            this.gbNatPower.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvStatusViewer;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.Button btnOpenLink;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
        private System.Windows.Forms.GroupBox gbNatPower;
        private System.Windows.Forms.RadioButton rbDiethnes;
        private System.Windows.Forms.RadioButton rbKoinotiko;
        private System.Windows.Forms.RadioButton rbEthniko;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFinUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_TmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_DepositDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_DecisionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_DecisionDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_AppealDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_TermCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_TermDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_FinalizedDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_FinalizedUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalApplicationDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_RenewalProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_InsDt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFiles;
    }
}