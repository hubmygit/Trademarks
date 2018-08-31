namespace TMAlerts
{
    partial class TMAlerts
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
            this.btnRunProcedure = new System.Windows.Forms.Button();
            this.btnEncryptConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRunProcedure
            // 
            this.btnRunProcedure.Location = new System.Drawing.Point(127, 70);
            this.btnRunProcedure.Name = "btnRunProcedure";
            this.btnRunProcedure.Size = new System.Drawing.Size(80, 40);
            this.btnRunProcedure.TabIndex = 0;
            this.btnRunProcedure.Text = "Run Procedure";
            this.btnRunProcedure.UseVisualStyleBackColor = true;
            this.btnRunProcedure.Click += new System.EventHandler(this.btnRunProcedure_Click);
            // 
            // btnEncryptConfig
            // 
            this.btnEncryptConfig.Location = new System.Drawing.Point(12, 200);
            this.btnEncryptConfig.Name = "btnEncryptConfig";
            this.btnEncryptConfig.Size = new System.Drawing.Size(100, 30);
            this.btnEncryptConfig.TabIndex = 6;
            this.btnEncryptConfig.Text = "Encrypt Config";
            this.btnEncryptConfig.UseVisualStyleBackColor = true;
            this.btnEncryptConfig.Click += new System.EventHandler(this.btnEncryptConfig_Click);
            // 
            // TMAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 242);
            this.Controls.Add(this.btnEncryptConfig);
            this.Controls.Add(this.btnRunProcedure);
            this.Name = "TMAlerts";
            this.Text = "TM Alerts";
            this.Load += new System.EventHandler(this.TMAlerts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunProcedure;
        private System.Windows.Forms.Button btnEncryptConfig;
    }
}

