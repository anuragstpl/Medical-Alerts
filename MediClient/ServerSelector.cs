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

namespace MediClient
{
    public partial class ServerSelector : Form
    {
        public ServerSelector()
        {
            InitializeComponent();
        }

        public static string ServerIPAddress = "";
        public static string IPAddressVal = "";

        //protected override void OnShown(EventArgs e)
        //{
            
        //}

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
                Clients clt = GetLatestClient();
                if (!String.IsNullOrEmpty(clt.ServerIP) && !String.IsNullOrEmpty(clt.ipadd))
                {
                    ServerIPAddress = clt.ServerIP;
                    IPAddressVal = clt.ipadd;
                    ClientForm serverMaster = new ClientForm();
                    serverMaster.Show();
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        Hide();
                    }));
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnIPSelector_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && ipbox.SelectedIndex > -1)
            {

                if (checkBox1.Checked == true)
                {
                    Clients clt = new Clients();
                    clt.ServerIP = textBox1.Text;
                    clt.ipadd = ipbox.SelectedItem.ToString();
                    WriteJsonFile(clt);
                }

                ServerIPAddress = textBox1.Text;
                IPAddressVal = ipbox.SelectedItem.ToString();
                this.Hide();
                ClientForm serverMaster = new ClientForm();
                serverMaster.Show();
            }
            else
            {
                MessageBox.Show("Please enter server ip/select client ip.", "Enter Server/Client IP", MessageBoxButtons.OK);
            }
            
        }

        string filename = "MediText.mdl";

        public void WriteJsonFile(Clients clt)
        {
            if (File.Exists(filename))
            {
                string fileData = FileHelper.ReadFileData(filename);
                string jsondata;
                if (String.IsNullOrEmpty(fileData))
                {
                    jsondata = MediHelper.JsonHelper<Clients>.JsonSerializer(clt);
                }
                else
                {
                    FileHelper.FlushFile(filename);
                    jsondata = MediHelper.JsonHelper<Clients>.JsonSerializer(clt);
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
                    jsondata = MediHelper.JsonHelper<Clients>.JsonSerializer(clt);
                }
                else
                {
                    FileHelper.FlushFile(filename);
                    jsondata = MediHelper.JsonHelper<Clients>.JsonSerializer(clt);
                }
                FileHelper.WriteFileData(filename, jsondata);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Clients GetLatestClient()
        {
            Clients clt = new Clients();
            string fileData = FileHelper.ReadFileData(filename);
            if (!String.IsNullOrEmpty(fileData))
            {
                clt = MediHelper.JsonHelper<Clients>.JsonDeserialize(fileData);
                if (String.IsNullOrEmpty(clt.AlertMessage))
                {
                    clt.AlertMessage = "Under Duress";
                }
                if (String.IsNullOrEmpty(clt.OkMessage))
                {
                    clt.OkMessage = "No longer under Duress";
                }
            }
            else
            {
                clt = null;
            }
            return clt;
        }

    }
}
