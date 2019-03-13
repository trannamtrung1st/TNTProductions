using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TOAuth.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the OAuthUser class
    public class OAuthUser : IdentityUser
    {
        [StringLength(100)]
        [PersonalData]
        public string Name { get; set; }
    }
}
