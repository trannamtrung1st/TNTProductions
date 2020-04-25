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
	public partial interface IIdentityRoleClaim_string_Repository : IBaseRepository<IdentityRoleClaim<string>, int>
	{
	}
	
	public partial class IdentityRoleClaim_string_Repository : BaseRepository<IdentityRoleClaim<string>, int>, IIdentityRoleClaim_string_Repository
	{
		public IdentityRoleClaim_string_Repository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityRoleClaim<string> FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<IdentityRoleClaim<string>> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<IdentityRoleClaim<string>> Remove(int key)
		{
			var entity = new IdentityRoleClaim<string> { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityRoleClaim<string>> RemoveIf(Expression<Func<IdentityRoleClaim<string>, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityRoleClaim<string> { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityRoleClaim<string>");
			return result;
		}
		
		#endregion
	}
}
