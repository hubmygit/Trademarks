namespace Trademarks
{
    partial class ComView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComView));
            this.dgvComRecs = new System.Windows.Forms.DataGridView();
            this.com_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateNew = new System.Windows.Forms.Button();
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
            this.dgvComRecs.ContextMenuStrip = this.cmsOnGrid;
            this.dgvComRecs.Location = new System.Drawing.Point(0, 63);
            this.dgvComRecs.MultiSelect = false;
            this.dgvComRecs.Name = "dgvComRecs";
            this.dgvComRecs.RowTemplate.Height = 25;
            this.dgvComRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComRecs.Size = new System.Drawing.Size(784, 379);
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
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpd,
            this.tsmiDel});
            this.cmsOnGrid.Name = "cmsOnClasses";
            this.cmsOnGrid.Size = new System.Drawing.Size(181, 70);
            // 
            // tsmiUpd
            // 
            this.tsmiUpd.Name = "tsmiUpd";
            this.tsmiUpd.Size = new System.Drawing.Size(180, 22);
            this.tsmiUpd.Text = "Μεταβολή";
            this.tsmiUpd.Click += new System.EventHandler(this.tsmiUpd_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(180, 22);
            this.tsmiDel.Text = "Διαγραφή";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Image = global::Trademarks.Properties.Resources.Create_32x;
            this.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNew.Location = new System.Drawing.Point(12, 12);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(120, 45);
            this.btnCreateNew.TabIndex = 35;
            this.btnCreateNew.Text = "Νέα Εταιρία";
            this.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // ComView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.dgvComRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εταιρίες";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComRecs)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvComRecs;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Address;
        private System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.Button btnCreateNew;
    }
}