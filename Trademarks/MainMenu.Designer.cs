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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripBasic = new System.Windows.Forms.MenuStrip();
            this.tsmiTM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTM_ins = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTM_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlerts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlerts_ViewGrouped = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlerts_View = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertTMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdmin_Encrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBtnShow = new System.Windows.Forms.ToolStripButton();
            this.TSBtnAlerts = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStripBasic.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // menuStripBasic
            // 
            this.menuStripBasic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTM,
            this.tsmiAlerts,
            this.newItemsToolStripMenuItem,
            this.tsmiAdmin});
            this.menuStripBasic.Location = new System.Drawing.Point(0, 0);
            this.menuStripBasic.Name = "menuStripBasic";
            this.menuStripBasic.Size = new System.Drawing.Size(784, 24);
            this.menuStripBasic.TabIndex = 6;
            this.menuStripBasic.Text = "menuStrip1";
            // 
            // tsmiTM
            // 
            this.tsmiTM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTM_ins,
            this.tsmiTM_View});
            this.tsmiTM.Name = "tsmiTM";
            this.tsmiTM.Size = new System.Drawing.Size(113, 20);
            this.tsmiTM.Text = "Εμπορικά Σήματα";
            // 
            // tsmiTM_ins
            // 
            this.tsmiTM_ins.Name = "tsmiTM_ins";
            this.tsmiTM_ins.Size = new System.Drawing.Size(195, 22);
            this.tsmiTM_ins.Text = "Καταχώρηση";
            this.tsmiTM_ins.Click += new System.EventHandler(this.tsmiTM_ins_Click);
            // 
            // tsmiTM_View
            // 
            this.tsmiTM_View.Name = "tsmiTM_View";
            this.tsmiTM_View.Size = new System.Drawing.Size(195, 22);
            this.tsmiTM_View.Text = "Προβολή/Επεξεργασία";
            this.tsmiTM_View.Click += new System.EventHandler(this.tsmiTM_View_Click);
            // 
            // tsmiAlerts
            // 
            this.tsmiAlerts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlerts_ViewGrouped,
            this.tsmiAlerts_View});
            this.tsmiAlerts.Name = "tsmiAlerts";
            this.tsmiAlerts.Size = new System.Drawing.Size(88, 20);
            this.tsmiAlerts.Text = "Ειδοποιήσεις";
            // 
            // tsmiAlerts_ViewGrouped
            // 
            this.tsmiAlerts_ViewGrouped.Name = "tsmiAlerts_ViewGrouped";
            this.tsmiAlerts_ViewGrouped.Size = new System.Drawing.Size(217, 22);
            this.tsmiAlerts_ViewGrouped.Text = "Προβολή (Συγκεντρωτικά)";
            this.tsmiAlerts_ViewGrouped.Click += new System.EventHandler(this.tsmiAlerts_ViewGrouped_Click);
            // 
            // tsmiAlerts_View
            // 
            this.tsmiAlerts_View.Name = "tsmiAlerts_View";
            this.tsmiAlerts_View.Size = new System.Drawing.Size(217, 22);
            this.tsmiAlerts_View.Text = "Προβολή (Αναλυτικά)";
            this.tsmiAlerts_View.Click += new System.EventHandler(this.tsmiAlerts_View_Click);
            // 
            // newItemsToolStripMenuItem
            // 
            this.newItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertTMToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.decisionToolStripMenuItem,
            this.appealToolStripMenuItem,
            this.terminationToolStripMenuItem,
            this.finalizationToolStripMenuItem,
            this.renewalToolStripMenuItem});
            this.newItemsToolStripMenuItem.Name = "newItemsToolStripMenuItem";
            this.newItemsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.newItemsToolStripMenuItem.Text = "NewItems";
            // 
            // insertTMToolStripMenuItem
            // 
            this.insertTMToolStripMenuItem.Name = "insertTMToolStripMenuItem";
            this.insertTMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.insertTMToolStripMenuItem.Text = "Κατάθεση";
            this.insertTMToolStripMenuItem.Click += new System.EventHandler(this.insertTMToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectToolStripMenuItem.Text = "Εμφάνιση";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // decisionToolStripMenuItem
            // 
            this.decisionToolStripMenuItem.Name = "decisionToolStripMenuItem";
            this.decisionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.decisionToolStripMenuItem.Text = "//Απόφαση";
            this.decisionToolStripMenuItem.Click += new System.EventHandler(this.decisionToolStripMenuItem_Click);
            // 
            // appealToolStripMenuItem
            // 
            this.appealToolStripMenuItem.Name = "appealToolStripMenuItem";
            this.appealToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.appealToolStripMenuItem.Text = "//Προσφυγή";
            this.appealToolStripMenuItem.Click += new System.EventHandler(this.appealToolStripMenuItem_Click);
            // 
            // terminationToolStripMenuItem
            // 
            this.terminationToolStripMenuItem.Name = "terminationToolStripMenuItem";
            this.terminationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.terminationToolStripMenuItem.Text = "//Ανακοπή";
            this.terminationToolStripMenuItem.Click += new System.EventHandler(this.terminationToolStripMenuItem_Click);
            // 
            // finalizationToolStripMenuItem
            // 
            this.finalizationToolStripMenuItem.Name = "finalizationToolStripMenuItem";
            this.finalizationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.finalizationToolStripMenuItem.Text = "//Οριστικοποίηση";
            this.finalizationToolStripMenuItem.Click += new System.EventHandler(this.finalizationToolStripMenuItem_Click);
            // 
            // renewalToolStripMenuItem
            // 
            this.renewalToolStripMenuItem.Name = "renewalToolStripMenuItem";
            this.renewalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renewalToolStripMenuItem.Text = "//Ανανέωση";
            this.renewalToolStripMenuItem.Click += new System.EventHandler(this.renewalToolStripMenuItem_Click);
            // 
            // tsmiAdmin
            // 
            this.tsmiAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdmin_Encrypt});
            this.tsmiAdmin.Name = "tsmiAdmin";
            this.tsmiAdmin.Size = new System.Drawing.Size(98, 20);
            this.tsmiAdmin.Text = "Administration";
            this.tsmiAdmin.Visible = false;
            // 
            // tsmiAdmin_Encrypt
            // 
            this.tsmiAdmin_Encrypt.Name = "tsmiAdmin_Encrypt";
            this.tsmiAdmin_Encrypt.Size = new System.Drawing.Size(180, 22);
            this.tsmiAdmin_Encrypt.Text = "Encrypt Config";
            this.tsmiAdmin_Encrypt.Click += new System.EventHandler(this.tsmiAdmin_Encrypt_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBtnShow,
            this.TSBtnAlerts});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 39);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBtnShow
            // 
            this.TSBtnShow.Image = global::Trademarks.Properties.Resources.ReportParameter_32x;
            this.TSBtnShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnShow.Name = "TSBtnShow";
            this.TSBtnShow.Size = new System.Drawing.Size(308, 36);
            this.TSBtnShow.Text = "Προβολή Εμπορικών Σημάτων";
            this.TSBtnShow.Click += new System.EventHandler(this.TSBtnShow_Click);
            // 
            // TSBtnAlerts
            // 
            this.TSBtnAlerts.Image = global::Trademarks.Properties.Resources.SendEmail_32x1;
            this.TSBtnAlerts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnAlerts.Name = "TSBtnAlerts";
            this.TSBtnAlerts.Size = new System.Drawing.Size(250, 36);
            this.TSBtnAlerts.Text = "Προβολή Ειδοποιήσεων";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Trademarks.Properties.Resources.TM1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStripBasic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripBasic;
            this.MaximumSize = new System.Drawing.Size(800, 480);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStripBasic.ResumeLayout(false);
            this.menuStripBasic.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.MenuStrip menuStripBasic;
        private System.Windows.Forms.ToolStripMenuItem tsmiTM;
        private System.Windows.Forms.ToolStripMenuItem tsmiTM_ins;
        private System.Windows.Forms.ToolStripMenuItem tsmiTM_View;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlerts;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlerts_View;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin_Encrypt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlerts_ViewGrouped;
        private System.Windows.Forms.ToolStripMenuItem newItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertTMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBtnShow;
        private System.Windows.Forms.ToolStripButton TSBtnAlerts;
    }
}

