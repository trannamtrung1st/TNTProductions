using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.WebApi.Social
{
    public class Google
    {
        private HttpClient http;
        private string clientId;
        private string clientSecret;

        public Google(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            http = new HttpClient();
            http.BaseAddress = new Uri("https://oauth2.googleapis.com");
        }

        public async Task<TokenInfoResponse> Validate(string token)
        {
            var resp = await http.GetAsync($"tokeninfo?id_token={token}");
            if (resp.IsSuccessStatusCode)
            {
                var tokenResp = await resp.Content.ReadAsAsync<TokenInfoResponse>();
                if (tokenResp.Audience != null && tokenResp.Audience.Equals(clientId))
                    return tokenResp;
                return null;
            }
            return null;
        }

        public class TokenInfoResponse
        {
            [JsonProperty("iss")]
            public string Issuer { get; set; }
            [JsonProperty("sub")]
            public string Subject { get; set; }
            [JsonProperty("azp")]
            public string Azp { get; set; }
            [JsonProperty("aud")]
            public string Audience { get; set; }
            [JsonProperty("iat")]
            public long IssuedAt { get; set; }
            [JsonProperty("exp")]
            public long Expires { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("email_verified")]
            public bool EmailVerified { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("picture")]
            public string Picture { get; set; }
            [JsonProperty("given_name")]
            public string GivenName { get; set; }
            [JsonProperty("family_name")]
            public string FamilyName { get; set; }
            [JsonProperty("locale")]
            public string Locale { get; set; }
        }

    }
}
