using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace system32
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            TopMost = true; TopLevel = true;
            CheckForIllegalCrossThreadCalls = false;
            SetBounds(0, Screen.PrimaryScreen.Bounds.Height - 5, Screen.PrimaryScreen.Bounds.Width, 0);
            MouseEnter += (o, e) =>
            {
                ProcessThread.LookupResource();
            };
        }

    }
}
