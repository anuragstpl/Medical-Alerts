using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediAlert
{
    public partial class AlertManagement : Form
    {
        public AlertManagement()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAlertMessage.Text))
            {
                alertMessageError.SetError(txtAlertMessage, "Please enter alert message.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOkMessage.Text))
            {
                alertMessageError.SetError(txtOkMessage, "Please enter OK message.");
            }
        }
    }
}
