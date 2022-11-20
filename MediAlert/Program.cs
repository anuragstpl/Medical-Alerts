using SecureApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediAlert
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string abc = @"Software\MediAlert\License";
            Secure scr = new Secure();
            bool logic = scr.Algorithm("123456789", abc);
            if (logic == true)
            Application.Run(new SplashScreen());
        }
    }
}
