using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinLess.Models;
using WinLess.Helpers;
using System.Text.RegularExpressions;
using System.Web;

namespace WinLess
{
    public static class LessCompiler
    {        
        public static void Compile(string lessFile, string cssFile, bool minify, bool addDebugInfo)
        {
            try
            {
                CompileCommandResult compileResult = ExecuteCompileCommand(lessFile, cssFile, minify, addDebugInfo);
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
            ExecuteNodePackageManagerCommand("update less");
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

        private static CommandResult ExecuteNodePackageManagerCommand(string arguments)
        {
            string fileName = string.Format("{0}\\node_modules\\.bin\\npm.cmd", Application.StartupPath);
            return ExecuteCommand(fileName, arguments);
        }

        private static CommandResult ExecuteLessCommand(string arguments)
        {
            string fileName = string.Format("{0}\\node_modules\\.bin\\lessc.cmd", Application.StartupPath);
            return ExecuteCommand(fileName, arguments);
        }

        private static CompileCommandResult ExecuteCompileCommand(string lessFile, string cssFile, bool minify, bool addDebugInfo)
        {
            string arguments = CreateCompileArguments(lessFile, cssFile, minify, addDebugInfo);

            CompileCommandResult result = new CompileCommandResult(ExecuteLessCommand(arguments));
            result.FullPath = lessFile;
           
            return result;
        }

        private static string CreateCompileArguments(string lessFile, string cssFile, bool minify, bool addDebugInfo)
        {
        string arguments = string.Format("\"{0}\" \"{1}\" --no-color", lessFile, cssFile);
            if (minify)
            {
                arguments = string.Format("{0} --yui-compress", arguments);
            }

            if (addDebugInfo)
            {
                arguments = string.Format("{0} --line-numbers=all", arguments);
            }

            return arguments;
        }

        private static CommandResult ExecuteCommand(string fileName, string arguments){
            CommandResult result = new CommandResult();            
            
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();

                process.StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = fileName,
                    Arguments = arguments,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

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
