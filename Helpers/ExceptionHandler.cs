using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinLess.Helpers
{
    static class ExceptionHandler
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        public static void ShowException(string message, Exception exception)
        {
            ShowErrorMessage(String.Format("{0}\n\nException message:\n{1}", message, exception.Message));
        }

        public static void LogErrorMessage(string message)
        {
            try
            {
                string errorFile = string.Format("{0}\\data\\errors.txt", Application.CommonAppDataPath);
                TextWriter writer = File.AppendText(errorFile);
                writer.WriteLine(message);
                writer.Flush();
                writer.Close();
            }
            catch {
                // do nothing
            }
        }

        public static void LogException(Exception exception)
        {
            string errrorMessage = String.Format("{0}\n\tMessage: {1}\n\tSource: {2}\n\tStackTrace: {3}", DateTime.Now, exception.Message, exception.Source, exception.StackTrace);
            LogErrorMessage(errrorMessage);
        }
    }
}
