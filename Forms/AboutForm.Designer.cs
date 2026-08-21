namespace CopyStand.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblAppName = new System.Windows.Forms.Label();
            this.picAppIcon = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnDevWebsite = new System.Windows.Forms.Button();
            this.btnSourceCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblAppName.Location = new System.Drawing.Point(114, 12);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(108, 13);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "Copy Stand v0.1a";
            // 
            // picAppIcon
            // 
            this.picAppIcon.Image = ((System.Drawing.Image)(resources.GetObject("picAppIcon.Image")));
            this.picAppIcon.Location = new System.Drawing.Point(12, 12);
            this.picAppIcon.Name = "picAppIcon";
            this.picAppIcon.Size = new System.Drawing.Size(96, 96);
            this.picAppIcon.TabIndex = 1;
            this.picAppIcon.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(114, 25);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(265, 57);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "A clipboard manager application that can synchronize the clipboard of various dev" +
    "ices on your local network.\r\n\r\nDeveloped by Nathan Campos";
            // 
            // btnDevWebsite
            // 
            this.btnDevWebsite.Location = new System.Drawing.Point(259, 85);
            this.btnDevWebsite.Name = "btnDevWebsite";
            this.btnDevWebsite.Size = new System.Drawing.Size(120, 23);
            this.btnDevWebsite.TabIndex = 3;
            this.btnDevWebsite.Text = "Developer Website";
            this.btnDevWebsite.UseVisualStyleBackColor = true;
            this.btnDevWebsite.Click += new System.EventHandler(this.btnDevWebsite_Click);
            // 
            // btnSourceCode
            // 
            this.btnSourceCode.Location = new System.Drawing.Point(163, 85);
            this.btnSourceCode.Name = "btnSourceCode";
            this.btnSourceCode.Size = new System.Drawing.Size(90, 23);
            this.btnSourceCode.TabIndex = 4;
            this.btnSourceCode.Text = "Source Code";
            this.btnSourceCode.UseVisualStyleBackColor = true;
            this.btnSourceCode.Click += new System.EventHandler(this.btnSourceCode_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 120);
            this.Controls.Add(this.btnSourceCode);
            this.Controls.Add(this.btnDevWebsite);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.picAppIcon);
            this.Controls.Add(this.lblAppName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.PictureBox picAppIcon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnDevWebsite;
        private System.Windows.Forms.Button btnSourceCode;
    }
}