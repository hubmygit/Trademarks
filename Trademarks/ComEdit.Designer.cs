namespace Trademarks
{
    partial class ComEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComEdit));
            this.lblComAddr = new System.Windows.Forms.Label();
            this.txtComAddr = new System.Windows.Forms.TextBox();
            this.lblComName = new System.Windows.Forms.Label();
            this.txtComName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblComAddr
            // 
            this.lblComAddr.AutoSize = true;
            this.lblComAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblComAddr.Location = new System.Drawing.Point(45, 116);
            this.lblComAddr.Name = "lblComAddr";
            this.lblComAddr.Size = new System.Drawing.Size(70, 16);
            this.lblComAddr.TabIndex = 3;
            this.lblComAddr.Text = "Διεύθυνση";
            // 
            // txtComAddr
            // 
            this.txtComAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtComAddr.Location = new System.Drawing.Point(121, 113);
            this.txtComAddr.Name = "txtComAddr";
            this.txtComAddr.Size = new System.Drawing.Size(800, 22);
            this.txtComAddr.TabIndex = 6;
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblComName.Location = new System.Drawing.Point(13, 62);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(102, 16);
            this.lblComName.TabIndex = 4;
            this.lblComName.Text = "Όνομα Εταιρίας";
            // 
            // txtComName
            // 
            this.txtComName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtComName.Location = new System.Drawing.Point(121, 59);
            this.txtComName.Name = "txtComName";
            this.txtComName.Size = new System.Drawing.Size(800, 22);
            this.txtComName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::Trademarks.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(387, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 50);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ComEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblComAddr);
            this.Controls.Add(this.txtComAddr);
            this.Controls.Add(this.lblComName);
            this.Controls.Add(this.txtComName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εταιρίες";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComAddr;
        private System.Windows.Forms.TextBox txtComAddr;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.TextBox txtComName;
        public System.Windows.Forms.Button btnSave;
    }
}