namespace MediAlert
{
    partial class ServerMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMaster));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsToolStripMenuItem,
            this.logManagementToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.emailManagementToolStripMenuItem,
            this.aboutITToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.clientsToolStripMenuItem.Text = "&Clients Management";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // logManagementToolStripMenuItem
            // 
            this.logManagementToolStripMenuItem.Name = "logManagementToolStripMenuItem";
            this.logManagementToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.logManagementToolStripMenuItem.Text = "&Log Management";
            this.logManagementToolStripMenuItem.Click += new System.EventHandler(this.logManagementToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.administrationToolStripMenuItem.Text = "&Alerts Management";
            this.administrationToolStripMenuItem.Click += new System.EventHandler(this.administrationToolStripMenuItem_Click);
            // 
            // emailManagementToolStripMenuItem
            // 
            this.emailManagementToolStripMenuItem.Name = "emailManagementToolStripMenuItem";
            this.emailManagementToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.emailManagementToolStripMenuItem.Text = "&Email Management";
            this.emailManagementToolStripMenuItem.Click += new System.EventHandler(this.emailManagementToolStripMenuItem_Click);
            // 
            // aboutITToolStripMenuItem
            // 
            this.aboutITToolStripMenuItem.Name = "aboutITToolStripMenuItem";
            this.aboutITToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.aboutITToolStripMenuItem.Text = "About &MediAlert";
            this.aboutITToolStripMenuItem.Click += new System.EventHandler(this.aboutITToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Medi Alert";
            this.notifyIcon1.Visible = true;
            // 
            // ServerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 580);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Master";
            this.Load += new System.EventHandler(this.ServerMaster_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutITToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}