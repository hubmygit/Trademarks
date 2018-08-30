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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Companies));
            this.dgvTempRecs = new System.Windows.Forms.DataGridView();
            this.com_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).BeginInit();
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
            this.com_Id,
            this.com_Name,
            this.com_Address});
            this.dgvTempRecs.Location = new System.Drawing.Point(0, 120);
            this.dgvTempRecs.MultiSelect = false;
            this.dgvTempRecs.Name = "dgvTempRecs";
            this.dgvTempRecs.RowTemplate.Height = 50;
            this.dgvTempRecs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTempRecs.Size = new System.Drawing.Size(784, 322);
            this.dgvTempRecs.TabIndex = 2;
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
            // Companies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.dgvTempRecs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Companies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Companies";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempRecs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTempRecs;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_Address;
    }
}