namespace WinLess
{
    partial class aboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutForm));
            this.versionGroupBox = new System.Windows.Forms.GroupBox();
            this.lessjsVersionLabel = new System.Windows.Forms.Label();
            this.lessjsLabel = new System.Windows.Forms.Label();
            this.winlessVersionLabel = new System.Windows.Forms.Label();
            this.winlessLabel = new System.Windows.Forms.Label();
            this.creditsGroupBox = new System.Windows.Forms.GroupBox();
            this.graphicalDesignNameLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.graphicalDesignLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.versionGroupBox.SuspendLayout();
            this.creditsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionGroupBox
            // 
            this.versionGroupBox.Controls.Add(this.lessjsVersionLabel);
            this.versionGroupBox.Controls.Add(this.lessjsLabel);
            this.versionGroupBox.Controls.Add(this.winlessVersionLabel);
            this.versionGroupBox.Controls.Add(this.winlessLabel);
            this.versionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.versionGroupBox.Name = "versionGroupBox";
            this.versionGroupBox.Size = new System.Drawing.Size(290, 59);
            this.versionGroupBox.TabIndex = 1;
            this.versionGroupBox.TabStop = false;
            this.versionGroupBox.Text = "Version info";
            // 
            // lessjsVersionLabel
            // 
            this.lessjsVersionLabel.AutoSize = true;
            this.lessjsVersionLabel.Location = new System.Drawing.Point(104, 37);
            this.lessjsVersionLabel.Name = "lessjsVersionLabel";
            this.lessjsVersionLabel.Size = new System.Drawing.Size(41, 13);
            this.lessjsVersionLabel.TabIndex = 3;
            this.lessjsVersionLabel.Text = "version";
            // 
            // lessjsLabel
            // 
            this.lessjsLabel.AutoSize = true;
            this.lessjsLabel.Location = new System.Drawing.Point(7, 37);
            this.lessjsLabel.Name = "lessjsLabel";
            this.lessjsLabel.Size = new System.Drawing.Size(84, 13);
            this.lessjsLabel.TabIndex = 2;
            this.lessjsLabel.Text = "LESS.js version:";
            // 
            // winlessVersionLabel
            // 
            this.winlessVersionLabel.AutoSize = true;
            this.winlessVersionLabel.Location = new System.Drawing.Point(104, 20);
            this.winlessVersionLabel.Name = "winlessVersionLabel";
            this.winlessVersionLabel.Size = new System.Drawing.Size(41, 13);
            this.winlessVersionLabel.TabIndex = 1;
            this.winlessVersionLabel.Text = "version";
            // 
            // winlessLabel
            // 
            this.winlessLabel.AutoSize = true;
            this.winlessLabel.Location = new System.Drawing.Point(7, 20);
            this.winlessLabel.Name = "winlessLabel";
            this.winlessLabel.Size = new System.Drawing.Size(91, 13);
            this.winlessLabel.TabIndex = 0;
            this.winlessLabel.Text = "WinLess version: ";
            // 
            // creditsGroupBox
            // 
            this.creditsGroupBox.Controls.Add(this.graphicalDesignNameLabel);
            this.creditsGroupBox.Controls.Add(this.authorNameLabel);
            this.creditsGroupBox.Controls.Add(this.graphicalDesignLabel);
            this.creditsGroupBox.Controls.Add(this.authorLabel);
            this.creditsGroupBox.Location = new System.Drawing.Point(13, 78);
            this.creditsGroupBox.Name = "creditsGroupBox";
            this.creditsGroupBox.Size = new System.Drawing.Size(289, 66);
            this.creditsGroupBox.TabIndex = 2;
            this.creditsGroupBox.TabStop = false;
            this.creditsGroupBox.Text = "Credits";
            // 
            // graphicalDesignNameLabel
            // 
            this.graphicalDesignNameLabel.AutoSize = true;
            this.graphicalDesignNameLabel.Location = new System.Drawing.Point(103, 37);
            this.graphicalDesignNameLabel.Name = "graphicalDesignNameLabel";
            this.graphicalDesignNameLabel.Size = new System.Drawing.Size(105, 13);
            this.graphicalDesignNameLabel.TabIndex = 3;
            this.graphicalDesignNameLabel.Text = "Elmar Kouwenhoven";
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Location = new System.Drawing.Point(103, 20);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(80, 13);
            this.authorNameLabel.TabIndex = 2;
            this.authorNameLabel.Text = "Mark Lagendijk";
            // 
            // graphicalDesignLabel
            // 
            this.graphicalDesignLabel.AutoSize = true;
            this.graphicalDesignLabel.Location = new System.Drawing.Point(6, 37);
            this.graphicalDesignLabel.Name = "graphicalDesignLabel";
            this.graphicalDesignLabel.Size = new System.Drawing.Size(89, 13);
            this.graphicalDesignLabel.TabIndex = 1;
            this.graphicalDesignLabel.Text = "Graphical design:";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(6, 20);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(41, 13);
            this.authorLabel.TabIndex = 0;
            this.authorLabel.Text = "Author:";
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 154);
            this.Controls.Add(this.creditsGroupBox);
            this.Controls.Add(this.versionGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "aboutForm";
            this.Text = "About";
            this.versionGroupBox.ResumeLayout(false);
            this.versionGroupBox.PerformLayout();
            this.creditsGroupBox.ResumeLayout(false);
            this.creditsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox versionGroupBox;
        private System.Windows.Forms.Label lessjsVersionLabel;
        private System.Windows.Forms.Label lessjsLabel;
        private System.Windows.Forms.Label winlessVersionLabel;
        private System.Windows.Forms.Label winlessLabel;
        private System.Windows.Forms.GroupBox creditsGroupBox;
        private System.Windows.Forms.Label graphicalDesignLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label graphicalDesignNameLabel;
        private System.Windows.Forms.Label authorNameLabel;

    }
}