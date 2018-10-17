namespace Trademarks
{
    partial class Companies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Companies));
            this.dgvComRecs = new System.Windows.Forms.DataGridView();
            this.com_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblComAddr = new System.Windows.Forms.Label();
            this.txtComAddr = new System.Windows.Forms.TextBox();
            this.lblComName = new System.Windows.Forms.Label();
            this.txtComName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComRecs)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvComRecs
            // 
            this.dgvComRecs.AllowUserToAddRows = false;
            this.dgvComRecs.AllowUserToDeleteRows = false;
            this.dgvComRecs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComRecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComRecs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.com_Id,
            this.com_Name,
            this.com_Address});
            this.dgvComRecs.Location = new System.Drawing.Point(0, 120);
            this.dgvComRecs.MultiSelect = false;
            this.dgvComRecs.Name = "dgvComRecs";
            this.dgvComRecs.RowTemplate.Height = 50;
            this.dgvComRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComRecs.Size = new System.Drawing.Size(784, 322);
            this.dgvComRecs.TabIndex = 2;
            this.dgvComRecs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvComRecs_MouseDown);
            // 
            // com_Id
            // 
            this.com_Id.HeaderText = "Id";
            this.com_Id.Name = "com_Id";
            this.com_Id.Visible = false;
            // 
            // com_Name
            // 
            this.com_Name.HeaderText = "Όνομα";
            this.com_Name.Name = "com_Name";
            this.com_Name.ReadOnly = true;
            this.com_Name.Width = 400;
            // 
            // com_Address
            // 
            this.com_Address.HeaderText = "Διεύθυνση";
            this.com_Address.Name = "com_Address";
            this.com_Address.ReadOnly = true;
            this.com_Address.Width = 300;
            // 
            // lblComAddr
            // 
            this.lblComAddr.AutoSize = true;
            this.lblComAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblComAddr.Location = new System.Drawing.Point(37, 64);
            this.lblComAddr.Name = "lblComAddr";
            this.lblComAddr.Size = new System.Drawing.Size(70, 16);
            this.lblComAddr.TabIndex = 3;
            this.lblComAddr.Text = "Διεύθυνση";
            // 
            // txtComAddr
            // 
            this.txtComAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtComAddr.Location = new System.Drawing.Point(113, 61);
            this.txtComAddr.Name = "txtComAddr";
            this.txtComAddr.Size = new System.Drawing.Size(500, 22);
            this.txtComAddr.TabIndex = 6;
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblComName.Location = new System.Drawing.Point(5, 36);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(102, 16);
            this.lblComName.TabIndex = 4;
            this.lblComName.Text = "Όνομα Εταιρίας";
            // 
            // txtComName
            // 
            this.txtComName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtComName.Location = new System.Drawing.Point(113, 33);
            this.txtComName.Name = "txtComName";
            this.txtComName.Size = new System.Drawing.Size(500, 22);
            this.txtComName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::Trademarks.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(623, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 50);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpd,
            this.tsmiDel});
            this.cmsOnGrid.Name = "cmsOnClasses";
            this.cmsOnGrid.Size = new System.Drawing.Size(131, 48);
            // 
            // tsmiUpd
            // 
            this.tsmiUpd.Name = "tsmiUpd";
            this.tsmiUpd.Size = new System.Drawing.Size(130, 22);
            this.tsmiUpd.Text = "Μεταβολή";
            this.tsmiUpd.Click += new System.EventHandler(this.tsmiUpd_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(130, 22);
            this.tsmiDel.Text = "Διαγραφή";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // Companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblComAddr);
            this.Controls.Add(this.txtComAddr);
            this.Controls.Add(this.lblComName);
            this.Controls.Add(this.txtComName);
            this.Controls.Add(this.dgvComRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Companies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εταιρίες";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComRecs)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvComRecs;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Address;
        private System.Windows.Forms.Label lblComAddr;
        private System.Windows.Forms.TextBox txtComAddr;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.TextBox txtComName;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
    }
}