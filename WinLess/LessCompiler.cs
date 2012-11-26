using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinLess.Models;
using WinLess.Helpers;
using System.Text.RegularExpressions;

namespace WinLess
{
    static class LessCompiler
    {        
        public static void CompileLessFile(string lessPath, string cssPath, bool minify)
        {
            try
            {
                CompileCommandResult compileResult = ExecuteCompileCommand(lessPath, cssPath, minify);
                mainForm.ActiveOrInActiveMainForm.AddCompileResult(compileResult);
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }

        public static string GetVersion()
        {
            string fileName = string.Format("{0}\\node_modules\\.bin\\lessc.cmd", Application.StartupPath);
            string arguments = " -v";
            CommandResult result = ExecuteCommand(fileName, arguments);
            string version = "";
            if (result.IsSuccess){
                Match versionMatch = Regex.Match(result.ResultText, "\\d+(?:\\.\\d+)+");
                if (versionMatch.Groups.Count > 0)
                {
                    version = versionMatch.Groups[0].Value;
                }
            }
            return version;
        }

        private static CompileCommandResult ExecuteCompileCommand(string lessPath, string cssPath, bool minify)
        {
            string fileName = string.Format("{0}\\node_modules\\.bin\\lessc.cmd", Application.StartupPath);
            string arguments = CreateCompileArguments(lessPath, cssPath, minify);

            CompileCommandResult result = new CompileCommandResult(ExecuteCommand(fileName, arguments));
            result.FullPath = lessPath;

            return result;
        }

        private static string CreateCompileArguments(string lessPath, string cssPath, bool minify)
        {
        string arguments = string.Format("\"{0}\" \"{1}\" --no-color", lessPath, cssPath);
            if (minify)
            {
                arguments = string.Format("{0} --yui-compress", arguments);
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
