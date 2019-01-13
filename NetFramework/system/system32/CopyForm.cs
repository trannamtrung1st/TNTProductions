using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using System.Windows.Forms;

namespace system32
{
    public partial class CopyForm : Form
    {
        public CopyForm()
        {
            InitializeComponent();
            TopMost = true; TopLevel = true;
            CheckForIllegalCrossThreadCalls = false;
            SetBounds(-125, 25, 0, Screen.PrimaryScreen.Bounds.Height / 2 - 50);
            MouseEnter += (o, e) =>
            {
                SendKeys.SendWait("^{INS}");
            };
        }
    }
}
