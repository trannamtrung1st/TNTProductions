using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using TNT.Helpers.WebApi.Externals;

namespace TNT.Helpers.WebApi.Owin.Externals
{

    //Get token from Authorization header
    public abstract class GoogleProvider : IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions>
    {
        public string AuthenticationType { get; set; } = "Google";
        public GoogleClient Provider { get; set; }

        public GoogleProvider(string clientId, string clientSecret)
        {
            Provider = new GoogleClient(clientId, clientSecret);
        }

        public async Task<AuthenticationTicket> AuthenticateAsync(ProviderBasedAuthenticationHandler handler)
        {
            var authHeader = handler.GetAuthHeader();
            var token = authHeader[1];
            return await AuthenticateAsync(token);
        }

        public abstract Task<AuthenticationTicket> AuthenticateAsync(string token);

        public void Dispose()
        {
            Provider.Dispose();
        }
    }
}
