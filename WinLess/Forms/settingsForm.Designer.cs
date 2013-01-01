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
            this.startMinimizedCheckBox = new System.Windows.Forms.CheckBox();
            this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.compilingGroupBox = new System.Windows.Forms.GroupBox();
            this.showSuccessMessagesCheckbox = new System.Windows.Forms.CheckBox();
            this.compileOnSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.defaultMinifyCheckBox = new System.Windows.Forms.CheckBox();
            this.checkForLessUpdatesCheckbox = new System.Windows.Forms.CheckBox();
            this.generalGroupBox.SuspendLayout();
            this.compilingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 233);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(116, 233);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
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
            this.generalGroupBox.Location = new System.Drawing.Point(13, 13);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Size = new System.Drawing.Size(259, 91);
            this.generalGroupBox.TabIndex = 2;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General";
            // 
            // startMinimizedCheckBox
            // 
            this.startMinimizedCheckBox.AutoSize = true;
            this.startMinimizedCheckBox.Location = new System.Drawing.Point(7, 44);
            this.startMinimizedCheckBox.Name = "startMinimizedCheckBox";
            this.startMinimizedCheckBox.Size = new System.Drawing.Size(96, 17);
            this.startMinimizedCheckBox.TabIndex = 1;
            this.startMinimizedCheckBox.Text = "Start minimized";
            this.startMinimizedCheckBox.UseVisualStyleBackColor = true;
            // 
            // startWithWindowsCheckBox
            // 
            this.startWithWindowsCheckBox.AutoSize = true;
            this.startWithWindowsCheckBox.Location = new System.Drawing.Point(7, 20);
            this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
            this.startWithWindowsCheckBox.Size = new System.Drawing.Size(117, 17);
            this.startWithWindowsCheckBox.TabIndex = 0;
            this.startWithWindowsCheckBox.Text = "Start with Windows";
            this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // compilingGroupBox
            // 
            this.compilingGroupBox.Controls.Add(this.showSuccessMessagesCheckbox);
            this.compilingGroupBox.Controls.Add(this.compileOnSaveCheckBox);
            this.compilingGroupBox.Controls.Add(this.defaultMinifyCheckBox);
            this.compilingGroupBox.Location = new System.Drawing.Point(13, 127);
            this.compilingGroupBox.Name = "compilingGroupBox";
            this.compilingGroupBox.Size = new System.Drawing.Size(259, 100);
            this.compilingGroupBox.TabIndex = 3;
            this.compilingGroupBox.TabStop = false;
            this.compilingGroupBox.Text = "Compiling";
            // 
            // showSuccessMessagesCheckbox
            // 
            this.showSuccessMessagesCheckbox.AutoSize = true;
            this.showSuccessMessagesCheckbox.Location = new System.Drawing.Point(7, 68);
            this.showSuccessMessagesCheckbox.Name = "showSuccessMessagesCheckbox";
            this.showSuccessMessagesCheckbox.Size = new System.Drawing.Size(200, 17);
            this.showSuccessMessagesCheckbox.TabIndex = 2;
            this.showSuccessMessagesCheckbox.Text = "Show message on succesful compile";
            this.showSuccessMessagesCheckbox.UseVisualStyleBackColor = true;
            // 
            // compileOnSaveCheckBox
            // 
            this.compileOnSaveCheckBox.AutoSize = true;
            this.compileOnSaveCheckBox.Location = new System.Drawing.Point(7, 44);
            this.compileOnSaveCheckBox.Name = "compileOnSaveCheckBox";
            this.compileOnSaveCheckBox.Size = new System.Drawing.Size(209, 17);
            this.compileOnSaveCheckBox.TabIndex = 1;
            this.compileOnSaveCheckBox.Text = "Automatically compile files when saved";
            this.compileOnSaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // defaultMinifyCheckBox
            // 
            this.defaultMinifyCheckBox.AutoSize = true;
            this.defaultMinifyCheckBox.Location = new System.Drawing.Point(7, 21);
            this.defaultMinifyCheckBox.Name = "defaultMinifyCheckBox";
            this.defaultMinifyCheckBox.Size = new System.Drawing.Size(102, 17);
            this.defaultMinifyCheckBox.TabIndex = 0;
            this.defaultMinifyCheckBox.Text = "Minify by default";
            this.defaultMinifyCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkForLessUpdatesCheckbox
            // 
            this.checkForLessUpdatesCheckbox.AutoSize = true;
            this.checkForLessUpdatesCheckbox.Location = new System.Drawing.Point(7, 67);
            this.checkForLessUpdatesCheckbox.Name = "checkForLessUpdatesCheckbox";
            this.checkForLessUpdatesCheckbox.Size = new System.Drawing.Size(208, 17);
            this.checkForLessUpdatesCheckbox.TabIndex = 2;
            this.checkForLessUpdatesCheckbox.Text = "Automatically check for less.js updates";
            this.checkForLessUpdatesCheckbox.UseVisualStyleBackColor = true;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 268);
            this.Controls.Add(this.compilingGroupBox);
            this.Controls.Add(this.generalGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}