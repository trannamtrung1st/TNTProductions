using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TNT.Core.Hooker
{
    public class HttpHookerOptions
    {
        public IEnumerable<string> HookPathsPattern { get; set; }
        public IEnumerable<string> NotHookPathsPattern { get; set; }
        private IEnumerable<string> _hookMethods;
        public IEnumerable<string> HookMethods
        {
            get
            {
                return _hookMethods;
            }
            set
            {
                if (value != null)
                    value = value.Select(s => s?.ToLower());
                _hookMethods = value;
            }
        }
        private IEnumerable<string> _notHookMethods;
        public IEnumerable<string> NotHookMethods
        {
            get
            {
                return _notHookMethods;
            }
            set
            {
                if (value != null)
                    value = value.Select(s => s?.ToLower());
                _notHookMethods = value;
            }
        }

        public bool HookUser { get; set; } = false;
        public bool HookRequest { get; set; } = true;
        public bool HookResponse { get; set; } = false;

        public Func<UserInfo, RequestInfo, ResponseInfo, Task> Process { get; set; }
    }

    public static class Extensions
    {
        public static bool ContainsIgnoreCase(this IEnumerable<string> list, string value)
        {
            return list.Select(s => s?.ToLower()).Contains(value.ToLower());
        }

        public static IApplicationBuilder UseHttpHooker(this IApplicationBuilder app, HttpHookerOptions options)
        {
            //check options;

            return app.Use(async (context, next) =>
            {
                var req = context.Request;
                var method = req.Method;
                var path = req.Path.HasValue ? req.Path.Value : null;

                #region Filter
                if (path != null)
                {
                    if (options.HookPathsPattern != null &&
                        !options.HookPathsPattern.Any(pattern => Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase)))
                    {
                        await next();
                        return;
                    }
                    if (options.NotHookPathsPattern != null &&
                        options.NotHookPathsPattern.Any(pattern => Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase)))
                    {
                        await next();
                        return;
                    }

                }
                if (options.HookMethods != null && !options.HookMethods.Contains(method.ToLower()))
                {
                    await next();
                    return;
                }
                if (options.NotHookMethods != null && options.NotHookMethods.Contains(method.ToLower()))
                {
                    await next();
                    return;
                }
                #endregion

                UserInfo user = options.HookUser ? UserInfo.From(context.User) : null;
                RequestInfo request = options.HookRequest ? await RequestInfo.From(req) : null;
                var originalBodyStream = context.Response.Body;
                ResponseInfo response = null;
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;
                    await next();
                    response = options.HookResponse ? await ResponseInfo.From(context.Response) : null;
                    if (options.Process != null)
                        await options.Process(user, request, response);
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            });
        }
    }

    public class UserInfo
    {
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }

        private UserInfo()
        {
        }

        public static UserInfo From(ClaimsPrincipal claimsPrincipal)
        {
            var uInfo = new UserInfo();
            var i = claimsPrincipal.Identity;
            uInfo.AuthenticationType = i.AuthenticationType;
            uInfo.IsAuthenticated = i.IsAuthenticated;
            uInfo.Name = i.Name;
            return uInfo;
        }
    }

    public class RequestInfo
    {
        public string QueryString { get; set; }
        public string ContentType { get; set; }
        public IDictionary<string, StringValues> Headers { get; set; }
        public string Protocol { get; set; }
        public IDictionary<string, StringValues> Query { get; set; }
        public string Path { get; set; }
        public string PathBase { get; set; }
        public string Host { get; set; }
        public bool IsHttps { get; set; }
        public string Scheme { get; set; }
        public string Method { get; set; }

        public long? ContentLength { get; set; }
        public byte[] RawBody { get; set; }
        public string ReadableBody { get; set; }
        public IFormCollection Form { get; set; }

        private RequestInfo()
        {
        }

        public static async Task<RequestInfo> From(HttpRequest request)
        {
            var rInfo = new RequestInfo();

            rInfo.QueryString = request.QueryString.HasValue ? request.QueryString.Value : null;
            rInfo.Query = new Dictionary<string, StringValues>(request.Query.ToList());
            rInfo.ContentType = request.ContentType;
            rInfo.Path = request.Path;
            rInfo.PathBase = request.PathBase;
            rInfo.Protocol = request.Protocol;
            rInfo.Headers = request.Headers;
            rInfo.Host = request.Host.Host + ":" + request.Host.Port;
            rInfo.IsHttps = request.IsHttps;
            rInfo.Scheme = request.Scheme;
            rInfo.Method = request.Method;

            var body = request.Body;
            request.EnableRewind();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;

            rInfo.RawBody = buffer;
            rInfo.ReadableBody = bodyAsText;
            rInfo.ContentLength = request.ContentLength;
            rInfo.Form = request.HasFormContentType ? request.Form : null;
            return rInfo;
        }

    }

    public class ResponseInfo
    {
        public int StatusCode { get; set; }
        public string Body { get; set; }
        public string ContentType { get; set; }
        public long? ContentLength { get; set; }
        public IDictionary<string, StringValues> Headers { get; set; }

        public async static Task<ResponseInfo> From(HttpResponse response)
        {
            var rInfo = new ResponseInfo();
            rInfo.StatusCode = response.StatusCode;
            rInfo.ContentType = response.ContentType;
            rInfo.Headers = response.Headers;

            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            rInfo.ContentLength = Encoding.ASCII.GetBytes(text).LongLength;
            rInfo.Body = text;
            return rInfo;
        }
    }
}
