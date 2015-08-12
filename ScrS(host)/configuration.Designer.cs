namespace ScrS_server_
{
    partial class configuration
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
            this.txtRDPFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRDPInvitationFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRDPFilePath
            // 
            this.txtRDPFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRDPFilePath.Location = new System.Drawing.Point(193, 45);
            this.txtRDPFilePath.Name = "txtRDPFilePath";
            this.txtRDPFilePath.Size = new System.Drawing.Size(460, 26);
            this.txtRDPFilePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "RDP invitation file:";
            // 
            // btnRDPInvitationFile
            // 
            this.btnRDPInvitationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRDPInvitationFile.Location = new System.Drawing.Point(659, 43);
            this.btnRDPInvitationFile.Name = "btnRDPInvitationFile";
            this.btnRDPInvitationFile.Size = new System.Drawing.Size(107, 30);
            this.btnRDPInvitationFile.TabIndex = 2;
            this.btnRDPInvitationFile.Text = "Pronađi";
            this.btnRDPInvitationFile.UseVisualStyleBackColor = true;
            this.btnRDPInvitationFile.Click += new System.EventHandler(this.btnRDPInvitationFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.Location = new System.Drawing.Point(475, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(261, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAČUVAJ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 240);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRDPInvitationFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRDPFilePath);
            this.Name = "configuration";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRDPFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRDPInvitationFile;
        private System.Windows.Forms.Button btnSave;
    }
}