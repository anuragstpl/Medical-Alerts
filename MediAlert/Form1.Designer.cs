namespace MediAlert
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mediAlertTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mediAlertContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.mediAlertContext.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediAlertTrayIcon
            // 
            this.mediAlertTrayIcon.ContextMenuStrip = this.mediAlertContext;
            this.mediAlertTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mediAlertTrayIcon.Icon")));
            this.mediAlertTrayIcon.Text = "MediAlert";
            this.mediAlertTrayIcon.Visible = true;
            this.mediAlertTrayIcon.Click += new System.EventHandler(this.mediAlertTrayIcon_Click);
            this.mediAlertTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mediAlertTrayIcon_MouseDoubleClick);
            // 
            // mediAlertContext
            // 
            this.mediAlertContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendLogsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.mediAlertContext.Name = "mediAlertContext";
            this.mediAlertContext.Size = new System.Drawing.Size(134, 54);
            this.mediAlertContext.Text = "Exit";
            // 
            // sendLogsToolStripMenuItem
            // 
            this.sendLogsToolStripMenuItem.Name = "sendLogsToolStripMenuItem";
            this.sendLogsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.sendLogsToolStripMenuItem.Text = "Start Server";
            this.sendLogsToolStripMenuItem.Click += new System.EventHandler(this.sendLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(43, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 273);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Box";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 73);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 50);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(534, 194);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 273);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(429, 72);
            this.textBox1.TabIndex = 0;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(506, 24);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(0, 15);
            this.lblConnectionStatus.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblConnectionStatus);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mediAlertContext.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon mediAlertTrayIcon;
        private System.Windows.Forms.ContextMenuStrip mediAlertContext;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblConnectionStatus;
    }
}

