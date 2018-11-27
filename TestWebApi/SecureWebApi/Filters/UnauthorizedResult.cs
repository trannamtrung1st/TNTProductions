using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace SecureWebApi.Filters
{
    public class UnauthorizedResult : IHttpActionResult
    {
        private string mess;
        public UnauthorizedResult(string mess)
        {
            this.mess = mess;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Http.Unauthorized(mess, mess));
        }
    }
}