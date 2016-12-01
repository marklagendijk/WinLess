using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using WinLess.Models;
using WinLess.Helpers;
using Ookii.Dialogs.Wpf;

namespace WinLess
{
    public partial class mainForm : Form
    {
        private static mainForm activeOrInActiveMainForm = null;
        public static mainForm ActiveOrInActiveMainForm
        {
            get
            {
                return activeOrInActiveMainForm;
            }
        }

        private delegate void AddCompileResultDelegate(Models.CompileCommandResult result);
        private bool finishedLoading;
        private VistaFolderBrowserDialog folderBrowserDialog;
        private VistaSaveFileDialog outputFileDialog;

        #region mainForm init and shutdown

        public mainForm()
        {
            try
            {
                finishedLoading = false;
                activeOrInActiveMainForm = this;

                Program.Settings = Settings.LoadSettings();
                Program.Settings.DirectoryList.Initialize();

                InitializeComponent();
                initFilesDataGridViewCheckAllCheckBox();
                foldersListBox.DataSource = Program.Settings.DirectoryList.Directories;
                compileResultsDataGridView.DataSource = new List<Models.CompileCommandResult>();
                folderBrowserDialog = new VistaFolderBrowserDialog();
                outputFileDialog = new VistaSaveFileDialog()
                {
                    AddExtension = true,
                    Filter = "*.css|*.css"
                };
            }
            catch (Exception e)
            {
                ExceptionHandler.LogException(e);
            }
        }

