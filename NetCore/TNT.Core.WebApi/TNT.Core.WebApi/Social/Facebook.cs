using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.WebApi.Social
{
    public class Facebook
    {

        private HttpClient http;
        private string clientId;
        private string clientSecret;

        public Facebook(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            http = new HttpClient();
            http.BaseAddress = new Uri("https://graph.facebook.com");
        }

        public class DebugTokenResponse
        {
            [JsonProperty("data")]
            public DebugTokenResponseData Data { get; set; }

            public class DebugTokenResponseData
            {
                [JsonProperty("app_id")]
                public string AppId { get; set; }
                [JsonProperty("expires_at")]
                public long ExpiresAt { get; set; }
                [JsonProperty("is_valid")]
                public bool IsValid { get; set; }
                [JsonProperty("issued_at")]
                public long IssuedAt { get; set; }
                [JsonProperty("scopes")]
                public IEnumerable<string> Scopes { get; set; }
                [JsonProperty("user_id")]
                public string UserId { get; set; }
            }
        }
        public async Task<DebugTokenResponse> DebugToken(string inputToken)
        {
            var resp = await http.GetAsync($"debug_token?input_token={inputToken}&" +
                $"access_token={clientId}|{clientSecret}");
            if (resp.IsSuccessStatusCode)
            {
                var debug = await resp.Content.ReadAsAsync<DebugTokenResponse>();
                if (debug.Data != null && debug.Data.IsValid)
                    return debug;
                return null;
            }
            return null;
        }
    }

}
