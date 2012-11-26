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
            lessjsVersionLabel.Text = LessCompiler.GetVersion();
        }

        private string GetApplicationVersion()
        {
            string version = Application.ProductVersion;
            
            // return the ProductVersion without the last '.0'
            return version.Substring(0, version.Length - 2);
        }
    }
}