        public void LoadDirectories(CommandArguments args)
        {
            if (args.ClearDirectories)
            {
                Program.Settings.DirectoryList.ClearDirectories();
            }

            //load directories specified in arguments
            foreach (string directoryPath in args.DirectoryPaths)
            {
                if (System.IO.Directory.Exists(directoryPath))
                {
                    Models.Directory directory = Program.Settings.DirectoryList.AddDirectory(directoryPath);

                    foreach (Models.File file in directory.Files)
                    {
                        file.Minify = args.Minify;
                        if (args.InitialCompile)
                        {
                            file.Compile();
                        }
                    }
                }
            }
            foldersListBox_DataChanged();
            SelectDirectory();
            Program.Settings.SaveSettings();
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            if (!this.finishedLoading)
            {
                this.finishedLoading = true;

                if (Program.Settings.StartMinified)
                {
                    MinimizeToTray();
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            CommandArguments commandLineArgs = new CommandArguments(args);
            if (commandLineArgs.HasArguments)
            {
                LoadDirectories(commandLineArgs);
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Settings.SaveSettings();
        }

        #endregion

        #region filesTabPage

        #region foldersListBox

        private void foldersListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Okay
            }
            else
            {
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
            }
        }

        private void foldersListBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fullPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string fullPath in fullPaths)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
                if (directoryInfo.Exists && !foldersListBox.Items.Contains(directoryInfo.FullName))
                {
                    Program.Settings.DirectoryList.AddDirectory(directoryInfo.FullName);
                    foldersListBox_DataChanged();
                    SelectDirectory();
                    Program.Settings.SaveSettings();
                }
            }
        }

        private void foldersListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveDirectory();
            }
        }

        private void foldersListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectDirectory();
        }

        private void foldersListBox_DataChanged()
        {
            ((CurrencyManager)foldersListBox.BindingContext[foldersListBox.DataSource]).Refresh();
            filesDataGridView_DataChanged();
        }

        private void RemoveDirectory()
        {
            if (foldersListBox.SelectedItem != null)
            {
                Program.Settings.DirectoryList.RemoveDirectory((Models.Directory)foldersListBox.SelectedItem);
                foldersListBox_DataChanged();
                filesDataGridView.DataSource = new List<Models.File>();
                filesDataGridView_DataChanged();
                Program.Settings.SaveSettings();
            }
        }


        private void SelectDirectory()
        {
            Models.Directory directory = (Models.Directory)foldersListBox.SelectedItem;
            if (directory != null)
            {
                filesDataGridView.DataSource = directory.Files;
            }
            else
            {
                filesDataGridView.DataSource = new List<Models.File>();
            }

            filesDataGridView_DataChanged();
        }

        #endregion

        #region filesDataGridView

        private void filesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Program.Settings.SaveSettings();
        }

        private void filesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            filesDataGridView_OpenSelectedFile();
        }

        private void filesDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                filesDataGridView.CurrentCell = filesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void initFilesDataGridViewCheckAllCheckBox()
        {
            // add checkbox header
            Rectangle rect = filesDataGridView.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = 10;
            rect.Y = 4;

            CheckBox checkAllFilesCheckbox = new CheckBox();
            checkAllFilesCheckbox.Name = "checkboxHeader";
            checkAllFilesCheckbox.Size = new Size(15, 15);
            checkAllFilesCheckbox.Location = rect.Location;
            checkAllFilesCheckbox.CheckedChanged += new EventHandler(checkAllFilesCheckbox_CheckedChanged);

            filesDataGridView.Controls.Add(checkAllFilesCheckbox);
        }

        private void checkAllFilesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < filesDataGridView.RowCount; i++)
            {
                filesDataGridView[0, i].Value = ((CheckBox)filesDataGridView.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            filesDataGridView.EndEdit();
        }

        private void filesDataGridView_DataChanged()
        {
            List<Models.File> files = (List<Models.File>)filesDataGridView.DataSource;
            files.Sort((x, y) => string.Compare(x.FullPath, y.FullPath));
            ((CurrencyManager)filesDataGridView.BindingContext[filesDataGridView.DataSource]).Refresh();
        }

        private void filesDataGridView_OpenSelectedFile()
        {
            DataGridViewCell cell = filesDataGridView.SelectedCells[0];
            Models.File file = (Models.File)cell.OwningRow.DataBoundItem;
            string filePath;
            if (cell.ColumnIndex == 1)
            {
                filePath = file.FullPath;
            }
            else
            {
                filePath = file.OutputPath;
            }

            if (System.IO.File.Exists(filePath))
            {
                Process process = new Process();
                process.StartInfo.FileName = filePath;
                process.Start();
            }
        }

        private void openFiletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesDataGridView_OpenSelectedFile();
        }

        private void fileOpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = filesDataGridView.SelectedCells[0];
            Models.File file = (Models.File)cell.OwningRow.DataBoundItem;
            string filePath;
            if (cell.ColumnIndex == 1)
            {
                filePath = file.FullPath;
            }
            else
            {
                filePath = file.OutputPath;
            }

            FileInfo fileInfo = new FileInfo(filePath);
            string directoryPath = fileInfo.DirectoryName;

            if (System.IO.Directory.Exists(directoryPath))
            {
                Process process = new Process();
                process.StartInfo.FileName = directoryPath;
                process.Start();
            }
        }

        private void fileSelectOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = filesDataGridView.SelectedCells[0];
            Models.File file = (Models.File)cell.OwningRow.DataBoundItem;
            FileInfo fileInfo = new FileInfo(file.OutputPath);

            outputFileDialog.InitialDirectory = fileInfo.DirectoryName;
            outputFileDialog.FileName = fileInfo.Name;
            if (outputFileDialog.ShowDialog() == true)
            {
                file.OutputPath = outputFileDialog.FileName;
                filesDataGridView_DataChanged();
                Program.Settings.SaveSettings();
            }
        }

        #endregion

        #region Buttons

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == true)
            {
                Program.Settings.DirectoryList.AddDirectory(folderBrowserDialog.SelectedPath);
                foldersListBox_DataChanged();
                Program.Settings.SaveSettings();
            }
        }

        private void removeDirectoryButton_Click(object sender, EventArgs e)
        {
            RemoveDirectory();
        }

        private void refreshDirectoryButton_Click(object sender, EventArgs e)
        {
            if (foldersListBox.SelectedItem != null)
            {
                Models.Directory directory = (Models.Directory)foldersListBox.SelectedItem;
                directory.Refresh();
                SelectDirectory();
                Program.Settings.SaveSettings();
            }
        }

        private void compileSelectedButton_Click(object sender, EventArgs e)
        {
            CompileSelectedFiles();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompileSelectedFiles();
        }

        #endregion

        #endregion

        #region compilerTabPage

        #region compileResultsDataGridView

        public void AddCompileResult(Models.CompileCommandResult result)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AddCompileResultDelegate(AddCompileResult), new object[] { result });
                return;
            }

            if (result.IsSuccess)
            {
                result.ResultText = "success";
            }

            List<Models.CompileCommandResult> compileResults = (List<Models.CompileCommandResult>)compileResultsDataGridView.DataSource;
            compileResults.Insert(0, result);
            compileResultsDataGridView_DataChanged();

            if (result.IsSuccess && Program.Settings.ShowSuccessMessages)
            {
                ShowSuccessNotification("Successful compile", result.ResultText);
            }
            else if (!result.IsSuccess)
            {
                ShowErrorNotification("Compile error", result.ResultText);
            }
        }

        private void compileResultsDataGridView_DataChanged()
        {
            ((CurrencyManager)compileResultsDataGridView.BindingContext[compileResultsDataGridView.DataSource]).Refresh();
        }

        #endregion

        #region Buttons

        private void clearCompileResultsButton_Click(object sender, EventArgs e)
        {
            compileResultsDataGridView.DataSource = new List<Models.CompileCommandResult>();
            compileResultsDataGridView_DataChanged();
        }

        #endregion

        #endregion

        #region notifyIcon

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                RestoreFromTray();
            }
            else
            {
                MinimizeToTray();
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            RestoreFromTray();
            tabControl.SelectTab(compilerTabPage);
        }

        private void MinimizeToTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        public void RestoreFromTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void ShowSuccessNotification(string title, string message)
        {
            notifyIcon.ShowBalloonTip(500, title, message, ToolTipIcon.Info);
        }

        private void ShowErrorNotification(string title, string message)
        {
            notifyIcon.ShowBalloonTip(500, title, message, ToolTipIcon.Error);
        }

        private void notifyIconMenuOpen_Click(object sender, EventArgs e)
        {
            RestoreFromTray();
        }

        private void notifyIconMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region menu

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm form = new settingsForm();
            form.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm form = new aboutForm();
            form.ShowDialog(this);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Compiles a list of selected LESS files
        /// </summary>
        private void CompileSelectedFiles()
        {
            // Retrieve list of files from data grid
            List<Models.File> files = (List<Models.File>)filesDataGridView.DataSource;

            // Compile files one by one
            foreach (Models.File file in files)
            {
                if (file.Enabled)
                {
                    LessCompiler.Compile(file.FullPath, file.OutputPath, file.Minify);
                }
            }
        }

        #endregion
    }
}
