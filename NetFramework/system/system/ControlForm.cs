using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace system
{
    public partial class ControlForm : Form
    {
        public ControlForm()
        {
            InitializeComponent();
            TopMost = true; TopLevel = true;
        }

        public new void Show()
        {
            base.Show();
            this.Result.SelectionLength = 0;
        }

        public void SetText(string text)
        {
            this.ResultLabel.Text = text;
            this.Result.Text = text;
            this.Result.Width = this.ResultLabel.Width;
            this.Result.Height = this.ResultLabel.Height + 10;

        }

    }
}
