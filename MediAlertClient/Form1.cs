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
    public partial class Form1 : Form
    {
        public Form1()
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
            String str = textBox1.Text;
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            lblConnectionStatus.Text = "Transmitting.....";

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                richTextBox1.Text += Convert.ToChar(bb[i]);

            tcpclnt.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
