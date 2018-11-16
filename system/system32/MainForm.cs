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
using System.Windows.Forms;

namespace system32
{
    public partial class MainForm : Form
    {
        static TextForm tF = new TextForm();
        static int currentX = 0;
        public MainForm()
        {
            InitializeComponent();
            TopMost = true; TopLevel = true;
            CheckForIllegalCrossThreadCalls = false;
            SetBounds(0, -30, Screen.PrimaryScreen.Bounds.Width, 0);
            _ClipboardViewerNext = SetClipboardViewer(this.Handle);
            MouseEnter += (o, e) =>
            {
                var p = Cursor.Position;

                currentX = p.X;
                tF.Opacity = 0.1;
                tF.Hide();
                if (Program.Results.Count > 0)
                {
                    var currResult = Program.Results.Dequeue();
                    Program.ClipboardText = currResult.Value;
                    Clipboard.SetText(currResult.Value);
                    Program.CurrentResult = currResult.Key + "\r\n------------------------------\r\n" + currResult.Value;
                    Program.Results.Enqueue(currResult);
                }
                else
                {
                    Program.CurrentResult = "null";
                    Program.ClipboardText = "null";
                    Clipboard.SetText("null");
                }
                tF.SetDesktopLocation(p.X + 30, p.Y + 20);
                tF.SetText(Program.CurrentResult);
                tF.Show();
            };
            MouseLeave += (o, e) =>
            {
                tF.Hide();
            };
            FormClosing += (o, e) =>
            {
                Program.OpenForm();
            };
            MouseMove += (o, e) =>
            {
                var newX = Cursor.Position.X;
                if (newX < 5)
                {
                    Environment.Exit(0);
                }
                if (newX < currentX - 10)
                {
                    if (tF.Opacity > 0)
                        tF.Opacity -= 0.05;
                    else tF.Opacity = 0;
                    currentX = newX;
                }
                else if (newX > currentX + 10)
                {
                    if (tF.Opacity < 0.5)
                        tF.Opacity += 0.05;
                    else tF.Opacity = 0.5;
                    currentX = newX;
                }
            };

            sF = new SearchForm();
            sF.Show();
            cF = new CopyForm();
            cF.Show();
            pF = new PasteForm();
            pF.Show();
        }

        public SearchForm sF;
        public CopyForm cF;
        public PasteForm pF;

        public void CloseSubForm()
        {
            sF.Close();
            cF.Close();
            pF.Close();
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        private IntPtr _ClipboardViewerNext;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    Program.ClipboardText = Clipboard.GetText();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

    }
}
