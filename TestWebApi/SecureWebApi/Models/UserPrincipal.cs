using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SecureWebApi.Models
{
    public class UserPrincipal : GenericPrincipal
    {
        public UserPrincipal(UserViewModel user) : base(user, user.Roles.ToArray())
        {
        }
    }
}