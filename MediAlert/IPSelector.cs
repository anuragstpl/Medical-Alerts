using MediEL;
using MediHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MediAlert
{
    public partial class IPSelector : Form
    {
        public IPSelector()
        {
            InitializeComponent();           
        }


        public static string IPAddressVal = "";
        string filename = "MediServer.mdl";
        private void IPSelector_Load(object sender, EventArgs e)
        {
           
            try
            {
               
                IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
                foreach (IPAddress item in IPHost.AddressList)
                {
                    ipbox.Items.Add(item.ToString());
                }
                ipbox.Items.Add("127.0.0.1");
                ServerData smtp = GetLatestSMTP();
                if (!String.IsNullOrEmpty(smtp.ServerIP))
                {
                    IPAddressVal = smtp.ServerIP;
                    ServerMaster serverMaster = new ServerMaster();
                    serverMaster.Show();
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        Hide();
                    }));
                }
            }
            catch (Exception ex)
            {
                MediLogger.logError(ex);
            }
        }

        private void btnIPSelector_Click(object sender, EventArgs e)
        {
            if (ipbox.SelectedIndex > -1)
            {
                if (checkBox1.Checked == true)
                {
                    ServerData smtp = new ServerData();
                    smtp.ServerIP = ipbox.SelectedItem.ToString();
                    WriteServerIPToFile(smtp);
                }
               
                IPAddressVal = ipbox.SelectedItem.ToString();
                ServerMaster serverMaster = new ServerMaster();
                serverMaster.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select one ip to continue.", "Select IP", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Going further without selecting an ip will showcase you the application only.Nothing will be functional.");
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

        public void WriteServerIPToFile(ServerData smtp)
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
    }
}
