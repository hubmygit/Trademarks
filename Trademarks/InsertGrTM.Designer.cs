namespace Trademarks
{
    partial class InsertGrTM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertGrTM));
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.Type_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.cbLawyerFullname = new System.Windows.Forms.ComboBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.Class_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Class_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class_Headers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class_Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnClasses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnRemoveTMFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddTMPic = new System.Windows.Forms.Button();
            this.lblTMPic = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblTMName = new System.Windows.Forms.Label();
            this.txtTMName = new System.Windows.Forms.TextBox();
            this.lblLawyerFullname = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblDepositTitle = new System.Windows.Forms.Label();
            this.dtpDepositTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDepositDt = new System.Windows.Forms.DateTimePicker();
            this.lblDepositDt = new System.Windows.Forms.Label();
            this.lblTMId = new System.Windows.Forms.Label();
            this.txtTMId = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.pbTMPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.cmsOnClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTMPic)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTypes
            // 
            this.dgvTypes.AllowUserToAddRows = false;
            this.dgvTypes.AllowUserToDeleteRows = false;
            this.dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type_Id,
            this.Type_Checked,
            this.Type_Name});
            this.dgvTypes.Location = new System.Drawing.Point(41, 224);
            this.dgvTypes.MultiSelect = false;
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.RowHeadersVisible = false;
            this.dgvTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypes.Size = new System.Drawing.Size(215, 140);
            this.dgvTypes.TabIndex = 7;
            // 
            // Type_Id
            // 
            this.Type_Id.HeaderText = "Id";
            this.Type_Id.Name = "Type_Id";
            this.Type_Id.Visible = false;
            this.Type_Id.Width = 40;
            // 
            // Type_Checked
            // 
            this.Type_Checked.HeaderText = "";
            this.Type_Checked.Name = "Type_Checked";
            this.Type_Checked.Width = 20;
            // 
            // Type_Name
            // 
            this.Type_Name.HeaderText = "Τύπος";
            this.Type_Name.Name = "Type_Name";
            this.Type_Name.ReadOnly = true;
            this.Type_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type_Name.Width = 170;
            // 
            // cbCompany
            // 
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.ItemHeight = 16;
            this.cbCompany.Location = new System.Drawing.Point(157, 140);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(500, 24);
            this.cbCompany.TabIndex = 5;
            // 
            // cbLawyerFullname
            // 
            this.cbLawyerFullname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLawyerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbLawyerFullname.FormattingEnabled = true;
            this.cbLawyerFullname.ItemHeight = 16;
            this.cbLawyerFullname.Location = new System.Drawing.Point(157, 181);
            this.cbLawyerFullname.Name = "cbLawyerFullname";
            this.cbLawyerFullname.Size = new System.Drawing.Size(500, 24);
            this.cbLawyerFullname.TabIndex = 6;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPreview.Location = new System.Drawing.Point(448, 270);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(247, 16);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Δεν είναι δυνατή η προβολή του αρχείου";
            this.lblPreview.Visible = false;
            // 
            // dgvClasses
            // 
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Class_Id,
            this.Class_Checked,
            this.Class_No,
            this.Class_Headers,
            this.Class_Link});
            this.dgvClasses.ContextMenuStrip = this.cmsOnClasses;
            this.dgvClasses.Location = new System.Drawing.Point(41, 385);
            this.dgvClasses.MultiSelect = false;
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.RowHeadersVisible = false;
            this.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.Size = new System.Drawing.Size(705, 140);
            this.dgvClasses.TabIndex = 11;
            this.dgvClasses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvClasses_MouseDown);
            // 
            // Class_Id
            // 
            this.Class_Id.HeaderText = "Id";
            this.Class_Id.Name = "Class_Id";
            this.Class_Id.Visible = false;
            this.Class_Id.Width = 40;
            // 
            // Class_Checked
            // 
            this.Class_Checked.HeaderText = "";
            this.Class_Checked.Name = "Class_Checked";
            this.Class_Checked.Width = 20;
            // 
            // Class_No
            // 
            this.Class_No.HeaderText = "Κλάση";
            this.Class_No.Name = "Class_No";
            this.Class_No.ReadOnly = true;
            this.Class_No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Class_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Class_No.Width = 40;
            // 
            // Class_Headers
            // 
            this.Class_Headers.HeaderText = "Επικεφαλίδες";
            this.Class_Headers.Name = "Class_Headers";
            this.Class_Headers.ReadOnly = true;
            this.Class_Headers.Width = 620;
            // 
            // Class_Link
            // 
            this.Class_Link.HeaderText = "Link";
            this.Class_Link.Name = "Class_Link";
            this.Class_Link.Visible = false;
            // 
            // cmsOnClasses
            // 
            this.cmsOnClasses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenUrl});
            this.cmsOnClasses.Name = "cmsOnClasses";
            this.cmsOnClasses.Size = new System.Drawing.Size(209, 48);
            // 
            // tsmiOpenUrl
            // 
            this.tsmiOpenUrl.Name = "tsmiOpenUrl";
            this.tsmiOpenUrl.Size = new System.Drawing.Size(208, 22);
            this.tsmiOpenUrl.Text = "Άνοιγμα Υπερσυνδέσμου";
            this.tsmiOpenUrl.Click += new System.EventHandler(this.tsmiOpenUrl_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFilename.Location = new System.Drawing.Point(396, 344);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(323, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Text = "Αρχείο: -";
            // 
            // btnRemoveTMFile
            // 
            this.btnRemoveTMFile.Location = new System.Drawing.Point(316, 278);
            this.btnRemoveTMFile.Name = "btnRemoveTMFile";
            this.btnRemoveTMFile.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveTMFile.TabIndex = 9;
            this.btnRemoveTMFile.Text = "-";
            this.btnRemoveTMFile.UseVisualStyleBackColor = true;
            this.btnRemoveTMFile.Click += new System.EventHandler(this.btnRemoveTMFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Location = new System.Drawing.Point(302, 750);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 50);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddTMPic
            // 
            this.btnAddTMPic.Location = new System.Drawing.Point(316, 243);
            this.btnAddTMPic.Name = "btnAddTMPic";
            this.btnAddTMPic.Size = new System.Drawing.Size(30, 30);
            this.btnAddTMPic.TabIndex = 8;
            this.btnAddTMPic.Text = "+";
            this.btnAddTMPic.UseVisualStyleBackColor = true;
            this.btnAddTMPic.Click += new System.EventHandler(this.btnAddTMPic_Click);
            // 
            // lblTMPic
            // 
            this.lblTMPic.AutoSize = true;
            this.lblTMPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMPic.Location = new System.Drawing.Point(279, 224);
            this.lblTMPic.Name = "lblTMPic";
            this.lblTMPic.Size = new System.Drawing.Size(114, 16);
            this.lblTMPic.TabIndex = 0;
            this.lblTMPic.Text = "Εικονίδιο / Αρχείο";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(41, 635);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(705, 87);
            this.txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDescription.Location = new System.Drawing.Point(38, 616);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(125, 16);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Περιγραφή / Σχόλια";
            // 
            // txtFees
            // 
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFees.Location = new System.Drawing.Point(41, 560);
            this.txtFees.Multiline = true;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(705, 39);
            this.txtFees.TabIndex = 12;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFees.Location = new System.Drawing.Point(38, 541);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(181, 16);
            this.lblFees.TabIndex = 0;
            this.lblFees.Text = "Αρ. Παραβόλων Δημ. Ταμείου";
            // 
            // lblTMName
            // 
            this.lblTMName.AutoSize = true;
            this.lblTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMName.Location = new System.Drawing.Point(287, 65);
            this.lblTMName.Name = "lblTMName";
            this.lblTMName.Size = new System.Drawing.Size(103, 16);
            this.lblTMName.TabIndex = 0;
            this.lblTMName.Text = "Όνομα Σήματος";
            // 
            // txtTMName
            // 
            this.txtTMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMName.Location = new System.Drawing.Point(396, 62);
            this.txtTMName.Name = "txtTMName";
            this.txtTMName.Size = new System.Drawing.Size(350, 22);
            this.txtTMName.TabIndex = 2;
            // 
            // lblLawyerFullname
            // 
            this.lblLawyerFullname.AutoSize = true;
            this.lblLawyerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLawyerFullname.Location = new System.Drawing.Point(24, 184);
            this.lblLawyerFullname.Name = "lblLawyerFullname";
            this.lblLawyerFullname.Size = new System.Drawing.Size(126, 16);
            this.lblLawyerFullname.TabIndex = 0;
            this.lblLawyerFullname.Text = "Ονομ/μο Δικηγόρου";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(24, 143);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(52, 16);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Εταιρία";
            // 
            // lblDepositTitle
            // 
            this.lblDepositTitle.AutoSize = true;
            this.lblDepositTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDepositTitle.Location = new System.Drawing.Point(222, 13);
            this.lblDepositTitle.Name = "lblDepositTitle";
            this.lblDepositTitle.Size = new System.Drawing.Size(340, 24);
            this.lblDepositTitle.TabIndex = 0;
            this.lblDepositTitle.Text = "Δήλωση Κατάθεσης Εθνικού Σήματος";
            // 
            // dtpDepositTime
            // 
            this.dtpDepositTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpDepositTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDepositTime.Location = new System.Drawing.Point(282, 100);
            this.dtpDepositTime.Name = "dtpDepositTime";
            this.dtpDepositTime.ShowUpDown = true;
            this.dtpDepositTime.Size = new System.Drawing.Size(120, 22);
            this.dtpDepositTime.TabIndex = 4;
            // 
            // dtpDepositDt
            // 
            this.dtpDepositDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpDepositDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepositDt.Location = new System.Drawing.Point(156, 100);
            this.dtpDepositDt.Name = "dtpDepositDt";
            this.dtpDepositDt.Size = new System.Drawing.Size(120, 22);
            this.dtpDepositDt.TabIndex = 3;
            // 
            // lblDepositDt
            // 
            this.lblDepositDt.AutoSize = true;
            this.lblDepositDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDepositDt.Location = new System.Drawing.Point(24, 105);
            this.lblDepositDt.Name = "lblDepositDt";
            this.lblDepositDt.Size = new System.Drawing.Size(114, 16);
            this.lblDepositDt.TabIndex = 0;
            this.lblDepositDt.Text = "Ημ/νία Κατάθεσης";
            // 
            // lblTMId
            // 
            this.lblTMId.AutoSize = true;
            this.lblTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTMId.Location = new System.Drawing.Point(24, 65);
            this.lblTMId.Name = "lblTMId";
            this.lblTMId.Size = new System.Drawing.Size(112, 16);
            this.lblTMId.TabIndex = 0;
            this.lblTMId.Text = "Αριθμός Σήματος";
            // 
            // txtTMId
            // 
            this.txtTMId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTMId.Location = new System.Drawing.Point(156, 62);
            this.txtTMId.Name = "txtTMId";
            this.txtTMId.Size = new System.Drawing.Size(100, 22);
            this.txtTMId.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = global::Trademarks.Properties.Resources.OpenFile_16x;
            this.btnOpenFile.Location = new System.Drawing.Point(724, 343);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(22, 22);
            this.btnOpenFile.TabIndex = 10;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // pbTMPic
            // 
            this.pbTMPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTMPic.Location = new System.Drawing.Point(396, 224);
            this.pbTMPic.Name = "pbTMPic";
            this.pbTMPic.Size = new System.Drawing.Size(350, 100);
            this.pbTMPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTMPic.TabIndex = 71;
            this.pbTMPic.TabStop = false;
            // 
            // InsertGrTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 812);
            this.Controls.Add(this.dgvTypes);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.cbLawyerFullname);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnRemoveTMFile);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddTMPic);
            this.Controls.Add(this.lblTMPic);
            this.Controls.Add(this.pbTMPic);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.lblFees);
            this.Controls.Add(this.lblTMName);
            this.Controls.Add(this.txtTMName);
            this.Controls.Add(this.lblLawyerFullname);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblDepositTitle);
            this.Controls.Add(this.dtpDepositTime);
            this.Controls.Add(this.dtpDepositDt);
            this.Controls.Add(this.lblDepositDt);
            this.Controls.Add(this.lblTMId);
            this.Controls.Add(this.txtTMId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InsertGrTM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εθνικό Σήμα";
            this.Load += new System.EventHandler(this.InsertGrTM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.cmsOnClasses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTMPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Type_Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Name;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.ComboBox cbLawyerFullname;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Class_Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class_Headers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class_Link;
        private System.Windows.Forms.ContextMenuStrip cmsOnClasses;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenUrl;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnRemoveTMFile;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddTMPic;
        private System.Windows.Forms.Label lblTMPic;
        private System.Windows.Forms.PictureBox pbTMPic;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblTMName;
        private System.Windows.Forms.TextBox txtTMName;
        private System.Windows.Forms.Label lblLawyerFullname;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDepositTitle;
        private System.Windows.Forms.DateTimePicker dtpDepositTime;
        private System.Windows.Forms.DateTimePicker dtpDepositDt;
        private System.Windows.Forms.Label lblDepositDt;
        private System.Windows.Forms.Label lblTMId;
        private System.Windows.Forms.TextBox txtTMId;
    }
}