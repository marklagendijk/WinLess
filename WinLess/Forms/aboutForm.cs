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
            lessjsVersionLabel.Text = LessCompiler.GetCurrentCompilerVersion().ToString();
        }

        private string GetApplicationVersion()
        {
            string version = Application.ProductVersion;
            
            // return the ProductVersion without the last '.0'
            return version.Substring(0, version.Length - 2);
        }

        private void aboutForm_Shown(object sender, EventArgs e)
        {
            //Force paint by calling Application.DoEvents();
            Application.DoEvents();

            bool lessCompilerUpdateAvailable = LessCompiler.IsCompilerUpdateAvailable();
            checkingForUpdatesLabel.Visible = false;

            if(lessCompilerUpdateAvailable)
            {
                if (MessageBox.Show(string.Format("WinLess uses the official LESS compiler, less.js, to compile your LESS files.\n\nA new version of less.js is available. Do you want to update less.js from {0} to {1}?", LessCompiler.GetCurrentCompilerVersion(), LessCompiler.GetAvailableCompilerVersion()), "Update LESS compiler?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Show updatingLabel and force repaint by calling Application.DoEvents();
                    updatingLabel.Visible = true;
                    Application.DoEvents();
                    
                    LessCompiler.UpdateCompiler();

                    Version newVersion = LessCompiler.GetCurrentCompilerVersion();
                    lessjsVersionLabel.Text = newVersion.ToString();

                    updatingLabel.Visible = false;

                    MessageBox.Show(string.Format("Succesfully updated less.js to version {0}", newVersion), "LESS compiler update");
                }
            }            
        }

            
    }
}
