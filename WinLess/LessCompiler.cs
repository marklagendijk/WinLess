using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinLess.Models;
using WinLess.Helpers;
using System.Text.RegularExpressions;

namespace WinLess
{
    public static class LessCompiler
    {        
        public static void Compile(string lessFile, string cssFile, bool minify)
        {
            try
            {
                CompileCommandResult compileResult = ExecuteCompileCommand(lessFile, cssFile, minify);
                mainForm.ActiveOrInActiveMainForm.AddCompileResult(compileResult);
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }

        public static Version GetCurrentCompilerVersion()
        {
            CommandResult result = ExecuteLessCommand("-v");

            return GetVersionFromCommandResult(result);
        }

        public static Version GetAvailableCompilerVersion()
        {
            CommandResult result = ExecuteNodePackageManagerCommand("view less version");

            return GetVersionFromCommandResult(result);
        }

        public static bool IsCompilerUpdateAvailable()
        {
            Version currentVersion = GetCurrentCompilerVersion();
            Version availableVersion = GetAvailableCompilerVersion();

            return (currentVersion.CompareTo(availableVersion) < 0);
        }

        public static void UpdateCompiler()
        {
            ExecuteNodePackageManagerCommand("update less", true);
        }

        private static Version GetVersionFromCommandResult(CommandResult result)
        {
            if (result.IsSuccess)
            {
                Match versionMatch = Regex.Match(result.ResultText, "\\d+(?:\\.\\d+)+");
                if (versionMatch.Groups.Count > 0)
                {
                    return new Version(versionMatch.Groups[0].Value);
                }
            }
            return null;
        }

        private static CommandResult ExecuteNodePackageManagerCommand(string arguments, bool elevated = false)
        {
            string fileName = string.Format("{0}\\node_modules\\.bin\\npm.cmd", Application.StartupPath);
            if (elevated)
            {
				ExecuteElevatedCommand(fileName, arguments);
	            return null;
            }
            else
            {
				return ExecuteCommand(fileName, arguments);  
            }
        }

        private static CommandResult ExecuteLessCommand(string arguments)
        {
            string fileName = string.Format("{0}\\node_modules\\.bin\\lessc.cmd", Application.StartupPath);
            return ExecuteCommand(fileName, arguments);
        }

        private static CompileCommandResult ExecuteCompileCommand(string lessFile, string cssFile, bool minify)
        { 
            string arguments = CreateCompileArguments(lessFile, cssFile, minify);

            CompileCommandResult result = new CompileCommandResult(ExecuteLessCommand(arguments));
            result.FullPath = lessFile;

            return result;
        }

        private static string CreateCompileArguments(string lessFile, string cssFile, bool minify)
        {
        string arguments = string.Format("\"{0}\" \"{1}\" --no-color", lessFile, cssFile);
            if (minify)
            {
                arguments = string.Format("{0} --yui-compress", arguments);
            }

            return arguments;
        }

		private static void ExecuteElevatedCommand(string fileName, string arguments)
		{
			try
			{
				var process = new Process {
					StartInfo = new ProcessStartInfo()
					{
						FileName = fileName,
						Arguments = arguments,
						WindowStyle = ProcessWindowStyle.Hidden,
						CreateNoWindow = true,
						UseShellExecute = false,
						RedirectStandardError = true,
						RedirectStandardOutput = true
					}
				};

				process.Start();
				process.WaitForExit();
			}

			catch (Exception e)
			{
				ExceptionHandler.LogException(e);
			}
		}

        private static CommandResult ExecuteCommand(string fileName, string arguments){
            var result = new CommandResult();            
            
            try
            {
                var startInfo = new ProcessStartInfo()
                {
                    FileName = fileName,
                    Arguments = arguments,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

	            var process = new Process { StartInfo = startInfo };
	            process.Start();

                string error = process.StandardError.ReadToEnd();
                if(error.Length > 0){
                    result.ResultText = error;
                }
                else{
                    result.ResultText = process.StandardOutput.ReadToEnd();
                    result.IsSuccess = true;
                }
                
                process.WaitForExit();
                result.Time = DateTime.Now;

                return result;
            }
            catch (Exception e)
            {
                result.Time = DateTime.Now;
                result.IsSuccess = false;
                result.ResultText = e.Message;
            }

            return result;
        }
    }
}
