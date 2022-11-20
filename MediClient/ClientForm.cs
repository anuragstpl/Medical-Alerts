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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MediClient
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();
            int id = 0;     // The id of the hotkey. 
            Clients clt = GetLatestClient();
            if (clt != null)
            {
                if (!String.IsNullOrEmpty(clt.ModifierCode) && !String.IsNullOrEmpty(clt.KeyHashCode))
                {
                    clt.LastHandle = RegisterKey(clt.ModifierCode, clt.KeyHashCode).ToString();
                    WriteJsonFile(clt);
                }
            }
        }

        string filename = "MediText.mdl";
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public const UInt32 SWP_NOSIZE = 0x0001;
        public const UInt32 SWP_NOMOVE = 0x0002;
        public const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
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
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);
        const UInt32 WM_CLOSE = 0x0010;

        Thread thread;

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        TcpClient tcpclnt = new TcpClient();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

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

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
                Thread t = new Thread(() => ClientThreadStart(MessageType.Normal));
                t.Start();
                if (icoCounter == 1)
                {
                    pictureBox1.Image = Properties.Resources.green;
                    icoCounter = 0;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.red;
                    icoCounter = 1;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public static int icoCounter = 0;

        private void ClientForm_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 1315, 1227, 1266, 1255, TOPMOST_FLAGS);
            this.Width = 47;
            Clients clientposition = GetLatestClient();
            if (clientposition != null)
            {
                if (clientposition.Top != null && clientposition.Left != null)
                {
                    this.Top = clientposition.Top;
                    this.Left = clientposition.Left;
                }
            }

            Thread t = new Thread(() => ClientThreadStart(MessageType.Connected));
            t.Start();
        }

        private void ClientForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }


            //SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); 
            RECT rct = new RECT();
            GetWindowRect(Handle, ref rct);
            try
            {
                Clients clientposition = GetLatestClient();
                clientposition.Top = rct.top;
                clientposition.Left = rct.left;
                WriteJsonFile(clientposition);
            }
            catch
            {

            }

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

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences pref = new Preferences();
            pref.Show();
        }

        public void ClientThreadStart(MessageType mode)
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
                string message = "";
                if (mode == MessageType.Normal)
                {
                    clp.ipadd = clientSocket.LocalEndPoint.ToString();
                    if (clp.MessageMode == "Both")
                    {
                        if (icoCounter == 1 || icoCounter == 2)
                        {

                            clp.Message = clp.OkMessage;
                        }
                        else
                            if (icoCounter == 0)
                            {
                                clp.Message = clp.AlertMessage;
                            }
                    }
                    message = MediHelper.JsonHelper<Clients>.JsonSerializer(clp);
                    clientSocket.Send(Encoding.ASCII.GetBytes(message));
                }
                else
                    if (mode == MessageType.Connected)
                    {
                        clp.Message = "Client connected.";
                        clp.ipadd = clientSocket.LocalEndPoint.ToString();
                        clp.MessageMode = "Status";
                        message = MediHelper.JsonHelper<Clients>.JsonSerializer(clp);
                        clientSocket.Send(Encoding.ASCII.GetBytes(message));
                    }
                    else
                        if (mode == MessageType.Disconnected)
                        {
                            clp.Message = "Client disconnected.";
                            clp.ipadd = clientSocket.LocalEndPoint.ToString();
                            clp.MessageMode = "Status";
                            message = MediHelper.JsonHelper<Clients>.JsonSerializer(clp);
                            clientSocket.Send(Encoding.ASCII.GetBytes(message));
                        }
                        else
                            if (mode == MessageType.Acknowledge)
                            {
                                clp.Message = clp.ClientName + " Acknowledged.";
                                clp.ipadd = clientSocket.LocalEndPoint.ToString();
                                clp.MessageMode = "ACK";
                                message = MediHelper.JsonHelper<Clients>.JsonSerializer(clp);
                                clientSocket.Send(Encoding.ASCII.GetBytes(message));
                            }

                //if (clp.MessageMode == "Alert")
                //{
                //    clientSocket.Send(Encoding.ASCII.GetBytes(message));
                //}
                //else
                //{
                //    clientSocket.Send(Encoding.ASCII.GetBytes(message));
                //}
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
                if (String.IsNullOrEmpty(clt.AlertMessage))
                {
                    clt.AlertMessage = "Under Duress";
                }
                if (String.IsNullOrEmpty(clt.OkMessage))
                {
                    clt.OkMessage = "No longer under Duress";
                }
            }
            else
            {
                clt = null;
            }
            return clt;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //dragging = true;
            //dragCursorPoint = Cursor.Position;
            //dragFormPoint = this.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                this.Location = new Point(Cursor.Position.X - 0, Cursor.Position.Y - 0);
                this.Update();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => ClientThreadStart(MessageType.Normal));
            t.Start();
            if (icoCounter == 1 || icoCounter == 2)
            {
                pictureBox1.Image = Properties.Resources.green;
                icoCounter = 0;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.red;
                icoCounter = 1;
            }
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread t = new Thread(() => ClientThreadStart(MessageType.Disconnected));
            t.Start();
        }

        private void menu1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Preferences pref = new Preferences();
            pref.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(() => ClientThreadStart(MessageType.Disconnected));
            t.Start();
            Application.Exit();
        }

        IPAddress ipAd = IPAddress.Parse(ServerSelector.IPAddressVal);
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

        static AlertBox alertbox;
        private static Thread workThread;
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
                        if (clt.MessageMode == "Alert")
                        {
                            workThread = new Thread(() => ShowAcknowledge(clt.ClientName, clt.AlertMessage));
                            workThread.Start();
                        }
                        else
                            if (clt.MessageMode == "Both")
                            {
                                workThread = new Thread(() => ShowAcknowledge(clt.ClientName, clt.Message));
                                workThread.Start();
                            }
                            else
                                if (clt.MessageMode == "Status")
                                {
                                    break;
                                }
                            else
                                if (clt.MessageMode == "ACK")
                                {
                                    pictureBox1.Image = Properties.Resources.amber;
                                    icoCounter = 2;
                                    workThread = new Thread(() => CloseAcknowledge());
                                    workThread.Start();
                                }
                                else
                                {
                                    workThread=new Thread(()=> ShowAcknowledge(clt.ClientName, clt.OkMessage));
                                    workThread.Start();
                                }
                        break;
                    }
                }
                handlerSocket = null;
            }
            catch 
            {

            }
        }

        public string RegisterKey(string controlKey, string hashCodeKey)
        {
            int id = 0;     // The id of the hotkey. 
            IntPtr winHandle = this.Handle;
            int keymodifier = 0, keyHashCode = 0;
            switch (controlKey)
            {
                case "Control":
                    keymodifier = (int)KeyModifier.Control;
                    break;
                case "Alt":
                    keymodifier = (int)KeyModifier.Alt;
                    break;
                case "Shift":
                    keymodifier = (int)KeyModifier.Shift;
                    break;
                case "WinKey":
                    keymodifier = (int)KeyModifier.WinKey;
                    break;
                case "None":
                    keymodifier = (int)KeyModifier.None;
                    break;
                default:
                    break;
            }

            switch (hashCodeKey)
            {
                case "A":
                    keyHashCode = Keys.A.GetHashCode();
                    break;
                case "B":
                    keyHashCode = Keys.B.GetHashCode();
                    break;
                case "C":
                    keyHashCode = Keys.C.GetHashCode();
                    break;
                case "D":
                    keyHashCode = Keys.D.GetHashCode();
                    break;
                case "E":
                    keyHashCode = Keys.E.GetHashCode();
                    break;
                case "F":
                    keyHashCode = Keys.F.GetHashCode();
                    break;
                case "G":
                    keyHashCode = Keys.G.GetHashCode();
                    break;
                case "H":
                    keyHashCode = Keys.H.GetHashCode();
                    break;
                case "I":
                    keyHashCode = Keys.I.GetHashCode();
                    break;
                case "J":
                    keyHashCode = Keys.J.GetHashCode();
                    break;
                case "K":
                    keyHashCode = Keys.K.GetHashCode();
                    break;
                case "L":
                    keyHashCode = Keys.L.GetHashCode();
                    break;
                case "M":
                    keyHashCode = Keys.M.GetHashCode();
                    break;
                case "N":
                    keyHashCode = Keys.N.GetHashCode();
                    break;
                case "O":
                    keyHashCode = Keys.O.GetHashCode();
                    break;
                case "P":
                    keyHashCode = Keys.P.GetHashCode();
                    break;
                case "Q":
                    keyHashCode = Keys.Q.GetHashCode();
                    break;
                case "R":
                    keyHashCode = Keys.R.GetHashCode();
                    break;
                case "S":
                    keyHashCode = Keys.S.GetHashCode();
                    break;
                case "T":
                    keyHashCode = Keys.T.GetHashCode();
                    break;
                case "U":
                    keyHashCode = Keys.U.GetHashCode();
                    break;
                case "V":
                    keyHashCode = Keys.V.GetHashCode();
                    break;
                case "W":
                    keyHashCode = Keys.W.GetHashCode();
                    break;
                case "X":
                    keyHashCode = Keys.X.GetHashCode();
                    break;
                case "Y":
                    keyHashCode = Keys.Y.GetHashCode();
                    break;
                case "Z":
                    keyHashCode = Keys.Z.GetHashCode();
                    break;
                case "F1":
                    keyHashCode = Keys.F1.GetHashCode();
                    break;
                case "F2":
                    keyHashCode = Keys.F2.GetHashCode();
                    break;
                case "F3":
                    keyHashCode = Keys.F3.GetHashCode();
                    break;
                case "F4":
                    keyHashCode = Keys.F4.GetHashCode();
                    break;
                case "F5":
                    keyHashCode = Keys.F5.GetHashCode();
                    break;
                case "F6":
                    keyHashCode = Keys.F6.GetHashCode();
                    break;
                case "F7":
                    keyHashCode = Keys.F7.GetHashCode();
                    break;
                case "F8":
                    keyHashCode = Keys.F8.GetHashCode();
                    break;
                case "F9":
                    keyHashCode = Keys.F9.GetHashCode();
                    break;
                case "F10":
                    keyHashCode = Keys.F10.GetHashCode();
                    break;
                case "F11":
                    keyHashCode = Keys.F11.GetHashCode();
                    break;
                case "F12":
                    keyHashCode = Keys.F12.GetHashCode();
                    break;
                default:
                    break;
            }


            RegisterHotKey(winHandle, id, keymodifier, keyHashCode);

            return winHandle.ToString();
        }

        public void UnRegisterKey(IntPtr winHandle)
        {
            UnregisterHotKey(winHandle, 0);
        }

        void CloseMessageBox(string captiontext)
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, captiontext);
            if (hWnd != IntPtr.Zero)
                PostMessage(hWnd, WM_CLOSE, 0, 0);

            if (thread.IsAlive)
                thread.Abort();
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.Control | Keys.F))
        //    {
        //        Thread t = new Thread(() => ClientThreadStart(MessageType.Normal));
        //        t.Start();
        //        if (icoCounter == 1)
        //        {
        //            pictureBox1.Image = Properties.Resources.green;
        //            icoCounter = 0;
        //        }
        //        else
        //        {
        //            pictureBox1.Image = Properties.Resources.red;
        //            icoCounter = 1;
        //        }
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        public void ShowAcknowledge(string clientName,string message)
        {
            alertbox = new AlertBox(clientName, message);
            alertbox.ShowDialog();
        }

        public void CloseAcknowledge()
        {
            try
            {
                if (alertbox.InvokeRequired)
                {
                    alertbox.Invoke(new MethodInvoker(delegate { alertbox.Close(); alertbox.Dispose(); }));

                }
            }
            catch 
            {

            }
        }

    }

    public enum MessageType
    {
        Normal,
        Connected,
        Disconnected,
        Acknowledge
    }
}
