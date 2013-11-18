using System;
using System.Collections.Generic;
using System.Text;
using NDesk.Options;

namespace WinLess.Models
{
    public class CommandArguments
    {
        public CommandArguments(string[] args)
        {
            HasArguments = args.Length > 0;
            ConsoleExit = false;
            ShowHelp = false;
            Minify = false;
            InitialCompile = false;
            ClearDirectories = false;

            if (HasArguments)
            {
                DirectoryPaths = new List<string>();
                FilePaths = new List<string>();
                OptionSet optionSet = new OptionSet(){
                    {
                        "d|directory=",
                        "The {DIRECTORY} you want WinLess to watch. Can be used multiple times. Directories are added to the current directory list.",
                        v=> DirectoryPaths.Add(v)
                    },
                    {
                        "f|file=",
                        "The File you want WinLess to compile. Can be used multiple times. Files are added to the current file list.",
                        v=> FilePaths.Add(v)
                    },
                    {
                        "minify",
                        "Add the 'minify' flag to have minification enabled.",
                        v=> Minify = v != null
                    },
                    {
                        "compile",
                        "Add the 'compile' flag to do an initial compile of the LESS files.",
                        v=> InitialCompile = v != null

                    },
                    {
                        "clear",
                        "Add the 'clear' flag to clear the current directory list",
                        v=> ClearDirectories = v != null
                    },
                    {
                        "h|help",
                        "Show this message and exit",
                        v=> ShowHelp = v != null
                    }
                };

                try
                {
                    optionSet.Parse(args);
                }
                catch (OptionException e)
                {
                    //Make sure we have a Console
                    if (!AttachConsole(-1))
                    {
                        AllocConsole();
                    }
                    Console.WriteLine("\nAn exception occured when try to parse the command line arguments.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try `WinLess.exe --help' for more information.");
                    ConsoleExit = true;
                }

                if (ShowHelp)
                {
                    //Make sure we have a Console
                    if (!AttachConsole(-1))
                    {
                        AllocConsole();
                    }
                    Console.WriteLine("\nWinless can be used with command line arguments. This can be useful if you create 'startup' scripts for your projects.\nNote: WinLess is single instance. If WinLess is already running your arguments will be applied to the running instance.\n\nWinLess accepts the following arguments:");
                    optionSet.WriteOptionDescriptions(Console.Out);
                    Console.WriteLine("\nExample usage:\nWinLess.exe -d \"C:\\projects\\project1\" -d \"C:\\projects\\project2\" --minify --compile --clear");
                    ConsoleExit = true;
                }
            }
        }

        #region Properties

        public bool HasArguments { get; set; }
        public bool ConsoleExit { get; set; }
        public bool ShowHelp { get; set; }

        public List<string> DirectoryPaths { get; set; }
        public List<string> FilePaths { get; set; }
        public bool Minify { get; set; }
        public bool InitialCompile { get; set; }
        public bool ClearDirectories { get; set; }

        #endregion

        #region Console Dll imports

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);

        #endregion
    }
}
