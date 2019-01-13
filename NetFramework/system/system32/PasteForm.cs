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
using System.Windows.Forms;

namespace system32
{
    public partial class PasteForm : Form
    {
        public PasteForm()
        {
            InitializeComponent();
            TopMost = true; TopLevel = true;
            CheckForIllegalCrossThreadCalls = false;
            SetBounds(-125, 350, 0, Screen.PrimaryScreen.Bounds.Height / 2 - 50);
            MouseEnter += (o, e) =>
            {
                if (Program.ClipboardText != null && !Program.ClipboardText.Equals(""))
                {
                    Clipboard.SetText(Program.ClipboardText);
                    SendKeys.SendWait("+{INS}");
                }
            };
        }

    }
}
