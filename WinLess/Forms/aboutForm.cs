using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinLess.Helpers;
using System.Text.RegularExpressions;

namespace WinLess
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
            winlessVersionLabel.Text = GetApplicationVersion();
            lessjsVersionLabel.Text = GetLessJsVersion();
        }

        private string GetApplicationVersion()
        {
            string version = Application.ProductVersion;
            
            // return the ProductVersion without the last '.0'
            return version.Substring(0, version.Length - 2);
        }

        private string GetLessJsVersion()
        {
            string lessFileName = string.Format("{0}\\Less\\less.js", Application.StartupPath);
            
            // read the less.js file
            string lessFileText = null;
            try
            {
                StreamReader streamReader = new StreamReader(lessFileName);
                lessFileText = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }

            // retreive the version number from the text of less.js
            if (!string.IsNullOrEmpty(lessFileText))
            {
                Match versionMatch = Regex.Match(lessFileText, "// LESS - Leaner CSS v(.+)"); 
                if(versionMatch.Groups.Count > 1){
                    return versionMatch.Groups[1].Value;
                }
            }

            return "Error while reading version number.";
        }
    }
}
