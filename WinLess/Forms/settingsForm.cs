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
        }

        private void saveSettings()
        {
            Program.Settings.StartWithWindows = startWithWindowsCheckBox.Checked;
            Program.Settings.StartMinified = startMinimizedCheckBox.Checked;
            Program.Settings.CheckForLessUpdates = checkForLessUpdatesCheckbox.Checked;
            Program.Settings.DefaultMinify = defaultMinifyCheckBox.Checked;
            Program.Settings.CompileOnSave = compileOnSaveCheckBox.Checked;
            Program.Settings.ShowSuccessMessages = showSuccessMessagesCheckbox.Checked;
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
    }
}
