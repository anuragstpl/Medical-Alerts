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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        Timer tmr;
        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 5 sec
            tmr.Interval = 5000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 5 sec stop the timer
            tmr.Stop();
            //display mainform
            //ServerMaster mf = new ServerMaster();
            IPSelector mf = new IPSelector();
            mf.Show();
            //hide this form
            this.Hide();
        }
    }
}
