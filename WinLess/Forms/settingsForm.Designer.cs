namespace WinLess
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.generalGroupBox = new System.Windows.Forms.GroupBox();
            this.checkForLessUpdatesCheckbox = new System.Windows.Forms.CheckBox();
            this.startMinimizedCheckBox = new System.Windows.Forms.CheckBox();
            this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.compilingGroupBox = new System.Windows.Forms.GroupBox();
            this.compileOnDirectoryChangeCheckBox = new System.Windows.Forms.CheckBox();
            this.showSuccessMessagesCheckbox = new System.Windows.Forms.CheckBox();
            this.compileOnSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.defaultMinifyCheckBox = new System.Windows.Forms.CheckBox();
            this.generalGroupBox.SuspendLayout();
            this.compilingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(262, 313);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(154, 313);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // generalGroupBox
            // 
            this.generalGroupBox.Controls.Add(this.checkForLessUpdatesCheckbox);
            this.generalGroupBox.Controls.Add(this.startMinimizedCheckBox);
            this.generalGroupBox.Controls.Add(this.startWithWindowsCheckBox);
            this.generalGroupBox.Location = new System.Drawing.Point(17, 16);
            this.generalGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.generalGroupBox.Size = new System.Drawing.Size(345, 112);
            this.generalGroupBox.TabIndex = 2;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General";
            // 
            // checkForLessUpdatesCheckbox
            // 
            this.checkForLessUpdatesCheckbox.AutoSize = true;
            this.checkForLessUpdatesCheckbox.Location = new System.Drawing.Point(9, 82);
            this.checkForLessUpdatesCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.checkForLessUpdatesCheckbox.Name = "checkForLessUpdatesCheckbox";
            this.checkForLessUpdatesCheckbox.Size = new System.Drawing.Size(273, 21);
            this.checkForLessUpdatesCheckbox.TabIndex = 2;
            this.checkForLessUpdatesCheckbox.Text = "Automatically check for less.js updates";
            this.checkForLessUpdatesCheckbox.UseVisualStyleBackColor = true;
            // 
            // startMinimizedCheckBox
            // 
            this.startMinimizedCheckBox.AutoSize = true;
            this.startMinimizedCheckBox.Location = new System.Drawing.Point(9, 54);
            this.startMinimizedCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.startMinimizedCheckBox.Name = "startMinimizedCheckBox";
            this.startMinimizedCheckBox.Size = new System.Drawing.Size(126, 21);
            this.startMinimizedCheckBox.TabIndex = 1;
            this.startMinimizedCheckBox.Text = "Start minimized";
            this.startMinimizedCheckBox.UseVisualStyleBackColor = true;
            // 
            // startWithWindowsCheckBox
            // 
            this.startWithWindowsCheckBox.AutoSize = true;
            this.startWithWindowsCheckBox.Location = new System.Drawing.Point(9, 25);
            this.startWithWindowsCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
            this.startWithWindowsCheckBox.Size = new System.Drawing.Size(148, 21);
            this.startWithWindowsCheckBox.TabIndex = 0;
            this.startWithWindowsCheckBox.Text = "Start with Windows";
            this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // compilingGroupBox
            // 
            this.compilingGroupBox.Controls.Add(this.compileOnDirectoryChangeCheckBox);
            this.compilingGroupBox.Controls.Add(this.showSuccessMessagesCheckbox);
            this.compilingGroupBox.Controls.Add(this.compileOnSaveCheckBox);
            this.compilingGroupBox.Controls.Add(this.defaultMinifyCheckBox);
            this.compilingGroupBox.Location = new System.Drawing.Point(17, 156);
            this.compilingGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.compilingGroupBox.Name = "compilingGroupBox";
            this.compilingGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.compilingGroupBox.Size = new System.Drawing.Size(345, 149);
            this.compilingGroupBox.TabIndex = 3;
            this.compilingGroupBox.TabStop = false;
            this.compilingGroupBox.Text = "Compiling";
            // 
            // compileOnDirectoryChangeCheckBox
            // 
            this.compileOnDirectoryChangeCheckBox.AutoSize = true;
            this.compileOnDirectoryChangeCheckBox.Location = new System.Drawing.Point(45, 82);
            this.compileOnDirectoryChangeCheckBox.Name = "compileOnDirectoryChangeCheckBox";
            this.compileOnDirectoryChangeCheckBox.Size = new System.Drawing.Size(237, 21);
            this.compileOnDirectoryChangeCheckBox.TabIndex = 3;
            this.compileOnDirectoryChangeCheckBox.Text = "Compile on any directory change";
            this.compileOnDirectoryChangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // showSuccessMessagesCheckbox
            // 
            this.showSuccessMessagesCheckbox.AutoSize = true;
            this.showSuccessMessagesCheckbox.Location = new System.Drawing.Point(9, 112);
            this.showSuccessMessagesCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.showSuccessMessagesCheckbox.Name = "showSuccessMessagesCheckbox";
            this.showSuccessMessagesCheckbox.Size = new System.Drawing.Size(260, 21);
            this.showSuccessMessagesCheckbox.TabIndex = 2;
            this.showSuccessMessagesCheckbox.Text = "Show message on successful compile";
            this.showSuccessMessagesCheckbox.UseVisualStyleBackColor = true;
            // 
            // compileOnSaveCheckBox
            // 
            this.compileOnSaveCheckBox.AutoSize = true;
            this.compileOnSaveCheckBox.Location = new System.Drawing.Point(9, 54);
            this.compileOnSaveCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.compileOnSaveCheckBox.Name = "compileOnSaveCheckBox";
            this.compileOnSaveCheckBox.Size = new System.Drawing.Size(273, 21);
            this.compileOnSaveCheckBox.TabIndex = 1;
            this.compileOnSaveCheckBox.Text = "Automatically compile files when saved";
            this.compileOnSaveCheckBox.UseVisualStyleBackColor = true;
            this.compileOnSaveCheckBox.CheckedChanged += new System.EventHandler(this.compileOnSaveCheckBox_CheckedChanged);
            // 
            // defaultMinifyCheckBox
            // 
            this.defaultMinifyCheckBox.AutoSize = true;
            this.defaultMinifyCheckBox.Location = new System.Drawing.Point(9, 26);
            this.defaultMinifyCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.defaultMinifyCheckBox.Name = "defaultMinifyCheckBox";
            this.defaultMinifyCheckBox.Size = new System.Drawing.Size(132, 21);
            this.defaultMinifyCheckBox.TabIndex = 0;
            this.defaultMinifyCheckBox.Text = "Minify by default";
            this.defaultMinifyCheckBox.UseVisualStyleBackColor = true;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 354);
            this.Controls.Add(this.compilingGroupBox);
            this.Controls.Add(this.generalGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.generalGroupBox.ResumeLayout(false);
            this.generalGroupBox.PerformLayout();
            this.compilingGroupBox.ResumeLayout(false);
            this.compilingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox generalGroupBox;
        private System.Windows.Forms.CheckBox startMinimizedCheckBox;
        private System.Windows.Forms.CheckBox startWithWindowsCheckBox;
        private System.Windows.Forms.GroupBox compilingGroupBox;
        private System.Windows.Forms.CheckBox defaultMinifyCheckBox;
        private System.Windows.Forms.CheckBox compileOnSaveCheckBox;
        private System.Windows.Forms.CheckBox showSuccessMessagesCheckbox;
        private System.Windows.Forms.CheckBox checkForLessUpdatesCheckbox;
        private System.Windows.Forms.CheckBox compileOnDirectoryChangeCheckBox;
    }
}
