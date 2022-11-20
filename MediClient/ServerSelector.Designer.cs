namespace MediClient
{
    partial class ServerSelector
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
            this.btnIPSelector = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ipbox = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnIPSelector
            // 
            this.btnIPSelector.Location = new System.Drawing.Point(121, 147);
            this.btnIPSelector.Name = "btnIPSelector";
            this.btnIPSelector.Size = new System.Drawing.Size(141, 27);
            this.btnIPSelector.TabIndex = 1;
            this.btnIPSelector.Text = "Connect With Server";
            this.btnIPSelector.UseVisualStyleBackColor = true;
            this.btnIPSelector.Click += new System.EventHandler(this.btnIPSelector_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 23);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipbox
            // 
            this.ipbox.FormattingEnabled = true;
            this.ipbox.ItemHeight = 15;
            this.ipbox.Location = new System.Drawing.Point(26, 65);
            this.ipbox.Name = "ipbox";
            this.ipbox.Size = new System.Drawing.Size(314, 64);
            this.ipbox.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 147);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Remember";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ServerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 195);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ipbox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIPSelector);
            this.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerSelector";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP Selector";
            this.Load += new System.EventHandler(this.IPSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIPSelector;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ipbox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}