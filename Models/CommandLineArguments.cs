using System;
using System.Collections.Generic;
using System.Text;
using NDesk.Options;

namespace WinLess.Models
{
    public class CommandLineArguments
    {
        public CommandLineArguments(string[] args)
        {
            HasArguments = args.Length > 0;
            ConsoleExit = false;
            ShowHelp = false;
            Minify = false;
            InitialCompile = false;

            if (HasArguments)
            {
                DirectoryPaths = new List<string>();
                OptionSet optionSet = new OptionSet(){
                    {
                        "d|directory=",
                        "The {DIRECTORY} you want WinLess to watch. Can be used multiple times.",
                        v=> DirectoryPaths.Add(v)
                    },
                    {
                        "m|minify",
                        "Add the 'minify' flag to have minification enabled.",
                        v=> Minify = v != null
                    },
                    {
                        "c|compile",
                        "Add the 'compile' flag to do an initial compile of the LESS files.",
                        v=> InitialCompile = v != null

                    },
                    {
                        "h|help",
                        "Show this message and exit",
                        v=> ShowHelp = v != null
                    }
                };

                //Make sure we have a Console
                if (!AttachConsole(-1))
                {
                    AllocConsole();
                }

                try
                {
                    optionSet.Parse(args);
                }
                catch (OptionException e)
                {
                    Console.WriteLine("\nAn exception occured when try to parse the command line arguments.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try `WinLess.exe -help' for more information.");
                    ConsoleExit = true;
                }

                if (ShowHelp)
                {
                    Console.WriteLine("\nWinless can be used with command line arguments. This can be useful if you create 'startup' scripts for your projects.\n\nWinLess accepts the following arguments:");
                    optionSet.WriteOptionDescriptions(Console.Out);
                    Console.WriteLine("\nExample usage:\nWinLess.exe -d \"C:\\projects\\project1\" -d \"C:\\projects\\project2\" --minify --compile");
                    ConsoleExit = true;
                }
            }
        }

        #region Properties

        public bool HasArguments { get; set; }
        public bool ConsoleExit { get; set; }
        public bool ShowHelp { get; set; }

        public List<string> DirectoryPaths { get; set; }
        public bool Minify { get; set; }
        public bool InitialCompile { get; set; }

        #endregion

        #region Console Dll imports

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);

        #endregion
    }
}
