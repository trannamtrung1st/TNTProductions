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
	public partial interface IIdentityUserRole_string_Repository : IBaseRepository<IdentityUserRole<string>, IdentityUserRole_string_PK>
	{
	}
	
	public partial class IdentityUserRole_string_Repository : BaseRepository<IdentityUserRole<string>, IdentityUserRole_string_PK>, IIdentityUserRole_string_Repository
	{
		public IdentityUserRole_string_Repository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityUserRole<string> FindById(IdentityUserRole_string_PK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
			return entity;
		}
		
		public override async Task<IdentityUserRole<string>> FindByIdAsync(IdentityUserRole_string_PK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
			return entity;
		}
		
		public override EntityEntry<IdentityUserRole<string>> Remove(IdentityUserRole_string_PK key)
		{
			var entity = new IdentityUserRole<string> { UserId = key.UserId,RoleId = key.RoleId };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityUserRole<string>> RemoveIf(Expression<Func<IdentityUserRole<string>, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityUserRole<string> { UserId = o.UserId,RoleId = o.RoleId }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityUserRole<string>");
			return result;
		}
		
		#endregion
	}
}
