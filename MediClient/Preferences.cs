using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MediHelper;
using MediEL;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace MediClient
{
    public partial class Preferences : Form
    {
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public static string OkMessage = "";
        public static string AlertMessage = "";
        public static string MessageMode = "";
        string filename = "MediText.mdl";
        public Preferences()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("MyApp", Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("MyApp", false);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOk.Text))
            {
                errorOk.SetError(txtOk, "Please enter Ok Message");
                return;
            }
            if (String.IsNullOrEmpty(txtAlert.Text))
            {
                errorOk.SetError(txtAlert, "Please enter Alert Message");
                return;
            }
            if (radAlert.Checked == true)
            {
                MessageMode = "Alert";
            }
            else
                if (radOk.Checked == true)
                {
                    MessageMode = "Ok";
                }
                else
                    if (radBoth.Checked == true)
                    {
                        MessageMode = "Both";
                    }


            Clients clt = GetLatestClient();
            if (clt != null)
            {
                clt.AlertMessage = txtAlert.Text;
                clt.OkMessage = txtOk.Text;
                clt.MessageMode = MessageMode;
            }
            else
            {
                clt = new Clients();
                clt.AlertMessage = txtAlert.Text;
                clt.OkMessage = txtOk.Text;
                clt.MessageMode = MessageMode;
            }
            WriteJsonFile(clt);
            MessageBox.Show("Settings saved successfully.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            Clients clt = GetLatestClient();
            if (clt != null)
            {
                txtOk.Text = clt.OkMessage;
                txtAlert.Text = clt.AlertMessage;
                txtClientName.Text = clt.ClientName;
                txtCurrentIP.Text = clt.ipadd;
                txtServerIP.Text = clt.ServerIP;
                if (!String.IsNullOrEmpty(clt.ModifierCode))
                {
                    comboBox1.Text = clt.ModifierCode;
                }
                if (!String.IsNullOrEmpty(clt.KeyHashCode))
                {
                    comboBox2.Text = clt.KeyHashCode;
                }
                if (clt.MessageMode == "Alert")
                {
                    radAlert.Checked = true;
                }
                else
                    if (clt.MessageMode == "Ok")
                    {
                        radOk.Checked = true;
                    }
                    else
                        if (clt.MessageMode == "Both")
                        {
                            radBoth.Checked = true;
                        }
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public IntPtr GetWindowHandle(string wName)
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(wName))
                {
                    hWnd = pList.MainWindowHandle;
                }
            }
            return hWnd;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clients clt = GetLatestClient();
            if (clt == null)
            {
                clt = new Clients();
                clt.ClientName = txtClientName.Text;
                WriteJsonFile(clt);
            }
            else
            {
                clt.ClientName = txtClientName.Text;
                WriteJsonFile(clt);
            }
            ClientForm cltr = new ClientForm();
            IntPtr ptrData = new IntPtr(Convert.ToInt32(clt.LastHandle));
            cltr.UnRegisterKey(ptrData);

            string winHandle = cltr.RegisterKey(comboBox1.Text, comboBox2.Text);
            
            clt = GetLatestClient();
            if (clt == null)
            {
                clt = new Clients();
                clt.ModifierCode = comboBox1.Text;
                clt.KeyHashCode = comboBox2.Text;
                clt.LastHandle = winHandle.ToString();
                WriteJsonFile(clt);
            }
            else
            {
                clt.ModifierCode = comboBox1.Text;
                clt.KeyHashCode = comboBox2.Text;
                clt.LastHandle = winHandle.ToString();
                WriteJsonFile(clt);
            }
            MessageBox.Show("Client name saved succesfully.");
        }

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

        public Clients GetLatestClient()
        {
            Clients clt = new Clients();
            string fileData = FileHelper.ReadFileData(filename);
            if (!String.IsNullOrEmpty(fileData))
            {
                clt = MediHelper.JsonHelper<Clients>.JsonDeserialize(fileData);
            }
            else
            {
                clt = null;
            }
            return clt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Clients clt = GetLatestClient();
                clt.ipadd = txtCurrentIP.Text;
                WriteJsonFile(clt);
                ServerSelector.IPAddressVal = clt.ipadd;
                MessageBox.Show("Current client ip updated successfully.");
            }
            catch 
            {
                MessageBox.Show("Some error occured while updating current ip.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Clients clt = GetLatestClient();
                clt.ServerIP = txtServerIP.Text;
                WriteJsonFile(clt);
                ServerSelector.ServerIPAddress = clt.ServerIP;
                MessageBox.Show("Server ip updated successfully.");
            }
            catch 
            {
                MessageBox.Show("Some error occured while updating server ip.");
            }
        }

    }
}
