using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace system32
{
    static class Program
    {
        static MainForm Form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Results = new Queue<KeyValuePair<string, string>>();
            ProcessThread.LoadResource();
            KeepOnTop();
            Application.Run();
            Main();
        }

        static void KeepOnTop()
        {
            OpenForm();
            var refresh = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(10000);
                    Form.CloseSubForm();
                    Form.Close();
                    try
                    {
                        var fptExam = FindWindow("FPT-Exam");
                        if (!fptExam.Equals(IntPtr.Zero))
                            ChangeClipboardChain(fptExam, IntPtr.Zero);
                    }
                    catch (Exception)
                    {
                    }
                }
            });
            refresh.Start();
        }

        public static string ClipboardText = "null";
        public static string CurrentResult = "null";
        public static Queue<KeyValuePair<string, string>> Results;
        public static void OpenForm()
        {
            Form = new MainForm();
            Form.Show();

            try
            {
                var fptExam = FindWindow("FPT-Exam");
                if (fptExam.Equals(IntPtr.Zero))
                    SetWindowPos(fptExam, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE);
            }
            catch (Exception) { }
            SetWindowPos(Form.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd,
            int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;

        [DllImport("user32.dll")]
        public static extern int SendMessage(
                 IntPtr hWnd,      // handle to destination window
                 int Msg,       // message
                 IntPtr wParam,  // first message parameter
                 IntPtr lParam   // second message parameter
                 );

        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static IntPtr FindWindow(string caption)
        {
            return FindWindow(String.Empty, caption);
        }

        [DllImport("user32.dll")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
    }
}
