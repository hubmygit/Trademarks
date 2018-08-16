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
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.btnQuickInsert);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuickInsert;
    }
}

