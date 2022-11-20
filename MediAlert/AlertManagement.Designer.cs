namespace MediAlert
{
    partial class AlertManagement
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtAlertMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtOkMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.alertMessageError = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertMessageError)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtAlertMessage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(38, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alert Message";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Save Message";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtAlertMessage
            // 
            this.txtAlertMessage.Location = new System.Drawing.Point(110, 22);
            this.txtAlertMessage.Name = "txtAlertMessage";
            this.txtAlertMessage.Size = new System.Drawing.Size(492, 23);
            this.txtAlertMessage.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Message";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtOkMessage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(38, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 112);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OK Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOkMessage
            // 
            this.txtOkMessage.Location = new System.Drawing.Point(110, 22);
            this.txtOkMessage.Name = "txtOkMessage";
            this.txtOkMessage.Size = new System.Drawing.Size(492, 23);
            this.txtOkMessage.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Message";
            // 
            // alertMessageError
            // 
            this.alertMessageError.ContainerControl = this;
            // 
            // AlertManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlertManagement";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertMessageError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtAlertMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtOkMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider alertMessageError;
    }
}