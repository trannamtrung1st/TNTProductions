using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.OAuth
{
    public interface IAuthenticationProvider<TFilter> : IDisposable where TFilter : IAuthenticationFilter
    {
        string AuthenticationType { get; set; }
        Task AuthenticateAsync(TFilter filter);
    }

}
