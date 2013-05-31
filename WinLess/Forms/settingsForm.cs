using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinLess
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            loadSettings();
        }

        private void loadSettings()
        {
            startWithWindowsCheckBox.Checked = Program.Settings.StartWithWindows;
            startMinimizedCheckBox.Checked = Program.Settings.StartMinified;
            checkForLessUpdatesCheckbox.Checked = Program.Settings.CheckForLessUpdates;
            defaultMinifyCheckBox.Checked = Program.Settings.DefaultMinify;
            compileOnSaveCheckBox.Checked = Program.Settings.CompileOnSave;
            showSuccessMessagesCheckbox.Checked = Program.Settings.ShowSuccessMessages;
            AddDebuggInfoCheckBox.Checked = Program.Settings.DefaultDebugInfo;
        }

        private void saveSettings()
        {
            Program.Settings.StartWithWindows = startWithWindowsCheckBox.Checked;
            Program.Settings.StartMinified = startMinimizedCheckBox.Checked;
            Program.Settings.CheckForLessUpdates = checkForLessUpdatesCheckbox.Checked;
            Program.Settings.DefaultMinify = defaultMinifyCheckBox.Checked;
            Program.Settings.CompileOnSave = compileOnSaveCheckBox.Checked;
            Program.Settings.ShowSuccessMessages = showSuccessMessagesCheckbox.Checked;
            Program.Settings.DefaultDebugInfo = AddDebuggInfoCheckBox.Checked;
            Program.Settings.SaveSettings();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void AddDebuggInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultMinifyCheckBox.Checked && AddDebuggInfoCheckBox.Checked)
            {
                MessageBox.Show("You can´t add debug info when minifying. Please uncheck '" + defaultMinifyCheckBox.Text + "'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddDebuggInfoCheckBox.Checked = false;
                return;
            }
        }

        private void defaultMinifyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultMinifyCheckBox.Checked && AddDebuggInfoCheckBox.Checked)
            {
                MessageBox.Show("You can´t minifying and add debug info. Please uncheck '" + AddDebuggInfoCheckBox.Text + "'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddDebuggInfoCheckBox.Checked = false;
                return;
            }
        }      
    }
}
