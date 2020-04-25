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
	public partial interface IIdentityUserClaim_string_Repository : IBaseRepository<IdentityUserClaim<string>, int>
	{
	}
	
	public partial class IdentityUserClaim_string_Repository : BaseRepository<IdentityUserClaim<string>, int>, IIdentityUserClaim_string_Repository
	{
		public IdentityUserClaim_string_Repository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityUserClaim<string> FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<IdentityUserClaim<string>> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<IdentityUserClaim<string>> Remove(int key)
		{
			var entity = new IdentityUserClaim<string> { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityUserClaim<string>> RemoveIf(Expression<Func<IdentityUserClaim<string>, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityUserClaim<string> { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityUserClaim<string>");
			return result;
		}
		
		#endregion
	}
}
