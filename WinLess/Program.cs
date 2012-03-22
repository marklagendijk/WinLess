using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinLess.Helpers;
using WinLess.Models;

namespace WinLess
{
    static class Program
    {
        private static Settings settings;
        public static Settings Settings
        {
            get
            {
                return settings;
            }
        }

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                CommandLineArguments commandLineArguments = new CommandLineArguments(args);
                
                //if there is a ConsoleExit we don't continue loading
                if (!commandLineArguments.ConsoleExit)
                {
                    //load the settings from the settings.xml file
                    settings = Settings.LoadSettings();

                    //if WinLess was called with arguments
                    if (commandLineArguments.HasArguments)
                    {
                        //clear loaded directories
                        settings.DirectoryList.ClearDirectories();
                        
                        //load directories specified in arguments
                        foreach(string directoryPath in commandLineArguments.DirectoryPaths){
                            Directory directory = settings.DirectoryList.AddDirectory(directoryPath);

                            foreach (File file in directory.Files)
                            {
                                file.Minify = commandLineArguments.Minify;            
                            }
                        }

                        settings.SaveSettings();
                    }

                    settings.DirectoryList.Initialize();

                    //load the mainform
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new mainForm(commandLineArguments.InitialCompile));

                    //save settings on exit
                    settings.SaveSettings();
                }
            }
            //log uncaught expections
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }
    }
}
