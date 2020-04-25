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
	public partial interface I.AspNetUserTokensRepository : IBaseRepository<.AspNetUserTokens, .AspNetUserTokensPK>
	{
	}
	
	public partial class .AspNetUserTokensRepository : BaseRepository<.AspNetUserTokens, .AspNetUserTokensPK>, I.AspNetUserTokensRepository
	{
		public .AspNetUserTokensRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override .AspNetUserTokens FindById(.AspNetUserTokensPK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
			return entity;
		}
		
		public override async Task<.AspNetUserTokens> FindByIdAsync(.AspNetUserTokensPK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.UserId == key.UserId && e.LoginProvider == key.LoginProvider && e.Name == key.Name);
			return entity;
		}
		
		public override EntityEntry<.AspNetUserTokens> Remove(.AspNetUserTokensPK key)
		{
			var entity = new .AspNetUserTokens { UserId = key.UserId,LoginProvider = key.LoginProvider,Name = key.Name };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<.AspNetUserTokens> RemoveIf(Expression<Func<.AspNetUserTokens, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new .AspNetUserTokens { UserId = o.UserId,LoginProvider = o.LoginProvider,Name = o.Name }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlCommandAsync("DELETE FROM .AspNetUserTokens");
			return result;
		}
		
		#endregion
	}
}
