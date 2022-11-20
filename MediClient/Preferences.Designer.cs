namespace MediClient
{
    partial class Preferences
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOk = new System.Windows.Forms.TextBox();
            this.txtAlert = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radAlert = new System.Windows.Forms.RadioButton();
            this.radOk = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorAlert = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.radBoth = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentIP = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorAlert)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(64, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Run On Startup";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "OK Message";
            // 
            // txtOk
            // 
            this.txtOk.Location = new System.Drawing.Point(187, 63);
            this.txtOk.Name = "txtOk";
            this.txtOk.Size = new System.Drawing.Size(174, 23);
            this.txtOk.TabIndex = 2;
            // 
            // txtAlert
            // 
            this.txtAlert.Location = new System.Drawing.Point(187, 106);
            this.txtAlert.Name = "txtAlert";
            this.txtAlert.Size = new System.Drawing.Size(174, 23);
            this.txtAlert.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alert Message";
            // 
            // radAlert
            // 
            this.radAlert.AutoSize = true;
            this.radAlert.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAlert.Location = new System.Drawing.Point(243, 154);
            this.radAlert.Name = "radAlert";
            this.radAlert.Size = new System.Drawing.Size(53, 19);
            this.radAlert.TabIndex = 5;
            this.radAlert.TabStop = true;
            this.radAlert.Text = "Alert";
            this.radAlert.UseVisualStyleBackColor = true;
            // 
            // radOk
            // 
            this.radOk.AutoSize = true;
            this.radOk.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOk.Location = new System.Drawing.Point(187, 154);
            this.radOk.Name = "radOk";
            this.radOk.Size = new System.Drawing.Size(42, 19);
            this.radOk.TabIndex = 6;
            this.radOk.TabStop = true;
            this.radOk.Text = "OK";
            this.radOk.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message Mode";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorOk
            // 
            this.errorOk.ContainerControl = this;
            // 
            // errorAlert
            // 
            this.errorAlert.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(46, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 280);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtClientName);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(424, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.comboBox2.Location = new System.Drawing.Point(288, 125);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(75, 23);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Text = "None";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Control",
            "Shift",
            "Winkey"});
            this.comboBox1.Location = new System.Drawing.Point(143, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Hot Keys";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Save ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Client Name";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(143, 70);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(220, 23);
            this.txtClientName.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.radBoth);
            this.tabPage2.Controls.Add(this.txtAlert);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.txtOk);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.radOk);
            this.tabPage2.Controls.Add(this.radAlert);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(424, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Messages Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // radBoth
            // 
            this.radBoth.AutoSize = true;
            this.radBoth.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBoth.Location = new System.Drawing.Point(312, 154);
            this.radBoth.Name = "radBoth";
            this.radBoth.Size = new System.Drawing.Size(52, 19);
            this.radBoth.TabIndex = 9;
            this.radBoth.TabStop = true;
            this.radBoth.Text = "Both";
            this.radBoth.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtServerIP);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtCurrentIP);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(424, 252);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Server Configuration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Your Current IP";
            // 
            // txtCurrentIP
            // 
            this.txtCurrentIP.Location = new System.Drawing.Point(138, 19);
            this.txtCurrentIP.Name = "txtCurrentIP";
            this.txtCurrentIP.Size = new System.Drawing.Size(268, 23);
            this.txtCurrentIP.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(220, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(186, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Update Current IP";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Server IP";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(138, 126);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(268, 23);
            this.txtServerIP.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(220, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(186, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Update Server IP";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 429);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Preferences";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorAlert)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOk;
        private System.Windows.Forms.TextBox txtAlert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radAlert;
        private System.Windows.Forms.RadioButton radOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorOk;
        private System.Windows.Forms.ErrorProvider errorAlert;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radBoth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentIP;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button button5;
    }
}