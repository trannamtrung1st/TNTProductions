using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;

namespace TestCodeFirst.Models.Repositories
{
	public partial interface IIdentityUserLogin_string_Repository : IBaseRepository<IdentityUserLogin<string>, IdentityUserLogin_string_PK>
	{
	}
	
	public partial class IdentityUserLogin_string_Repository : BaseRepository<IdentityUserLogin<string>, IdentityUserLogin_string_PK>, IIdentityUserLogin_string_Repository
	{
		public IdentityUserLogin_string_Repository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityUserLogin<string> FindById(IdentityUserLogin_string_PK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
			return entity;
		}
		
		public override async Task<IdentityUserLogin<string>> FindByIdAsync(IdentityUserLogin_string_PK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
			return entity;
		}
		
		public override EntityEntry<IdentityUserLogin<string>> Remove(IdentityUserLogin_string_PK key)
		{
			var entity = new IdentityUserLogin<string> { LoginProvider = key.LoginProvider,ProviderKey = key.ProviderKey };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityUserLogin<string>> RemoveIf(Expression<Func<IdentityUserLogin<string>, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityUserLogin<string> { LoginProvider = o.LoginProvider,ProviderKey = o.ProviderKey }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityUserLogin<string>");
			return result;
		}
		
		#endregion
	}
}