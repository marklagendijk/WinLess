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
                if (commandLineArguments.HasArguments && commandLineArguments.FilePaths.Count > 0)
                {
                    Program.Settings = Settings.LoadSettings();
                    LoadFiles(commandLineArguments);
                    
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SingleInstanceController controller = new SingleInstanceController();
                controller.Run(args);
            }
        }

        private static void LoadFiles(CommandArguments args)
        {
            //load files specified in arguments and compile these files
            foreach (string filePath in args.FilePaths)
            {
                if (System.IO.File.Exists(filePath))
                {
                    Models.File file = new Models.File(filePath, args.Minify);
                        file.Compile(false);
                }
            }
        }
    }
}
