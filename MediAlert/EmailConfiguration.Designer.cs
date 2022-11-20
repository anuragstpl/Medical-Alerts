namespace MediAlert
{
    partial class EmailConfiguration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtEmailTester = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtReciever = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.errorHostName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPortNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorSender = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorReciever = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorMailTester = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkActiveEmail = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnITDeliverySmtp = new System.Windows.Forms.Button();
            this.txtITDeliveryEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtITDeliveryHost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorITDeliveryHost = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorITDeliveryEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorHostName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPortNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorReciever)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMailTester)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorITDeliveryHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorITDeliveryEmail)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPortNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHostName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other SMTP Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(110, 90);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(186, 23);
            this.txtPortNo.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Port No";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save SMTP details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(392, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(210, 23);
            this.txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 56);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(186, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email ";
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(110, 22);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(492, 23);
            this.txtHostName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtEmailTester);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(35, 529);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test SMTP";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Send Test Mail";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtEmailTester
            // 
            this.txtEmailTester.Location = new System.Drawing.Point(110, 22);
            this.txtEmailTester.Name = "txtEmailTester";
            this.txtEmailTester.Size = new System.Drawing.Size(492, 23);
            this.txtEmailTester.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtReciever);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(35, 334);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 177);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reciever Details";
            // 
            // txtReciever
            // 
            this.txtReciever.Location = new System.Drawing.Point(138, 37);
            this.txtReciever.Multiline = true;
            this.txtReciever.Name = "txtReciever";
            this.txtReciever.Size = new System.Drawing.Size(464, 81);
            this.txtReciever.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Reciever Emails";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(392, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Save Details";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorHostName
            // 
            this.errorHostName.ContainerControl = this;
            // 
            // errorEmail
            // 
            this.errorEmail.ContainerControl = this;
            // 
            // errorPassword
            // 
            this.errorPassword.ContainerControl = this;
            // 
            // errorPortNo
            // 
            this.errorPortNo.ContainerControl = this;
            // 
            // errorSender
            // 
            this.errorSender.ContainerControl = this;
            // 
            // errorReciever
            // 
            this.errorReciever.ContainerControl = this;
            // 
            // errorMailTester
            // 
            this.errorMailTester.ContainerControl = this;
            // 
            // chkActiveEmail
            // 
            this.chkActiveEmail.AutoSize = true;
            this.chkActiveEmail.Location = new System.Drawing.Point(35, 22);
            this.chkActiveEmail.Name = "chkActiveEmail";
            this.chkActiveEmail.Size = new System.Drawing.Size(143, 19);
            this.chkActiveEmail.TabIndex = 9;
            this.chkActiveEmail.Text = "Enable Email Logging";
            this.chkActiveEmail.UseVisualStyleBackColor = true;
            this.chkActiveEmail.CheckedChanged += new System.EventHandler(this.chkActiveEmail_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnITDeliverySmtp);
            this.groupBox4.Controls.Add(this.txtITDeliveryEmail);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtITDeliveryHost);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(35, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(624, 104);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "IT Delivery SMTP Details";
            // 
            // btnITDeliverySmtp
            // 
            this.btnITDeliverySmtp.Location = new System.Drawing.Point(392, 55);
            this.btnITDeliverySmtp.Name = "btnITDeliverySmtp";
            this.btnITDeliverySmtp.Size = new System.Drawing.Size(210, 23);
            this.btnITDeliverySmtp.TabIndex = 6;
            this.btnITDeliverySmtp.Text = "Save IT Delievry SMTP details";
            this.btnITDeliverySmtp.UseVisualStyleBackColor = true;
            this.btnITDeliverySmtp.Click += new System.EventHandler(this.btnITDeliverySmtp_Click);
            // 
            // txtITDeliveryEmail
            // 
            this.txtITDeliveryEmail.Location = new System.Drawing.Point(110, 56);
            this.txtITDeliveryEmail.Name = "txtITDeliveryEmail";
            this.txtITDeliveryEmail.Size = new System.Drawing.Size(186, 23);
            this.txtITDeliveryEmail.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Email ";
            // 
            // txtITDeliveryHost
            // 
            this.txtITDeliveryHost.Location = new System.Drawing.Point(110, 22);
            this.txtITDeliveryHost.Name = "txtITDeliveryHost";
            this.txtITDeliveryHost.Size = new System.Drawing.Size(492, 23);
            this.txtITDeliveryHost.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Host";
            // 
            // errorITDeliveryHost
            // 
            this.errorITDeliveryHost.ContainerControl = this;
            // 
            // errorITDeliveryEmail
            // 
            this.errorITDeliveryEmail.ContainerControl = this;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Location = new System.Drawing.Point(214, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(445, 46);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(75, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "IT Delivery SMTP";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(360, 15);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Others";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // EmailConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 648);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chkActiveEmail);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmailConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Configuration";
            this.Load += new System.EventHandler(this.EmailConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorHostName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPortNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorReciever)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMailTester)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorITDeliveryHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorITDeliveryEmail)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtEmailTester;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtReciever;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorHostName;
        private System.Windows.Forms.ErrorProvider errorEmail;
        private System.Windows.Forms.ErrorProvider errorPassword;
        private System.Windows.Forms.ErrorProvider errorPortNo;
        private System.Windows.Forms.ErrorProvider errorSender;
        private System.Windows.Forms.ErrorProvider errorReciever;
        private System.Windows.Forms.ErrorProvider errorMailTester;
        private System.Windows.Forms.CheckBox chkActiveEmail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnITDeliverySmtp;
        private System.Windows.Forms.TextBox txtITDeliveryEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtITDeliveryHost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorITDeliveryHost;
        private System.Windows.Forms.ErrorProvider errorITDeliveryEmail;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}