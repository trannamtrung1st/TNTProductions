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

namespace system32
{
    public class ProcessThread
    {
        private static IDictionary<string, string> mappings = new Dictionary<string, string>();

        public static void LookupResource()
        {
            var word = Program.ClipboardText.Trim().ToLower();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            var filter = mappings.Where(kvp => compareInfo.IndexOf(kvp.Key, word, CompareOptions.IgnoreNonSpace) > -1);
            Program.Results.Clear();
            foreach (var kvp in filter)
            {
                Program.Results.Enqueue(kvp);
            }
        }

        public static void LoadResource()
        {
            try
            {
                var config = File.ReadAllLines("config.txt");
                foreach (var file in config)
                {
                    var text = File.ReadAllText(file);
                    var parts = text.Split(new[] { "<PASSALL>" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in parts)
                    {
                        var kvp = p.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
                        var val1 = kvp[0].Trim().ToLower();
                        var val2 = kvp[1].Trim().ToLower();

                        if (!mappings.ContainsKey(val1))
                        {
                            mappings[val1] = val2;
                        }
                        else mappings[val1] += "\r\n-----\r\n" + val2;

                        if (!mappings.ContainsKey(val2))
                        {
                            mappings[val2] = val1;
                        }
                        else mappings[val2] += "\r\n-----\r\n" + val1;
                    }
                }
            }
            catch (Exception e)
            {
                File.WriteAllText("log.txt", e.Message);
                throw e;
            }
        }

        private static void Translate(string word, string fromLanguage, string toLanguage)
        {
            //word = HttpUtility.UrlEncode(word);
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
