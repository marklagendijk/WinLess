namespace WinLess
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.directoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFiletoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSelectOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.filesTabPage = new System.Windows.Forms.TabPage();
            this.directoryFilesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.foldersListBox = new System.Windows.Forms.ListBox();
            this.filesDataGridView = new System.Windows.Forms.DataGridView();
            this.enabledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fullPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outputPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minifyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.compileSelectedButton = new System.Windows.Forms.Button();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.refreshDirectoryButton = new System.Windows.Forms.Button();
            this.removeDirectoryButton = new System.Windows.Forms.Button();
            this.compilerTabPage = new System.Windows.Forms.TabPage();
            this.clearCompileResultsButton = new System.Windows.Forms.Button();
            this.compileResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compileResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIconMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.outputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.directoryBindingSource)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBindingSource)).BeginInit();
            this.fileContextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.filesTabPage.SuspendLayout();
            this.directoryFilesSplitContainer.Panel1.SuspendLayout();
            this.directoryFilesSplitContainer.Panel2.SuspendLayout();
            this.directoryFilesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).BeginInit();
            this.compilerTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compileResultsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compileResultBindingSource)).BeginInit();
            this.notifyIconContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // directoryBindingSource
            // 
            this.directoryBindingSource.DataSource = typeof(WinLess.Models.Directory);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(849, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(35, 20);
            this.menuItemFile.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileBindingSource
            // 
            this.fileBindingSource.DataSource = typeof(WinLess.Models.File);
            // 
            // fileContextMenuStrip
            // 
            this.fileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFiletoolStripMenuItem,
            this.fileOpenFolderToolStripMenuItem,
            this.fileSelectOutputToolStripMenuItem});
            this.fileContextMenuStrip.Name = "fileContextMenuStrip";
            this.fileContextMenuStrip.Size = new System.Drawing.Size(184, 70);
            // 
            // openFiletoolStripMenuItem
            // 
            this.openFiletoolStripMenuItem.Name = "openFiletoolStripMenuItem";
            this.openFiletoolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openFiletoolStripMenuItem.Text = "Open file";
            this.openFiletoolStripMenuItem.Click += new System.EventHandler(this.openFiletoolStripMenuItem_Click);
            // 
            // fileOpenFolderToolStripMenuItem
            // 
            this.fileOpenFolderToolStripMenuItem.Name = "fileOpenFolderToolStripMenuItem";
            this.fileOpenFolderToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.fileOpenFolderToolStripMenuItem.Text = "Open containing folder";
            this.fileOpenFolderToolStripMenuItem.Click += new System.EventHandler(this.fileOpenFolderToolStripMenuItem_Click);
            // 
            // fileSelectOutputToolStripMenuItem
            // 
            this.fileSelectOutputToolStripMenuItem.Name = "fileSelectOutputToolStripMenuItem";
            this.fileSelectOutputToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.fileSelectOutputToolStripMenuItem.Text = "Select output folder";
            this.fileSelectOutputToolStripMenuItem.Click += new System.EventHandler(this.fileSelectOutputToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.filesTabPage);
            this.tabControl.Controls.Add(this.compilerTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(824, 369);
            this.tabControl.TabIndex = 8;
            // 
            // filesTabPage
            // 
            this.filesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.filesTabPage.Controls.Add(this.directoryFilesSplitContainer);
            this.filesTabPage.Controls.Add(this.compileSelectedButton);
            this.filesTabPage.Controls.Add(this.addDirectoryButton);
            this.filesTabPage.Controls.Add(this.refreshDirectoryButton);
            this.filesTabPage.Controls.Add(this.removeDirectoryButton);
            this.filesTabPage.Location = new System.Drawing.Point(4, 22);
            this.filesTabPage.Name = "filesTabPage";
            this.filesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filesTabPage.Size = new System.Drawing.Size(816, 343);
            this.filesTabPage.TabIndex = 0;
            this.filesTabPage.Text = "Less Files";
            // 
            // directoryFilesSplitContainer
            // 
            this.directoryFilesSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryFilesSplitContainer.Location = new System.Drawing.Point(7, 7);
            this.directoryFilesSplitContainer.Name = "directoryFilesSplitContainer";
            // 
            // directoryFilesSplitContainer.Panel1
            // 
            this.directoryFilesSplitContainer.Panel1.Controls.Add(this.foldersListBox);
            // 
            // directoryFilesSplitContainer.Panel2
            // 
            this.directoryFilesSplitContainer.Panel2.Controls.Add(this.filesDataGridView);
            this.directoryFilesSplitContainer.Size = new System.Drawing.Size(803, 304);
            this.directoryFilesSplitContainer.SplitterDistance = 217;
            this.directoryFilesSplitContainer.TabIndex = 8;
            // 
            // foldersListBox
            // 
            this.foldersListBox.AllowDrop = true;
            this.foldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.foldersListBox.DataSource = this.directoryBindingSource;
            this.foldersListBox.ForeColor = System.Drawing.Color.Black;
            this.foldersListBox.FormattingEnabled = true;
            this.foldersListBox.Location = new System.Drawing.Point(0, 0);
            this.foldersListBox.Name = "foldersListBox";
            this.foldersListBox.Size = new System.Drawing.Size(216, 303);
            this.foldersListBox.TabIndex = 2;
            this.foldersListBox.TabStop = false;
            this.foldersListBox.SelectedValueChanged += new System.EventHandler(this.foldersListBox_SelectedValueChanged);
            this.foldersListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.foldersListBox_DragDrop);
            this.foldersListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.foldersListBox_DragEnter);
            this.foldersListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.foldersListBox_KeyUp);
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.AllowUserToAddRows = false;
            this.filesDataGridView.AllowUserToDeleteRows = false;
            this.filesDataGridView.AllowUserToResizeColumns = false;
            this.filesDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.filesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.filesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filesDataGridView.AutoGenerateColumns = false;
            this.filesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.filesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewTextBoxColumn,
            this.fullPathDataGridViewTextBoxColumn,
            this.outputPathDataGridViewTextBoxColumn,
            this.minifyDataGridViewCheckBoxColumn});
            this.filesDataGridView.DataSource = this.fileBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.filesDataGridView.Location = new System.Drawing.Point(1, 1);
            this.filesDataGridView.MultiSelect = false;
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.RowHeadersVisible = false;
            this.filesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.filesDataGridView.Size = new System.Drawing.Size(581, 303);
            this.filesDataGridView.TabIndex = 5;
            this.filesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filesDataGridView_CellDoubleClick);
            this.filesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.filesDataGridView_CellEndEdit);
            this.filesDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.filesDataGridView_CellMouseDown);
            // 
            // enabledDataGridViewTextBoxColumn
            // 
            this.enabledDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enabledDataGridViewTextBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewTextBoxColumn.HeaderText = "";
            this.enabledDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.enabledDataGridViewTextBoxColumn.Name = "enabledDataGridViewTextBoxColumn";
            this.enabledDataGridViewTextBoxColumn.Width = 30;
            // 
            // fullPathDataGridViewTextBoxColumn
            // 
            this.fullPathDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullPathDataGridViewTextBoxColumn.ContextMenuStrip = this.fileContextMenuStrip;
            this.fullPathDataGridViewTextBoxColumn.DataPropertyName = "RelativePath";
            this.fullPathDataGridViewTextBoxColumn.HeaderText = "File";
            this.fullPathDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.fullPathDataGridViewTextBoxColumn.Name = "fullPathDataGridViewTextBoxColumn";
            this.fullPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullPathDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // outputPathDataGridViewTextBoxColumn
            // 
            this.outputPathDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.outputPathDataGridViewTextBoxColumn.ContextMenuStrip = this.fileContextMenuStrip;
            this.outputPathDataGridViewTextBoxColumn.DataPropertyName = "RelativeOutputPath";
            this.outputPathDataGridViewTextBoxColumn.HeaderText = "Output file";
            this.outputPathDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.outputPathDataGridViewTextBoxColumn.Name = "outputPathDataGridViewTextBoxColumn";
            this.outputPathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // minifyDataGridViewCheckBoxColumn
            // 
            this.minifyDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.minifyDataGridViewCheckBoxColumn.DataPropertyName = "Minify";
            this.minifyDataGridViewCheckBoxColumn.HeaderText = "Minify";
            this.minifyDataGridViewCheckBoxColumn.MinimumWidth = 40;
            this.minifyDataGridViewCheckBoxColumn.Name = "minifyDataGridViewCheckBoxColumn";
            this.minifyDataGridViewCheckBoxColumn.Width = 40;
            // 
            // compileSelectedButton
            // 
            this.compileSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compileSelectedButton.Location = new System.Drawing.Point(712, 315);
            this.compileSelectedButton.Name = "compileSelectedButton";
            this.compileSelectedButton.Size = new System.Drawing.Size(98, 23);
            this.compileSelectedButton.TabIndex = 7;
            this.compileSelectedButton.Text = "Compile";
            this.compileSelectedButton.UseVisualStyleBackColor = true;
            this.compileSelectedButton.Click += new System.EventHandler(this.compileSelectedButton_Click);
            // 
            // addDirectoryButton
            // 
            this.addDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addDirectoryButton.Location = new System.Drawing.Point(6, 315);
            this.addDirectoryButton.Name = "addDirectoryButton";
            this.addDirectoryButton.Size = new System.Drawing.Size(88, 23);
            this.addDirectoryButton.TabIndex = 1;
            this.addDirectoryButton.Text = "Add folder";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Click += new System.EventHandler(this.addDirectoryButton_Click);
            // 
            // refreshDirectoryButton
            // 
            this.refreshDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshDirectoryButton.Location = new System.Drawing.Point(625, 315);
            this.refreshDirectoryButton.Name = "refreshDirectoryButton";
            this.refreshDirectoryButton.Size = new System.Drawing.Size(84, 23);
            this.refreshDirectoryButton.TabIndex = 6;
            this.refreshDirectoryButton.Text = "Refresh folder";
            this.refreshDirectoryButton.UseVisualStyleBackColor = true;
            this.refreshDirectoryButton.Click += new System.EventHandler(this.refreshDirectoryButton_Click);
            // 
            // removeDirectoryButton
            // 
            this.removeDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeDirectoryButton.Location = new System.Drawing.Point(100, 315);
            this.removeDirectoryButton.Name = "removeDirectoryButton";
            this.removeDirectoryButton.Size = new System.Drawing.Size(88, 23);
            this.removeDirectoryButton.TabIndex = 4;
            this.removeDirectoryButton.Text = "Delete folder";
            this.removeDirectoryButton.UseVisualStyleBackColor = true;
            this.removeDirectoryButton.Click += new System.EventHandler(this.removeDirectoryButton_Click);
            // 
            // compilerTabPage
            // 
            this.compilerTabPage.BackColor = System.Drawing.Color.Transparent;
            this.compilerTabPage.Controls.Add(this.clearCompileResultsButton);
            this.compilerTabPage.Controls.Add(this.compileResultsDataGridView);
            this.compilerTabPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compilerTabPage.Location = new System.Drawing.Point(4, 22);
            this.compilerTabPage.Name = "compilerTabPage";
            this.compilerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.compilerTabPage.Size = new System.Drawing.Size(816, 343);
            this.compilerTabPage.TabIndex = 1;
            this.compilerTabPage.Text = "Compiler";
            // 
            // clearCompileResultsButton
            // 
            this.clearCompileResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearCompileResultsButton.Location = new System.Drawing.Point(735, 314);
            this.clearCompileResultsButton.Name = "clearCompileResultsButton";
            this.clearCompileResultsButton.Size = new System.Drawing.Size(75, 23);
            this.clearCompileResultsButton.TabIndex = 1;
            this.clearCompileResultsButton.Text = "Clear";
            this.clearCompileResultsButton.UseVisualStyleBackColor = true;
            this.clearCompileResultsButton.Click += new System.EventHandler(this.clearCompileResultsButton_Click);
            // 
            // compileResultsDataGridView
            // 
            this.compileResultsDataGridView.AllowUserToAddRows = false;
            this.compileResultsDataGridView.AllowUserToDeleteRows = false;
            this.compileResultsDataGridView.AllowUserToResizeColumns = false;
            this.compileResultsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.compileResultsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.compileResultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.compileResultsDataGridView.AutoGenerateColumns = false;
            this.compileResultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.compileResultsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.compileResultsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.compileResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compileResultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeDataGridViewTextBoxColumn,
            this.fileDataGridViewTextBoxColumn,
            this.resultTextDataGridViewTextBoxColumn});
            this.compileResultsDataGridView.DataSource = this.compileResultBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.compileResultsDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.compileResultsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.compileResultsDataGridView.MultiSelect = false;
            this.compileResultsDataGridView.Name = "compileResultsDataGridView";
            this.compileResultsDataGridView.ReadOnly = true;
            this.compileResultsDataGridView.RowHeadersVisible = false;
            this.compileResultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.compileResultsDataGridView.ShowEditingIcon = false;
            this.compileResultsDataGridView.Size = new System.Drawing.Size(804, 302);
            this.compileResultsDataGridView.TabIndex = 0;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "TimeString";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeDataGridViewTextBoxColumn.Width = 55;
            // 
            // fileDataGridViewTextBoxColumn
            // 
            this.fileDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fileDataGridViewTextBoxColumn.DataPropertyName = "FullPath";
            this.fileDataGridViewTextBoxColumn.HeaderText = "File";
            this.fileDataGridViewTextBoxColumn.Name = "fileDataGridViewTextBoxColumn";
            this.fileDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileDataGridViewTextBoxColumn.Width = 48;
            // 
            // resultTextDataGridViewTextBoxColumn
            // 
            this.resultTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resultTextDataGridViewTextBoxColumn.DataPropertyName = "ResultText";
            this.resultTextDataGridViewTextBoxColumn.HeaderText = "Compiler Result";
            this.resultTextDataGridViewTextBoxColumn.Name = "resultTextDataGridViewTextBoxColumn";
            this.resultTextDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compileResultBindingSource
            // 
            this.compileResultBindingSource.DataSource = typeof(WinLess.Models.CompileResult);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WinLess";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyIconMenuOpen,
            this.compileToolStripMenuItem,
            this.notifyIconMenuExit});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // notifyIconMenuOpen
            // 
            this.notifyIconMenuOpen.Name = "notifyIconMenuOpen";
            this.notifyIconMenuOpen.Size = new System.Drawing.Size(152, 22);
            this.notifyIconMenuOpen.Text = "Open";
            this.notifyIconMenuOpen.Click += new System.EventHandler(this.notifyIconMenuOpen_Click);
            // 
            // notifyIconMenuExit
            // 
            this.notifyIconMenuExit.Name = "notifyIconMenuExit";
            this.notifyIconMenuExit.Size = new System.Drawing.Size(152, 22);
            this.notifyIconMenuExit.Text = "Exit";
            this.notifyIconMenuExit.Click += new System.EventHandler(this.notifyIconMenuExit_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(0, 402);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(849, 100);
            this.logoPictureBox.TabIndex = 9;
            this.logoPictureBox.TabStop = false;
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 502);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.logoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "mainForm";
            this.Text = "WinLess - Windows GUI for less.js";
            this.Activated += new System.EventHandler(this.mainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.directoryBindingSource)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBindingSource)).EndInit();
            this.fileContextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.filesTabPage.ResumeLayout(false);
            this.directoryFilesSplitContainer.Panel1.ResumeLayout(false);
            this.directoryFilesSplitContainer.Panel2.ResumeLayout(false);
            this.directoryFilesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).EndInit();
            this.compilerTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compileResultsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compileResultBindingSource)).EndInit();
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.BindingSource fileBindingSource;
        private System.Windows.Forms.BindingSource directoryBindingSource;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage compilerTabPage;
        private System.Windows.Forms.DataGridView compileResultsDataGridView;
        private System.Windows.Forms.BindingSource compileResultBindingSource;
        private System.Windows.Forms.Button clearCompileResultsButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip fileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileSelectOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFiletoolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog outputFolderBrowserDialog;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem notifyIconMenuExit;
        private System.Windows.Forms.ToolStripMenuItem notifyIconMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage filesTabPage;
        private System.Windows.Forms.SplitContainer directoryFilesSplitContainer;
        private System.Windows.Forms.ListBox foldersListBox;
        private System.Windows.Forms.DataGridView filesDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outputPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn minifyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button compileSelectedButton;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.Button refreshDirectoryButton;
        private System.Windows.Forms.Button removeDirectoryButton;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
    }
}

