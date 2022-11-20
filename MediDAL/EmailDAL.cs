using MediEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MediDAL
{
    public class EmailDAL
    {
        public bool isEmailSaved(ServerData smtp)
        {
            bool isSaved = false;
            SqlConnection sqc = DBConnecter.OpenDB();
            SqlCommand cmd = new SqlCommand("insert into EmailMaster values(@host,@email,@password,@portno,@sender,@reciever)", sqc);
            cmd.Parameters.Add("@host", smtp.Host);
            cmd.Parameters.Add("@email", smtp.Email);
            cmd.Parameters.Add("@password", smtp.Password);
            cmd.Parameters.Add("@portno", smtp.PortNo);
            cmd.Parameters.Add("@sender", smtp.Sender);
            cmd.Parameters.Add("@reciever", smtp.Reciever);
            int saveCounter = cmd.ExecuteNonQuery();
            if (saveCounter > -1)
            {
                isSaved = true;
            }
            return isSaved;
        }

        public DataSet getSMTPData()
        {
            List<ServerData> smtpData = new List<ServerData>();
            SqlConnection sqc = DBConnecter.OpenDB();
            SqlCommand cmd = new SqlCommand("Select * from EmailMaster", sqc);
            SqlDataAdapter sdra = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sdra.Fill(ds);
            return ds;
        }

        public bool isEmailUpdated(ServerData smtp)
        {
            bool isSaved = false;
            SqlConnection sqc = DBConnecter.OpenDB();
            SqlCommand cmd = new SqlCommand("update EmailMaster set host=@host,email=@email,password=@password,portno=@portno,sender=@sender,reciever=@reciever where EmailMasterID=1", sqc);
            cmd.Parameters.Add("@host", smtp.Host);
            cmd.Parameters.Add("@email", smtp.Email);
            cmd.Parameters.Add("@password", smtp.Password);
            cmd.Parameters.Add("@portno", smtp.PortNo);
            cmd.Parameters.Add("@sender", smtp.Sender);
            cmd.Parameters.Add("@reciever", smtp.Reciever);
            int saveCounter = cmd.ExecuteNonQuery();
            if (saveCounter > -1)
            {
                isSaved = true;
            }
            return isSaved;
        }
    }
}
