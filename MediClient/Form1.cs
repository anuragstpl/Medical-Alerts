using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using MediEL;
using MediHelper;
using System.IO;

namespace MediClient
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        string filename = "MediText.mdl";
        public static int icoCounter = 0;
        TcpClient tcpclnt = new TcpClient();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x216)
            { // Trap WM_MOVING
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                Screen scr = Screen.FromRectangle(Rectangle.FromLTRB(rc.left, rc.top, rc.right, rc.bottom));
                if (rc.left < scr.WorkingArea.Left) { rc.left = scr.WorkingArea.Left; rc.right = rc.left + this.Width; }
                if (rc.top < scr.WorkingArea.Top) { rc.top = scr.WorkingArea.Top; rc.bottom = rc.top + this.Height; }
                if (rc.right > scr.WorkingArea.Right) { rc.right = scr.WorkingArea.Right; rc.left = rc.right - this.Width; }
                if (rc.bottom > scr.WorkingArea.Bottom) { rc.bottom = scr.WorkingArea.Bottom; rc.top = rc.bottom - this.Height; }
                Marshal.StructureToPtr(rc, m.LParam, false);
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 1315, 1227, 1266, 1255, TOPMOST_FLAGS);
            this.Width = 47;
            Clients clientposition = GetLatestClient();
            if (clientposition.Top != null && clientposition.Left != null)
            {
                this.Top = clientposition.Top;
                this.Left = clientposition.Left;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            RECT rct = new RECT();
            GetWindowRect(Handle, ref rct);
            Clients clientposition = GetLatestClient();
            clientposition.Top = rct.top;
            clientposition.Left = rct.left;
            WriteJsonFile(clientposition);
        }

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences pref = new Preferences();
            pref.Show();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ClientThreadStart));
            t.Start();
            if (icoCounter == 1)
            {
                this.BackgroundImage = Properties.Resources.green;
                icoCounter = 0;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.red;
                icoCounter = 1;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClientThreadStart()
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ServerSelector.ServerIPAddress), 8001));
            }
            catch (SocketException ex)
            {

                MessageBox.Show("Please start server in order to send commands.");
                return;
            }
            Clients clp = GetLatestClient();
            if (clp != null)
            {
                string message = MediHelper.JsonHelper<Clients>.JsonSerializer(clp);
                if (clp.MessageMode == "Alert")
                {
                    clientSocket.Send(Encoding.ASCII.GetBytes(message));
                }
                else
                {
                    clientSocket.Send(Encoding.ASCII.GetBytes(message));
                }

            }
            else
            {
                MessageBox.Show("Please do save complete settings of client.");
            }
            clientSocket.Close();
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

        public bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);

                if (screen.WorkingArea.Contains(formRectangle))
                {
                    return true;
                }
            }

            return false;
        }


      
    }
}
