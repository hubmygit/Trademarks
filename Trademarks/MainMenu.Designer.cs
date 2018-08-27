namespace Trademarks
{
    partial class MainMenu
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
            this.btnQuickInsert = new System.Windows.Forms.Button();
            this.btnQuickView = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuickInsert
            // 
            this.btnQuickInsert.Location = new System.Drawing.Point(12, 12);
            this.btnQuickInsert.Name = "btnQuickInsert";
            this.btnQuickInsert.Size = new System.Drawing.Size(100, 30);
            this.btnQuickInsert.TabIndex = 0;
            this.btnQuickInsert.Text = "Quick Insert";
            this.btnQuickInsert.UseVisualStyleBackColor = true;
            this.btnQuickInsert.Click += new System.EventHandler(this.btnQuickInsert_Click);
            // 
            // btnQuickView
            // 
            this.btnQuickView.Location = new System.Drawing.Point(12, 48);
            this.btnQuickView.Name = "btnQuickView";
            this.btnQuickView.Size = new System.Drawing.Size(100, 30);
            this.btnQuickView.TabIndex = 1;
            this.btnQuickView.Text = "Quick View";
            this.btnQuickView.UseVisualStyleBackColor = true;
            this.btnQuickView.Click += new System.EventHandler(this.btnQuickView_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLblUser
            // 
            this.tsStatusLblUser.BackColor = System.Drawing.SystemColors.Control;
            this.tsStatusLblUser.Image = global::Trademarks.Properties.Resources.User_16x;
            this.tsStatusLblUser.Name = "tsStatusLblUser";
            this.tsStatusLblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsStatusLblUser.Size = new System.Drawing.Size(103, 17);
            this.tsStatusLblUser.Text = "User: Unknown";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnQuickView);
            this.Controls.Add(this.btnQuickInsert);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuickInsert;
        private System.Windows.Forms.Button btnQuickView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
    }
}

