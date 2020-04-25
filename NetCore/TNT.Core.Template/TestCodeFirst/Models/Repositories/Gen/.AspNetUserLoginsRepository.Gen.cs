using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestCodeFirst.Models.Repositories
{
	public partial interface I.AspNetUserLoginsRepository : IBaseRepository<.AspNetUserLogins, .AspNetUserLoginsPK>
	{
	}
	
	public partial class .AspNetUserLoginsRepository : BaseRepository<.AspNetUserLogins, .AspNetUserLoginsPK>, I.AspNetUserLoginsRepository
	{
		public .AspNetUserLoginsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override .AspNetUserLogins FindById(.AspNetUserLoginsPK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
			return entity;
		}
		
		public override async Task<.AspNetUserLogins> FindByIdAsync(.AspNetUserLoginsPK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey);
			return entity;
		}
		
		public override EntityEntry<.AspNetUserLogins> Remove(.AspNetUserLoginsPK key)
		{
			var entity = new .AspNetUserLogins { LoginProvider = key.LoginProvider,ProviderKey = key.ProviderKey };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<.AspNetUserLogins> RemoveIf(Expression<Func<.AspNetUserLogins, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new .AspNetUserLogins { LoginProvider = o.LoginProvider,ProviderKey = o.ProviderKey }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlCommandAsync("DELETE FROM .AspNetUserLogins");
			return result;
		}
		
		#endregion
	}
}
