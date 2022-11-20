using MediEL;
using MediHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace MediAlert
{
    public partial class EmailConfiguration : Form
    {
        public EmailConfiguration()
        {
            InitializeComponent();
        }

        string filename = "MediServer.mdl";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtEmail.Text))
                {
                    errorEmail.SetError(txtEmail, "Please enter email.");
                }
                if (String.IsNullOrEmpty(txtHostName.Text))
                {
                    errorHostName.SetError(txtHostName, "Please enter hostname.");
                }
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    errorPassword.SetError(txtPassword, "Please enter password.");
                }
                if (String.IsNullOrEmpty(txtPortNo.Text))
                {
                    errorPortNo.SetError(txtPortNo, "Please enter port no.");
                }
                ServerData smtp = GetLatestSMTP();
                smtp.Email = txtEmail.Text;
                smtp.Host = txtHostName.Text;
                smtp.Password = txtPassword.Text;
                smtp.PortNo = txtPortNo.Text;
                WriteJsonFile(smtp);
                MessageBox.Show("Mail configuration saved successfully.");
            }
            catch
            {
                MessageBox.Show("Some error occured.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtReciever.Text))
                {
                    errorReciever.SetError(txtReciever, "Please enter reciever emails separated with comma.");
                }
                ServerData smtp = GetLatestSMTP();
                smtp.Reciever = txtReciever.Text;
                WriteJsonFile(smtp);
                MessageBox.Show("Reciever Mails saved successfully.");
            }
            catch
            {
                MessageBox.Show("Some error occured.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtEmailTester.Text))
                {
                    errorMailTester.SetError(txtEmailTester, "Please enter email for testing.");
                }
                MediEmailer medEmailer = new MediEmailer();
                ServerData smtp = GetLatestSMTP();
                smtp.Reciever = txtEmailTester.Text;
                if (smtp.MailMode == "IT")
                {
                    smtp.Sender = smtp.ITDeliveryEmail;
                    medEmailer.sendMailWithoutPWD(smtp, "Test Email.");
                }
                else
                {
                    smtp.Sender = smtp.Email;
                    medEmailer.sendMail(smtp, "Test Email.");
                }
                MessageBox.Show("Mail Sent successfully.");
            }
            catch
            {
                MessageBox.Show("Some error occured.");
            }
        }

        private void EmailConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                ServerData smtp = GetLatestSMTP();
                if (smtp != null)
                {
                    txtHostName.Text = smtp.Host;
                    txtEmail.Text = smtp.Email;
                    txtPassword.Text = smtp.Password;
                    txtPortNo.Text = smtp.PortNo;
                    txtReciever.Text = smtp.Reciever;
                    txtITDeliveryEmail.Text = smtp.ITDeliveryEmail;
                    txtITDeliveryHost.Text = smtp.ITDeliveryHost;
                    chkActiveEmail.CheckedChanged -= chkActiveEmail_CheckedChanged;
                    if (smtp.MailMode == "IT")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                        if (smtp.MailMode == "OTHER")
                        {
                            radioButton1.Checked = false;
                        }
                    if (smtp.isActive)
                    {
                        chkActiveEmail.Checked = true;
                    }
                    else
                    {
                        chkActiveEmail.Checked = false;
                    }
                    chkActiveEmail.CheckedChanged += chkActiveEmail_CheckedChanged;
                }
            }
            catch
            {
                MessageBox.Show("Some error occured.");
            }
        }

        public void WriteJsonFile(ServerData smtp)
        {
            try
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
            catch
            {
                MessageBox.Show("Some error occured.");
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

        private void chkActiveEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActiveEmail.Checked == true)
            {
                ServerData smtp = GetLatestSMTP();
                smtp.isActive = true;
                WriteJsonFile(smtp);
            }
            else
            {
                ServerData smtp = GetLatestSMTP();
                smtp.isActive = false;
                WriteJsonFile(smtp);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnITDeliverySmtp_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtITDeliveryHost.Text))
                {
                    errorITDeliveryHost.SetError(txtITDeliveryHost, "Please enter IT Delivery Host.");
                }
                if (String.IsNullOrEmpty(txtITDeliveryEmail.Text))
                {
                    errorITDeliveryEmail.SetError(txtITDeliveryEmail, "Please enter IT Delivery Email.");
                }

                ServerData smtp = GetLatestSMTP();
                smtp.ITDeliveryEmail = txtITDeliveryEmail.Text;
                smtp.ITDeliveryHost = txtITDeliveryHost.Text;
                WriteJsonFile(smtp);
                MessageBox.Show("Mail configuration saved successfully.");
            }
            catch
            {
                MessageBox.Show("Some error occured.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ServerData smtp = GetLatestSMTP();
                smtp.MailMode = "IT";
                WriteJsonFile(smtp);
            }
            else
            {
                ServerData smtp = GetLatestSMTP();
                smtp.MailMode = "OTHER";
                WriteJsonFile(smtp);
            }
        }
    }
}
