using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.WebApi;

namespace TNT.Core.OAuth.Authorization
{
    public abstract class OAuthContext
    {
        public ErrorResponse Error { get; protected set; }
        public bool HasError { get; protected set; }
        public bool IsValidated { get; protected set; }
        public IDictionary<string, string> FormData { get; private set; }
        public HttpContext HttpContext { get; internal set; }
        public AuthenticationTicket Ticket { get; set; }
        public AuthorizationServerOptions Options { get; protected set; }

        public OAuthContext(HttpContext httpContext, AuthorizationServerOptions options)
        {
            HttpContext = httpContext;
            Options = options;
            FormData = httpContext.Request.ReadAsFormAsync().Result;
            Ticket = new AuthenticationTicket(httpContext.User, new AuthenticationProperties(), null);
        }

        public OAuthContext(OAuthContext context)
        {
            HttpContext = context.HttpContext;
            Options = context.Options;
            FormData = context.FormData;
            Ticket = context.Ticket;
        }

        public void Rejected()
        {
            Ticket = null;
            Error = null;
            HasError = false;
            IsValidated = false;
        }

        public void SetError(int status, string error, string description = null)
        {
            Ticket = null;
            Error = new ErrorResponse(status, error, description);
            HasError = true;
            IsValidated = false;
        }

        public void Validate()
        {
            Error = null;
            HasError = false;
            IsValidated = true;
        }

        public void Validate(AuthenticationTicket ticket)
        {
            Ticket = ticket;
            Error = null;
            HasError = false;
            IsValidated = true;
        }

    }

}
