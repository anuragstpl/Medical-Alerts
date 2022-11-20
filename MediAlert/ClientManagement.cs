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
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediAlert
{
    public partial class ClientManagement : Form
    {
        public ClientManagement()
        {
            InitializeComponent();
        }
        Thread thd;
        private void ClientManagement_Load(object sender, EventArgs e)
        {
            ServerData smtp = GetLatestSMTP();
            if (!String.IsNullOrEmpty(smtp.ServerIP))
            {
                textBox1.Text = smtp.ServerIP;
            }

            BindData();
        }

        public List<Clients> GetLatestClients()
        {
            string clientsfile = "clients.mdl";
            List<Clients> clt = new List<Clients>();
            if (File.Exists(clientsfile))
            {
                string fileData = FileHelper.ReadFileData(clientsfile);
                if (!String.IsNullOrEmpty(fileData))
                {
                    clt = MediHelper.JsonHelper<List<Clients>>.JsonDeserialize(fileData);
                }
            }
            return clt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            dataGridView1.DataSource = null;
            List<Clients> lstClients = GetLatestClients();

            Parallel.ForEach(lstClients, (items) =>
            {
                items.isConnected = NetPing(items.ipadd);
            });

            //foreach (Clients item in lstClients)
            //{
            //    thd = new Thread(() => item.isConnected = NetPing(item.ipadd));
            //    thd.Start();
            //    //item.isConnected = NetPing(item.ipadd);
            //}

            if (lstClients.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "ClientName";
                dataGridView1.Columns[0].HeaderText = "Client Name";
                dataGridView1.Columns[0].DataPropertyName = "ClientName";

                dataGridView1.Columns[1].Name = "ipadd";
                dataGridView1.Columns[1].HeaderText = "IP Address";
                dataGridView1.Columns[1].DataPropertyName = "ipadd";

                dataGridView1.Columns[2].Name = "AlertMessage";
                dataGridView1.Columns[2].HeaderText = "Alert Message";
                dataGridView1.Columns[2].DataPropertyName = "AlertMessage";

                dataGridView1.Columns[3].Name = "OkMessage";
                dataGridView1.Columns[3].HeaderText = "Ok Message";
                dataGridView1.Columns[3].DataPropertyName = "OkMessage";

                dataGridView1.Columns[4].Name = "isConnected";
                dataGridView1.Columns[4].HeaderText = "Connection Status";
                dataGridView1.Columns[4].DataPropertyName = "isConnected";

                dataGridView1.DataSource = lstClients;
            }
        }

        public static bool NetPing(string hostname)
        {
            Ping pingSender = new Ping();
            bool isConnected = false;
            try
            {
                IPAddress address = IPAddress.Parse(hostname.Split(':')[0]);
                PingReply reply = pingSender.Send(address);

                if (reply.Status == IPStatus.Success)
                {
                    isConnected = true;
                }
                else
                {
                    isConnected = false;
                }
            }
            catch
            {
                isConnected = false;
            }
            return isConnected;

        }

        public static bool GetState(string hostname)
        {
            bool isConnected = false;
            try
            {
                //TcpClient client = new TcpClient(hostname.Split(':')[0], Convert.ToInt32(hostname.Split(':')[1]));

                //TcpClient client = new TcpClient(

                IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
                //TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections().Where(x => x.LocalEndPoint.Equals(client.Client.LocalEndPoint) && x.RemoteEndPoint.Equals(client.Client.RemoteEndPoint)).ToArray();
                TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

                if (tcpConnections != null && tcpConnections.Length > 0)
                {
                    TcpState stateOfConnection = tcpConnections.First().State;
                    if (stateOfConnection == TcpState.Established)
                    {
                        isConnected = true;
                    }
                    else
                    {
                        isConnected = false;
                    }

                }
                //client.Close();
            }
            catch
            {
                isConnected = false;
            }
            return isConnected;
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

        string filename = "MediServer.mdl";

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Please enter server ip.");
                return;
            }
            ServerData smtp = new ServerData();
            smtp.ServerIP = textBox1.Text;
            WriteServerIPToFile(smtp);
            IPSelector.IPAddressVal = smtp.ServerIP;
            ToolStripStatusLabel statusStrip = ((ServerMaster)(this.MdiParent)).toolStripStatusLabel1;
            statusStrip.Text = "Your IP is : " + IPSelector.IPAddressVal;
            
        }

       
    }
}
