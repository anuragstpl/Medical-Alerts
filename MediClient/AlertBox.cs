using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MediClient
{
    public partial class AlertBox : Form
    {
        public AlertBox()
        {
            InitializeComponent();
        }

        public AlertBox(string clientName,string message)
        {
            InitializeComponent();
            this.Text = clientName;
            this.label1.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClientForm clf = new ClientForm();
                Thread t = new Thread(() => clf.ClientThreadStart(MessageType.Acknowledge));
                t.Start();
                this.Close();
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
