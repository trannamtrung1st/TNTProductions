using AuthorizationServer.ConstantsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationServer.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string RedirectUrl { get; set; }

        public static readonly IDictionary<string, Client> Clients = new Dictionary<string, Client>()
        {
            { "123456", new Client()
            {
                Id = "123456",
                Secret = "abcdef",
                RedirectUrl = Paths.AuthorizeCodeCallBackPath
            } },
            { "7890ab", new Client()
            {
                Id = "7890ab",
                Secret = "7890ab",
                RedirectUrl = Paths.ImplicitGrantCallBackPath
            } }
        };

    }

}