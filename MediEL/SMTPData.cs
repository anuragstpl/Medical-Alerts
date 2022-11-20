using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediEL
{
    public class ServerData
    {
        public int EmailMasterID { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PortNo { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public bool isActive { get; set; }
        public string logpath { get; set; }

        public string ITDeliveryHost { get; set; }
        public string ITDeliveryEmail { get; set; }
        public string MailMode { get; set; }
        public string ServerIP { get; set; }
    }
}
