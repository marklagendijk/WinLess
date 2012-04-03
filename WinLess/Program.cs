using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using WinLess.Models;

namespace WinLess
{
    static class Program
    {
        public static Settings Settings { get; set; }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CommandLineArguments commandLineArguments = new CommandLineArguments(args);
            if (!commandLineArguments.ConsoleExit)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SingleInstanceController controller = new SingleInstanceController();
                controller.Run(args);
            }
        }
    }
}
