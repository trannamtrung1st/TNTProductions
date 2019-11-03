using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SignalRFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add("http://localhost:8080/");
                string content = "true";
                listener.Start();
                while (!string.IsNullOrWhiteSpace(content))
                {
                    var context = listener.GetContext();
                    var req = context.Request;
                    var res = context.Response;

                    using (var reader = new StreamReader(req.InputStream))
                    {
                        content = reader.ReadToEnd();
                        Console.WriteLine(content);
                    }
                    using (res)
                    {
                        res.StatusCode = 200;
                        var writer = new StreamWriter(res.OutputStream);
                        writer.WriteLine(content);
                        writer.Flush();
                    }
                }
            }
        }
    }
}
