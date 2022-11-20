using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MediDAL
{
    public static class DBConnecter
    {
        public static SqlConnection OpenDB()
        {
            SqlConnection sqc = new SqlConnection();
            sqc.ConnectionString = ConfigurationManager.ConnectionStrings["MediConnection"].ConnectionString;
            sqc.Open();
            return sqc;
        }
    }
}
