using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinLess.Models;
using WinLess.Helpers;

namespace WinLess.Less
{
    static class Compiler
    {        
        public static void CompileLessFile(string lessPath, string cssPath, bool minify)
        {
            try
            {
                CompileResult compileResult = ExecuteCompileCommand(lessPath, cssPath, minify);
                mainForm.ActiveOrInActiveMainForm.AddCompileResult(compileResult);
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }

        private static CompileResult ExecuteCompileCommand(string lessPath, string cssPath, bool minify)
        {
            string fileName = string.Format("{0}\\Less\\lessc.cmd", Application.StartupPath);
            string arguments = CreateCompileArguments(lessPath, cssPath, minify);

            CompileResult result = new CompileResult(){
                FullPath = lessPath,
                Time = DateTime.Now
            };
   
            string error = ExecuteCommand(fileName, arguments);          
            if(error.Length > 0){
                if (error.Contains("Microsoft JScript runtime error: Input past end of file")) {
                    result.ResultText = "Error: empty file";    
                }
                else{
                    result.ResultText = error.Replace("ERR", "Error");
                }
            }
            else{
                result.ResultText = "success";
            }

            return result;
        }

        private static string CreateCompileArguments(string lessPath, string cssPath, bool minify)
        {
            string arguments = string.Format("\"{0}\" \"{1}\"", lessPath, cssPath);
            if (minify)
            {
                arguments = string.Format("{0} -compress", arguments);
            }

            return arguments;
        }

        private static string ExecuteCommand(string fileName, string arguments)
        {
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
                    RedirectStandardError = true
                };

                process.Start();

                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                return error;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
