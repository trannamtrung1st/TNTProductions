using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.General;

namespace TNT.OAuth.Externals
{
    public class FacebookClient : IDisposable
    {

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AppToken { get; set; }
        public Func<string, bool> CheckStateParam { get; set; }
        protected HttpClient _httpClient;

        public FacebookClient(string appId, string appSecret)
        {
            AppId = appId;
            AppSecret = appSecret;
            AppToken = AppId + "|" + AppSecret;
            _httpClient = new HttpClient();
        }

        public async Task<FacebookDebugToken> DebugToken(string inputToken, string stateParam)
        {
            if (!CheckStateParam(stateParam))
                throw new Exception("Invalid state param");

            var http = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token=" + AppToken, inputToken);
            var res = await _httpClient.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(http),
                Method = HttpMethod.Get
            });

            var dataStr = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<FacebookDebugToken>(dataStr);
            return data;
        }

        public async Task<FacebookDebugToken> DebugToken(string inputToken)
        {
            var http = string.Format("https://graph.facebook.com/debug_token?input_token={0}&access_token=" + AppToken, inputToken);
            var res = await _httpClient.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(http),
                Method = HttpMethod.Get
            });

            var dataStr = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<FacebookDebugToken>(dataStr);
            data.ProviderId = AppId;
            if (data.IsValid)
                return data;
            return null;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

    public class FacebookDebugToken
    {
        [JsonProperty("data")]
        public DebugData Data { get; set; }
        public string ProviderId { get; set; }
        public class DebugData
        {
            [JsonProperty("app_id")]
            public string AppId { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("is_valid")]
            public bool IsValid { get; set; }
            [JsonProperty("user_id")]
            public string UserId { get; set; }
            [JsonProperty("expires_at")]
            public string ExpiresAt { get; set; }
        }

        public bool IsValid
        {
            get
            {
                return Data != null && Data.IsValid
                      && Data.Type.Equals("user", StringComparison.InvariantCultureIgnoreCase)
                      && Data.AppId.Equals(ProviderId)
                      && (long.Parse(Data.ExpiresAt) * 1000).ToUnixDateTime().CompareTo(DateTime.UtcNow) > 0;
            }
        }
    }
}
