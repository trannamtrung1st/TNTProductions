using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace system
{
    public class ProcessThread
    {
        private static bool Active = true;
        private static IDictionary<string, string> mappings = new Dictionary<string, string>();
        [STAThread]
        public async static void Process(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            await Task.Run(() =>
            { });
            if (key == Keys.Escape)
            {
                if ((System.Windows.Input.Keyboard.Modifiers
                & System.Windows.Input.ModifierKeys.Control) == System.Windows.Input.ModifierKeys.Control)
                {
                    Application.Exit();
                }
                else
                    Active = !Active;
            }
            else if (Active)
            {
                switch (key)
                {
                    case Keys.Oem4:
                        LookupResource();
                        break;
                    case Keys.Oem6:
                        var text = Clipboard.GetText();
                        Translate(text, "vi", "ja");
                        break;
                    case Keys.Oem5:
                        text = Clipboard.GetText();
                        Translate(text, "ja", "vi");
                        break;
                }
            }
        }

        private static void LookupResource()
        {
            var word = Clipboard.GetText().Trim().ToLower();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            var filter = mappings.Where(kvp => compareInfo.IndexOf(kvp.Key, word, CompareOptions.IgnoreNonSpace) > -1);
            Program.Results.Clear();
            foreach (var kvp in filter)
            {
                Program.Results.Enqueue(kvp);
            }
            if (Program.Results.Count > 0)
            {
                var currResult = Program.Results.Dequeue();
                Clipboard.SetText(currResult.Value);
                Program.CurrentResult = currResult.Key + ": " + currResult.Value;
                Program.Results.Enqueue(currResult);
            }
            else
            {
                Program.CurrentResult = "null";
                Clipboard.SetText("null");
            }
        }

        public static void LoadResource()
        {
            var config = File.ReadAllLines("config.txt");
            var file = config[0];
            var lines = File.ReadAllLines(file);
            foreach (var l in lines)
            {
                var kvp = l.Split('=');
                var val1 = kvp[0].Trim().ToLower();
                var val2 = kvp[1].Trim().ToLower();

                if (!mappings.ContainsKey(val1))
                {
                    mappings[val1] = val2;
                }
                else mappings[val1] += ", " + val2;

                if (!mappings.ContainsKey(val2))
                {
                    mappings[val2] = val1;
                }
                else mappings[val2] += ", " + val1;
            }
        }

        private static void Translate(string word, string fromLanguage, string toLanguage)
        {
            word = HttpUtility.UrlEncode(word);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&hl={fromLanguage}&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&ie=UTF-8&oe=UTF-8&otf=1&ssel=5&tsel=5&kc=5&tk=796364.700137&q=" + word;
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            try
            {
                Program.Results.Clear();
                var result = webClient.DownloadString(url);
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                Program.CurrentResult = "result: " + result;
                Clipboard.SetText(result);
            }
            catch (Exception e)
            {
                Program.CurrentResult = "Error";
                Clipboard.SetText("Error");
            }
        }

    }
}
