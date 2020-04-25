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
	public partial interface IIdentityUserToken_string_Repository : IBaseRepository<IdentityUserToken<string>, IdentityUserToken_string_PK>
	{
	}
	
	public partial class IdentityUserToken_string_Repository : BaseRepository<IdentityUserToken<string>, IdentityUserToken_string_PK>, IIdentityUserToken_string_Repository
	{
		public IdentityUserToken_string_Repository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityUserToken<string> FindById(IdentityUserToken_string_PK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
			return entity;
		}
		
		public override async Task<IdentityUserToken<string>> FindByIdAsync(IdentityUserToken_string_PK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
			return entity;
		}
		
		public override EntityEntry<IdentityUserToken<string>> Remove(IdentityUserToken_string_PK key)
		{
			var entity = new IdentityUserToken<string> { UserId = key.UserId,LoginProvider = key.LoginProvider,Name = key.Name };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityUserToken<string>> RemoveIf(Expression<Func<IdentityUserToken<string>, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityUserToken<string> { UserId = o.UserId,LoginProvider = o.LoginProvider,Name = o.Name }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityUserToken<string>");
			return result;
		}
		
		#endregion
	}
}
