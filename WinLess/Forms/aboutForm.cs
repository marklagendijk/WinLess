using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinLess
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
            winlessVersionLabel.Text = Program.WINLESS_VERSION;
            lessjsVersionLabel.Text = Program.LESS_JS_VERSION;
        }
    }
}
