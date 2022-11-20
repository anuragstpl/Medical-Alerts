using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace MediAlertClient
{
    public partial class LogManagement : Form
    {
        public LogManagement()
        {
            InitializeComponent();
        }

        TcpClient tcpclnt = new TcpClient();

        private void button2_Click(object sender, EventArgs e)
        {

            lblConnectionStatus.Text = "Connecting....";
            tcpclnt.Connect("192.168.1.103", 8001);
            //tcpclnt.Connect("127.0.0.1", 8002);
            lblConnectionStatus.Text = "Connected";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFile.Text = openFileDialog1.FileName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Stream fileStream = File.OpenRead(txtFile.Text);
            // Alocate memory space for the file
            byte[] fileBuffer = new byte[fileStream.Length];
            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);
            // Open a TCP/IP Connection and send the data
            TcpClient clientSocket = new TcpClient("192.168.1.103", 8001);
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Write(fileBuffer, 0, fileBuffer.GetLength(0));
            networkStream.Close();

        }
    }
}
