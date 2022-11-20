using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediAlert
{
    public static class MediLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void logError(Exception ex)
        {
            log.Error(ex.Message, ex);
        }

        public static void logInfo(string infoMessage)
        {
            log.Info(infoMessage);
        }

        public static void logWarning(string warningMessage)
        {
            log.Warn(warningMessage);
        }

        public static void logDebug(string message)
        {
            log.Debug(message);
        }

        public static void logFatal(string fatalMessage, Exception ex)
        {
            log.Fatal(ex.Message, ex);
        }
    }
}
