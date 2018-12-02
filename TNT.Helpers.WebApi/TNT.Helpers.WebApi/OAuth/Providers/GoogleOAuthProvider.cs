using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using TNT.Helpers.WebApi.Externals;
using TNT.Helpers.WebApi.OAuth;
using TNT.Helpers.WebApi.OAuth.Filters;

namespace TNT.Helpers.WebApi.OAuth.Providers
{
    public abstract class GoogleOAuthProvider : IAuthenticationProvider<ProviderBasedAuthenticationFilter>
    {

        public GoogleClient Provider { get; set; }
        public abstract string AuthenticationType { get; set; }

        public GoogleOAuthProvider(string clientId, string clientSecret)
        {
            Provider = new GoogleClient(clientId, clientSecret);
        }


        public void Dispose()
        {
            Provider.Dispose();
        }

        public abstract Task AuthenticateAsync(ProviderBasedAuthenticationFilter filter);
    }


}
