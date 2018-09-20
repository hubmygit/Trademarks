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
            this.btnQuickInsert = new System.Windows.Forms.Button();
            this.btnQuickView = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.menuStripBasic = new System.Windows.Forms.MenuStrip();
            this.tsmiTM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTM_ins = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTM_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlerts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlerts_ViewGrouped = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlerts_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdmin_Encrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertTMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlertsGrouped = new System.Windows.Forms.Button();
            this.decisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStripBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuickInsert
            // 
            this.btnQuickInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnQuickInsert.Location = new System.Drawing.Point(167, 49);
            this.btnQuickInsert.Name = "btnQuickInsert";
            this.btnQuickInsert.Size = new System.Drawing.Size(125, 50);
            this.btnQuickInsert.TabIndex = 0;
            this.btnQuickInsert.Text = "Καταχώρηση";
            this.btnQuickInsert.UseVisualStyleBackColor = true;
            this.btnQuickInsert.Click += new System.EventHandler(this.btnQuickInsert_Click);
            // 
            // btnQuickView
            // 
            this.btnQuickView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnQuickView.Location = new System.Drawing.Point(167, 115);
            this.btnQuickView.Name = "btnQuickView";
            this.btnQuickView.Size = new System.Drawing.Size(125, 50);
            this.btnQuickView.TabIndex = 1;
            this.btnQuickView.Text = "Προβολή / Επεξεργασία";
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
            // btnAlerts
            // 
            this.btnAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAlerts.Location = new System.Drawing.Point(489, 49);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(125, 50);
            this.btnAlerts.TabIndex = 4;
            this.btnAlerts.Text = "Ειδοποιήσεις / Αναλυτικά";
            this.btnAlerts.UseVisualStyleBackColor = true;
            this.btnAlerts.Click += new System.EventHandler(this.btnAlerts_Click);
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
            this.tsmiAdmin_Encrypt.Size = new System.Drawing.Size(153, 22);
            this.tsmiAdmin_Encrypt.Text = "Encrypt Config";
            this.tsmiAdmin_Encrypt.Click += new System.EventHandler(this.tsmiAdmin_Encrypt_Click);
            // 
            // newItemsToolStripMenuItem
            // 
            this.newItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertTMToolStripMenuItem,
            this.decisionToolStripMenuItem});
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
            // btnAlertsGrouped
            // 
            this.btnAlertsGrouped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAlertsGrouped.Location = new System.Drawing.Point(489, 115);
            this.btnAlertsGrouped.Name = "btnAlertsGrouped";
            this.btnAlertsGrouped.Size = new System.Drawing.Size(125, 50);
            this.btnAlertsGrouped.TabIndex = 7;
            this.btnAlertsGrouped.Text = "Ειδοποιήσεις / Συγκεντρωτικά";
            this.btnAlertsGrouped.UseVisualStyleBackColor = true;
            this.btnAlertsGrouped.Click += new System.EventHandler(this.btnAlertsGrouped_Click);
            // 
            // decisionToolStripMenuItem
            // 
            this.decisionToolStripMenuItem.Name = "decisionToolStripMenuItem";
            this.decisionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.decisionToolStripMenuItem.Text = "Απόφαση";
            this.decisionToolStripMenuItem.Click += new System.EventHandler(this.decisionToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Trademarks.Properties.Resources.TM1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.btnAlertsGrouped);
            this.Controls.Add(this.btnAlerts);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStripBasic);
            this.Controls.Add(this.btnQuickView);
            this.Controls.Add(this.btnQuickInsert);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuickInsert;
        private System.Windows.Forms.Button btnQuickView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.MenuStrip menuStripBasic;
        private System.Windows.Forms.ToolStripMenuItem tsmiTM;
        private System.Windows.Forms.ToolStripMenuItem tsmiTM_ins;
        private System.Windows.Forms.ToolStripMenuItem tsmiTM_View;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlerts;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlerts_View;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin_Encrypt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlerts_ViewGrouped;
        private System.Windows.Forms.Button btnAlertsGrouped;
        private System.Windows.Forms.ToolStripMenuItem newItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertTMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decisionToolStripMenuItem;
    }
}

