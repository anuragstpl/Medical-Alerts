using MediEL;
using MediHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MediAlert
{
    public partial class ServerMaster : Form
    {
        string filename = "MediServer.mdl";
        public ServerMaster()
        {
            InitializeComponent();
            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientManagement clientConfiguration = new ClientManagement();
            OpenForm(clientConfiguration);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void closeAllChildren()
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void emailManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailConfiguration emailConfiguration = new EmailConfiguration();
            OpenForm(emailConfiguration);
        }

        private void administrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlertManagement alertManagement = new AlertManagement();
            OpenForm(alertManagement);
        }

        private void aboutITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutITDelivery aboutMedi = new AboutITDelivery();
            OpenForm(aboutMedi);
        }

        public static int icoCounter = 0;

        private void ServerMaster_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Hi");
            toolStripStatusLabel1.Text = "Your IP is : " + IPSelector.IPAddressVal;
            if (!File.Exists("logger.mdl"))
            {
                using (var stream = File.Create("logger.mdl")) { }
                ServerData smtp = new ServerData();
                if (String.IsNullOrEmpty(smtp.logpath))
                {
                    smtp = GetLatestSMTP();
                    smtp.logpath = "logger.mdl";
                    LogManager lgm = new LogManager();
                    lgm.WriteJsonFile(smtp);
                    //WriteLogFile(smtp,smtp.logpath);
                }
            }
            if (!File.Exists("clients.mdl"))
            {
                using (var stream = File.Create("clients.mdl")) { }
            }
            ClientManagement clientConfiguration = new ClientManagement();
            OpenForm(clientConfiguration);
            //Form1 frm = new Form1();
            //frm.Hide();
        }

        private void serverListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            OpenForm(frm);
        }

        private void logManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogManager logManager = new LogManager();
            OpenForm(logManager);
        }

        public void OpenForm(Form frm)
        {
            try
            {
                closeAllChildren();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
            catch (Exception ex)
            {
                MediLogger.logError(ex);
            }
        }

        IPAddress ipAd = IPAddress.Parse(IPSelector.IPAddressVal);
        private ArrayList nSockets = new ArrayList();

        public void listenerThread()
        {
            try
            {
                TcpListener tcpListener = new TcpListener(ipAd, 8001);

                tcpListener.Start();
                while (true)
                {
                    Socket handlerSocket = tcpListener.AcceptSocket();
                    if (handlerSocket.Connected)
                    {
                        lock (this)
                        {
                            nSockets.Add(handlerSocket);
                        }
                        ThreadStart thdstHandler = new
                        ThreadStart(handlerThread);
                        Thread thdHandler = new Thread(thdstHandler);
                        thdHandler.Start();
                    }
                }
            }
            catch
            {

            }
        }

        public void handlerThread()
        {
            try
            {
                Socket handlerSocket = (Socket)nSockets[nSockets.Count - 1];
                NetworkStream networkStream = new NetworkStream(handlerSocket);
                int thisRead = 0;
                int blockSize = 1024;
                Byte[] dataByte = new Byte[blockSize];
                string fileData = null;
                lock (this)
                {
                    while (true)
                    {
                        thisRead = networkStream.Read(dataByte, 0, blockSize);
                        fileData = (Encoding.ASCII.GetString(dataByte)).Trim().Replace("\0", String.Empty);
                        Clients clt = MediHelper.JsonHelper<Clients>.JsonDeserialize(fileData);

                        if (String.IsNullOrEmpty(clt.AlertMessage))
                        {
                            clt.AlertMessage = "Under Duress";
                        }
                        if (String.IsNullOrEmpty(clt.OkMessage))
                        {
                            clt.OkMessage = "No longer under Duress";
                        }

                        ServerData smtp = GetLatestSMTP();
                        if (smtp.isActive == true)
                        {
                            try
                            {
                                MediEmailer medEmailer = new MediEmailer();
                                smtp.Sender = smtp.Email;
                                if (clt.MessageMode == "Alert")
                                {
                                    if (smtp.MailMode == "OTHER")
                                    {
                                        medEmailer.sendMail(smtp, clt.AlertMessage);
                                    }
                                    else
                                    {
                                        medEmailer.sendMailWithoutPWD(smtp, clt.AlertMessage);
                                    }
                                }
                                else
                                    if (clt.MessageMode == "Ok")
                                    {
                                        if (smtp.MailMode == "OTHER")
                                        {
                                            medEmailer.sendMail(smtp, clt.OkMessage);
                                        }
                                        else
                                        {
                                            medEmailer.sendMailWithoutPWD(smtp, clt.OkMessage);
                                        }
                                    }
                                    else
                                        if (clt.MessageMode == "Both")
                                        {
                                            if (smtp.MailMode == "OTHER")
                                            {
                                                medEmailer.sendMail(smtp, clt.Message);
                                            }
                                            else
                                            {
                                                medEmailer.sendMailWithoutPWD(smtp, clt.Message);
                                            }

                                        }
                                        else
                                            if (clt.MessageMode == "Status")
                                            {


                                            }
                                            else
                                            {
                                                if (smtp.MailMode == "OTHER")
                                                {
                                                    medEmailer.sendMail(smtp, clt.OkMessage);
                                                }
                                                else
                                                {
                                                    medEmailer.sendMailWithoutPWD(smtp, clt.OkMessage);
                                                }
                                            }
                            }
                            catch
                            {
                                //MessageBox.Show("Some error occured in sending emails.");
                            }
                        }

                        string clientMessage = "";
                        if (String.IsNullOrEmpty(smtp.logpath))
                        {
                            smtp = GetLatestSMTP();
                            smtp.logpath = "logger.mdl";
                            LogManager lgm = new LogManager();
                            lgm.WriteJsonFile(smtp);
                            //WriteLogFile(smtp,smtp.logpath);
                        }

                        if (clt.MessageMode == "Alert")
                        {
                            if (!String.IsNullOrEmpty(smtp.logpath))
                            {
                                FileHelper.WriteFileData(smtp.logpath, DateTime.Now.ToString() + ":" + clt.ClientName + ":" + clt.ipadd + ":" + clt.AlertMessage);
                            }
                            clientMessage = clt.AlertMessage;
                            MessageBox.Show(clt.AlertMessage, clt.ClientName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                        }
                        else
                            if (clt.MessageMode == "Status")
                            {
                                if (!String.IsNullOrEmpty(smtp.logpath))
                                {
                                    FileHelper.WriteFileData(smtp.logpath, DateTime.Now.ToString() + ":" + clt.ClientName + ":" + clt.ipadd + ":" + clt.Message);
                                }
                                notifyIcon1.Visible = true;
                                notifyIcon1.ShowBalloonTip(10, "MediAlert Client Status", clt.Message, ToolTipIcon.Info);
                                if (clt.Message == "Client connected.")
                                {
                                    clt.isConnected = true;
                                }
                                else
                                    if (clt.Message == "Client disconnected.")
                                    {
                                        clt.isConnected = false;
                                    }
                                WriteJsonFile(clt);
                            }
                            else
                                if (clt.MessageMode == "Both")
                                {
                                    if (!String.IsNullOrEmpty(smtp.logpath))
                                    {
                                        FileHelper.WriteFileData(smtp.logpath, DateTime.Now.ToString() + ":" + clt.ClientName + ":" + clt.ipadd + ":" + clt.Message);
                                    }
                                    //clientMessage = clt.AlertMessage + " " + clt.OkMessage;
                                    clientMessage = clt.Message;
                                    //MessageBox.Show(clt.AlertMessage + "\n" + clt.OkMessage, clt.ClientName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                                    MessageBox.Show(clt.Message, clt.ClientName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                                }
                                else
                                    if (clt.MessageMode == "ACK")
                                    {
                                        if (!String.IsNullOrEmpty(smtp.logpath))
                                        {
                                            FileHelper.WriteFileData(smtp.logpath, DateTime.Now.ToString() + ":" + clt.ClientName + ":" + clt.ipadd + ":" + clt.Message);
                                        }
                                        MessageBox.Show(clt.Message, clt.ClientName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(smtp.logpath))
                                        {
                                            FileHelper.WriteFileData(smtp.logpath, DateTime.Now.ToString() + ":" + clt.ClientName + ":" + clt.ipadd + ":" + clt.OkMessage);
                                        }
                                        clientMessage = clt.OkMessage;
                                        MessageBox.Show(clt.OkMessage, clt.ClientName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                                    }
                        //if (clt.MessageMode == "Alert" || clt.MessageMode == "Ok" || clt.MessageMode == "Both")
                        //{
                        if (clt.MessageMode == "ACK")
                        {
                            if (!String.IsNullOrEmpty(smtp.logpath))
                            {
                                FileHelper.WriteFileData(smtp.logpath, DateTime.Now.ToString() + ":" + clt.ClientName + ":" + clt.ipadd + ":" + clt.OkMessage);
                            }
                            List<Clients> cltList = GetLatestClient();
                            foreach (Clients item in cltList)
                            {
                                if (clt.ipadd.Split(':')[0] != item.ipadd.Split(':')[0] && item.ipadd.Split(':')[0] != IPSelector.IPAddressVal)
                                {
                                    //item.ipadd = clt.ipadd.Split(':')[0];
                                    clientMessage = MediHelper.JsonHelper<Clients>.JsonSerializer(clt);
                                    Thread t = new Thread(() => ClientThreadStart(item.ipadd.Split(':')[0], clientMessage));
                                    t.Start();
                                }
                            }
                        }
                        else
                            if (clt.MessageMode != "Status")
                            {
                                List<Clients> cltList = GetLatestClient();
                                foreach (Clients item in cltList)
                                {
                                    if (clt.ipadd.Split(':')[0] != item.ipadd.Split(':')[0] && item.ipadd.Split(':')[0] != IPSelector.IPAddressVal)
                                    {
                                        //item.ipadd = clt.ipadd.Split(':')[0];
                                        if (String.IsNullOrEmpty(clt.AlertMessage))
                                        {
                                            clt.AlertMessage = "Under Duress";
                                        }
                                        if (String.IsNullOrEmpty(clt.OkMessage))
                                        {
                                            clt.OkMessage = "No longer under Duress";
                                        }
                                        clientMessage = MediHelper.JsonHelper<Clients>.JsonSerializer(clt);
                                        Thread t = new Thread(() => ClientThreadStart(item.ipadd.Split(':')[0], clientMessage));
                                        t.Start();
                                    }
                                }
                            }
                        //}

                        break;
                    }
                }
                handlerSocket = null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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

        public List<Clients> GetLatestClient()
        {
            List<Clients> clt = new List<Clients>();
            string fileData = FileHelper.ReadFileData("clients.mdl");
            if (!String.IsNullOrEmpty(fileData))
            {
                clt = MediHelper.JsonHelper<List<Clients>>.JsonDeserialize(fileData);
            }
            else
            {
                clt = null;
            }
            return clt;
        }

        private void ClientThreadStart(string ipadd, string message)
        {

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipadd), 8001));
                //string jsonMessage = JsonHelper<Clients>.JsonSerializer(clt);
                clientSocket.Send(Encoding.ASCII.GetBytes(message));
                clientSocket.Close();
            }
            catch
            {

            }

        }

        public void WriteLogFile(ServerData smtp, string logfile)
        {
            if (File.Exists(logfile))
            {
                string fileData = FileHelper.ReadFileData(logfile);
                string jsondata;
                if (String.IsNullOrEmpty(fileData))
                {
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                else
                {
                    FileHelper.FlushFile(logfile);
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                FileHelper.WriteFileData(logfile, jsondata);
            }
            else
            {
                using (var stream = File.Create(logfile)) { }
                string fileData = FileHelper.ReadFileData(logfile);
                string jsondata;
                if (String.IsNullOrEmpty(fileData))
                {
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                else
                {
                    FileHelper.FlushFile(logfile);
                    jsondata = MediHelper.JsonHelper<ServerData>.JsonSerializer(smtp);
                }
                FileHelper.WriteFileData(logfile, jsondata);

            }
        }

        public void WriteJsonFile(Clients clt)
        {
            List<Clients> cltList = new List<Clients>();
            string clientsfile = "clients.mdl";
            if (File.Exists(clientsfile))
            {
                string fileData = FileHelper.ReadFileData(clientsfile);
                if (!String.IsNullOrEmpty(fileData))
                {
                    cltList = MediHelper.JsonHelper<List<Clients>>.JsonDeserialize(fileData);
                    string jsondata = "";
                    if (cltList.Count > 0)
                    {
                        FileHelper.FlushFile(clientsfile);
                        bool isClientExist = cltList.Any(x => x.ipadd.Split(':')[0] == clt.ipadd.Split(':')[0]);
                        if (!isClientExist)
                        {
                            cltList.Add(clt);
                        }
                        else
                        {
                            cltList.Where(x => x.ipadd.Split(':')[0] == clt.ipadd.Split(':')[0]).FirstOrDefault().isConnected = clt.isConnected;
                            cltList.Where(x => x.ipadd.Split(':')[0] == clt.ipadd.Split(':')[0]).FirstOrDefault().ClientName = clt.ClientName;
                            cltList.Where(x => x.ipadd.Split(':')[0] == clt.ipadd.Split(':')[0]).FirstOrDefault().AlertMessage = clt.AlertMessage;
                            cltList.Where(x => x.ipadd.Split(':')[0] == clt.ipadd.Split(':')[0]).FirstOrDefault().OkMessage = clt.OkMessage;
                        }
                        jsondata = MediHelper.JsonHelper<List<Clients>>.JsonSerializer(cltList);
                    }
                    FileHelper.WriteFileData(clientsfile, jsondata);
                }
                else
                {
                    string jsondata;
                    if (String.IsNullOrEmpty(fileData))
                    {
                        cltList.Add(clt);
                        jsondata = MediHelper.JsonHelper<List<Clients>>.JsonSerializer(cltList);
                    }
                    else
                    {
                        cltList.Add(clt);
                        FileHelper.FlushFile(clientsfile);
                        jsondata = MediHelper.JsonHelper<List<Clients>>.JsonSerializer(cltList);
                    }
                    FileHelper.WriteFileData(clientsfile, jsondata);
                }
            }
            else
            {
                using (var stream = File.Create(clientsfile)) { }
                string fileData = FileHelper.ReadFileData(clientsfile);
                string jsondata;
                if (String.IsNullOrEmpty(fileData))
                {
                    cltList.Add(clt);
                    jsondata = MediHelper.JsonHelper<List<Clients>>.JsonSerializer(cltList);
                }
                else
                {
                    cltList.Add(clt);
                    FileHelper.FlushFile(clientsfile);
                    jsondata = MediHelper.JsonHelper<List<Clients>>.JsonSerializer(cltList);
                }
                FileHelper.WriteFileData(clientsfile, jsondata);

            }
        }
    }
}
