using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            CommandArguments commandLineArguments = new CommandArguments(args);
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
