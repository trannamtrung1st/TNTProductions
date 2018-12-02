using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using TNT.Helpers.WebApi.Externals;
using TNT.Helpers.WebApi.OAuth;
using TNT.Helpers.WebApi.OAuth.Filters;

namespace TNT.Helpers.WebApi.OAuth.Providers
{

    public abstract class FacebookOAuthProvider : IAuthenticationProvider<ProviderBasedAuthenticationFilter>
    {
        public FacebookClient Provider { get; set; }
        public abstract string AuthenticationType { get; set; }

        public FacebookOAuthProvider(string appId, string appSecret)
        {
            Provider = new FacebookClient(appId, appSecret);
        }


        public void Dispose()
        {
            Provider.Dispose();
        }

        public abstract Task AuthenticateAsync(ProviderBasedAuthenticationFilter filter);
    }

}
