using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediEL
{
    public class Clients
    {
        //private string ok, alert;

        public string ipadd { get; set; }
        public bool isConnected { get; set; }
        public string ClientName { get; set; }
        public bool Status { get; set; }
        public string OkMessage { get; set; }
        public string AlertMessage { get; set; }
        public string MessageMode { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public string Message { get; set; }
        public string KeyHashCode { get; set; }
        public string ModifierCode { get; set; }
        public string LastHandle { get; set; }

        public string ServerIP { get; set; }

    }
}
