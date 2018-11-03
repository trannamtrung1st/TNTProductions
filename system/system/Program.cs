using Hook;
using System;
using System.Collections.Generic;
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
        public static ControlForm ControlForm { get; set; } = new ControlForm();
        [STAThread]
        static void Main(string[] args)
        {
            ProcessProtector.Protect();
            ProcessThread.LoadResource();
            var hook = new UserActivityHook();
            hook.KeyDown += Hook_KeyDown;
            hook.OnMouseActivity += Hook_OnMouseActivity;
            //activate
            ControlForm = new ControlForm();
            ControlForm.Show();
            ControlForm.Close();
            //------------------------
            Application.Run();
        }

        private static double currentOpacity = 0.5;
        private static int Delta { get; set; } = 0;
        private static void Hook_OnMouseActivity(object sender, CustomMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.IsMouseUp)
            {
                SendKeys.Send("^c");
            }
            else if (e.Delta != Delta)
            {
                Delta = e.Delta;
                if (Delta > 0)
                {
                    if (currentOpacity + 0.2 <= 1)
                        currentOpacity += 0.2;
                    else
                        currentOpacity = 1;
                    ControlForm.Opacity = currentOpacity;
                }
                else if (Delta < 0)
                {
                    if (currentOpacity - 0.2 >= 0)
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
            if (key == Keys.Oem4 || key == Keys.Oem6 || key == Keys.Oem5 || key == Keys.Escape)
            {
                ProcessThread.Process(key, e.Shift, e.Control, e.Alt);
            }
            else if (key == Keys.Oem3)
            {
                if (!TextShown)
                {
                    ControlForm = new ControlForm();
                    var p = Cursor.Position;
                    ControlForm.SetDesktopLocation(p.X, p.Y);
                    ControlForm.SetText(CurrentResult);
                    ControlForm.Show();
                }
                else
                {
                    ControlForm.Close();
                }
                TextShown = !TextShown;
            }
            else if (key == Keys.Space && TextShown)
            {
                var currResult = Program.Results.Dequeue();
                Clipboard.SetText(currResult.Value);
                Program.CurrentResult = currResult.Key + ": " + currResult.Value;
                Program.Results.Enqueue(currResult);
                ControlForm.SetText(CurrentResult);
            }
        }


    }
}
