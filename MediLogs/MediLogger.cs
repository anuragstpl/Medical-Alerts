using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediLogs
{
    public class MediLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void LogInfo(string message)
        {
            log.Info(message);
        }



    }
}
