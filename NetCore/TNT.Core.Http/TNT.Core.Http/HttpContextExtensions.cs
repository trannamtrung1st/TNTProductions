using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.Core.Helpers.DI;

namespace TNT.Core.Http
{
    public static class HttpContextExtensions
    {
        public static async Task<IDictionary<string, string>> ReadAsFormAsync(this HttpRequest stream)
        {
            try
            {
                if (stream.ContentLength == null)
                    return null;
                var bytes = new byte[stream.ContentLength.Value];
                await stream.Body.ReadAsync(bytes);
                var data = Encoding.UTF8.GetString(bytes);
                var parts = data.Split('&');
                var dict = new Dictionary<string, string>();
                foreach (var p in parts)
                {
                    var kvp = p.Split('=');
                    dict[HttpUtility.UrlDecode(kvp[0])] = HttpUtility.UrlDecode(kvp[1]);
                }
                return dict;
            }
            catch (Exception) { return null; }
        }

        public static void Inject(this HttpContext context, object obj)
        {
            var pI = context.RequestServices.GetRequiredService<ServiceInjection>();
            pI.Inject(obj);
        }
    }
}
