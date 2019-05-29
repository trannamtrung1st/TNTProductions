using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AutoGoogleTranslate
{
    public partial class Main : Form
    {

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message
        private IntPtr _clipboardViewerNext;                // Our variable that will hold the value to identify the next window in the clipboard viewer chain

        public Main()
        {
            Clipboard.Clear();
            _clipboardViewerNext = SetClipboardViewer(this.Handle);      // Adds our form to the chain of clipboard viewers.
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);    // Process the message 
            if (active)
                if (m.Msg == WM_DRAWCLIPBOARD)
                {
                    IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        string text = (string)iData.GetData(DataFormats.Text);      // Clipboard text
                                                                                    // do something with it
                        Process.Start("chrome.exe", "https://translate.google.com/#view=home&op=translate&sl=en&tl=vi&text="
                            + HttpUtility.UrlEncode(text));
                    }
                }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeClipboardChain(this.Handle, _clipboardViewerNext);        // Removes our from the chain of clipboard viewers when the form closes.
        }

        private bool active = true;
        private void btnActive_Click(object sender, EventArgs e)
        {
            if (active)
                this.btnActive.Text = "Start";
            else this.btnActive.Text = "Stop";
            active = !active;
        }
    }
}
