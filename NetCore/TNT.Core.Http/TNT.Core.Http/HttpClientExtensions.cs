using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Http
{
    public static class HttpClientExtensions
    {

        public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string uri, object obj)
        {
            return client.PostAsync(uri, new JsonContent(obj));
        }

        public static Task<HttpResponseMessage> PutAsJsonAsync(this HttpClient client, string uri, object obj)
        {
            return client.PutAsync(uri, new JsonContent(obj));
        }

        public static Task<HttpResponseMessage> PatchAsJsonAsync(this HttpClient client, string uri, object obj)
        {
            return client.PatchAsync(uri, new JsonContent(obj));
        }

        public static Task<HttpResponseMessage> PostAsFormUrlEncodedAsync(this HttpClient client, string uri, IEnumerable<KeyValuePair<string, string>> form)
        {
            return client.PostAsync(uri, new FormUrlEncodedContent(form));
        }

        public static Task<HttpResponseMessage> PutAsFormUrlEncodedAsync(this HttpClient client, string uri, IEnumerable<KeyValuePair<string, string>> form)
        {
            return client.PutAsync(uri, new FormUrlEncodedContent(form));
        }

        public static Task<HttpResponseMessage> PatchAsFormUrlEncodedAsync(this HttpClient client, string uri, IEnumerable<KeyValuePair<string, string>> form)
        {
            return client.PatchAsync(uri, new FormUrlEncodedContent(form));
        }


        public static async Task<T> ReadAsAsync<T>(this HttpContent message)
        {
            return JsonConvert.DeserializeObject<T>(await message.ReadAsStringAsync());
        }

    }

    public class JsonContent : StringContent
    {
        public const string JsonMediaType = "application/json";

        public JsonContent(object content) : base(JsonConvert.SerializeObject(content), Encoding.UTF8, JsonMediaType)
        {
        }

        public JsonContent(object content, Encoding encoding) : base(JsonConvert.SerializeObject(content), encoding, JsonMediaType)
        {
        }

        public JsonContent(object content, Encoding encoding, string mediaType) : base(JsonConvert.SerializeObject(content), encoding, mediaType)
        {
        }
    }


}
