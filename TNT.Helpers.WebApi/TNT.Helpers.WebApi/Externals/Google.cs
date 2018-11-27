using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TNT.Helpers.General;

namespace TNT.Helpers.WebApi.Externals
{
    public class Google : IDisposable
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public Google(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            _httpClient = new HttpClient();
        }

        protected HttpClient _httpClient;

        public async Task<GoogleDebugToken> DebugToken(string token)
        {
            var http = string.Format("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={0}", token);
            var res = await _httpClient.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(http),
                Method = HttpMethod.Get
            });

            var dataStr = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<GoogleDebugToken>(dataStr);
            data.ProviderId = ClientId;
            return data;
        }


        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

    public class GoogleDebugToken
    {
        [JsonProperty("iss")]
        public string Issuer { get; set; }
        [JsonProperty("sub")]
        public string SubId { get; set; }
        [JsonProperty("aud")]
        public string Audience { get; set; }
        [JsonProperty("exp")]
        public string Expires { get; set; }
        public string ProviderId { get; set; }

        public bool IsValid
        {
            get
            {
                return
                    #if !DEBUG
                    SubId != null && Audience.Equals(ProviderId) &&
                    #endif
                    (Issuer.Equals("https://accounts.google.com") || Issuer.Equals("accounts.google.com"))
                    && (long.Parse(Expires) * 1000).ToUnixDateTime().CompareTo(DateTime.UtcNow) > 0;
            }
        }
    }
}
