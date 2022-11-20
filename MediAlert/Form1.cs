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
    public partial class Form1 : Form
    {
        public static int icoCounter = 0;
        //Server Listener
        IPAddress ipAd = IPAddress.Parse("192.168.1.102");
        /* Initializes the Listener */
        TcpListener myList;
        private ArrayList nSockets = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mediAlertTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            mediAlertTrayIcon.BalloonTipText = "Medi Alert running...";
            mediAlertTrayIcon.BalloonTipTitle = "Medialert Notifier";
            mediAlertTrayIcon.ShowBalloonTip(1000);
            mediAlertTrayIcon.Text = "Medi Alert";
            mediAlertTrayIcon.Visible = true;

            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();


            //myList = new TcpListener(ipAd, 8001);
            /* Start Listeneting at the specified port */
            //myList.Start();
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text += text;
            }
        }

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
                        string txt = handlerSocket.RemoteEndPoint.ToString() + " connected.";
                        SetText(txt.ToString());
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
            Socket handlerSocket = (Socket)nSockets[nSockets.Count - 1];
            NetworkStream networkStream = new NetworkStream(handlerSocket);
            int thisRead = 0;
            int blockSize = 1024;
            Byte[] dataByte = new Byte[blockSize];
            lock (this)
            {
                // Only one process can access
                // the same file at any given time
                Stream fileStream = File.OpenWrite("E:\\application.log");
                while (true)
                {
                    //if (networkStream.DataAvailable == true)
                    //{
                        thisRead = networkStream.Read(dataByte, 0, blockSize);
                        fileStream.Write(dataByte, 0, thisRead);
                        if (thisRead == 0) break;
                    //}
                }
                fileStream.Close();
            }
            string txt = "\nFile Written";
            SetText(txt.ToString());
            handlerSocket = null;
        }




        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mediAlertTrayIcon_Click(object sender, EventArgs e)
        {
            if (icoCounter == 1)
            {
                mediAlertTrayIcon.Icon = new System.Drawing.Icon("green.ico");
                icoCounter = 0;
            }
            else
            {
                mediAlertTrayIcon.Icon = new System.Drawing.Icon("red.ico");
                icoCounter = 1;
            }

        }

        private void mediAlertTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void sendLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text += "The server is running at port 8001...";
                richTextBox1.Text += "\nWaiting for a connection.....";

                Socket s = myList.AcceptSocket();
                MessageBox.Show("\nConnection accepted from " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);
                richTextBox1.Text += "\nRecieved...";
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                /* clean up */
                s.Close();
                myList.Stop();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    //static class SocketExtensions
    //{
    //    public static bool IsConnected(this Socket socket)
    //    {
    //        try
    //        {
    //            return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
    //        }
    //        catch (SocketException) { return false; }
    //    }
    //}

}
