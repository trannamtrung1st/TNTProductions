using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.ViewModels;
using TestCodeFirst.Models;
using TestCodeFirst.Global;
using Microsoft.AspNetCore.Identity;

namespace TestCodeFirst.Models
{
	public partial class IdentityUserLogin_string_PK
	{
		public string LoginProvider { get; set; }
		public string ProviderKey { get; set; }
	}
	
}


namespace TestCodeFirst.Models.Extensions
{
	public static partial class IdentityUserLogin_string_Extension
	{
		public static IdentityUserLogin<string> Id(this IQueryable<IdentityUserLogin<string>> query, IdentityUserLogin_string_PK key)
		{
			return query.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
		}
		
		public static IdentityUserLogin<string> Id(this IEnumerable<IdentityUserLogin<string>> query, IdentityUserLogin_string_PK key)
		{
			return query.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
		}
		
		public static bool Existed(this IQueryable<IdentityUserLogin<string>> query, IdentityUserLogin_string_PK key)
		{
			return query.Any(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
		}
		
	}
}
