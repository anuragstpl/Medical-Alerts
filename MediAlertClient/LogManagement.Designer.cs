namespace MediAlertClient
{
    partial class LogManagement
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Connect with server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(383, 26);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(0, 15);
            this.lblConnectionStatus.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(13, 64);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(324, 23);
            this.txtFile.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(115, 105);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(155, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send to Server";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // LogManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 150);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LogManagement";
            this.Text = "Log Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSend;
    }
}