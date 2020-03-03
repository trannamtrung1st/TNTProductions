using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestDataService.Models.Repositories
{
	public partial interface IAspNetUserLoginsRepository : IBaseRepository<AspNetUserLogins, AspNetUserLoginsPK>
	{
	}
	
	public partial class AspNetUserLoginsRepository : BaseRepository<AspNetUserLogins, AspNetUserLoginsPK>, IAspNetUserLoginsRepository
	{
		public AspNetUserLoginsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUserLogins FindById(AspNetUserLoginsPK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
			return entity;
		}
		
		public override async Task<AspNetUserLogins> FindByIdAsync(AspNetUserLoginsPK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
			return entity;
		}
		
		#endregion
	}
}
