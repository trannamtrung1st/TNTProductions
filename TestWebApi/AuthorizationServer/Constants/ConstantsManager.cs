using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationServer.ConstantsManager
{
    public static class Paths
    {

        public static readonly string LoginPath = "/api/account/login";
        public static readonly string LogoutPath = "/api/account/logout";
        public static readonly string AuthorizePath = "/api/oauth/authorize";
        public static readonly string TokenPath = "/api/oauth/token";

        public static readonly string AuthorizeCodeCallBackPath = "/";
        public static readonly string ImplicitGrantCallBackPath = "/api/account/login";
    }

    public static class Constants
    {
        public static readonly string GoogleClientId = "";
        public static readonly string GoogleSecretId = "";

    }
}