using MediEL;
using MediHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediAlert
{
    public partial class LogManager : Form
    {
        string filename = "MediServer.mdl";
        public LogManager()
        {
            InitializeComponent();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentLogs.Text = openFileDialog1.FileName;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentLogs.Text != "Select log file")
            {
                ServerData smtp = GetLatestSMTP();
                smtp.logpath = currentLogs.Text;
                WriteJsonFile(smtp);
            }
            else
            {
                MessageBox.Show("Kindly select file for logs");
            }
        }

        public void WriteJsonFile(ServerData smtp)
        {
            if (File.Exists(filename))
            {
                string fileData = FileHelper.ReadFileData(filename);
                string jsondata;
                if (String.IsNullOrEmpty(fileData))
                {
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                else
                {
                    FileHelper.FlushFile(filename);
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                FileHelper.WriteFileData(filename, jsondata);
            }
            else
            {
                using (var stream = File.Create(filename)) { }
                string fileData = FileHelper.ReadFileData(filename);
                string jsondata;
                if (String.IsNullOrEmpty(fileData))
                {
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                else
                {
                    FileHelper.FlushFile(filename);
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                FileHelper.WriteFileData(filename, jsondata);

            }
        }

        public ServerData GetLatestSMTP()
        {
            ServerData smtp = new ServerData();
            string fileData = FileHelper.ReadFileData(filename);
            if (!String.IsNullOrEmpty(fileData))
            {
                smtp = MediHelper.JsonHelper<ServerData>.JsonDeserialize(fileData);
            }
            return smtp;
        }

        private void LogManager_Load(object sender, EventArgs e)
        {
            try
            {
                ServerData smtp = GetLatestSMTP();
                if (smtp != null)
                {
                    if (!String.IsNullOrEmpty(smtp.logpath))
                    {
                        currentLogs.Text = smtp.logpath;
                        richTextBox1.Text = FileHelper.ReadFileData(smtp.logpath);
                    }
                }
            }
            catch 
            {
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ServerData smtp = GetLatestSMTP();
                if (smtp != null)
                {
                    if (!String.IsNullOrEmpty(smtp.logpath))
                    {
                        currentLogs.Text = smtp.logpath;
                        richTextBox1.Text = FileHelper.ReadFileData(smtp.logpath);
                    }
                }
            }
            catch 
            {
               
            }
        }
    }
}
