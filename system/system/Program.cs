using Hook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace system
{
    public class Program
    {
        public static bool dispose = false;
        public static int test = 0;
        public static ControlForm ControlForm { get; set; } = new ControlForm();
        public static GlobalKeyboardHook keyBoardHook;
        [STAThread]
        static void Main(string[] args)
        {
            //ProcessProtector.Protect();
            ProcessThread.LoadResource();
            BringOnTop();
            //------------------------
            Application.Run();
            dispose = true;
        }

        private static void KeyBoardHook_KeyboardPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (!TextShown)
            {
                ControlForm = new ControlForm();
                var p = Cursor.Position;
                ControlForm.SetDesktopLocation(p.X, p.Y);
                ControlForm.SetText("OKOKOK" + test++);
                ControlForm.Show();
                try
                {
                    var fptExam = Process.GetProcessesByName("FPT-Exam")[0];
                    SetWindowPos(fptExam.MainWindowHandle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE);
                }
                catch (Exception) { }
                SetWindowPos(ControlForm.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
            }
            else
            {
                ControlForm.Close();
            }
            TextShown = !TextShown;
        }

        private static double currentOpacity = 0.5;
        private static int Delta { get; set; } = 0;
        private static void Hook_OnMouseActivity(object sender, CustomMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.IsMouseUp)
            {
                SendKeys.Send("^c");
            }
            else if (e.Delta != Delta && TextShown)
            {
                Delta = e.Delta;
                if (Delta > 0)
                {
                    if (currentOpacity + 0.2 < 0.5)
                        currentOpacity += 0.2;
                    else
                        currentOpacity = 0.5;
                    ControlForm.Opacity = currentOpacity;
                }
                else if (Delta < 0)
                {
                    if (currentOpacity - 0.2 > 0)
                        currentOpacity -= 0.2;
                    else
                        currentOpacity = 0;
                    ControlForm.Opacity = currentOpacity;
                }
            }
        }

        public static Queue<KeyValuePair<string, string>> Results { get; set; }
            = new Queue<KeyValuePair<string, string>>();
        public static string CurrentResult { get; set; } = "";
        private static bool TextShown = false;
        private static void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (key == Keys.Oem6 || key == Keys.Oem5 || key == Keys.Escape)
            {
                ProcessThread.Process(key, e.Shift, e.Control, e.Alt);
            }
            else if (key == Keys.Oem3)
            {

            }
            else if (key == Keys.LMenu)
            {
                if (TextShown)
                {
                    var currResult = Program.Results.Dequeue();
                    Clipboard.SetText(currResult.Value);
                    Program.CurrentResult = currResult.Key + "\r\n------------------------------\r\n" + currResult.Value;
                    Program.Results.Enqueue(currResult);
                    ControlForm.SetText(CurrentResult);
                }
                else ProcessThread.LookupResource();
            }
        }

        private static void Log(string mess)
        {
            File.AppendAllText("log.txt", mess);
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd,
            int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
        public static void BringOnTop()
        {
            var str = "";
            ControlForm = new ControlForm();
            ControlForm.CheckForIllegalCrossThreadCalls = false;
            ControlForm.Result.GotFocus += (o, e) =>
            {
                test++;
                ControlForm.Result.Focus();
                ControlForm.Result.Text = test.ToString();
            };
            var p = Cursor.Position;
            ControlForm.SetDesktopLocation(p.X, p.Y);
            ControlForm.Result.LostFocus += (o, e) =>
            {
                ControlForm.Close();
                BringOnTop();
            };
            ControlForm.Result.KeyPress += (o, e) =>
            {
                str += "a";
                ControlForm.Result.Text = str;
            };
            ControlForm.Show();
            ControlForm.Result.Focus();
        }

    }
}
